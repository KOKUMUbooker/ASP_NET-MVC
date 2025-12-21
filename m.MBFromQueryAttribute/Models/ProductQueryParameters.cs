namespace m.MBFromQueryAttribute.Models;

public class ProductQueryParameters
{
    public required string SearchTerm { get; set; } 
    public required string Category { get; set; }
    public required string SortBy { get; set; }
    public bool SortAscending { get; set; } = true; //Default is True
    public int PageNumber { get; set; } = 1; //Default Page Number
    public int PageSize { get; set; } = 3; //Default Size
}