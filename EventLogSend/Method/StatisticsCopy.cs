using System.Diagnostics;

namespace EventLogSend.Method
{
    public static class StatisticsCopy
    {
        public static void Report(EventLog[] eventLogs, DateTime dateTime)
        {
            foreach (EventLog eventLog in eventLogs)
            {
                int criticalCount = 0;
                int errorCount = 0;
                int warningCount = 0;
                int informationCount = 0;

                if (eventLog.Log.Equals("System"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= dateTime)
                        {
                            switch (eventLogEntry.EntryType.ToString())
                            {
                                case "0":
                                    criticalCount += 1;
                                    break;
                                case "Error":
                                    errorCount += 1;
                                    break;
                                case "Warning":
                                    warningCount += 1;
                                    break;
                                case "Information":
                                    informationCount += 1;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    Line.Store.Add("");
                    Line.Store.Add(string.Concat(eventLog.Log, " log counts"));
                    Line.Store.Add(string.Concat("  Critical    ", criticalCount.ToString()));
                    Line.Store.Add(string.Concat("  Error       ", errorCount.ToString()));
                    Line.Store.Add(string.Concat("  Warning     ", warningCount.ToString()));
                    Line.Store.Add(string.Concat("  Information ", informationCount.ToString()));
                    Line.Store.Add(string.Concat("  Unknown     ", eventLog.Entries.Count - (criticalCount + errorCount + warningCount + informationCount)));
                }
            }

            foreach (EventLog eventLog in eventLogs)
            {
                int criticalCount = 0;
                int errorCount = 0;
                int warningCount = 0;
                int informationCount = 0;

                if (eventLog.Log.Equals("Application"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= dateTime)
                        {
                            switch (eventLogEntry.EntryType.ToString())
                            {
                                case "0":
                                    criticalCount += 1;
                                    break;
                                case "Error":
                                    errorCount += 1;
                                    break;
                                case "Warning":
                                    warningCount += 1;
                                    break;
                                case "Information":
                                    informationCount += 1;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    Line.Store.Add("");
                    Line.Store.Add(string.Concat(eventLog.Log, " log counts"));
                    Line.Store.Add(string.Concat("  Critical    ", criticalCount.ToString()));
                    Line.Store.Add(string.Concat("  Error       ", errorCount.ToString()));
                    Line.Store.Add(string.Concat("  Warning     ", warningCount.ToString()));
                    Line.Store.Add(string.Concat("  Information ", informationCount.ToString()));
                    Line.Store.Add(string.Concat("  Unknown     ", eventLog.Entries.Count - (criticalCount + errorCount + warningCount + informationCount)));
                }
            }

            foreach (EventLog eventLog in eventLogs)
            {
                int auditFailureCount = 0;
                int auditSuccessCount = 0;

                if (eventLog.Log.Equals("Security"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= dateTime)
                        {
                            switch (eventLogEntry.EntryType.ToString())
                            {
                                case "FailureAudit":
                                    auditFailureCount += 1;
                                    break;
                                case "SuccessAudit":
                                    auditSuccessCount += 1;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    Line.Store.Add("");
                    Line.Store.Add(string.Concat(eventLog.Log, " log counts"));
                    Line.Store.Add(string.Concat("  AuditFailure ", auditFailureCount.ToString()));
                    Line.Store.Add(string.Concat("  AuditSuccess ", auditSuccessCount.ToString()));
                    Line.Store.Add(string.Concat("  Unknown      ", eventLog.Entries.Count - (auditFailureCount + auditSuccessCount)));
                }
            }
        }
    }
}
