using Microsoft.AspNetCore.Mvc.Rendering;
using m.MBFromQueryAttribute.Models;

namespace m.MBFromQueryAttribute.ViewModels;

public class ProductListViewModel
{
    public required IEnumerable<Product> Products { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public required string SearchTerm { get; set; }
    public required string Category { get; set; }
    public required string SortBy { get; set; }
    public bool SortAscending { get; set; }
    public required IEnumerable<SelectListItem> Categories { get; set; }
    public required IEnumerable<SelectListItem> SortOptions { get; set; }
    public required IEnumerable<SelectListItem> PageSizeOptions { get; set; } // Add this property
}