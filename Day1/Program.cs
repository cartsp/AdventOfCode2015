// See https://aka.ms/new-console-template for more information
var ins = File.ReadAllText("day1input.txt");

int floor = 0;
bool reached = false;
var part1 = ins.Aggregate(0, (i, c) => c == '(' ? i + 1 : i - 1);

Console.WriteLine(part1);
for (var index = 0; index < ins.Length; index++)
{
    var c = ins[index];
    if (c == '(')
    {
        floor++;
    }
    else
    {
        floor--;
    }

    if (!reached && floor == -1)
    {
        Console.WriteLine(index +1);
        reached = true;
    }
}

Console.WriteLine(floor);