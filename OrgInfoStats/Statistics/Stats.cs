using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    public class Stats
    {
        /*
         Нет потребности ограничивать доступ к данным полям, т.к. статистика используется сугубо в личных целях и она нигде не хранится
         */
        public Stats()
        {
            High = Decimal.MinValue;
            Low = Decimal.MaxValue;
            Sum = 0.0m;
            CountActivities = 0;
        }

        // Средняя цена
        public decimal Average
        {
            get => Sum / CountActivities;
        }

        // Минимальная цена
        public decimal Low;

        // Максимальная цена
        public decimal High;

        // Кол-во активностей
        public int CountActivities;

        public decimal Sum;

        public void Add(decimal price)
        {
            Sum += price;
            High = Math.Max(High, price);
            Low = Math.Min(Low, price);
            CountActivities += 1;
        }

        
        
    }
}
