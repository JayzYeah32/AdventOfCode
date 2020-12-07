Dictionary<string, Dictionary<string, int>> arr = report.Select(x => Regex.Split(x, " bags contain ")).ToDictionary(x => x.First(), x => Regex.Matches(x.Last(), "(?<a>[0-9]+) (?<c>[a-z ]+)").Cast<Match>().ToDictionary(y => y.Groups["c"].Value.Replace(" bags", "").Replace(" bag", ""), y => Convert.ToInt32(y.Groups["a"].Value)));
Dictionary<string, Dictionary<string, int>> containnon = report.Where(x => x.Contains("contain no other bags")).ToDictionary(x => x.Substring(0, x.Length - 28), x => new Dictionary<string, int>() { { x.Substring(0, x.Length - 28), 1 } });
Dictionary<string, long> bags = containnon.ToDictionary(x => x.Key, x => 1L);
arr = arr.Where(x => !containnon.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
while (arr.Count > 0)
{
    foreach (KeyValuePair<string, Dictionary<string, int>> s in arr.Where(x => x.Value.Keys.Except(containnon.Keys).Count() == 0))
    {
        containnon[s.Key] = new Dictionary<string, int>();
        bags[s.Key] = s.Value.Select(x => bags[x.Key] * x.Value).Sum(x => x) + 1;
        foreach (KeyValuePair<string, int> kvp in s.Value)
            if (kvp.Key != "shiny gold")
                foreach (KeyValuePair<string, int> kvp2 in containnon[kvp.Key])
                    containnon[s.Key][kvp2.Key] = kvp2.Value * kvp.Value + (containnon[s.Key].ContainsKey(kvp2.Key) ? containnon[s.Key][kvp2.Key] : 0);
            else
                containnon[s.Key][kvp.Key] = kvp.Value + (containnon[s.Key].ContainsKey(kvp.Key) ? containnon[s.Key][kvp.Key] : 0);
    }
    arr = arr.Where(x => !containnon.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
}

 // part 1
Console.WriteLine(containnon.Where(x => x.Value.Where(y => y.Key.Contains("shiny gold")).Count() > 0).Count());

 // part 2
Console.WriteLine(bags["shiny gold"] - 1);
