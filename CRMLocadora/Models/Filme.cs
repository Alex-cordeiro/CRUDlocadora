using System.ComponentModel.DataAnnotations.Schema;

namespace CRMLocadora.Models
{
    [Table("filme")]
    public class Filme
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Titulo")]
        public string Titulo { get; set; }
        [Column("ClassificacaoIndicativa")]
        public int ClassificacaoIndicativa { get; set; }
        [Column("Lancamento")]
        public bool Lancamento { get; set; }
    }
}
