namespace Entidades
{
    public class Historico
    {
        public enum OperacaoEnum
        {
            Criado = 1,
            Editado = 2,
            Inativo = 0,
            Deletada = 9
        }
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdTarefa { get; set; }

        public OperacaoEnum Operacao { get; set; }

        public DateTime DtRegistro { get; set; }

        public Historico()
        {
            DtRegistro = DateTime.Now; // Definindo o status como Ativo por padrão
        }
    }
}
