using System;
using System.Collections.Generic;
using MISA.WEBAPI.Core.Entities;

namespace MISA.WEBAPI.Core.Interfaces.Infrastructure
{
    public interface IBillInfrastructure
    {
        public IEnumerable<Bill> getByCustomerId(Guid customerId);
    }
}
