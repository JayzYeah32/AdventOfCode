string report = File.ReadAllText("Numbers.txt").Replace("\r", "");

 // part 1
Console.WriteLine(Regex.Split(report, "\n\n").Select(x => x.Replace("\n", "").Distinct().Count()).Sum(x => x));

 // part 2
Console.WriteLine(Regex.Split(report, "\n\n").Select(x => x.Split('\n').Cast<IEnumerable<char>>().Aggregate((p, n) => p.Intersect(n)).Count()).Sum(x => x));
