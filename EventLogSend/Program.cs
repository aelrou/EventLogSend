using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    static class Program
    {
        static void Main(string[] args)
        {
            new MainArgs(args);

            ASCII.FillTables();

            EventLog[] eventLogs = EventLog.GetEventLogs();

            ReportEventLog.Properties(eventLogs);

            Statistics.Report("System");
            SystemSources.Report( "Microsoft-Windows-WHEA-Logger");
            SystemTypes.Report();

            Statistics.Report("Application");
            //ApplicationSources.Report();
            ApplicationTypes.Report();

            Statistics.Report("Security");
            SecuritySources.Report();

            Console.WriteLine("Writing log file");
            Log.Write(Value.Log);
        }
    }
    
    class Value
    {
        internal static List<string> WorkDir = new List<string>();
        internal static readonly string LogFile = "EventLogSend.log";
        internal static List<DateTime> OldestDate = new List<DateTime>();

        //internal static HashSet<EventLog> eventLogsHashset = new HashSet<EventLog>();
        internal static HashSet<EventLogEntry> systemLogEntryHashset = new HashSet<EventLogEntry>();
        internal static HashSet<EventLogEntry> applicationLogEntryHashset = new HashSet<EventLogEntry>();
        internal static HashSet<EventLogEntry> securityLogEntryHashset = new HashSet<EventLogEntry>();

        internal static List<string> Log = new List<string>();

        internal static readonly string DateFormat = "yyyy-MM-dd HH:mm:ss.fff";
    }
}