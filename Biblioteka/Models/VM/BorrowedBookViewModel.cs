namespace Biblioteka.Models.VM
{
    public class BorrowedBookViewModel
    {
        public string User { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public int CopieNumber { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
