string report = File.ReadAllText("Numbers.txt").Replace("\r", "");

 // part 1
Console.WriteLine(Regex.Split(report, "\n\n").Select(x => x.Replace("\n", "").Distinct().Count()).Sum(x => x));

 // part 2
int overlap(string[] s)
{
	IEnumerable<char> first = s.First();
	foreach (string x in s.Skip(1))
		first = first.Intersect(x.ToCharArray());
	return first.Count();
}
Console.WriteLine(Regex.Split(report, "\n\n").Select(x => overlap(x.Split('\n'))).Sum(x => x));
