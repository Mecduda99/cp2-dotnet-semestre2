using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        [Key]
        [Column("id_fornecedor")]
        public int Id { get; set; }

        [Column("nome_fornecedor")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("cnpj_fornecedor")]
        [Required]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [Column("endereco_fornecedor")]
        [Required]
        [MaxLength(200)]
        public string Endereco { get; set; }

        [Column("telefone_fornecedor")]
        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Column("email_fornecedor")]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("criado_em")]
        public DateTime CriadoEm { get; set; }
    }
}
