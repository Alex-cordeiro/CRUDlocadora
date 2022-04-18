using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMLocadora.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("CPF")]
        public string CPF { get; set; }
        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
