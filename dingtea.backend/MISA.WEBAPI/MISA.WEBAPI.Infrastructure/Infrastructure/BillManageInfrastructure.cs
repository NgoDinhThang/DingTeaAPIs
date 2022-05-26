using System;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;

namespace MISA.WEBAPI.Infrastructure.Infrastructure
{
    public class BillManageInfrastructure: BaseInfrastructure<BillManage>, IBillManage

    {
        public BillManageInfrastructure()
        {
        }

        public int Update(int state, Guid billId)
        {
            throw new NotImplementedException();
        }
    }
}
