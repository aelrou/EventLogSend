using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    public static class Value
    {
        public static readonly string DateFormat = "yyyy-MM-dd HH:mm:ss";
        public static readonly string WorkDir = @"C:\Users\Public\EventLogSend";
        public static readonly string LogFile = "EventLogSend.log";

        public static List<string> Log = new List<string>();

        const char carriagereturn = (char)13; // \r
        public static readonly string cr = carriagereturn.ToString();

        const char linefeed = (char)10; // \n
        public static readonly string lf = linefeed.ToString();

        public static readonly string crlf = string.Concat(cr, lf);

        const char tab = (char)09; // \t
        public static readonly string t = tab.ToString();

        const char nbspace = (char)160; // Non-breaking space
        public static readonly string nbsp = nbspace.ToString();
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            EventLog[] eventLogs = EventLog.GetEventLogs();
            //Console.WriteLine(string.Concat("Log count: ", EventLogs.Length));
            //foreach (EventLog log in EventLogs)
            //{
            //    Console.WriteLine(string.Concat("Log: ", log.Log));
            //}

            Dictionary<string, string> securitySuccessAuditDictionary = new Dictionary<string, string>();
            HashSet<string> securitySuccessAuditList = new HashSet<string>();
            Dictionary<string, string> securityFailureAuditDictionary = new Dictionary<string, string>();
            HashSet<string> securityFailureAuditList = new HashSet<string>();
            foreach (EventLog eventLog in eventLogs)
            {
                if (eventLog.Log.Equals("Security"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.EntryType.Equals(EventLogEntryType.SuccessAudit))
                        {
                            securitySuccessAuditDictionary = SecuritySuccessAudit.ParseDictionary(eventLogEntry);
                            string SourceNetworkAddress = "";
                            if (securitySuccessAuditDictionary.TryGetValue(
                                    @"Network Information: Source Network Address:", out SourceNetworkAddress))
                            {
                                if (SourceNetworkAddress.Equals("-") | SourceNetworkAddress.Equals("::1") | SourceNetworkAddress.Equals("")) { }
                                else
                                {
                                    string AccountName = "";
                                    if (securitySuccessAuditDictionary.TryGetValue(@"New Logon: Account Name:", out AccountName)) { }

                                    string WorkstationName = "";
                                    if (securitySuccessAuditDictionary.TryGetValue(@"Network Information: Workstation Name:", out WorkstationName))
                                    {
                                        if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
                                        {
                                            securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                        }
                                        else
                                        {
                                            securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", WorkstationName, @"\", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                        }
                                    }
                                }
                            }
                        }

                        if (eventLogEntry.EntryType.Equals(EventLogEntryType.FailureAudit))
                        {
                            securityFailureAuditDictionary = SecurityFailureAudit.ParseDictionary(eventLogEntry);
                            string SourceNetworkAddress = "";
                            if (securityFailureAuditDictionary.TryGetValue(@"Network Information: Source Network Address:", out SourceNetworkAddress))
                            {
                                if (SourceNetworkAddress.Equals("-") | SourceNetworkAddress.Equals("::1") | SourceNetworkAddress.Equals("")) { }
                                else
                                {
                                    string AccountName = "";
                                    if (securityFailureAuditDictionary.TryGetValue( @"Account For Which Logon Failed: Account Name:", out AccountName))
                                    {
                                        if (AccountName.Equals("-") | AccountName.Equals(""))
                                        {
                                            if (securityFailureAuditDictionary.TryGetValue(@"Subject: Account Name:", out AccountName)) { }
                                        }
                                    }

                                    string AccountDomain = "";
                                    if (securityFailureAuditDictionary.TryGetValue(@"Account For Which Logon Failed: Account Domain:", out AccountDomain)) { }

                                    string WorkstationName = "";
                                    if (securityFailureAuditDictionary.TryGetValue( @"Network Information: Workstation Name:", out WorkstationName)) { }

                                    if (AccountDomain.Equals("-") | AccountDomain.Equals(""))
                                    {
                                        if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
                                        {
                                            securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                        }
                                        else
                                        {
                                            securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                        }
                                    }
                                    else
                                    {
                                        if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
                                        {
                                            securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\",AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                        }
                                        else
                                        {
                                            securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                        }
                                    }
                                }
                            }
                        }
                    }

                    foreach (string line in securitySuccessAuditList) { Value.Log.Add(line); }

                    foreach (string line in securityFailureAuditList) { Value.Log.Add(line); }
                }

                //ReportEventLog.Properties();

                if (Directory.Exists(Value.WorkDir))
                {
                    Log.Write(Value.Log);
                }
                else
                {
                    Directory.CreateDirectory(Value.WorkDir);
                    Log.Write(Value.Log);
                }
            }
        }
    }
}
