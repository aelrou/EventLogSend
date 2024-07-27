namespace EventLogSend.Method
{
    public static class Message
    {
        public static string Filter(string message, int keep)
        {
            if (message.Contains("The description for Event ID"))
            {
                return "";
            }
            //message = message.Replace("The details view of this entry contains further information.", "");
            message = message.Replace((char)09, (char)32); // Remove tabs
            message = message.Replace((char)10, (char)32); // Remove line feeds
            message = message.Replace((char)13, (char)32); // Remove carriage returns
            message = message.Replace((char)160, (char)32); // Remove non-breaking spaces
            message = message.Replace("        ", " ");
            message = message.Replace("       ", " ");
            message = message.Replace("      ", " ");
            message = message.Replace("     ", " ");
            message = message.Replace("    ", " ");
            message = message.Replace("   ", " ");
            message = message.Replace("  ", " ");
            message = message.Replace(" , ", ", ");
            message = message[..Math.Min(keep, message.Length)];
            return message;
        }
    }
}
