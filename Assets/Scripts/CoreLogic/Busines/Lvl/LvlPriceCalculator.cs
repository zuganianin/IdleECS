namespace CoreLogic.Business
{
    public class LvlPriceCalculator 
    {
        public int IncomeForParamets(Lvl lvl, IncomeConfig conf)
        {
            // Доход = lvl * базовый_доход * (1 + множитель_от_улучшения_1 + множитель_от_улучшения_2)

            return lvl.current * conf.baseIncome;
        }

        public int PriceForLevel(Lvl lvl)
        {
            return PriceForLevel(lvl.current, lvl.basePrice);
        }
        public int PriceForLevel(int lvl, int basePrice)
        {
            return (lvl + 1) * basePrice;
        }
    }
}
