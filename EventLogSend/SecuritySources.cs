using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    static class SecuritySources
    {
        //internal static void Report(EventLog[] eventLogs)
        internal static void Report()
        {
            Dictionary<string, string> securityLogEntryDictionary = new Dictionary<string, string>();
            HashSet<string> securitySuccessAuditList = new HashSet<string>();
            HashSet<string> securityFailureAuditList = new HashSet<string>();
            //foreach (EventLog eventLog in eventLogs)
            //{
                //if (eventLog.Log.Equals("Security"))
                //{
                    //foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    foreach (EventLogEntry eventLogEntry in Value.securityLogEntryHashset)
                    {
                        securityLogEntryDictionary.Clear();

                        //if (eventLogEntry.TimeGenerated >= Value.OldestDate[0])
                        //{
                            if (eventLogEntry.EntryType.Equals(EventLogEntryType.SuccessAudit))
                            {
                                securityLogEntryDictionary = SecuritySuccessAudit.Parse(eventLogEntry);
                                string SourceNetworkAddress = "";
                                if (securityLogEntryDictionary.TryGetValue(@"Network Information: Source Network Address:", out SourceNetworkAddress))
                                {
                                    if (SourceNetworkAddress.Equals("-") | SourceNetworkAddress.Equals("::1") | SourceNetworkAddress.Equals("")) { }
                                    else
                                    {
                                        string AccountName = "";
                                        if (securityLogEntryDictionary.TryGetValue(@"New Logon: Account Name:", out AccountName)) { }

                                        string AccountDomain = "";
                                        if (securityLogEntryDictionary.TryGetValue(@"New Logon: Account Domain:", out AccountDomain)) { }

                                        string WorkstationName = "";
                                        if (securityLogEntryDictionary.TryGetValue(@"Network Information: Workstation Name:", out WorkstationName))
                                        {
                                            if (AccountDomain.Equals("-") | AccountDomain.Equals(""))
                                            {
                                                if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
                                                {
                                                    securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                                }
                                                else
                                                {
                                                    securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                                }
                                            }
                                            else
                                            {
                                                if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
                                                {
                                                    securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                                }
                                                else
                                                {
                                                    securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (eventLogEntry.EntryType.Equals(EventLogEntryType.FailureAudit))
                            {
                                securityLogEntryDictionary = SecurityFailureAudit.Parse(eventLogEntry);
                                string SourceNetworkAddress = "";
                                if (securityLogEntryDictionary.TryGetValue(@"Network Information: Source Network Address:", out SourceNetworkAddress))
                                {
                                    if (SourceNetworkAddress.Equals("-") | SourceNetworkAddress.Equals("::1") | SourceNetworkAddress.Equals("")) { }
                                    else
                                    {
                                        string AccountName = "";
                                        if (securityLogEntryDictionary.TryGetValue(@"Account For Which Logon Failed: Account Name:", out AccountName))
                                        {
                                            if (AccountName.Equals("-") | AccountName.Equals(""))
                                            {
                                                if (securityLogEntryDictionary.TryGetValue(@"Subject: Account Name:", out AccountName)) { }
                                            }
                                        }

                                        string AccountDomain = "";
                                        if (securityLogEntryDictionary.TryGetValue(@"Account For Which Logon Failed: Account Domain:", out AccountDomain)) { }

                                        string WorkstationName = "";
                                        if (securityLogEntryDictionary.TryGetValue(@"Network Information: Workstation Name:", out WorkstationName)) { }

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
                                                securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                            }
                                            else
                                            {
                                                securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)));
                                            }
                                        }
                                    }
                                }
                            }
                        //}
                    //}
                //}
            }
            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- Security, SuccessAudit, Remote Login ----"));
            foreach (string line in securitySuccessAuditList) { Value.Log.Add(line); }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- Security, FailureAudit, Remote Login ----"));
            foreach (string line in securityFailureAuditList) { Value.Log.Add(line); }
        }
    }
}
