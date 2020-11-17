using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.Entitades;

namespace TesteEucard.DAO
{
    public class TransactionsDAO
    {
        #region LIST AND OBJECT
        public static Transactions _transactions = new Transactions();
        public static List<Transactions> _ListTransactions = new List<Transactions>();
        #endregion LIST AND OBJECT

        #region SETTRANSACTIONS
        public static void SetTransactions()
        {
            Console.Write($"\nInforme o valor da Transação:");
            _transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());

            if (_transactions.ValorTotal > 0)
                _transactions.ValorTotal *= 100; /*Valor Total em centavos E Deve ser maior que zero*/
            else
            {
                Console.Write(_transactions.Erromessage);
                _transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());
                _transactions.ValorTotal *= 100;
            }
            Console.Write($"\nInforme o identificador único:");
            _transactions.Identificador = Convert.ToInt32(Console.ReadLine());
            ValidarDuplicidade(_transactions.Identificador);
            _transactions.DataDeCriação = DateTime.Now;
            _transactions.ValorParcela = _transactions.ValorTotal.HasValue ? _transactions.ValorTotal / 2 : null;
            _ListTransactions.Add(_transactions);
            SaveTransactions();
        }
        #endregion SETTRANSACTIONS

        #region SAVETRANSACTIONS
        public static bool SaveTransactions()
        {
            return _ListTransactions.Count > 0 ? true : false;
        }

        public static void ValidarDuplicidade(int Identificador)
        {
            if (_ListTransactions.Count > 0 & _ListTransactions.Select(x => x.Identificador).Contains(Identificador))
            {
                Console.Write("\nO identificador único informado já existe,informe um outro identificador:");
                _transactions.Identificador = Convert.ToInt32(Console.ReadLine());
            }
        }
        #endregion SAVETRANSACTIONS

    }
}
