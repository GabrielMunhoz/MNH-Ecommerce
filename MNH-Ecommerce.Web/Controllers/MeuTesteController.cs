using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MNH_Ecommerce.Web.Controllers
{
    public class MeuTesteController : Controller
    {
        [Route("api/[controller]")]
        [HttpGet("[action]")]
        public IEnumerable<User> Users()
        {
            return Enumerable.Range(1, 5).Select(index => new User
            {
                Nome = "Gabriel",
                Idade = 20,
                Apelido = ""
            });
            
        }
    }
    public class User
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Apelido { get; set; }
        public string Sexo { get; set; }
    }

}