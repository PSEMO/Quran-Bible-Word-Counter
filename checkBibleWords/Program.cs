using static System.Net.Mime.MediaTypeNames;

Console.ReadKey();

//===============================Reads the text file
string path = Path.GetFullPath("Bible.txt");
string WholeBible = System.IO.File.ReadAllText(path);
//===============================lower cases it
WholeBible = WholeBible.ToLower();

//===============================deletes verse names and verse numbers
//ex:
//from; Genesis 6:8 But Noah found favor in Yahweh’s eyes.
//to;   But Noah found favor in Yahweh’s eyes.
string[] lines = WholeBible.Split('\n');
for (int i = 0; i < lines.Length; i++)
{
    Console.WriteLine(lines[i]);
}
for (int i = 0; i < lines.Length; i++)
{
    lines[i] = DeleteStr(lines[i], '	');
}
for (int i = 0; i < lines.Length; i++)
{
    Console.WriteLine(lines[i]);
}

//===============================deletes symbols from the text
for (int i = 0; i < lines.Length; i++)
{
    lines[i] = new string((from c in lines[i]
                           where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                           select c 
               ).ToArray());
}

//===============================counting words
//word, occurrences
Dictionary<string, int> WordsAndCounts = new Dictionary<string, int>();
for (int i = 0; i < lines.Length; i++)
{
    foreach (var word in lines[i].Split(" "))
    {
        if(WordsAndCounts.ContainsKey(word))
        {
            WordsAndCounts[word] += 1;
        }
        else
        {
            WordsAndCounts[word] = 1;
        }
    }
}

//===============================sorting words
var sortedDict = from entry in WordsAndCounts orderby entry.Value ascending select entry;

//===============================printing words
foreach (KeyValuePair<string, int> ele1 in sortedDict)
{
    Console.WriteLine("{0} - {1}",
              ele1.Key, ele1.Value);
}

Console.ReadKey();
/////////////////////////////////

string DeleteStr(string str, char From)
{
    int pFrom = str.LastIndexOf(From);
    string result = str.Substring(pFrom + 1, str.Length - pFrom - 1);
    return result;
}