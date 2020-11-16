using System;
using System.Collections.Generic;
using System.Text;
using TesteEucard.Entitades;

namespace TesteEucard.DAO
{
    public class TransactionsDAO
    {
        public static List<Transactions> _list = new List<Transactions>();
        /*Method SetTransactions*/
        public static void SetTransactions(Transactions transactions)
        {
            Console.Write($"Informe o valor da Transação:");
            transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());

            if (transactions.ValorTotal > 0)
                transactions.ValorTotal *= 100; /*Valor Total em centavos E Deve ser maior que zero*/
            else
            {
                Console.WriteLine(transactions.Erromessage);
                return;
            }

            Console.Write($"\nInforme o identificador único:");
            transactions.Identificador = Convert.ToInt32(Console.ReadLine());

            transactions.DataDeCriação = DateTime.Now;

            transactions.ValorParcela = transactions.ValorTotal.HasValue ? transactions.ValorTotal / 2 : null;

            SaveTransactions(transactions);
        }

        public static void SaveTransactions(Transactions transactions)
        {
            _list.Add(transactions);
        }

    }
}
