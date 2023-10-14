namespace Fernweh.Models.ViewModels;
public class MemberInMembershipViewModel : BaseViewModelTracked
{
    public MemberViewModel Member { get; set; } = new();
    public MembershipViewModel Membership { get; set; } = new();

}
