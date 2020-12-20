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
        }

        public string Color { get; set; }
        public List<Bag> Content { get; set; }
        public bool NoOtherBags { get; set; }
    }
}
