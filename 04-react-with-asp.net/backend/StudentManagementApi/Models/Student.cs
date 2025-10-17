namespace StudentManagementApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
    }
}