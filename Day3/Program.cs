var directions = File.ReadAllText("day3input.txt");
var santaHouseVisited = new List<House>() {new(0,0)};
var roboHouseVisited = new List<House>() {new(0,0)};

foreach (var direction in directions)
{
    var lastHouseVisited = santaHouseVisited.Last();
    
    switch(direction)
    {
        case '^': 
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord, lastHouseVisited.Ycoord+1));
            break;
        case 'v': 
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord, lastHouseVisited.Ycoord-1));
            break;
        case '>': 
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord + 1, lastHouseVisited.Ycoord));
            break;
        case '<': 
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord - 1, lastHouseVisited.Ycoord));
            break;
    }
}

var part1 = santaHouseVisited.Distinct().Count();

santaHouseVisited = new List<House>() {new House(0,0)};

for (var index = 0; index < directions.Length; index += 2)
{
    var direction = directions[index];
    var roboDirection = directions[index+1];
    var lastHouseVisited = santaHouseVisited.Last();
    var lastRoboHouseVisited = roboHouseVisited.Last();

    switch (direction)
    {
        case '^':
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord, lastHouseVisited.Ycoord + 1));
            break;
        case 'v':
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord, lastHouseVisited.Ycoord - 1));
            break;
        case '>':
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord + 1, lastHouseVisited.Ycoord));
            break;
        case '<':
            santaHouseVisited.Add(new House(lastHouseVisited.Xcoord - 1, lastHouseVisited.Ycoord));
            break;
    }
    
    switch (roboDirection)
    {
        case '^':
            roboHouseVisited.Add(new House(lastRoboHouseVisited.Xcoord, lastRoboHouseVisited.Ycoord + 1));
            break;
        case 'v':
            roboHouseVisited.Add(new House(lastRoboHouseVisited.Xcoord, lastRoboHouseVisited.Ycoord - 1));
            break;
        case '>':
            roboHouseVisited.Add(new House(lastRoboHouseVisited.Xcoord + 1, lastRoboHouseVisited.Ycoord));
            break;
        case '<':
            roboHouseVisited.Add(new House(lastRoboHouseVisited.Xcoord - 1, lastRoboHouseVisited.Ycoord));
            break;
    }
}

var part2 = santaHouseVisited.Concat(roboHouseVisited).Distinct().Count();

Console.WriteLine(part1);
Console.WriteLine(part2);
public record House
{
    public House(int xcoord, int ycoord)
    {
        Xcoord = xcoord;
        Ycoord = ycoord;
    }

    public int Xcoord { get; set; }
    public int Ycoord { get; set; }
}