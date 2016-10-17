namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    public class Bazaar : Shop<Mall>
    {
        private const long MaxCapacity = 30;

        public Bazaar(Mall successor)
            : base(successor, MaxCapacity)
        {
        }
    }
}
