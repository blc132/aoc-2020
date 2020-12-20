using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace day7
{
    public class Bag
    {
        public Bag(string color)
        {
            Color = color;
            Content = new List<Bag>();
            Content2 = new Dictionary<Bag, int>();
        }

        public string Color { get; set; }
        public List<Bag> Content { get; set; }
        public Dictionary<Bag, int> Content2 { get; set; }
        public bool NoOtherBags { get; set; }
    }
}
