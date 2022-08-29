using Microsoft.AspNetCore.Identity;

namespace WorkOrganizationPanel.Database.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
