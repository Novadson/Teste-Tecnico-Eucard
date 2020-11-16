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
            #region ENTITY
            Payments cocredores = new Payments();
            /*New Object Cocredores*/
            #endregion ENTITY

            /*Set Trasactions*/ 
            TransactionsDAO.SetTransactions();

            /*SetCredores*/
            if (TransactionsDAO.SaveTransactions())
                PaymentsDAO.SetCredores(TransactionsDAO._transactions);

            /*Rastrear Trasaction e Credores*/
            RastrearTrasactionsDAO.RastrearTrasactionAndCredores();
            Console.ReadKey();

        }



    }
}
