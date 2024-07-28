namespace EventLogSend.Method
{
    class MainArgs
    {
        internal MainArgs(string[] args)
        {
            if (args.Length == 2)
            {
                int days;
                bool number = int.TryParse(args[0], out days);
                if (number)
                {
                    if (days < 1 | days > 9999)
                    {
                        Console.WriteLine(string.Concat("Number of days must be from 1 to 9999."));
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                    DateTime oldestDate = DateTime.UtcNow.AddDays(-1 * days);
                    Value.OldestDate.Add(oldestDate);
                }
                else
                {
                    Console.WriteLine(string.Concat("Number of days must be from 1 to 9999."));
                    Console.ReadLine();
                    Environment.Exit(1);
                }

                if (Directory.Exists(args[1]))
                {
                    Value.WorkDir.Add(args[1]);
                }
                else
                {
                    Directory.CreateDirectory(args[1]);
                    if (Directory.Exists(args[1]))
                    {
                        Value.WorkDir.Add(args[1]);
                    }
                    else
                    {
                        Console.WriteLine(string.Concat(@"Cannot access """, args[1], @""""));
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                }
            }
            else
            {
                Console.WriteLine("Two arguments are required:");
                Console.WriteLine("  How many days of EventLog entries to collect.");
                Console.WriteLine("  What directory to use for logs and configuration.");
                Console.WriteLine();
                Console.WriteLine(@"Usage: EventLogSend.exe 7 ""C:\Users\Public\EventLogSend""");
                Console.ReadLine();
                Environment.Exit(1);
            }
        }
    }
}