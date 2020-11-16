using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.DAO;
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

            /*Set Trasactions*/
            TransactionsDAO.SetTransactions(transactions);


            if (TransactionsDAO._list.Count > 0)
                foreach (var transac in TransactionsDAO._list)
                    Console.Write($"\nValor Total:{transac.ValorTotal} centanos" + "\t" + $"Identificador único: {transac.Identificador}" + "\t" +
                        $"Data de Criação: {transac.DataDeCriação} " + "\t" + $"Valor por Parcela: {transac.ValorParcela} centavos" + "\n");

            // transactions.ValorTotal = Convert.ToDecimal(Console.ReadLine());
            Console.ReadKey();


        }


        public static Payments SetCredores(Payments payments)
        {
            return payments;
        }

    }
}
