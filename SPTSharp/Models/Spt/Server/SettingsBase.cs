#pragma warning disable

namespace SPTSharp.Models.Spt.Server
{
    public class SettingsBase
    {
        public Config config {  get; set; }
    }

    public class Config
    {
        public int AFKTimeoutSeconds { get; set; }
        public int AdditionalRandomDelaySeconds { get; set; }
        public int ClientSendRateLimit {  get; set; }
        public int CriticalRetriesCount { get; set; }
        public int DefaultRetriesCount { get; set; }
        public int FirstCycleDelaySeconds { get; set; }
        public FrameRateLimit FramerateLimit { get; set; }
        public int GroupStatusInterval { get; set; }
        public int GroupStatusButtonInterval { get; set; }
        public int KeepAliveInternal {  get; set; }
        public int LobbyKeepAliveInternal { get; set; }
        public bool Mark502and504AsNonImportant { get; set; }
        public MemoryManagementSettings MemoryManagementSettings { get; set; }
        public bool NVidiaHighlights { get; set; }
        public int NextCycleDelaySeconds { get; set; }
        public int PingServerResultSendInterval { get; set; }
        public int PingServersInterval { get; set; }
        public ReleaseProfiler ReleaseProfiler { get; set; }
        public List<float> RequestConfirmationTimeouts { get; set; }
        public List<string> RequestsMadeThroughLobby { get; set; }
        public int SecondCycleDelaySeconds { get; set; }
        public bool ShouldEstablishLobbyConnection { get; set; }
        public bool TurnOffLogging { get; set; }
        public float WeaponOverlapDistanceCulling { get; set; }
        public bool WebDiagnosticsEnabled { get; set; }
        public NetworkStateView NetworkStateView { get; set; }

    }

    public class FrameRateLimit
    {
        public int MaxFramerateGameLimit { get; set; }
        public int MaxFramerateLobbyLimit { get; set; }
        public int MinFramerateLimit { get; set; }
    }

    public class MemoryManagementSettings
    {
        public bool AgressiveGC { get; set; }
        public int GigabytesRequiredToDisableGCDuringRaid { get; set; }
        public bool HeapPreAllocationEnabled { get; set; }
        public int HeapPreAllocationMB { get; set; }
        public bool OverrideRamCleanerSettings { get; set; }
        public bool RamCleanerEnabled { get; set; }
    }

    public class ReleaseProfiler
    {
        public bool Enabled { get; set; }
        public int MaxRecords { get; set; }
        public int RecordTriggerValue { get; set; }
    }

    public class NetworkStateView
    {
        public int LossThreshhold { get; set; }
        public int RttThreshhold { get; set; }
    }
}
