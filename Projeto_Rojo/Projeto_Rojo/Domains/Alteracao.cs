using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Rojo.Domains
{
    public partial class Alteracao
    {
        public int IdAlteracao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int? IdEquipamento { get; set; }

        public virtual Equipamento IdEquipamentoNavigation { get; set; }
    }
}
