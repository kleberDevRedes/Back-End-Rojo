using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto_Rojo.Domains;
using Projeto_Rojo.Interfaces;
using Projeto_Rojo.Repositories;
using Projeto_Rojo.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto_Rojo.Controllers
{
    [Produces("application/json")]


    [Route("api/[controller]")]


    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login (LoginViewModel login)
        {
            
            try
            {
                Usuario b = _usuarioRepository.Login(login.Email, login.Senha);

                if (b == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                        var minhasClaims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Email, b.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, b.IdUsuario.ToString()),
                            new Claim(ClaimTypes.Role, b.IdTipoUsuario.ToString()),
                            new Claim("role", b.IdTipoUsuario.ToString()),
                            new Claim("nome", b.Nome),
                            new Claim("cargo", b.Cargo)
                        };

                        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("rojo-chave-seguranca-amais"));

                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var meuToken = new JwtSecurityToken(
                                issuer: "RojoEmpresa.webAPI",
                                audience: "RojoEmpresa.webAPI",
                                claims: minhasClaims,
                                expires: DateTime.Now.AddHours(2),
                                signingCredentials: creds
                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(meuToken)

                        });


                } 


            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
            
 }

