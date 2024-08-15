class FileReader 
{    
    public List<string> ReadText(string path)
    {
        return File.ReadAllLines(path).ToList();
    }
}