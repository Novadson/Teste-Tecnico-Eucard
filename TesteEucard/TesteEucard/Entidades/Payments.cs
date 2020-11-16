using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEucard.Entidades
{
    public class Payments
    {

        #region PROPRIETY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idpaymentscredor", TypeName = "bigint")]
        public long IDPaymentsCredor { get; set; }

        [Column("Cnpj_Credor", TypeName = "varchar(14)")]
        public string Cnpj_Credor { get; set; }

        [Column("ValorAReceber", TypeName = "varchar(14)")]
        public decimal? ValorAReceber { get; set; }

        [Column("ValorAReceber", TypeName = "varchar(14)")]
        public decimal? ValorTotalRecibido { get; set; }

        public string Erromessage { get; set; } = "CNPJ Inválido,por favor informe um CNPJ válido que possui 14 NÚMERO!";
        #endregion

        #region ForeignKey
        [ForeignKey(nameof(IDTransaction))]
        public long IDTransaction { get; set; }

        [ForeignKey(nameof(IndetificadorTransaction))]
        public long IndetificadorTransaction { get; set; }
        #endregion ForeignKey
    }
}
