using System;
using System.Collections.Generic;
using MISA.WEBAPI.Core.Entities;

namespace MISA.WEBAPI.Core.Interfaces.Infrastructure
{
    public interface IAccountInfrastructure:IBaseInfrastructure<UserAccount>
    {
        public IEnumerable<UserAccount> login(UserAccount account);
        public UserAccount GetEntityByCode(string userCode);
        public int ChangePass(Guid id, string newPass);
    }
}
