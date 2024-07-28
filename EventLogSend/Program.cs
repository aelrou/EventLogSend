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

            TypesCopy.Report(eventLogs);

            SecurityAuditLog.Report(eventLogs);

            Log.Write(Value.Log);
        }
    }
    
    class Value
    {
        internal static List<string> WorkDir = new List<string>();
        internal static readonly string LogFile = "EventLogSend.log";
        internal static List<DateTime> OldestDate = new List<DateTime>();

        internal static List<string> Log = new List<string>();

        internal static readonly string DateFormat = "yyyy-MM-dd HH:mm:ss.ffff";

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