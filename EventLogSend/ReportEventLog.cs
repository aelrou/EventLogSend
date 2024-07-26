using Microsoft.Win32;
using System.Diagnostics;


namespace EventLogSend
{
    public static class ReportEventLog
    {
        public static void Properties()
        {
            HashSet<EventLog> eventLogsHs = new HashSet<EventLog>();
            HashSet<EventLogEntry> applicationLogEntriesHs = new HashSet<EventLogEntry>();
            HashSet<EventLogEntry> securityLogEntriesHs = new HashSet<EventLogEntry>();
            HashSet<EventLogEntry> systemLogEntriesHs = new HashSet<EventLogEntry>();

            EventLog[] eventLogs = EventLog.GetEventLogs();
            Console.WriteLine("Populating HashSet<EventLog>");
            eventLogsHs = eventLogs.ToHashSet();

            foreach (EventLog eventLog in eventLogsHs)
            {
                if (eventLog.Log.ToString().Equals("Application"))
                {
                    Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        applicationLogEntriesHs.Add(eventLogEntry);
                    }
                }
                if (eventLog.Log.ToString().Equals("System"))
                {
                    Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        systemLogEntriesHs.Add(eventLogEntry);
                    }
                }
                if (eventLog.Log.ToString().Equals("Security"))
                {
                    Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        securityLogEntriesHs.Add(eventLogEntry);
                    }
                }
            }
            
            DateTime dateTime = DateTime.UtcNow.AddYears(-1);
            Line.Store.Add("");
            Line.Store.Add(string.Concat("Entries newer than ", dateTime.ToString(Constants.DateFormat)));
            Line.Store.Add("");

            Method.Statistics.Report("Application", applicationLogEntriesHs, dateTime);
            Line.Store.Add("");
            Method.Types.Report("Application", applicationLogEntriesHs, dateTime);
            Line.Store.Add("");

            Method.Statistics.Report("System", systemLogEntriesHs, dateTime);
            Line.Store.Add("");
            Method.Types.Report("System", systemLogEntriesHs, dateTime);
            Line.Store.Add("");
            Method.Sources.Report("System", systemLogEntriesHs, dateTime);
            Line.Store.Add("");

            Method.Statistics.Report("Security", securityLogEntriesHs, dateTime);
            Line.Store.Add("");
            Method.Types.Report("Security", securityLogEntriesHs, dateTime);
            Line.Store.Add("");
        }
    }
}
