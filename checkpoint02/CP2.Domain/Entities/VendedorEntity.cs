using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        [Column("id_vendedor")]
        public int Id { get; set; }

        [Column("nome_vendedor")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("email_vendedor")]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("telefone_vendedor")]
        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Column("data_nascimento_vendedor")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Column("endereco_vendedor")]
        [Required]
        [MaxLength(200)]
        public string Endereco { get; set; }

        [Column("data_contratacao_vendedor")]
        [Required]
        public DateTime DataContratacao { get; set; }

        [Column("comissao_percentual")]
        [Required]
        [Range(0, 100)]
        public decimal ComissaoPercentual { get; set; }

        [Column("meta_mensal")]
        [Required]
        public decimal MetaMensal { get; set; }

        [Column("criado_em")]
        public DateTime CriadoEm { get; set; }
    }
}
