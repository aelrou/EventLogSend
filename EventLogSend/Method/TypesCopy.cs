using System.Diagnostics;
using System.Text.RegularExpressions;

//using System.Management.Automation;
//using System.Management.Automation.Runspaces;
// https://www.nuget.org/packages/Microsoft.PowerShell.SDK/7.4.4

namespace EventLogSend.Method
{
    public static class TypesCopy
    {
        public static void Report(EventLog[] eventLogs, DateTime dateTime)
        {
            //foreach (EventLog eventLog in eventLogs)
            //{
            //    if (eventLog.Log.Equals("System"))
            //    {
            //        Line.Store.Add("");
            //        Line.Store.Add(string.Concat("---- Critical, ", eventLog.Log, " ----"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            if (eventLogEntry.TimeWritten >= dateTime)
            //            {
            //                if (eventLogEntry.EntryType.ToString().Equals("0"))
            //                {
            //                    string line = string.Concat(
            //                        //"Category ", eventLogEntry.Category,
            //                        //" - CategoryNumber ", eventLogEntry.CategoryNumber,
            //                        //" - Data ", eventLogEntry.Data,
            //                        //" - EntryType ", eventLogEntry.EntryType,
            //                        //"Critical",
            //                        eventLogEntry.Source,
            //                        ", Id ", eventLogEntry.InstanceId,
            //                        //", Index ", eventLogEntry.Index
            //                        //", MachineName ", eventLogEntry.MachineName,
            //                        ", ", Message.Filter(eventLogEntry.Message, 1000),
            //                        ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
            //                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
            //                    //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
            //                    //", UserName ", eventLogEntry.UserName
            //                    );
            //                    Line.Store.Add(line);
            //                }
            //            }
            //        }

            //        Line.Store.Add("");
            //        Line.Store.Add(string.Concat("---- Error, ", eventLog.Log, " ----"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            if (eventLogEntry.TimeWritten >= dateTime)
            //            {
            //                if (eventLogEntry.EntryType.ToString().Equals("Error"))
            //                {
            //                    bool send = true;
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("DCOM") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("SNMP") & eventLogEntry.Message.ToString().Contains("encountered an error while accessing the registry key"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Service Control Manager") & eventLogEntry.Message.ToString().Contains("The Printer Extensions and Notifications service"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WMI") & eventLogEntry.Message.ToString().Contains("attempted to"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
            //                    {
            //                        send = false;
            //                    }

            //                    if (send)
            //                    {
            //                        string line = string.Concat(
            //                            //"Category ", eventLogEntry.Category,
            //                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
            //                            //" - Data ", eventLogEntry.Data,
            //                            //" - EntryType ", eventLogEntry.EntryType,
            //                            //eventLogEntry.EntryType,
            //                            eventLogEntry.Source,
            //                            //", EventId ", eventLogEntry.InstanceId,
            //                            //", Index ", eventLogEntry.Index
            //                            //", MachineName ", eventLogEntry.MachineName,
            //                            ", ", Message.Filter(eventLogEntry.Message, 1000),
            //                            ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
            //                        //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
            //                        //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
            //                        //", UserName ", eventLogEntry.UserName
            //                        );
            //                        Line.Store.Add(line);
            //                    }
            //                }
            //            }
            //        }

            //        Line.Store.Add("");
            //        Line.Store.Add(string.Concat("---- Warning, ", eventLog.Log, " ----"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            if (eventLogEntry.TimeWritten >= dateTime)
            //            {
            //                if (eventLogEntry.EntryType.ToString().Equals("Warning"))
            //                {
            //                    bool send = true;
            //                    if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("DCOM") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("HTTP") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
            //                    {
            //                        send = false;
            //                    }

            //                    if (send)
            //                    {
            //                        string line = string.Concat(
            //                            //"Category ", eventLogEntry.Category,
            //                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
            //                            //" - Data ", eventLogEntry.Data,
            //                            //" - EntryType ", eventLogEntry.EntryType,
            //                            //eventLogEntry.EntryType,
            //                            eventLogEntry.Source,
            //                            //", EventId ", eventLogEntry.InstanceId,
            //                            //", Index ", eventLogEntry.Index
            //                            //", MachineName ", eventLogEntry.MachineName,
            //                            ", ", Message.Filter(eventLogEntry.Message, 1000),
            //                            ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
            //                        //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
            //                        //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
            //                        //", UserName ", eventLogEntry.UserName
            //                        );
            //                        Line.Store.Add(line);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //foreach (EventLog eventLog in eventLogs)
            //{
            //    if (eventLog.Log.Equals("Application"))
            //    {
            //        Line.Store.Add("");
            //        Line.Store.Add(string.Concat("---- Critical, ", eventLog.Log, " ----"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            if (eventLogEntry.TimeWritten >= dateTime)
            //            {
            //                if (eventLogEntry.EntryType.ToString().Equals("0"))
            //                {
            //                    string line = string.Concat(
            //                        //"Category ", eventLogEntry.Category,
            //                        //" - CategoryNumber ", eventLogEntry.CategoryNumber,
            //                        //" - Data ", eventLogEntry.Data,
            //                        //" - EntryType ", eventLogEntry.EntryType,
            //                        //"Critical",
            //                        eventLogEntry.Source,
            //                        ", Id ", eventLogEntry.InstanceId,
            //                        //", Index ", eventLogEntry.Index
            //                        //", MachineName ", eventLogEntry.MachineName,
            //                        ", ", Message.Filter(eventLogEntry.Message, 1000),
            //                        ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
            //                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
            //                    //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
            //                    //", UserName ", eventLogEntry.UserName
            //                    );
            //                    Line.Store.Add(line);
            //                }
            //            }
            //        }

            //        Line.Store.Add("");
            //        Line.Store.Add(string.Concat("---- Error ", eventLog.Log, " ----"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            if (eventLogEntry.TimeWritten >= dateTime)
            //            {
            //                if (eventLogEntry.EntryType.ToString().Equals("Error"))
            //                {
            //                    bool send = true;
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("DCOM") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("SNMP") & eventLogEntry.Message.ToString().Contains("encountered an error while accessing the registry key"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Service Control Manager") & eventLogEntry.Message.ToString().Contains("The Printer Extensions and Notifications service"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WMI") & eventLogEntry.Message.ToString().Contains("attempted to"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
            //                    {
            //                        send = false;
            //                    }

            //                    if (send)
            //                    {
            //                        string line = string.Concat(
            //                            //"Category ", eventLogEntry.Category,
            //                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
            //                            //" - Data ", eventLogEntry.Data,
            //                            //" - EntryType ", eventLogEntry.EntryType,
            //                            //eventLogEntry.EntryType,
            //                            eventLogEntry.Source,
            //                            //", EventId ", eventLogEntry.InstanceId,
            //                            //", Index ", eventLogEntry.Index
            //                            //", MachineName ", eventLogEntry.MachineName,
            //                            ", ", Message.Filter(eventLogEntry.Message, 1000),
            //                            ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
            //                        //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
            //                        //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
            //                        //", UserName ", eventLogEntry.UserName
            //                        );
            //                        Line.Store.Add(line);
            //                    }
            //                }
            //            }
            //        }

            //        Line.Store.Add("");
            //        Line.Store.Add(string.Concat("---- Warning, ", eventLog.Log, " ----"));
            //        foreach (EventLogEntry eventLogEntry in eventLog.Entries)
            //        {
            //            if (eventLogEntry.TimeWritten >= dateTime)
            //            {
            //                if (eventLogEntry.EntryType.ToString().Equals("Warning"))
            //                {
            //                    bool send = true;
            //                    if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("DCOM") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("HTTP") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
            //                    {
            //                        send = false;
            //                    }
            //                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
            //                    {
            //                        send = false;
            //                    }

            //                    if (send)
            //                    {
            //                        string line = string.Concat(
            //                            //"Category ", eventLogEntry.Category,
            //                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
            //                            //" - Data ", eventLogEntry.Data,
            //                            //" - EntryType ", eventLogEntry.EntryType,
            //                            //eventLogEntry.EntryType,
            //                            eventLogEntry.Source,
            //                            //", EventId ", eventLogEntry.InstanceId,
            //                            //", Index ", eventLogEntry.Index
            //                            //", MachineName ", eventLogEntry.MachineName,
            //                            ", ", Message.Filter(eventLogEntry.Message, 1000),
            //                            ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
            //                        //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
            //                        //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
            //                        //", UserName ", eventLogEntry.UserName
            //                        );
            //                        Line.Store.Add(line);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}



            string pattern = @".*(?:An account failed to log on\.).*(?:Subject\:).*?(?:Security ID\:)(.*)?(?:Account Name\:)(.*)?(?:Account Domain\:)(.*)?(?:Logon ID\:)(.*)?(?:Logon Type\:)(.*)(?:Account For Which Logon Failed\:).*?(?:Security ID\:)(.*)?(?:Account Name\:)(.*)?(?:Account Domain\:)(.*)(?:Failure Information\:).*?(?:Failure Reason\:)(.*)?(?:Status\:)(.*)?(?:Sub Status\:)(.*)(?:Process Information\:).*?(?:Caller Process ID\:)(.*)?(?:Caller Process Name\:)(.*)(?:Network Information\:).*?(?:Workstation Name\:)(.*)?(?:Source Network Address\:)(.*)?(?:Source Port\:)(.*)(?:Detailed Authentication Information\:).*?(?:Logon Process\:)(.*)?(?:Authentication Package\:)(.*)?(?:Transited Services\:)(.*)?(?:Package Name \(NTLM only\)\:)(.*)?(?:Key Length\:)(.*)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // (?:An account failed to log on\.).*
            // (?:Subject\:).*
            // ?(?:Security ID\:)(.*)
            // ?(?:Account Name\:)(.*)
            // ?(?:Account Domain\:)(.*)
            // ?(?:Logon ID\:)(.*)
            // ?(?:Logon Type\:)(.*)
            // (?:Account For Which Logon Failed\:).*
            // ?(?:Security ID\:)(.*)
            // ?(?:Account Name\:)(.*)
            // ?(?:Account Domain\:)(.*)
            // (?:Failure Information\:).*
            // ?(?:Failure Reason\:)(.*)
            // ?(?:Status\:)(.*)
            // ?(?:Sub Status\:)(.*)
            // (?:Process Information\:).*
            // ?(?:Caller Process ID\:)(.*)
            // ?(?:Caller Process Name\:)(.*)
            // (?:Network Information\:).*
            // ?(?:Workstation Name\:)(.*)
            // ?(?:Source Network Address\:)(.*)
            // ?(?:Source Port\:)(.*)
            // (?:Detailed Authentication Information\:).*
            // ?(?:Logon Process\:)(.*)
            // ?(?:Authentication Package\:)(.*)
            // ?(?:Transited Services\:)(.*)
            // ?(?:Package Name \(NTLM only\)\:)(.*)
            // ?(?:Key Length\:)(.*)

            foreach (EventLog eventLog in eventLogs)
            {
                if (eventLog.Log.Equals("Security"))
                {
                    Line.Store.Add("");
                    Line.Store.Add(string.Concat("---- FailureAudit, ", eventLog.Log, " ----"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= dateTime)
                        {
                            if (eventLogEntry.EntryType.ToString().Equals("FailureAudit"))
                            {
                                // Accessing EventLogEntry.Data
                                byte[] data = eventLogEntry.Data;
                                if (data != null && data.Length > 0)
                                {
                                    // Process the data as needed
                                    string hex = BitConverter.ToString(data);
                                    Console.WriteLine(string.Concat("Data (Hex): ", hex));

                                    // Convert to string if the data is a string
                                    string dataString = System.Text.Encoding.UTF8.GetString(data);
                                    Console.WriteLine(string.Concat("Data (String): ", dataString));
                                }
                                else
                                {
                                    Console.WriteLine("Nothing in EventLogEntry.Data");
                                }






                                bool send = true;
                                //if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed"))
                                //{
                                //    send = false;
                                //}

                                if (send)
                                {
                                    string message = eventLogEntry.Message.ToString();
                                    //message = message.Replace("This event is generated when a logon request fails. It is generated on the computer where access was attempted.", "");
                                    //message = message.Replace("The Subject fields indicate the account on the local system which requested the logon. This is most commonly a service such as the Server service, or a local process such as Winlogon.exe or Services.exe.", "");
                                    //message = message.Replace("The Logon Type field indicates the kind of logon that was requested. The most common types are 2 (interactive) and 3 (network).", "");
                                    //message = message.Replace("The Process Information fields indicate which account and process on the system requested the logon.", "");
                                    //message = message.Replace("The Network Information fields indicate where a remote logon request originated. Workstation name is not always available and may be left blank in some cases.", "");
                                    //message = message.Replace("The authentication information fields provide detailed information about this specific logon request.", "");
                                    //message = message.Replace("- Transited services indicate which intermediate services have participated in this logon request.", "");
                                    //message = message.Replace("- Package name indicates which sub-protocol was used among the NTLM protocols.", "");
                                    //message = message.Replace("- Key length indicates the length of the generated session key. This will be 0 if no session key was requested.", "");
                                    
                                    int index = message.IndexOf("This event is generated when a logon request fails.");
                                    if (index != -1)
                                    {
                                        message = message.Remove(index);
                                    }
                                    message = Message.Filter(message, 4000);

                                    MatchCollection matches = regex.Matches(message);
                                    if (matches.Count == 1)
                                    {
                                        GroupCollection groups = matches[0].Groups;
                                        if (groups.Count == 22)
                                        {
                                            //string zero = groups[0].Value;
                                            string SecurityID = groups[1].Value;
                                            string AccountName = groups[2].Value;
                                            string AccountDomain = groups[3].Value;
                                            string LogonID = groups[4].Value;
                                            string LogonType = groups[5].Value;
                                            string SecurityID2 = groups[6].Value;
                                            string AccountName2 = groups[7].Value;
                                            string AccountDomain2 = groups[8].Value;
                                            string FailureReason = groups[9].Value;
                                            string Status = groups[10].Value;
                                            string SubStatus = groups[11].Value;
                                            string CallerProcessID = groups[12].Value;
                                            string CallerProcessName = groups[13].Value;
                                            string WorkstationName = groups[14].Value;
                                            string SourceNetworkAddress = groups[15].Value;
                                            string SourcePort = groups[16].Value;
                                            string LogonProcess = groups[17].Value;
                                            string AuthenticationPackage = groups[18].Value;
                                            string TransitedServices = groups[19].Value;
                                            string PackageName = groups[20].Value;
                                            string KeyLength = groups[21].Value;
                                        }
                                        else
                                        {
                                            Console.WriteLine(groups.Count);
                                        }
                                    }

                                    string line = string.Concat(
                                        //"Category ", eventLogEntry.Category,
                                        //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                                        //" - EntryType ", eventLogEntry.EntryType,
                                        //eventLogEntry.EntryType,
                                        eventLogEntry.Source,
                                        //", ", eventLogEntry.InstanceId,
                                        //", Index ", eventLogEntry.Index
                                        //", MachineName ", eventLogEntry.MachineName,
                                        //", ", eventLogEntry.Data.GetHashCode(),
                                        ", ", message,
                                        ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                    );
                                    Line.Store.Add(line);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
