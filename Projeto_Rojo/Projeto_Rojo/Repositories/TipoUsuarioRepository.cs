using Microsoft.EntityFrameworkCore;
using Projeto_Rojo.Contexts;
using Projeto_Rojo.Domains;
using Projeto_Rojo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rojo.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository  
    {
        RojoContext ctx = new RojoContext();

       // private readonly RojoContext ctx;

       // public TipoUsuarioRepository(RojoContext rojoContext)
       // {
       //     ctx = rojoContext;
       // }
 
        public void Atualizar(int id, TipoUsuario a )
        {
            TipoUsuario b = ctx.TipoUsuarios.FirstOrDefault(a => a.IdTipoUsuario == id);

            if(a.Usuario != null)
            {
                b.Usuario = a.Usuario;
            }

            ctx.Update(b);

            ctx.SaveChanges();
            
        }



        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }


        public TipoUsuario Cadastrar(TipoUsuario a)
        {
           
                ctx.TipoUsuarios.Add(a);

                ctx.SaveChanges();

                return a;
   
        }


        public void Deletar(int id)
        {
            var b = ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == id);

            ctx.TipoUsuarios.Remove(b);

            ctx.SaveChanges();

        }


        public IEnumerable<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
