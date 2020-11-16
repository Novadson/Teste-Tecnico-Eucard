using System;
using System.Linq;
using TesteEucard.Entitades;

namespace TesteEucard.DAO
{
    public class RastrearTrasactionsDAO
    {
        public static int _Indetificador = 0;
        public static Transactions _transactions = new Transactions();
        public static void RastrearTrasactionAndCredores()
        {
            Console.WriteLine("Informe o número de Indentificador para rastrear a Transaçã:");
            _Indetificador = Convert.ToInt32(Console.ReadLine());
            _transactions = TransactionsDAO._ListTransactions.Where(x => x.Identificador == _Indetificador).FirstOrDefault();
            try
            {
                if (_transactions != null)
                {
                    #region IMPRIMIR TRANSACTIONS
                    Console.WriteLine("*************************************Dados da Transação*******************************************************");
                    Console.Write($"\nValor Total:{_transactions.ValorTotal} centanos" + "\t" + $"Identificador único: {_transactions.Identificador}" + "\t" +
                      $"Data de Criação: {_transactions.DataDeCriação} " + "\t" + $"Valor por Parcela: {_transactions.ValorParcela} centavos" + "\n");
                    #region IMPRIMIR TRANSACTIONS

                    #region IMPRIMIR LISTA DE CREDORES
                    Console.WriteLine("\n*************************************Lista de Cocredores por Transaction****************************************");
                    if (PaymentsDAO._ListCredores.Count > 0)
                    {
                        foreach (var credor in PaymentsDAO._ListCredores.Where(c => c.IndetificadorTransaction.Equals(_transactions.Identificador)))
                            Console.Write($"\nCNPJ de Credor:{credor.Cnpj_Credor}" + "\t" + $"Valor recebido por transaçao: {credor.ValorAReceber}" + "\t");

                        Console.WriteLine($"A somado os valores de cada credor é: {PaymentsDAO._credores.ValorTotalRecibido}");
                    }
                    #endregion IMPRIMIR LISTA DE CREDORES

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
