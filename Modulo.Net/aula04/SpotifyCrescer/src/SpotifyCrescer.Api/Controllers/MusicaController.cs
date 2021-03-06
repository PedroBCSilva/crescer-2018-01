using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyCrescer.Dominio.Model;
using SpotifyCrescer.Infra;
using SpotifyCrescer.Api.Models;
using SpotifyCrescer.Dominio.Service;
using SpotifyCrescer.Dominio.Contratos;

namespace SpotifyCrescer.Api.Controllers
{
    [Route("api/[controller]")]
    public class MusicaController : Controller
    {
        private IAlbumRepository database;

        private MusicaService musicaService;

        public MusicaController(IAlbumRepository albumRepository,MusicaService musicaService){
            database=albumRepository;
            this.musicaService = musicaService;
        }

        [HttpPost("{albumId}/musica")]
        public ActionResult PostNovoMusica(int albumId, [FromBody]MusicaRequestDTO musicaDTO)
        {
            var musica = new Musica(musicaDTO.Nome, musicaDTO.Duracao);
            var album = database.BuscaAlbumPorId(albumId);

            if (album == null)
            {
                return NotFound("Não existe album com esse id");
            }

            var inconsistencias = musicaService.VerificarInconsistencia(musica);
            if (inconsistencias.Count > 0)
            {
                return BadRequest(inconsistencias);
            }

            database.InsereMusicaEmAlbum(album.Id, musica);

            return Ok("Inseriu com sucesso");
        }

        [HttpGet("{albumId}/musica/{id}")]
        public ActionResult GetMusicaPeloId(int albumId, int id)
        {
            var album = database.BuscaAlbumPorId(albumId);
            if (album == null)
            {
                return NotFound("Não existe album com esse id");
            }

            var musica = database.BuscaMusicaPorId(albumId, id);
            if (musica == null)
            {
                return NotFound("Não existe musica com esse id");
            }
            return Ok(musica);
        }

        [HttpGet("{albumId}/musica")]
        public ActionResult GetMusicaDeUmAlbumPeloId(int albumId)
        {
            var album = database.BuscaAlbumPorId(albumId);
            if (album == null)
            {
                return NotFound("Não existe album com esse id");
            }
            return Ok(album.Musicas);
        }

        [HttpDelete("{albumId}/musica/{id}")]
        public ActionResult DeleteMusicaPeloId(int albumId, int id)
        {
            var album = database.BuscaAlbumPorId(albumId);
            if (album == null)
            {
                return NotFound("Não existe album com esse id");
            }

            var musica = database.BuscaMusicaPorId(albumId, id);
            if (musica == null)
            {
                return NotFound("Não existe musica com esse id");
            }
            database.RemoveMusicaPorId(albumId, id);

            return Ok("Musica Removida");
        }

        [HttpPut("{albumId}/musica/{id}")]
        public ActionResult AtualizaMusicaPeloId(int albumId, int id,[FromBody]MusicaRequestDTO musicaDTO)
        {
            var album = database.BuscaAlbumPorId(albumId);
            if (album == null)
            {
                return NotFound("Não existe album com esse id");
            }

            var musica = database.BuscaMusicaPorId(albumId, id);
            if (musica == null)
            {
                return NotFound("Não existe musica com esse id");
            }

            var musicaAtualizada = new Musica(musicaDTO.Nome,musicaDTO.Duracao);

            musicaAtualizada.Id=musica.Id;

            database.AtualizaMusica(musicaAtualizada,albumId);

            return Ok("Musica atualizada");
        }
    }
}