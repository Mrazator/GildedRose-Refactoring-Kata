﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.Strategies.Quality.Common;
using csharp.Strategies.Quality.Interfaces;

namespace csharp.Strategies.Quality
{
    public class AgedBrieQualityStrategy : CommonQualityStrategy, IQualityStrategy
    {
        public void UpdateQuality(Item item, bool sellByDateHasPassed = false)
        {
            IncreaseQualityBy(item, sellByDateHasPassed ? 2 : 1);
        }
    }
}
