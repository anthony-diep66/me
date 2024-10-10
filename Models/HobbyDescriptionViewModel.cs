using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Me.Models;

public class HobbyDescriptionViewModel
{
    public List<Hobby>? Hobbies { get; set; }
    public SelectList? WordInDescriptions { get; set; }
    public string? HobbyDescription { get; set; }
    public string? SearchString { get; set; }
}

