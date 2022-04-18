using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMLocadora.Models
{
    [Table("locacao")]
    public class Locacao
    {
        public Locacao()
        {
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("Id_Cliente")]
        public int Id_Cliente { get; set; }
        [Column("Id_Filme")]
        public int Id_Filme { get; set; }
        [Column ("DataLocacao")]
        public DateTime DataLocacao { get; set; }
        [Column("DataDevolucao")]
        public DateTime DataDevolucao { get; set; }
        [NotMapped]
        public ICollection<Filme> Filmes { get; set; }
        [NotMapped]
        public Cliente Cliente { get; set; }
       

    }
}
