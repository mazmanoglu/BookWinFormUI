namespace BusinessObject
{
    public class DtoBook //:Book da diyebiliriz. boylece book property'lerini yazmak zorunda kalmayiz ama burada yapmadik.
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Country CountryId { get; set; }

        public override string ToString()
        {
            return $"{ID} {Title} {Author} {Price} {CountryId}";
        }
    }
}
