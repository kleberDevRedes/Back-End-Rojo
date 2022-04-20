using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    
        public class ImgUsuarioController : ControllerBase
        {
            private IUsuarioRepository _usuarioRepository { get; set; }

            public ImgUsuarioController() 
            {
                _usuarioRepository = new UsuarioRepository();
            }

            [HttpPost("imagem/bd")]
            public IActionResult postBD(IFormFile arquivo)
            {
                try
                {
            
                    if (arquivo.Length > 5000000) 
                        return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                //string extensao = arquivo.FileName.Split('.').Last();

                //if (extensao != "png")
                //return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos." });


                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                    _usuarioRepository.SalvarPerfilBD(arquivo, idUsuario);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }




            }

      
            [HttpGet("imagem/bd")]
            public IActionResult getbd()
            {
                try
                {

                    int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                    string base64 = _usuarioRepository.ConsultarPerfilBD(idUsuario);

                    return Ok(base64);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            
            [HttpPost("imagem/dir")]
            public IActionResult postDIR(IFormFile arquivo)
            {
                try
                {
                    //analise de tamanho do arquivo.
                    if (arquivo.Length > 5000) //5MB
                        return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                    string extensao = arquivo.FileName.Split('.').Last();

                    if (extensao != "png")
                        return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos." });


                    int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                    _usuarioRepository.SalvarPerfilDir(arquivo, idUsuario);

                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }


            
            [HttpGet("imagem/dir")]
            public IActionResult getDIR()
            {
                try
                {

                    int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                    string base64 = _usuarioRepository.ConsultarPerfilDir(idUsuario);

                    return Ok(base64);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


        }
    }
