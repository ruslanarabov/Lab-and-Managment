using StudentCRUD.Entity;

namespace StudentCRUD.Services;

public class GroupService
{
    private List<Group> groups = new List<Group>();
    
    public Group? GetGroupById(int groupId)
    {
        foreach (Group group in groups)
        {
            if (group.Id == groupId)
            {
                return group;
            }
        }
        return null;
    }

    public bool AddGroup(string groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
            return false;

        bool exists = groups.Any(g => g.Name.Equals(groupName.Trim(), StringComparison.OrdinalIgnoreCase));
        if (exists)
            return false;

        groups.Add(new Group() { Name = groupName.Trim() });
        return true;
    }
    
    public List<Group> GetAllGroups()
    {
        return groups;
    }

    public bool UpdateGroup(int groupId, string groupName)
    {
        var group = GetGroupById(groupId);
        if (group == null) return false;

        group.Name = groupName.Trim();
        return true;
    }

    public bool DeleteGroup(int groupId)
    {
        var group = GetGroupById(groupId);
        if (group == null) return false;

        groups.Remove(group);
        return true;
    }
}