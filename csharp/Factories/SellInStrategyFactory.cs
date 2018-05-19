using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Strategies.SellIn;
using csharp.Strategies.SellIn.Interfaces;

namespace csharp.Factories
{
    public class SellInStrategyFactory
    {
        public static ISellInStrategy Create(string itemName)
        {
            switch (itemName)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasSellInStrategy();
                default:
                    return new DefaultSellInStrategy();
            }
        }
    }
}
