namespace SlidEagle.Models
{
    public class RideStyle
    {
        public RideStyle()
        {
            Items = new HashSet<Item>();
        }
        public int RideStyleId { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
