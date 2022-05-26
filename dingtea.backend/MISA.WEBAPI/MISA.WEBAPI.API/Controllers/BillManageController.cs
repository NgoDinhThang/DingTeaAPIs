using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WEBAPI.API.Controllers
{
    public class BillManageController : MISABaseController<BillManage>
    {
        IBillManage _billInfrastructure;

        //khoi tao chuc nang thong qua interface
        public BillManageController(IBaseService<BillManage> baseService, IBaseInfrastructure<BillManage> baseInfrastructure, IBillManage _billInfrastructure) : base(baseService, baseInfrastructure)
        {
            this._billInfrastructure = _billInfrastructure;
        }
    }
}
