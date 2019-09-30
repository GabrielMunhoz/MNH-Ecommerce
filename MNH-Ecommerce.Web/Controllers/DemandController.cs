using Microsoft.AspNetCore.Mvc;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNH_Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    public class DemandController : Controller
    {
        private readonly IDemandRepository _DemandRepository;

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_DemandRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult Post([FromBody] Demand demand)
        {
            try
            {

                return Ok(demand);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

    }
}
