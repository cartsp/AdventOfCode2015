using System.Security.Cryptography;
using System.Text;

var key = "iwrupvqb";
var secret = 0;

var hash = CreateMD5Hash(key);

while (!hash.StartsWith("00000"))
{
    secret++;
    hash = CreateMD5Hash(key + secret);
}

Console.WriteLine($"part1: {secret}");

secret = 0;

while (!hash.StartsWith("000000"))
{
    secret++;
    hash = CreateMD5Hash(key + secret);
}

Console.WriteLine($"part2: {secret}");

string CreateMD5Hash(string input)
{
    var md5 = MD5.Create();
    var inputBytes = Encoding.ASCII.GetBytes(input);
    var hashBytes = md5.ComputeHash(inputBytes);
     
    var sb = new StringBuilder();
    foreach (var t in hashBytes)
    {
        sb.Append(t.ToString("X2"));
    }
    return sb.ToString();
}