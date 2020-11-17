using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.DAO;
using TesteEucard.Entidades;
using TesteEucard.Entitades;

namespace TesteEucard
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            /*Set Trasactions*/
            TransactionsDAO.SetTransactions();

            /*SetCredores*/
            if (TransactionsDAO.SaveTransactions())
                PaymentsDAO.SetCredores(TransactionsDAO._transactions);

            /*Fazer nova transação ou rastrear*/
            if (PaymentsDAO.SavePayments())
                PaymentsDAO.FazerNovaTrasaction();

            Console.ReadKey();

        }
    }
}
