using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.Entidades;
using TesteEucard.Entitades;

namespace TesteEucard.DAO
{
    public class PaymentsDAO
    {
        #region OBJECT AND LIST
        public static List<Payments> _ListCredores = new List<Payments>();
        public static Payments _credores = new Payments();
        public const int qtdCredor = 2;
        #endregion OBJECT AND LIST

        public static void SetCredores(Transactions transactions)
        {
            for (int i = 0; i < qtdCredor; i++)
            {
                Console.Write($"Informe o CNPJ do Credor:");
                _credores.Cnpj_Credor = Console.ReadLine();

                /*VALIDAR CNPJ*/
                if (!_credores.Cnpj_Credor.Trim().Length.Equals(14))
                {
                    Console.WriteLine(_credores.Erromessage);
                    return;
                }
                _credores.ValorAReceber = transactions.ValorParcela;
                _credores.IndetificadorTransaction = transactions.Identificador;
                _ListCredores.Add(_credores);
            }
            _credores.ValorTotalRecibido = _ListCredores.Sum(x => x.ValorAReceber);
            SavePayments(_ListCredores);
        }

        private static List<Payments> SavePayments(List<Payments> _listCredores)
        {
            return _listCredores;
        }
    }
}
