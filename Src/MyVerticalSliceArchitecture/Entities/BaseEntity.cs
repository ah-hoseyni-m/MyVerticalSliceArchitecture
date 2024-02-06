//using System.Security.Principal;
namespace MyVerticalSliceArchitecture.Entities;

public abstract class BaseEntity<Tkey>
{
    public Tkey Id { get; set; }
    public DateTime CreateAt { get; set; }
}
public abstract class BaseEntity : BaseEntity<int>
{
}