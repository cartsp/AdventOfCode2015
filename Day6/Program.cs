// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var inputs = File.ReadAllLines("day6input.txt");
var lights = new bool[1000, 1000];
//inputs = new[] { "turn on 1,1 through 2,2" };
foreach (var instruction in inputs)
{
    var coords = Regex.Matches(instruction, (@"(\d+)"));
    var parsedCoords = ParseCoords(coords);
    
    if (instruction.StartsWith("turn on"))
    {
        TurnOn((parsedCoords.startx, parsedCoords.endx), 
            (parsedCoords.starty, parsedCoords.endy));
    }
    
    if (instruction.StartsWith("turn off"))
    {
        TurnOff((parsedCoords.startx, parsedCoords.endx), 
            (parsedCoords.starty, parsedCoords.endy));
    }
    
    if (instruction.StartsWith("toggle"))
    {
        Toggle((parsedCoords.startx, parsedCoords.endx), 
            (parsedCoords.starty, parsedCoords.endy));
    }  
}
(int startx, int endx ,int starty,int endy) ParseCoords(MatchCollection coords)
{
    return (int.Parse(coords[0].Value), int.Parse(coords[1].Value),
        int.Parse(coords[2].Value), int.Parse(coords[3].Value));
}

void TurnOn((int, int) start, (int, int) end)
{
    for (int y = start.Item2; y < end.Item2 + 1; y++)
    {
        for (int x = start.Item1 ; x < end.Item1 + 1; x++)
        {
            lights[x, y] = true;
        }
    }
}

void TurnOff((int, int) start, (int, int) end)
{
    for (int y = start.Item2; y < end.Item2 + 1; y++)
    {
        for (int x = start.Item1 ; x < end.Item1 + 1; x++)
        {
            lights[x, y] = false;
        }
    }
}

void Toggle((int, int) start, (int, int) end)
{
    for (int y = start.Item2; y < end.Item2 + 1; y++)
    {
        for (int x = start.Item1 ; x < end.Item1 + 1; x++)
        {
            lights[x, y] = !lights[x, y];
        }
    }
}

var result = lights.Cast<bool>().Count(a => a);

Console.WriteLine($"part1 : {result}");
var newlights = new int[1000, 1000];

foreach (var instruction in inputs)
{
    var coords = Regex.Matches(instruction, (@"(\d+)"));
    var parsedCoords = ParseCoords(coords);
    
    if (instruction.StartsWith("turn on"))
    {
        TurnOnv2((parsedCoords.startx, parsedCoords.endx), 
            (parsedCoords.starty, parsedCoords.endy));
    }
    
    if (instruction.StartsWith("turn off"))
    {
        TurnOffv2((parsedCoords.startx, parsedCoords.endx), 
            (parsedCoords.starty, parsedCoords.endy));
    }
    
    if (instruction.StartsWith("toggle"))
    {
        Togglev2((parsedCoords.startx, parsedCoords.endx), 
            (parsedCoords.starty, parsedCoords.endy));
    }  
}

void TurnOnv2((int, int) start, (int, int) end)
{
    for (int y = start.Item2; y < end.Item2 + 1; y++)
    {
        for (int x = start.Item1 ; x < end.Item1 + 1; x++)
        {
            newlights[x, y]++;
        }
    }
}

void TurnOffv2((int, int) start, (int, int) end)
{
    for (int y = start.Item2; y < end.Item2 + 1; y++)
    {
        for (int x = start.Item1 ; x < end.Item1 + 1; x++)
        {
            if(newlights[x, y] != 0)
                newlights[x, y]--;
        }
    }
}

void Togglev2((int, int) start, (int, int) end)
{
    for (int y = start.Item2; y < end.Item2 + 1; y++)
    {
        for (int x = start.Item1 ; x < end.Item1 + 1; x++)
        {
            newlights[x, y] = newlights[x, y] + 2;
        }
    }
}

var result2 = newlights.Cast<int>().Sum();
Console.WriteLine($"part2 : {result2}");