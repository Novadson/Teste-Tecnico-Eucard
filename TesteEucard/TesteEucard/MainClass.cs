using System;
using TesteEucard.DAO;

namespace TesteEucard
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            /*Set Transactions*/
            TransactionsDAO.SetTransactions();

            /*SetCredores*/
            if (TransactionsDAO.SaveTransactions())
                PaymentsDAO.SetCredores(TransactionsDAO._transactions);

            Console.ReadKey();
        }
    }
}
