internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Provide a local github repository destination.");
        System.Console.WriteLine("  for author details: \"-a\"");
        System.Console.WriteLine("  for frequency details: \"-f\"");
        var _GivenDirectory = Console.ReadLine();
        var GivenDirectory = _GivenDirectory!.Substring(0, (_GivenDirectory.Length - 3));
        //want this to be formatted like "local/github/repo/" -a

        var Mode = _GivenDirectory.Substring(_GivenDirectory.Length - 2);

        if (Mode.Equals("-a"))
        {
            GitInsightAuthor(GivenDirectory);
        }
        if (Mode.Equals("-f"))
        {
            GitInsightFrequent(GivenDirectory);
        }

    }

    public static void GitInsightAuthor(string path)
    {
        using (var repo = new Repository(path))
        {
            var commits = repo.Commits.ToList();
            var dict1 = new Dictionary<string, Dictionary<DateTime, int>>();
            var dict2 = new Dictionary<DateTime, int>();

            foreach (var c in commits)
            {
                if (!dict1.ContainsKey(c.Committer.Name))
                {
                    dict1.Add(c.Committer.Name, new Dictionary<DateTime, int>());
                }
                if (dict1.ContainsKey(c.Committer.Name))
                {
                    Dictionary<DateTime, int> dict22 = dict1[c.Committer.Name].GetValueOrDefault;

                    //SOMEHOW get this integrated
                    // if (!dict.ContainsKey(c.Committer.When.Date.Date))
                    // {
                    //     dict.Add(c.Committer.When.Date.Date, 1);
                    // }
                    // else if (dict.ContainsKey(c.Committer.When.Date.Date))
                    // {
                    //     dict[c.Committer.When.Date.Date]++;
                    // }
                }


                // System.Console.WriteLine(c.Committer.Name + " " + c.Author.When.Date.ToString());
            }

            foreach (var v1 in dict1)
            {
                System.Console.WriteLine();

                foreach (var v2 in dict2)
                {
                    System.Console.WriteLine("    " + "");
                }
            }
        }
    }

    public static void GitInsightFrequent(string path)
    {
        using (var repo = new Repository(path))
        {
            var commits = repo.Commits.ToList();
            var dict = new Dictionary<DateTime, int>();

            foreach (var c in commits)
            {
                if (!dict.ContainsKey(c.Committer.When.Date.Date))
                {
                    dict.Add(c.Committer.When.Date.Date, 1);
                }
                else if (dict.ContainsKey(c.Committer.When.Date.Date))
                {
                    dict[c.Committer.When.Date.Date]++;
                }
            }

            foreach (var v in dict)
            {
                System.Console.WriteLine(v.Value + " " + v.Key.ToString("dd/mm/yyyy"));
            }
        }
    }
}