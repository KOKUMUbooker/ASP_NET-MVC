using System.ComponentModel.DataAnnotations;
using n.WhitelistNBlacklistDataAnnotation.ValidationModels;

namespace n.WhitelistNBlacklistDataAnnotation.Models;

public class BlogComment
{
    [Required]
    [EmailAddress]
    public string UserEmail { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [OffensiveWordBlacklist(DisallowedWords = new string[] { "offensive1", "offensive2", "offensive3", "Sigma", "67", "One Piece is real" })]
    public string CommentText { get; set; }
}