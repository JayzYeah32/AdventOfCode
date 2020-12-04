List<string> report = File.ReadAllLines("Numbers.txt").ToList();

long count(int incx, int incy)
{
	int trees = 0;
	int pos = 0;
	for (int i = 0; i < report.Count; i += incy)
	{
		if (report[i][pos] == '#')
			trees++;
		pos = (pos + incx) % report.First().Length;
	}
	return trees;
}
