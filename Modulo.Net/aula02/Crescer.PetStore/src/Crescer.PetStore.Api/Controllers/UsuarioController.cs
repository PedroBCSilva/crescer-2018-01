using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Crescer.PetStore.Api.Model;
using Crescer.PetStore.Api.Model.Enum;

namespace Crescer.PetStore.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        public static List<Usuario> listaDeUsuarios = new List<Usuario>();

        private static int id=1;

        // GET usuario/values
        [HttpGet]
        public List<Usuario> Get()
        {
            return listaDeUsuarios;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Usuario newUser)
        {
            var procuraUser = listaDeUsuarios.FirstOrDefault(user=>user.Login==newUser.Login);
            if(procuraUser==null){
                newUser.Id=id++;
                listaDeUsuarios.Add(newUser);
                return Ok(newUser);
            }

            return BadRequest("Login em uso");
        }

        [HttpGet("{login}")]

        public ActionResult GetUsarioPeloId(string login)
        {
            var procuraUser = listaDeUsuarios.FirstOrDefault(user=>user.Login==login);
            if(procuraUser==null){
                return NotFound("Usuario não encontrado");
            }

            return Ok(procuraUser);
        }

        [HttpPut("{login}")]

        public ActionResult PutAtualizaUsuario(string login, [FromBody]string nomeCompleto){
            var procuraUser = listaDeUsuarios.FirstOrDefault(user=>user.Login==login);
            if(procuraUser==null){
                return NotFound("Usuario não encontrado");
            }

            procuraUser.PrimeiroNome=nomeCompleto.Split(" ")[0];
            procuraUser.UltimoNome=nomeCompleto.Split(" ")[1];

            return Ok(procuraUser);
        }

        [HttpDelete("{login}")]
        public ActionResult DeleteUsarioPeloLogin(string login){
            var procuraUser = listaDeUsuarios.FirstOrDefault(user=>user.Login==login);
            if(procuraUser==null){
                return NotFound("Usuario não encontrado");
            }

            listaDeUsuarios.Remove(procuraUser);

            return Ok("Usuario removido");
        }
    }
}