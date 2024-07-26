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
            
            message = message.Replace("The details view of this entry contains further information.", "");
            message = message.Replace("\t", " ");
            message = message.Replace("\r\n", " ");
            message = message.Replace("   ", " ");
            message = message.Replace("  ", " ");
            message = message[..Math.Min(keep, message.Length)];
            return message;
        }
    }
}
