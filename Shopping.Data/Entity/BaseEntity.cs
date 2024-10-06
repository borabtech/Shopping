using System.ComponentModel.DataAnnotations;

namespace Shopping.Data.Entity;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}