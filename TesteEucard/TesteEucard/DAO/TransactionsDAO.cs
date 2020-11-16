using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.Entitades;

namespace TesteEucard.DAO
{
    public class TransactionsDAO
    {
        public static Transactions _transactions = new Transactions();
        public static List<Transactions> _ListTransactions = new List<Transactions>();


        #region SETTRANSACTIONS
        public static void SetTransactions()
        {
            Console.Write($"Informe o valor da Transação:");
            _transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());

            if (_transactions.ValorTotal > 0)
                _transactions.ValorTotal *= 100; /*Valor Total em centavos E Deve ser maior que zero*/
            else
            {
                Console.WriteLine(_transactions.Erromessage);
                return;
            }

            Console.Write($"\nInforme o identificador único:");
            _transactions.Identificador = Convert.ToInt32(Console.ReadLine());
            if (_ListTransactions.Count > 0 & _ListTransactions.GroupBy(x => x.Identificador).Any(g => g.Count() > 1))
            {
                Console.WriteLine("O identificador único informado já existe");
                _transactions.Identificador = Convert.ToInt32(Console.ReadLine());
            }
            _transactions.DataDeCriação = DateTime.Now;
            _transactions.ValorParcela = _transactions.ValorTotal.HasValue ? _transactions.ValorTotal / 2 : null;

            _ListTransactions.Add(_transactions);
            SaveTransactions();
        }
        #endregion SETTRANSACTIONS


        #region SAVETRANSACTIONS
        public static bool SaveTransactions()
        {
            ValidarDuplicidade();
            return _ListTransactions.Count > 0 ? true : false;
        }

        public static void ValidarDuplicidade()
        {
            Console.WriteLine("Deseja fazer uma nova transação? Digite S para SIM/N para NÃO");
            string resposta = Console.ReadLine();
            if (resposta.Equals("S"))
                SetTransactions();
        }

        #endregion SAVETRANSACTIONS

    }
}
