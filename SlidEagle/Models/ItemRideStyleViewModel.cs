using Microsoft.AspNetCore.Mvc.Rendering;

namespace SlidEagle.Models
{
    public class ItemRideStyleViewModel
    {
        public List<Item>? Items { get; set; }
        public SelectList? RideStyles { get; set; }
        public string? ItemRideStyle { get; set; }
        public string? SearchString { get; set; }
    }
}
