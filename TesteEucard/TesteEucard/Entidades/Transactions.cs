using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteEucard.Entidades;

namespace TesteEucard.Entitades
{
    public class Transactions
    {

        #region PROPRIETY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idtransactions", TypeName = "bigint")]
        public long IDTransaction { get; set; }
        public int Identificador { get; set; }

        [Column("datadecriação")]
        public DateTime DataDeCriação { get; set; }

        [Column("valortotal")]
        public decimal? ValorTotal { get; set; }

        [Column("valorparcela")]
        public decimal? ValorParcela { get; set; }

        [Column("erromessage")]
        public string Erromessage { get; set; } = "O valor informado deve ser maior que ZERO,por favor informe um valor maior que ZERO!:";

        #endregion PROPRIETY

        #region LIST COCREDORES
        public static List<Payments> Cocredores = new List<Payments>();
        #endregion LIST

    }
}
