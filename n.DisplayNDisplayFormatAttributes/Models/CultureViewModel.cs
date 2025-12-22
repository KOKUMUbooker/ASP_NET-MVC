using Microsoft.AspNetCore.Mvc.Rendering;

namespace n.DisplayNDisplayFormatAttributes.Models;

public class CultureViewModel
{
    public string SelectedCulture { get; set; }
    public List<SelectListItem> Cultures { get; set; }
}