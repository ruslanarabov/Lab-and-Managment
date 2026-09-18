using StudentCRUD.Entity;

namespace StudentCRUD.Services;

public class StudentService
{
    private const string FilePath = "students.txt";

    private readonly GroupService _groupService;

    public StudentService(GroupService groupService)
    {
        _groupService = groupService;

        if (!File.Exists(FilePath))
        {
            File.Create(FilePath).Close();
        }
    }

    private List<Student> LoadStudentsFromFile()
    {
        var students = new List<Student>();

        if (!File.Exists(FilePath))
            return students;

        var lines = File.ReadAllLines(FilePath);

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split('|');

            if (parts.Length != 4)
                continue;

            if (!int.TryParse(parts[0], out int id))
                continue;

            if (!double.TryParse(parts[2], out double gpa))
                continue;

            if (!int.TryParse(parts[3], out int groupId))
                continue;

            students.Add(new Student
            {
                Id = id,
                FullName = parts[1],
                GPA = gpa,
                GroupId = groupId
            });
        }

        return students;
    }

    private void SaveStudentsToFile(List<Student> students)
    {
        File.WriteAllLines(
            FilePath,
            students.Select(s => s.ToString())
        );
    }

    public bool AddStudent(string fullName, double gpa, int groupId)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return false;

        if (gpa < 0 || gpa > 4)
        {
            Console.WriteLine("GPA must be between 0 and 4.");
            return false;
        }

        var group = _groupService.GetGroupById(groupId);

        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return false;
        }

        var students = LoadStudentsFromFile();

        int newId = students.Count == 0
            ? 1
            : students.Max(s => s.Id) + 1;

        var student = new Student
        {
            Id = newId,
            FullName = fullName.Trim(),
            GPA = gpa,
            GroupId = groupId
        };

        students.Add(student);

        SaveStudentsToFile(students);

        return true;
    }

    public List<Student> GetAllStudents()
    {
        return LoadStudentsFromFile();
    }

    public Student? GetStudentById(int id)
    {
        var students = LoadStudentsFromFile();

        return students.FirstOrDefault(s => s.Id == id);
    }

    public bool UpdateStudent(
        int studentId,
        string fullName,
        double gpa,
        int groupId)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return false;

        if (gpa < 0 || gpa > 4)
        {
            Console.WriteLine("GPA must be between 0 and 4.");
            return false;
        }

        var group = _groupService.GetGroupById(groupId);

        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return false;
        }

        var students = LoadStudentsFromFile();

        var student = students.FirstOrDefault(s => s.Id == studentId);

        if (student == null)
            return false;

        student.FullName = fullName.Trim();
        student.GPA = gpa;
        student.GroupId = groupId;

        SaveStudentsToFile(students);

        return true;
    }

    public bool DeleteStudent(int id)
    {
        var students = LoadStudentsFromFile();

        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return false;

        students.Remove(student);

        SaveStudentsToFile(students);

        return true;
    }

    public List<Student> GetStudentsByGroup(int groupId)
    {
        var group = _groupService.GetGroupById(groupId);

        if (group == null)
        {
            Console.WriteLine("Group not found.");
            return new List<Student>();
        }

        var students = LoadStudentsFromFile();

        return students
            .Where(s => s.GroupId == groupId)
            .ToList();
    }

    public string GetGroupName(int groupId)
    {
        var group = _groupService.GetGroupById(groupId);

        return group?.Name ?? "Unknown";
    }
}