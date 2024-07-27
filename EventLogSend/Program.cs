using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    public static class Constants
    {
        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";
        public const string WorkDir = "C:\\Users\\Public\\EventLogSend";
        public const string OutputFile = "Output.log";
    }

    public static class Line
    {
        public static List<string> Store = new List<string>();
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            //EventLog[] EventLogs = EventLog.GetEventLogs();
            //Console.WriteLine(string.Concat("Log count: ", EventLogs.Length));
            //foreach (EventLog log in EventLogs)
            //{
            //    Console.WriteLine(string.Concat("Log: ", log.Log));
            //}

            //Environment.Exit(0);

            ReportEventLog.Properties();

            if (Directory.Exists(Constants.WorkDir))
            {
                Log.Write(Line.Store);
            }
            else
            {
                Directory.CreateDirectory(Constants.WorkDir);
                Log.Write(Line.Store);
            }
        }
    }
}
