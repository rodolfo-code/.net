namespace Balta.ContentContext
{

    public class Career : Content
    {
        public Career()
        {
            Items = new List<CareerItem>();
        }
        public IList<CareerItem> Items { get; set; }

        public int TotalCourses
        {
            get
            {
                return Items.Count;
            }
        }
    }
}