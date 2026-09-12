namespace StudentCRUD.Entity;

public class Group
{
    private static int _id = 1;
    public int Id { get; set; }
    public string Name { get; set; }

    public Group()
    {
        Id = ++_id;
    }

    public override string ToString()
    {
        return $"{Id}|{Name}";
    }
    
}