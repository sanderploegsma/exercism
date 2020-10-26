using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly IDictionary<string, int> _studentsToGrades;

    public GradeSchool() 
    {
        _studentsToGrades = new Dictionary<string, int>();
    }

    public void Add(string student, int grade)
    {
        _studentsToGrades[student] = grade;
    }

    public IEnumerable<string> Roster()
    {
        return _studentsToGrades
            .Select(kv => kv.Value)
            .OrderBy(grade => grade)
            .Distinct()
            .SelectMany(Grade);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return _studentsToGrades
            .Where(kv => kv.Value == grade)
            .Select(kv => kv.Key)
            .OrderBy(student => student);
    }
}