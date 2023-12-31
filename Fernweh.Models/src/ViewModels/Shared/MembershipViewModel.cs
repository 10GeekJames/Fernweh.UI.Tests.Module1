namespace Fernweh.Models.ViewModels;
public class MembershipViewModel : BaseViewModelTracked
{
    public Guid MembershipCardNumber { get; set; }
    public string MembershipTitle { get; set; } = string.Empty;
    public DateTime MemberSince { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public List<MemberInMembershipViewModel> MemberInMemberships { get; set; } = new();

}
