using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    static class ReportEventLog
    {
        internal static void Properties()
        {
            //HashSet<EventLog> eventLogsHs = new HashSet<EventLog>();
            //HashSet<EventLogEntry> applicationLogEntriesHs = new HashSet<EventLogEntry>();
            //HashSet<EventLogEntry> securityLogEntriesHs = new HashSet<EventLogEntry>();
            //HashSet<EventLogEntry> systemLogEntriesHs = new HashSet<EventLogEntry>();

            //EventLog[] eventLogs = EventLog.GetEventLogs();
            EventLog[] eventLogs = EventLog.GetEventLogs();
            Console.WriteLine("Processing EventLog");
            //Console.WriteLine("Populating HashSet<EventLog>");
            //eventLogsHs = eventLogs.ToHashSet();

            //foreach (EventLog eventLog in eventLogsHs)
            //{
            //    if (eventLog.Log.ToString().Equals("Application"))
            //    {
            //        Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            applicationLogEntriesHs.Add(eventLogEntry);
            //        }
            //    }
            //    if (eventLog.Log.ToString().Equals("System"))
            //    {
            //        Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            systemLogEntriesHs.Add(eventLogEntry);
            //        }
            //    }
            //    if (eventLog.Log.ToString().Equals("Security"))
            //    {
            //        Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            securityLogEntriesHs.Add(eventLogEntry);
            //        }
            //    }
            //}

            Value.Log.Add(string.Concat("MachineName ", Environment.MachineName));
            Value.Log.Add(string.Concat("    OS Name ", RegistryOs.FriendlyName()));
            Value.Log.Add(string.Concat(" OS Version ", Environment.OSVersion));
            Value.Log.Add("");
            Value.Log.Add(string.Concat("EventLog entries newer than ", Value.OldestDate[0].ToString(Value.DateFormat)));

            //Statistics.Report("System", systemLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");
            //Sources.Report("System", "Microsoft-Windows-WHEA-Logger", systemLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");
            //Types.Report("System", systemLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");

            //Statistics.Report("Application", applicationLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");
            //Types.Report("Application", applicationLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");

            //Statistics.Report("Security", securityLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");
            //Types.Report("Security", securityLogEntriesHs, Value.OldestDate[0]);
            //Value.Log.Add("");

            //StatisticsCopy.Report(eventLogs, Value.OldestDate[0]);
            //SourcesCopy.Report("Microsoft-Windows-WHEA-Logger", eventLogs, Value.OldestDate[0]);
            TypesCopy.Report(eventLogs);
        }
    }
}
