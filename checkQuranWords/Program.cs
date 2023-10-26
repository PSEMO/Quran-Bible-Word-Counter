using static System.Net.Mime.MediaTypeNames;

Console.ReadKey();

//===============================Reads the text file
string path = Path.GetFullPath("Quran.txt");
string WholeQuran = System.IO.File.ReadAllText(path);
//===============================lower cases it
WholeQuran = WholeQuran.ToLower();

//===============================deletes verse names
string[] lines = WholeQuran.Split('\n');
string[] sentences = new string[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    Console.WriteLine(lines[i]);
}
for (int i = 0; i < lines.Length; i++)
{
    if (!lines[i].Contains("<td>"))
        sentences[i] = lines[i];
    else
        sentences[i] = "";
}
for (int i = 0; i < sentences.Length; i++)
{
    if (sentences[i] != "" || sentences[i] != "\n")
        Console.WriteLine(sentences[i]);
}

//===============================deletes symbols from the text
for (int i = 0; i < sentences.Length; i++)
{
    sentences[i] = new string((from c in sentences[i]
                           where (char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)) && c != '\n'
                           select c
               ).ToArray());;
}

//===============================counting words
//word, occurrences
Dictionary<string, int> WordsAndCounts = new Dictionary<string, int>();
for (int i = 0; i < sentences.Length; i++)
{
    foreach (var word in sentences[i].Split(" "))
    {
        if (WordsAndCounts.ContainsKey(word))
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