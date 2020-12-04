string report = File.ReadAllText("Numbers.txt");

IEnumerable<Dictionary<string, string>> arr = Regex.Split(report, "\r\n\r\n").Select(s => Regex.Matches(s, @"(?<name>[a-z]{3})\:(?<code>[^\s]+)").Cast<Match>().ToDictionary(x => x.Groups["name"].Value, x => x.Groups["code"].Value));
arr = arr.Where(x => x.Count == 8 || (x.Count == 7 && !x.ContainsKey("cid")));
arr = arr.Where(x => Convert.ToInt32(x["byr"]) >= 1920 && Convert.ToInt32(x["byr"]) <= 2002);
arr = arr.Where(x => Convert.ToInt32(x["iyr"]) >= 2010 && Convert.ToInt32(x["iyr"]) <= 2020);
arr = arr.Where(x => Convert.ToInt32(x["eyr"]) >= 2020 && Convert.ToInt32(x["eyr"]) <= 2030);
arr = arr.Where(x => new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(x["ecl"]));
arr = arr.Where(x => Regex.Replace(x["pid"], "[^0-9]", "").Length == 9); //
arr = arr.Where(x => x["hcl"].StartsWith("#") && Regex.Replace(x["hcl"].Substring(1), "[^0-9a-f]", "").Length == 6);
arr = arr.Where(x => (x["hgt"].EndsWith("cm") && Convert.ToInt32(Regex.Replace(x["hgt"], "[^0-9]", "")) >= 150 && Convert.ToInt32(Regex.Replace(x["hgt"], "[^0-9]", "")) <= 193) ||
    (x["hgt"].EndsWith("in") && Convert.ToInt32(Regex.Replace(x["hgt"], "[^0-9]", "")) >= 59 && Convert.ToInt32(Regex.Replace(x["hgt"], "[^0-9]", "")) <= 76));
Console.WriteLine(arr.ToArray().Length);
