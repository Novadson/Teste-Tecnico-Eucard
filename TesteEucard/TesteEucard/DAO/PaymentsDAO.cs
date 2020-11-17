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
        public const int qtdCredor = 3;
        #endregion OBJECT AND LIST


        #region SetCredores
        public static void SetCredores(Transactions transactions)
        {
            Payments _credores = new Payments();
            for (int i = 1; i < qtdCredor; i++)
            {
                Console.Write($"\n Informe o nome do {i}º Credor:");
                _credores.NomeCredor = Console.ReadLine();

                Console.Write($"\n Informe o CNPJ do Credor:");
                _credores.Cnpj_Credor = Console.ReadLine();

                /*VALIDAR CNPJ*/
                if (!_credores.Cnpj_Credor.Trim().Length.Equals(14))
                {
                    Console.Write(_credores.Erromessage);
                    _credores.Cnpj_Credor = Console.ReadLine();
                }
                _credores.ValorAReceber = transactions.ValorParcela;
                _credores.IndetificadorTransaction = transactions.Identificador;
                _ListCredores.Add(_credores);
                _credores = new Payments();
            }
            _credores.ValorTotalRecibido = _ListCredores.Sum(x => x.ValorAReceber);
            SavePayments();
            transactions = new Transactions();
        }
        #endregion SetCredores

        #region SAVEPAYMENTS
        public static bool SavePayments()
        {
            FazerNovaTrasaction();
            return _ListCredores.Count > 0 ? true : false;
        }
        #endregion SAVEPAYMENTS


        #region FazerNovaTrasaction
        public static void FazerNovaTrasaction()
        {
            Console.Write("\n Deseja rastrear a transação feita ou fazer uma nova transação? 1 para rastrear 2 para nova transação:");
            string resposta = Console.ReadLine();
            switch (resposta)
            {
                case "1":
                    new RastrearTrasactionsDAO().RastrearTrasactionAndCredores();
                    break;
                case "2":
                    TransactionsDAO._transactions = new Transactions();
                    TransactionsDAO.SetTransactions();
                    if (TransactionsDAO.SaveTransactions())
                        SetCredores(TransactionsDAO._transactions);
                    break;
                default:
                    break;
            }
        }
        #endregion FazerNovaTrasaction
    }
}
