namespace Biblioteka.Models.VM
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public List<Review> Reviews { get; set; }
        public string UserId { get; set; }
    }
}
