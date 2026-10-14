using AcadmyCourses.IDentity.Domain.UserGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Specification
{
    public class UserGroupSpecefication : BaseSpecification<UserGroup>
    {
        public UserGroupSpecefication(Guid id)
            : base(p => p.Id == id)
        {
            AddInclude(p => p.Users);
        }
    }
}
