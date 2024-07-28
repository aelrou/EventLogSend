using System.Diagnostics;

namespace EventLogSend.Method
{
    static class SecurityAuditLog
    {
        internal static void Report(EventLog[] eventLogs)
        {
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
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
							if (eventLogEntry.EntryType.Equals(EventLogEntryType.SuccessAudit))
							{
								securitySuccessAuditDictionary = SecuritySuccessAudit.Parse(eventLogEntry);
								string SourceNetworkAddress = "";
								if (securitySuccessAuditDictionary.TryGetValue(@"Network Information: Source Network Address:", out SourceNetworkAddress))
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
												securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)));
											}
											else
											{
												securitySuccessAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", WorkstationName, @"\", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)));
											}
										}
									}
								}
							}
	
							if (eventLogEntry.EntryType.Equals(EventLogEntryType.FailureAudit))
							{
								securityFailureAuditDictionary = SecurityFailureAudit.Parse(eventLogEntry);
								string SourceNetworkAddress = "";
								if (securityFailureAuditDictionary.TryGetValue(@"Network Information: Source Network Address:", out SourceNetworkAddress))
								{
									if (SourceNetworkAddress.Equals("-") | SourceNetworkAddress.Equals("::1") | SourceNetworkAddress.Equals("")) { }
									else
									{
										string AccountName = "";
										if (securityFailureAuditDictionary.TryGetValue(@"Account For Which Logon Failed: Account Name:", out AccountName))
										{
											if (AccountName.Equals("-") | AccountName.Equals(""))
											{
												if (securityFailureAuditDictionary.TryGetValue(@"Subject: Account Name:", out AccountName)) { }
											}
										}
	
										string AccountDomain = "";
										if (securityFailureAuditDictionary.TryGetValue(@"Account For Which Logon Failed: Account Domain:", out AccountDomain)) { }
	
										string WorkstationName = "";
										if (securityFailureAuditDictionary.TryGetValue(@"Network Information: Workstation Name:", out WorkstationName)) { }
	
										if (AccountDomain.Equals("-") | AccountDomain.Equals(""))
										{
											if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
											{
												securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)));
											}
											else
											{
												securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)));
											}
										}
										else
										{
											if (WorkstationName.Equals("-") | WorkstationName.Equals(""))
											{
												securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", SourceNetworkAddress, " at ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)));
											}
											else
											{
												securityFailureAuditList.Add(string.Concat(eventLogEntry.EntryType, " for user ", AccountDomain, @"\", AccountName, " to machine ", Environment.MachineName, " from ", WorkstationName, " ", SourceNetworkAddress, " at ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)));
											}
										}
									}
								}
							}
						}
                    }
                }
            }
            foreach (string line in securitySuccessAuditList) { Value.Log.Add(line); }

            foreach (string line in securityFailureAuditList) { Value.Log.Add(line); }
        }
    }
}
