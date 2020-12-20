using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace day7
{
    class Program
    {
        public static string MyBagColor = "shiny gold";
        public static string BagsContain = "bags contain";
        public static string NoOtherBags = "no other bags";

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var bags = GetBags(lines);

            var myBag = bags.First(x => x.Color == MyBagColor);
            var bagsWhereIsMyBag = new List<Bag>();

            GetBagsWhereIsMyBagReq(myBag, bagsWhereIsMyBag, bags);
        }


        static void GetBagsWhereIsMyBagReq(Bag bag, List<Bag> bagsToSave, List<Bag> allBags)
        {
            foreach (var b in allBags)
            {

                if(b.Content2.ContainsKey(bag) && b.Color != MyBagColor)
                    GetBagsWhereIsMyBagReq(b, bagsToSave, allBags);
            }

            if(!bagsToSave.Exists(x => x.Color == bag.Color) && bag.Color != MyBagColor)
                bagsToSave.Add(bag);
        }

        static List<Bag> GetBags(string[] lines)
        {
            var bags = new List<Bag>();

            foreach (var line in lines)
            {
                //get index of "bags contain"
                var index = line.IndexOf(BagsContain);

                //get everything to left from "bags contain" - bag color
                var bagColor = line.Substring(0, index - 1);

                //get bag content - everything to right from "bags contain"
                var bagContent = line.Substring(index + BagsContain.Length + 1);

                //remove numbers and dots
                bagContent = new string(bagContent.Where(x => x != '.').ToArray());

                var bag = bags.FirstOrDefault(x => x.Color == bagColor);

                if (bag == null)
                {
                    bag = new Bag(bagColor);
                    bags.Add(bag);
                }

                if (bagContent.Contains(NoOtherBags))
                {
                    bag.NoOtherBags = true;
                    continue;
                }

                var bagContentList = bagContent.Split(",");

                foreach (var content in bagContentList)
                {
                    string word;
                    var bagIndex = content.IndexOf(" bags");
                    if (bagIndex == -1)
                    {
                        bagIndex = content.IndexOf(" bag");
                        word = " bag";
                    }
                    else
                    {
                        word = " bags";
                    }
                    string bagInsideBagColorWithNumber = (bagIndex < 0)
                        ? content.Trim()
                        : content.Remove(bagIndex, word.Length).Trim();

                    var bagInsideBagCount = int.Parse(bagInsideBagColorWithNumber[0].ToString());
                    var bagInsideBagColor = bagInsideBagColorWithNumber.Substring(2);

                    var bagInsideBag = bags.FirstOrDefault(x => x.Color == bagInsideBagColor);

                    if (bagInsideBag == null)
                    {
                        bagInsideBag = new Bag(bagInsideBagColor);
                        bags.Add(bagInsideBag);
                    }

                    bag.Content2.Add(bagInsideBag, bagInsideBagCount);
                }
            }

            bags = bags.OrderBy(x => x.Color).ToList();

            return bags;
        }
    }
}
