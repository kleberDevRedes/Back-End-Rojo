using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Rojo.Domains
{
    public partial class ImgEquipamento
    {
        public int IdImagemEquipamento { get; set; }
        public int? IdEquipamento { get; set; }
        public byte[] Binario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public virtual Equipamento IdEquipamentoNavigation { get; set; }
    }
}
