using StudentCRUD.Entity;

namespace StudentCRUD.Services;

public class GroupService
{
    private const string FilePath = "groups.txt";

    public GroupService()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath).Close();
        }
    }

    private List<Group> LoadGroupsFromFile()
    {
        var groups = new List<Group>();

        if (!File.Exists(FilePath))
            return groups;

        var lines = File.ReadAllLines(FilePath);

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split('|');

            if (parts.Length != 2)
                continue;

            if (!int.TryParse(parts[0], out int id))
                continue;

            groups.Add(new Group
            {
                Id = id,
                Name = parts[1]
            });
        }

        return groups;
    }

    private void SaveGroupsToFile(List<Group> groups)
    {
        File.WriteAllLines(
            FilePath,
            groups.Select(g => g.ToString())
        );
    }

    public Group? GetGroupById(int groupId)
    {
        var groups = LoadGroupsFromFile();

        return groups.FirstOrDefault(g => g.Id == groupId);
    }

    public bool AddGroup(string groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
            return false;

        var groups = LoadGroupsFromFile();

        groupName = groupName.Trim();

        bool exists = groups.Any(g =>
            g.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase));

        if (exists)
            return false;

        int newId = groups.Count == 0
            ? 1
            : groups.Max(g => g.Id) + 1;

        var group = new Group
        {
            Id = newId,
            Name = groupName
        };

        groups.Add(group);

        SaveGroupsToFile(groups);

        return true;
    }

    public List<Group> GetAllGroups()
    {
        return LoadGroupsFromFile();
    }

    public bool UpdateGroup(int groupId, string groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
            return false;

        var groups = LoadGroupsFromFile();

        var group = groups.FirstOrDefault(g => g.Id == groupId);

        if (group == null)
            return false;

        group.Name = groupName.Trim();

        SaveGroupsToFile(groups);

        return true;
    }

    public bool DeleteGroup(int groupId, StudentService studentService)
    {
        var groups = LoadGroupsFromFile();

        var group = groups.FirstOrDefault(g => g.Id == groupId);

        if (group == null)
            return false;

        bool hasStudents = studentService
            .GetAllStudents()
            .Any(s => s.GroupId == groupId);

        if (hasStudents)
        {
            Console.WriteLine("Group cannot be deleted because it has students.");
            return false;
        }

        groups.Remove(group);

        SaveGroupsToFile(groups);

        return true;
    }
}