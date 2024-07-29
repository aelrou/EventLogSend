using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    static class Program
    {
        static void Main(string[] args)
        {
            new MainArgs(args);

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

        const char carriagereturn = (char)13; // \r
        internal static readonly string cr = carriagereturn.ToString();

        const char linefeed = (char)10; // \n
        internal static readonly string lf = linefeed.ToString();

        internal static readonly string crlf = string.Concat(cr, lf);

        const char tab = (char)09; // \t
        internal static readonly string t = tab.ToString();

        const char nbspace = (char)160; // Non-breaking space
        internal static readonly string nbsp = nbspace.ToString();
    }
}