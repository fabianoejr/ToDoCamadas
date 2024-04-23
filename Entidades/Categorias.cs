namespace Entidades
{
    public class Categorias
    {
        public enum StatusEnum
        {
            Ativo = 1,
            Inativo = 0
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public StatusEnum Status { get; set; }

        public Categorias()
        {
            Status = StatusEnum.Ativo; // Definindo o status como Ativo por padrão
        }
    }
}
