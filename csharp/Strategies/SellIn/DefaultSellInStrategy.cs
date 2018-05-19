using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Strategies.SellIn.Interfaces;

namespace csharp.Strategies.SellIn
{
    public class DefaultSellInStrategy : ISellInStrategy
    {
        public void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
