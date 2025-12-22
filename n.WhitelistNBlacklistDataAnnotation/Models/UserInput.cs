using n.WhitelistNBlacklistDataAnnotation.ValidationModels;

namespace n.WhitelistNBlacklistDataAnnotation.Models;

public class UserInput
{
    public int Id { get; set; }

    [Whitelist(AllowedValues = new string[] { "Admin", "User", "Guest" })]
    public string Role { get; set; }

    [Blacklist(DisallowedValues = new string[] { "example.com", "test.com" })]
    public string EmailDomain { get; set; }
}