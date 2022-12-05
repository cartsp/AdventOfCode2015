using System.Text.RegularExpressions;

static IEnumerable<int> ExtractInts(string str)
{
    foreach (Match m in Regex.Matches(str, "\\d+")) yield return int.Parse(m.Value);
}

var ins = File.ReadAllText("day2input.txt");
var part1 = ExtractInts(ins)
    .Chunk(3)
    .Select(a =>
    {
        //2*l*w + 2*w*h + 2*h*l
        var sides = new[] { a[0] * a[1], a[1] * a[2], a[0] * a[2] };
        var arr = new[] { 2 * sides[0], 2 * sides[1], 2 * sides[2] };
        return arr.Sum() + sides.OrderDescending().Last();
    }).Sum();

var part2 = ExtractInts(ins)
    .Chunk(3)
    .Select(a =>
    {
        var bow = a[0] * a[1] * a[2];
        var rib = a.OrderDescending().Skip(1).ToArray();
        var ribTotal = rib[0] + rib[0] + rib[1] + rib[1];
        
        return ribTotal + bow;
    }).Sum();

Console.WriteLine("Hello, World!");