using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteka.Models.VM
{
    public class RoleManagmentViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList {get; set;}        
    }
}
