namespace MyVerticalSliceArchitecture.Entities;

public class UserRelations : BaseEntity<Int64>
{
    public Int64 UserId { get; set; }
    public Int64 FollowUserId { get; set; }
    public virtual User User { get; set; }
    public virtual User User2 { get; set; }


}
