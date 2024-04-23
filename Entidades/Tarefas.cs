namespace Entidades
{
    public enum StatusEnum
    {
        Ativo = 1,
        Inativo = 0
    }

    public class Tarefas
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public int IdCategoria { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DtValidade { get; set; }

        public StatusEnum Status { get; set; }

        public Tarefas()
        {
            Status = StatusEnum.Ativo; // Definindo o status como Ativo por padrão
        }
    }
}
