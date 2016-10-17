namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    public class Store: Shop<Bazaar>
    {
        private const long MaxCapacity = 15;

        public Store(Bazaar successor)
            : base(successor, MaxCapacity)
        {

        }
    }
}
