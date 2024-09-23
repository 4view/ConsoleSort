using ConsoleSort.Sorting;

namespace ConsoleSort.Sorting;

class SortFactory
{
    public IEmployeeSorter CreateSorter(SortBy? sortBy)
    {
        switch (sortBy)
        {
            case SortBy.FIO:
                return new NameEmployeeSorter();
            case SortBy.Age:
                return new AgeEmployeeSorter();
            case SortBy.Language:
                return new LanguageEmployeeSorter();
            case SortBy.Position:
                return new PositionEmployeeSorter();
            default:
                throw new InvalidOperationException("There no sorter u choose");
        }
    }
}