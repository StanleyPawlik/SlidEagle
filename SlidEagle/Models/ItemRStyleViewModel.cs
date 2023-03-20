using Microsoft.AspNetCore.Mvc.Rendering;

namespace SlidEagle.Models
{
    public class ItemRStyleViewModel
    {
        public Item Item { get; set; }
        public SelectList? RideStyles { get; set; }

    }
}
