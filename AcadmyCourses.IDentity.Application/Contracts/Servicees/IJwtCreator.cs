using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Contracts.Servicees
{
    public interface IJwtCreator
    {
        public string CreateToken(string? email, string userName,  string id, IList<string>? Roles, CancellationToken cancellationToken = default!);
    }
}
