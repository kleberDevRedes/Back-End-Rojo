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
    public class TipoEquipamentoRepository : ITipoEquipamentoRepository
    {
        RojoContext ctx = new RojoContext();


        public void Atualizar(int id, TipoEquipamento novo)
        {
            TipoEquipamento b = ctx.TipoEquipamentos.FirstOrDefault(e => e.IdTipoEquipamento == id);

            if (b.Equipamento != null)
            {
                b.Equipamento = novo.Equipamento;
            }

          

            ctx.Entry(b).State = EntityState.Modified;

            ctx.SaveChanges();
            
        }



        public TipoEquipamento BuscarPorId(int id)
        {
            return ctx.TipoEquipamentos.FirstOrDefault(e => e.IdTipoEquipamento == id);
        }


        public TipoEquipamento Cadastrar(TipoEquipamento a)
        {
      
                ctx.TipoEquipamentos.Add(a);

                ctx.SaveChanges();

                return a;

        }


        public void Deletar(int id)
        {
            var b = ctx.TipoEquipamentos.FirstOrDefault(e => e.IdTipoEquipamento == id);

            ctx.TipoEquipamentos.Remove(b);

            ctx.SaveChanges();

        }


        public IEnumerable<TipoEquipamento> Listar()
        {
            return ctx.TipoEquipamentos.Select(e => new TipoEquipamento
            {
                IdTipoEquipamento = e.IdTipoEquipamento,
                Equipamento = e.Equipamento,
            })
                .ToList();
        }
    }
}
