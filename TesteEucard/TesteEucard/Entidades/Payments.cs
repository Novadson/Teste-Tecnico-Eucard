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
        public decimal ValorAReceber { get; set; }
        #endregion

        #region ForeignKey
        [ForeignKey(nameof(IDTransaction))]
        public long IDTransaction { get; set; }
        #endregion ForeignKey
    }
}
