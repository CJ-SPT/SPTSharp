namespace SPTSharp.Utils
{
    public static class HashUtil
    {
        public static int GenerateAccountId() 
        {
            int min = 1000000;
            int max = 1999999;

            Random random = new Random();
            return random.Next(min, max + 1);
        }
    }
}
