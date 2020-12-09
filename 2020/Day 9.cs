long[] report = File.ReadAllLines("Numbers.txt").Select(x => Convert.ToInt64(x)).ToArray();

KeyValuePair<int, long> find(long[] arr, int preamble)
{
	int pos = preamble;
	while (pos++ < arr.Length)
		if (arr.Skip(pos - preamble).Take(preamble).Where(x => arr.Skip(pos - preamble).Take(preamble).Where(y => x + y == arr[pos]).Count() > 0).Count() == 0)
			return new KeyValuePair<int, long>(pos, arr[pos]);
	return new KeyValuePair<int, long>(-1, -1);
}
long fix(long[] arr, int pos)
{
	int pos2 = 0;
	while (pos2++ < arr.Length)
	{
		long total = 0;
		int off = 0;
		while (total <= arr[pos])
			if ((total += arr.Skip(pos2 + off++).First()) == arr[pos])
				return arr.Skip(pos2).Take(off).Min(x => x) + arr.Skip(pos2).Take(off).Max(x => x);
	}
	return -1;
}
KeyValuePair<int, long> kvp = find(report, 25);

 // part 1
Console.WriteLine(kvp.Value);

 // part 2
Console.WriteLine(fix(report, kvp.Key));
