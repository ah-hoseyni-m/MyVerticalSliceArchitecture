namespace MyVerticalSliceArchitecture.Entities;

public class UserRelations : BaseEntity<Int64>
{
    public Int64 UserId { get; set; }
    public Int64 FollowUserId { get; set; }
    public User User { get; set; }
    //public User UserFollow { get; set; }


}
