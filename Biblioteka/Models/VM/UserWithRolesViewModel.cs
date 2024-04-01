namespace Biblioteka.Models.VM
{
    public class UserWithRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
    }
}
