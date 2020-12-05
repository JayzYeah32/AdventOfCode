string[] report = File.ReadAllLines("Numbers.txt");

List<int> ids = new List<int>();
foreach (string s in report)
{
	int x = Convert.ToInt32(s.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
	int y = Convert.ToInt32(s.Substring(7).Replace('L', '0').Replace('R', '1'), 2);
	ids.Add(x * 8 + y);
}
ids = ids.OrderBy(x => x).ToList();
foreach (int i in Enumerable.Range(0, ids.Count - 1).Where(x => ids[x + 1] - ids[x] == 2))
	Console.WriteLine(ids[i] + 1);
