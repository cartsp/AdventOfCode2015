using System.Text.RegularExpressions;

var inputs = File.ReadAllLines("day5input.txt");

var part1 = inputs
    .Select(NiceOrNaughty)
    .Count(a => a);

Console.WriteLine(part1);

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