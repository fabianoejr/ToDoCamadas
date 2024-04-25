using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirHistoricoDTO
    {
        public enum OperacaoEnum
        {
            Criado = 1,
            Editado = 2,
            Inativo = 0
        }
        public int IdUsuario { get; set; }

        public int IdTarefa { get; set; }

        public OperacaoEnum Operacao { get; set; }

    }
}
