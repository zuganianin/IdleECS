namespace CoreLogic.Business
{
    public class LvlPriceCalculator 
    {
        public int IncomeForParamets(Lvl lvl, IncomeConfig conf, IncomeBust bust)
        {
            // Доход = lvl * базовый_доход * (1 + множитель_от_улучшения_1 + множитель_от_улучшения_2)

            return (int)(lvl.current * conf.baseIncome * (1.0 + bust.bust));
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
