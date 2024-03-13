using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Routers;
using System.Net;
using NetCoreServer;
using System.Net.Sockets;
using System.Security.AccessControl;

namespace SPTSharp.Server
{
    internal class HttpServerRunner
    {
        HttpCacheServer server;

        public void StartHttpServer()
        {
            IPAddress ipAddr = IPAddress.Parse(Singleton<ConfigController>.Instance.http.ip);
            int port = Singleton<ConfigController>.Instance.http.port;

            server = new HttpCacheServer(ipAddr, port);
            server.Start();
            Logger.LogInfo($"Server running listening on http://{ipAddr}:{port}");
        }

        public void RestartHttpServer()
        {
            server.Restart();
        }

        public void StopHttpServer()
        {
            server.Stop();
        }
    }

    internal class HttpCacheServer : HttpServer
    {
        public HttpCacheServer(IPAddress address, int port): base(address, port) { }

        protected override TcpSession CreateSession()
        {
            return new HttpCacheSession(this);    
        }

        protected override void OnError(SocketError err)
        {
            Logger.LogError($"HTTP session caught an error: {err}");
        }
    }

    internal class HttpCacheSession : HttpSession
    {
        public HttpCacheSession(HttpServer server) : base(server) { }

        protected override void OnReceivedRequest(HttpRequest request)
        {
            Logger.LogInfo(request.Url);

            Logger.LogDebug(request);

            // Process HTTP request methods
            if (request.Method == "HEAD")
            {
                SendResponseAsync(Response.MakeHeadResponse());
            }
            else if (request.Method == "GET")
            {
                string key = request.Url;

                if (string.IsNullOrEmpty(key))
                {
                    Logger.LogError($"Empty key for request: \n{request}");
                    return;
                }
                BaseRequestRouter.RouteRequest(this, request, Response);
            }
            else if ((request.Method == "POST") || (request.Method == "PUT"))
            {
                BaseRequestRouter.RouteRequest(this, request, Response);
            }
            else if (request.Method == "DELETE")
            {
                Logger.LogError($"request method DELETE not handled.");
            }
            else if (request.Method == "OPTIONS")
            {
                Logger.LogError($"request method OPTIONS not handled.");
            }
            else if (request.Method == "TRACE")
            {
                Logger.LogError($"request method TRACE not handled.");
            }      
            else
                SendResponseAsync(Response.MakeErrorResponse("Unsupported HTTP method: " + request.Method));
        }

        protected override void OnReceivedRequestError(HttpRequest request, string error)
        {
            Console.WriteLine($"Request error: {error}");
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"HTTP session caught an error: {error}");
        }
    }
}
