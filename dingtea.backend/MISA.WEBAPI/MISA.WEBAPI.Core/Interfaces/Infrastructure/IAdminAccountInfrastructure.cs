using System;
using System.Collections.Generic;
using MISA.WEBAPI.Core.Entities;

namespace MISA.WEBAPI.Core.Interfaces.Infrastructure
{
    public interface IAdminAccountInfrastructure : IBaseInfrastructure<AdminAccount>
    {
        public IEnumerable<AdminAccount> login(AdminAccount account);
    }
}
