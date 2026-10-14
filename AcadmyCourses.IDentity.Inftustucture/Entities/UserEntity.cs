using AcadmyCourses.IDentity.Domain.UserGroup;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcadmyCourses.IDentity.Inftustucture.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public bool isActive { get; set; } = true;
        public Guid UserGroupId { get; set; }
        [ForeignKey(nameof(UserGroupId))]
        public UserGroup UserGroupNavigational { get; set; }
    } 
}
