namespace Web_API_and_EFcore.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string  FullName { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    
}