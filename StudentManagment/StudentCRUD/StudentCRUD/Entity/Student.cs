namespace StudentCRUD.Entity;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public double GPA { get; set; }
    public int GroupId { get; set; }
    
    public override string ToString()
    {
        return $"{Id}|{FullName}|{GPA}|{GroupId}";
    }
}