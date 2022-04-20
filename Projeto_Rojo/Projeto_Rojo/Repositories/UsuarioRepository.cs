using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Projeto_Rojo.Contexts;
using Projeto_Rojo.Domains;
using Projeto_Rojo.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RojoContext ctx = new RojoContext();     

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public string ConsultarPerfilBD(int id_usuario)
        {
            ImgUsuario ImgUsuario = new ImgUsuario();

            ImgUsuario = ctx.ImgUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if (ImgUsuario != null)
            {
                return Convert.ToBase64String(ImgUsuario.Binario);
            }

            return null;
        }

        public void SalvarPerfilBD(IFormFile foto, int id_usuario)
        {
            
            ImgUsuario ImgUsuario = new ImgUsuario();

            using (var ms = new MemoryStream())
            {
               
                foto.CopyTo(ms) ;
               
                ImgUsuario.Binario = ms.ToArray();
               
                ImgUsuario.NomeArquivo = foto.FileName;
               
                ImgUsuario.MimeType = foto.FileName.Split('.').Last();
             
                ImgUsuario.IdUsuario = id_usuario;
            }

            
            ImgUsuario fotoexistente = new ImgUsuario();
            fotoexistente = ctx.ImgUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if (fotoexistente != null)
            {
                fotoexistente.Binario = ImgUsuario.Binario;
                fotoexistente.NomeArquivo = ImgUsuario.NomeArquivo;
                fotoexistente.MimeType = ImgUsuario.MimeType;
                fotoexistente.IdUsuario = id_usuario;

              
                ctx.ImgUsuarios.Update(fotoexistente);
            }
            else
            { 
                ctx.ImgUsuarios.Add(ImgUsuario);
            }

           
            ctx.SaveChanges();
        }

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {

           
            string nome_novo = id_usuario.ToString() + ".png";

           
            using (var stream = new FileStream(Path.Combine("perfil", nome_novo), FileMode.Create))
            {
               
                foto.CopyTo(stream);
            }
        }


        public string ConsultarPerfilDir(int id_usuario)
        {
            string nome_novo = id_usuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

           
            if (File.Exists(caminho))
            {
             
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
              
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;

        }
         
        public void Atualizar(int id, Usuario a)
        {
            Usuario b = ctx.Usuarios.FirstOrDefault(a => a.IdUsuario == id);

            b.IdTipoUsuario = a.IdTipoUsuario;
            b.Email = a.Email;
            b.Senha = a.Senha;
            b.Contato = a.Contato;
            b.Nome = a.Nome;
            b.Cargo = a.Cargo;
            b.RazaoSocial = a.RazaoSocial;

            ctx.Entry(b).State = EntityState.Modified;

            ctx.SaveChanges();
            
        }



        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }


        public Usuario Cadastrar(Usuario a)
        {

                ctx.Usuarios.Add(a);

                ctx.SaveChanges();

                return a;
           
        }


        public void Deletar(int id)
        {
            var u = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            ctx.Usuarios.Remove(u);

            ctx.SaveChanges();

        }


        public IEnumerable<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
