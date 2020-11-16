using System;
using System.Linq;
using TesteEucard.Entidades;
using TesteEucard.Entitades;

namespace TesteEucard
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region ENTITY
            /*New Object Transactions*/
            Transactions transactions = new Transactions();

            /*New Object Cocredores*/
            Payments cocredores = new Payments();
            #endregion ENTITY


            Console.WriteLine($"Informe o valor da Transação:");
            transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());


        }
        /*Metho SetTransactions*/
        public static Transactions SetTransactions(Transactions transactions)
        {
            Console.WriteLine($"Informe o valor da Transação:");
            if (Convert.ToDecimal(Console.ReadLine()) > 0)
                transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine()) * 100;
            else
                Console.WriteLine("O valor total deve ser maior que zero;");

            Console.WriteLine($"Informe o identificador único:");
            transactions.Identificador = Convert.ToInt32(Console.ReadLine());

            transactions.DataDeCriação = DateTime.Now;

            transactions.ValorParcela = transactions.ValorTotal.HasValue ? transactions.ValorTotal / 2 : null;

            return transactions;
        }
    }
}
