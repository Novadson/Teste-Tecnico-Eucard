using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.Entidades;
using TesteEucard.Entitades;

namespace TesteEucard
{
    public class Program
    {
        static List<Transactions> _list = new List<Transactions>();
        static void Main(string[] args)
        {
            #region ENTITY
            /*New Object Transactions*/
            Transactions transactions = new Transactions();

            /*New Object Cocredores*/
            Payments cocredores = new Payments();
            #endregion ENTITY

            /*Setar valor da Transação*/
            SetTransactions(transactions);

            /*Save Transactions*/
            SaveTransactions(transactions);

            foreach (var transac in _list)
                Console.Write($"\nValor Total:{transac.ValorTotal} centanos" + "\t" + $"Identificador único: {transac.Identificador}" + "\t" +
                    $"Data de Criação: {transac.DataDeCriação} " + "\t" + $"Valor por Parcela: {transac.ValorParcela} centavos" + "\n");

            // transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());


        }


        /*Metho SetTransactions*/
        public static Transactions SetTransactions(Transactions transactions)
        {
            Console.Write($"Informe o valor da Transação:");
            transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());

            if (transactions.ValorTotal > 0)
                transactions.ValorTotal *= 100; /*Valor Totalem centavos E Maior que zero*/
            else
                Console.WriteLine(transactions.Erromessage);

            Console.Write($"\nInforme o identificador único:");
            transactions.Identificador = Convert.ToInt32(Console.ReadLine());
            transactions.DataDeCriação = DateTime.Now;

            transactions.ValorParcela = transactions.ValorTotal.HasValue ? transactions.ValorTotal / 2 : null;

            return transactions;
        }

        /*Save Transactions*/
        public static void SaveTransactions(Transactions transactions)
        {
            _list.Add(transactions);
        }
    }
}
