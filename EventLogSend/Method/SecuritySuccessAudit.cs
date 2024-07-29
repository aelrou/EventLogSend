using System.Diagnostics;

namespace EventLogSend.Method
{
    static class SecuritySuccessAudit
    {
        internal static Dictionary<string, string> Parse(EventLogEntry entry)
        {
            Dictionary<string, string> messageData = new Dictionary<string, string>();
            // Check entry source is "Security" EventLog
            if (entry.Source.Equals("Microsoft-Windows-Security-Auditing"))
            {
                // Check entry type is "SuccessAudit"
                if (entry.EntryType.Equals(EventLogEntryType.SuccessAudit))
                {
                    // Check entry detail is "4624 An account was successfully logged on."
                    if (entry.InstanceId.Equals(4624))
                    {
                        string[] successDataLines = entry.Message.Split(new string[] { Value.crlf, Value.cr, Value.lf }, StringSplitOptions.None);
                        int dataLineCount = successDataLines.Length;

                        int startPosition = 99;
                        int subjectPosition = 99;
                        int loginInfoPosition = 99;
                        int newLogonPosition = 99;
                        int processPosition = 99;
                        int networkPosition = 99;
                        int authPosition = 99;
                        int endPosition = 99;

                        for (int i = 0; i < dataLineCount; i++)
                        {
                            if (successDataLines[i].Trim().Equals(@"An account was successfully logged on.")) { startPosition = i; }
                            if (i > startPosition & successDataLines[i].Trim().Equals(@"Subject:")) { subjectPosition = i; }
                            if (i > subjectPosition & successDataLines[i].Trim().Equals(@"Logon Information:")) { loginInfoPosition = i; }
                            if (i > loginInfoPosition & successDataLines[i].Trim().Equals(@"New Logon:")) { newLogonPosition = i; }
                            if (i > newLogonPosition & successDataLines[i].Trim().Equals(@"Process Information:")) { processPosition = i; }
                            if (i > processPosition & successDataLines[i].Trim().Equals(@"Network Information:")) { networkPosition = i; }
                            if (i > networkPosition & successDataLines[i].Trim().Equals(@"Detailed Authentication Information:")) { authPosition = i; }
                            if (i > authPosition & successDataLines[i].Trim().StartsWith(@"This event is generated when a logon session is created.")) { endPosition = i; }
                        }

                        HashSet<string> subjectSet = new HashSet<string>();
                        HashSet<string> loginInfoSet = new HashSet<string>();
                        HashSet<string> newLogonSet = new HashSet<string>();
                        HashSet<string> processSet = new HashSet<string>();
                        HashSet<string> networkSet = new HashSet<string>();
                        HashSet<string> authSet = new HashSet<string>();

                        if (startPosition < subjectPosition
                            & subjectPosition < loginInfoPosition
                            & loginInfoPosition < newLogonPosition
                            & newLogonPosition < processPosition
                            & processPosition < networkPosition
                            & networkPosition < authPosition
                            & authPosition < endPosition
                            & endPosition < 99)
                        {
                            for (int i = subjectPosition; i < loginInfoPosition; i++) { subjectSet.Add(successDataLines[i]); }
                            for (int i = loginInfoPosition; i < newLogonPosition; i++) { loginInfoSet.Add(successDataLines[i]); }
                            for (int i = newLogonPosition; i < processPosition; i++) { newLogonSet.Add(successDataLines[i]); }
                            for (int i = processPosition; i < networkPosition; i++) { processSet.Add(successDataLines[i]); }
                            for (int i = networkPosition; i < authPosition; i++) { networkSet.Add(successDataLines[i]); }
                            for (int i = authPosition; i < endPosition; i++) { authSet.Add(successDataLines[i]); }
                        }
                        else
                        {
                            Console.WriteLine("Message data heading mismatch");
                            Console.WriteLine(string.Concat("startPosition ", startPosition));
                            Console.WriteLine(string.Concat("subjectPosition ", subjectPosition));
                            Console.WriteLine(string.Concat("loginInfoPosition ", loginInfoPosition));
                            Console.WriteLine(string.Concat("newLogonPosition ", newLogonPosition));
                            Console.WriteLine(string.Concat("processPosition ", processPosition));
                            Console.WriteLine(string.Concat("networkPosition ", networkPosition));
                            Console.WriteLine(string.Concat("authPosition ", authPosition));
                            Console.WriteLine(string.Concat("endPosition ", endPosition));
                        }

                        //foreach (string line in subjectSet) { Console.WriteLine(line); }
                        //foreach (string line in loginInfoSet) { Console.WriteLine(line); }
                        //foreach (string line in newLogonSet) { Console.WriteLine(line); }
                        //foreach (string line in processSet) { Console.WriteLine(line); }
                        //foreach (string line in networkSet) { Console.WriteLine(line); }
                        //foreach (string line in authSet) { Console.WriteLine(line); }

                        foreach (string line in subjectSet)
                        {
                            string section = @"Subject:";
                            string key = @"Security ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Domain:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Logon ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        foreach (string line in loginInfoSet)
                        {
                            string section = @"Logon Information:";
                            string key = @"Logon Type:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Restricted Admin Mode:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Remote Credential Guard:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Virtual Account:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Elevated Token:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Impersonation Level:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                        }

                        foreach (string line in newLogonSet)
                        {
                            string section = @"New Logon:";
                            string key = @"Security ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Domain:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Logon ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Linked Logon ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Network Account Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Network Account Domain:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Logon GUID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        foreach (string line in processSet)
                        {
                            string section = @"Process Information:";
                            string key = @"Process ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Process Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        foreach (string line in networkSet)
                        {
                            string section = @"Network Information:";
                            string key = @"Workstation Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Source Network Address:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Source Port:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        foreach (string line in authSet)
                        {
                            string section = @"Detailed Authentication Information:";
                            string key = @"Logon Process:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Authentication Package:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Transited Services:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Package Name (NTLM only):";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Key Length:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }
                    }
                }
            }
            return messageData;
        }
        static bool LineKeyCheck(string key, string line)
        {
            if (line.Trim().StartsWith(key.Trim()))
            {
                return true;
            }
            return false;
        }
        static string LineGetValue(string key, string line)
        {
            int position = line.IndexOf(key);
            string value = "";
            if (position != -1)
            {
                value = line.Substring(position + key.Length);
            }
            return value.Trim();
        }
    }
}
