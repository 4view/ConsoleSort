using ConsoleSort.Model;

namespace ConsoleSort.Sorting;

class SortContext
{
    public List<Employee> SortUsing(IEmployeeSorter strategy, List<Employee> emplList, string searchQuery)
    {
        return strategy.Sort(emplList, searchQuery);
    }
}