using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WEBAPI.API.Controllers
{


    //[Route("api/v1/[controller]")]
    public class ManufacturesController : MISABaseController<Manufacture>
    {
        
        /// <summary>
        /// Controller Department
        /// created by NgoDinhThang(18/01/2022)
        /// </summary>
        ///

        //khoi tao chuc nang thong qua interface
        public ManufacturesController(IBaseService<Manufacture> baseService, IBaseInfrastructure<Manufacture> baseInfrastructure) : base(baseService, baseInfrastructure)
        {
        }

        


    }
}
