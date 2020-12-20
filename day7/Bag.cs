using System.Collections.Generic;

namespace day7
{
    public class Bag
    {
        public Bag(string color)
        {
            Color = color;
            Content = new Dictionary<Bag, int>();
        }

        public string Color { get; set; }
        public Dictionary<Bag, int> Content { get; set; }
        public bool NoOtherBags { get; set; }
    }
}
