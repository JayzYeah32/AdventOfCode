int[] report = File.ReadAllLines("Numbers.txt").Select(int.Parse).OrderBy(x => x).ToArray();

 // part 1
Console.WriteLine((Enumerable.Range(0, report.Length - 1).Where(x => report[x + 1] - report[x] == 1).Count() + 1) *
	(Enumerable.Range(0, report.Length - 1).Where(x => report[x + 1] - report[x] == 3).Count() + 1));

 // part 2
IEnumerable<int> arr = report.Reverse().Append(0).Prepend(report.Max() + 3);
Dictionary<int, long> sub = new Dictionary<int, long>();
foreach (int i in arr)
	sub[i] = new long[] { arr.Where(x => x > i && x - i <= 3).Select(n => sub[n]).Sum() }.Select(x => x == 0 ? 1 : x).First();
Console.WriteLine(sub[0]);
