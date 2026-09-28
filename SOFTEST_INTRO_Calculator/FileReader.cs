using System.IO;

namespace SOFTEST_INTRO_Calculator;

// Add the ": IFileReader" part here!
public class FileReader : IFileReader 
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}