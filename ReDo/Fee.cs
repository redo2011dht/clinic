namespace ReDo
{
    public class Fee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }      
        public int sum
        {
            get
            {
                return price*quantity;
            }

            set
            {
                _sum = value;
            }
        }

        private double _sum;
        public string usage { get; set; }

    }
}
