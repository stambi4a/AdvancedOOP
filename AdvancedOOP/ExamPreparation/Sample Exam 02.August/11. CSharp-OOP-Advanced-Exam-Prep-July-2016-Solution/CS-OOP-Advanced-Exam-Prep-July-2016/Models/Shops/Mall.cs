namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    public class Mall : Shop<Mall>
    {
        public Mall()
            : base(null, long.MaxValue)
        {
        }
    }
}
