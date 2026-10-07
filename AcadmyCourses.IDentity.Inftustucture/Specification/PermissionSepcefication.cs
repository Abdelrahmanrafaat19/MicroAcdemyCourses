using AcadmyCourses.IDentity.Inftustucture.Entities;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Specification
{
    public class PermissionSepcefication : BaseSpecification<Permission>
    {
        public PermissionSepcefication(string code)
            : base(p => p.Code == code)
        {
        }
    }
}
