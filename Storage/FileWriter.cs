using ConsoleSort.Model;

namespace ConsoleSort.Storage;

class FileWriter
{
    public void WriteEmployees(string path, List<Employee> employees)
    {
        List<string> outContent = new List<string>();

        foreach (Employee empl in employees)
        {
            outContent.Add(empl.ToString());
        }     

        File.WriteAllLines(path, outContent);
    }
}