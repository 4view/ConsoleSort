using ConsoleSort.Model;

namespace ConsoleSort.Sorting;

public class LanguageEmployeeSorter : IEmployeeSorter
{
    public List<Employee> Sort(List<Employee> employees, string searchQuery) =>
        employees.Where(e => e.Language.Contains(searchQuery)).ToList();
}
