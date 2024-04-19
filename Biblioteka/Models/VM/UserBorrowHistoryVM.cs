namespace Biblioteka.Models.VM
{
    public class UserBorrowHistoryVM
    {
        public List<Book> Books { get; set; }
        public List<BorrowHistory> BorrowHistories { get; set; }
    }
}
