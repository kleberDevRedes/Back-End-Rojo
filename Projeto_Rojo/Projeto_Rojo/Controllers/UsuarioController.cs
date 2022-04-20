using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Rojo.Contexts;
using Projeto_Rojo.Domains;
using Projeto_Rojo.Interfaces;
using Projeto_Rojo.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        public class UsuarioController : ControllerBase
        {

            private IUsuarioRepository usuarioRepository { get; set; }

            public UsuarioController()
            {
                usuarioRepository = new UsuarioRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    return Ok(usuarioRepository.Listar());
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [HttpGet("usuario/{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(idUsuario);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [HttpPost("cadastro-usuario")]
            public IActionResult Post(Usuario novoUsuario)
            {
                try
                {
                    usuarioRepository.Cadastrar(novoUsuario);

                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            [HttpPut("atualizar/{id}")]
            public IActionResult Put(int id, Usuario usuarioAtualizado)
            {
                try
                {

                    usuarioRepository.Atualizar( id, usuarioAtualizado);

                    return StatusCode(204);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {

                    usuarioRepository.Deletar(id);

    
                    return StatusCode(204);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
    }

