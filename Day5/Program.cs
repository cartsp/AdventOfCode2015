using System.Text.RegularExpressions;

var inputs = File.ReadAllLines("day5input.txt");

var part1 = inputs
    .Select(NiceOrNaughty)
    .Count(a => a);

var part2 = inputs
    .Select(NiceOrNaughtyV2)
    .Count(a => a);

Console.WriteLine(part1);
Console.WriteLine(part2);

bool NiceOrNaughty(string phrase)
{
    if (phrase.Contains("ab") ||
        phrase.Contains("cd") ||
        phrase.Contains("pq") ||
        phrase.Contains("xy"))
    {
        return false;
    }

    return Regex.Match(phrase, @"[aeiou].*[aeiou].*[aeiou]").Success 
           && Regex.Match(phrase, @"(.)\1{1,}").Success;
}

bool NiceOrNaughtyV2(string phrase)
{
    return Regex.Match(phrase, @"(\w\w).*?\1").Success 
           && Regex.Match(phrase, @"(\w)\w\1").Success;
}
