using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SlidEagle.Models
{
    public class Item
    {
        [HiddenInput]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RideStyle { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

    }
}
