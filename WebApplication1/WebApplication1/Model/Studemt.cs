
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Studemt
{
    public int StudentRegNo { get; set; }
    public string? StudentName { get; set; }
    public string? StudentEmail { get; set; }
    public string? StudentPhone { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
