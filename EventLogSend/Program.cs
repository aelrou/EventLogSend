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

            SecurityAuditLog.Report(eventLogs);

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
