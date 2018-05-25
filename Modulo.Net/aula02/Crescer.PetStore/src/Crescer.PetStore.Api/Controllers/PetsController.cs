﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crescer.PetStore.Api.Model;

namespace Crescer.PetStore.Api.Controllers
{
    [Route("api/[controller]")] //mesma coisa que [Route("api/pets")]
    public class PetsController : Controller
    {

        public static List<Pet> listaDePets = new List<Pet>();

        private static int id = 1;

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get([FromQuery]string filtro)
        {
            return new string[] { "value1", "value2", filtro };
        }

        // GET api/values/5 pegar dado na rota
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var petEncontrado = listaDePets.FirstOrDefault(pet => pet.Id == id);

            if (petEncontrado == null)
            {
                return NotFound("Não existe pet com esse id");
            }

            return Ok(petEncontrado);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Pet pet)
        {
            if (pet.Categoria == null)
            {
                return BadRequest("Categoria é obrigatoria");
            }

            pet.Id = id++;
            listaDePets.Add(pet);

            return Ok(pet);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var petEncontrado = listaDePets.FirstOrDefault(pet => pet.Id == id);

            if (petEncontrado == null)
            {
                return NotFound("Pet a ser removido não foi encontrado");
            }

            listaDePets.Remove(petEncontrado);

            return Ok("Pet removido");
        }

        [HttpGet("{id}/tags")]
        public ActionResult GetTagsDeUmPetPeloId(int id)
        {
            var petEncontrado = listaDePets.FirstOrDefault(pet => pet.Id == id);

            if (petEncontrado == null)
            {
                return NotFound("Pet não foi encontrado");
            }

            return Ok(petEncontrado.Tags);
        }

        [HttpGet("/tags")]
        public ActionResult GetTodasAsTags()
        {
            List<string> listaDeTags = new List<string>();

            foreach(Pet pet in listaDePets){
                foreach(string tag in pet.Tags){
                    listaDeTags.Add(tag);
                }
            }

            return Ok(listaDeTags);
        }

        [HttpPost("{id}/tags")]
        public ActionResult PostTagsDeUmPetPeloId(int id,[FromBody]string tag)
        {
            var petEncontrado = listaDePets.FirstOrDefault(pet => pet.Id == id);

            if (petEncontrado == null)
            {
                return NotFound("Pet não foi encontrado");
            }

            petEncontrado.Tags.Add(tag);

            return Ok("Tag adicionada");
        }
    }
}
