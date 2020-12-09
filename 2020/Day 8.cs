string[] report = File.ReadAllLines("Numbers.txt");

KeyValuePair<bool, int> count(string[] rep)
{
	int pos = -1;
	int accumulator = 0;
	List<int> complete = new List<int>();
	while (!complete.Contains(++pos) && rep.Length > pos)
	{
		complete.Add(pos);
		if (rep[pos].StartsWith("acc"))
			accumulator += Convert.ToInt32(rep[pos].Substring(4));
		else if (rep[pos].StartsWith("jmp"))
			pos += Convert.ToInt32(rep[pos].Substring(4)) - 1;
	}
	return new KeyValuePair<bool, int>(pos == rep.Length, accumulator);
}

 // part 1
Console.WriteLine(count(report));

 // part 2
foreach (int i in Enumerable.Range(0, report.Length - 1).Where(x => report[x].StartsWith("nop") || report[x].StartsWith("jmp")))
{
	string[] report2 = (string[])report.Clone();
	report2[i] = report2[i].StartsWith("jmp") ? "nop" : "jmp" + report[i].Substring(3);
	KeyValuePair<bool, int> kvp = count(report2);
	if (kvp.Key)
		Console.WriteLine(kvp);
}
