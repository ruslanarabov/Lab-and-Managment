namespace StudentCRUD.Entity;

public class Student
{
    private static int _id = 1;
    public int Id { get; set; }
    public string FullName { get; set; }
    public float GPA { get; set; }
    public int GroupId { get; set; }

    public Student()
    {
        Id = _id++;
    }
    
}