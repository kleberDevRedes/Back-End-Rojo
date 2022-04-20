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
    public class AlteracaoRepository : IAlteracaoRepository
    {
        RojoContext ctx = new RojoContext();

               
       
        public void Atualizar(int id, Alteracao a)
        {
            Alteracao b = ctx.Alteracaos.Find(id);
            
            if(a.IdEquipamento != null)
            {
                b.IdEquipamento = a.IdEquipamento;
            }

            if (a.Descricao != null)
            {
                b.Descricao = a.Descricao;
            }
            
            if(a.DataAlteracao >= DateTime.Today)
            {
                b.DataAlteracao = a.DataAlteracao;
            }

            ctx.Alteracaos.Update(b);

            ctx.SaveChanges();
            
        }

        public Alteracao BuscarPorId(int id)
        {
            return ctx.Alteracaos.FirstOrDefault(e => e.IdAlteracao == id);
        }


        public Alteracao Cadastrar(Alteracao a)
        {
            ctx.Alteracaos.Add(a);

            ctx.SaveChanges();

            return a;
     
        }


        public void Deletar(int id)
        {
            var a = ctx.Alteracaos.FirstOrDefault(a => a.IdAlteracao == id);

            ctx.Alteracaos.Remove(a);

            ctx.SaveChanges();

        }


        public IEnumerable<Alteracao> Listar()
        {
            return ctx.Alteracaos.ToList();
        }
    }
}
