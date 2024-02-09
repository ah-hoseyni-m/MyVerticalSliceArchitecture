namespace MyVerticalSliceArchitecture.Entities;

public class User : BaseEntity<Int64>
{
    public string UserName { get; set; } 
    public string UserEmail { get; set; }
    public string UserPhone { get; set; }
    public string UserPassword { get; set; }
    public string UserEmailConfirmed { get; set; }
    public virtual ICollection<UserRelations> UserRelations { get; set; }
    public virtual ICollection<UserRelations> UserRelations2 { get; set; }



}
