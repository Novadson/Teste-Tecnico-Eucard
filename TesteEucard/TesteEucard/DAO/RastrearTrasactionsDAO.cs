using System;
using System.Collections.Generic;
using System.Linq;
using TesteEucard.Entidades;
using TesteEucard.Entitades;

namespace TesteEucard.DAO
{
    public class RastrearTrasactionsDAO
    {
        #region VARIAVEIS E OBJETOS
        public static int _Indetificador = 0;
        public static Transactions _transactions = new Transactions();
        List<Payments> listCredorPorTrasacao = new List<Payments>();
        #endregion VARIAVEIS E OBJETOS

        public void RastrearTrasactionAndCredores()
        {
            #region LIST E OBJETO
            Console.Write("\nInforme o número de Indentificador para rastrear a Transação:");
            _Indetificador = Convert.ToInt32(Console.ReadLine());
            _transactions = TransactionsDAO._ListTransactions.Where(x => x.Identificador == _Indetificador).FirstOrDefault();
            listCredorPorTrasacao = PaymentsDAO._ListCredores.Where(c => c.IndetificadorTransaction.Equals(_transactions.Identificador)).ToList();
            #endregion LIST E OBJETO

            try
            {
                if (_transactions != null)
                {
                    #region IMPRIMIR TRANSACTIONS
                    Console.Write("\n*************************************Dados da Transação*******************************************************");
                    Console.Write($"\nValor Total:{_transactions.ValorTotal} centanos" + "\t" + $"Identificador único: {_transactions.Identificador}" + "\t" +
                      $"Data de Criação: {_transactions.DataDeCriação} " + "\t" + $"Valor por Parcela: {_transactions.ValorParcela} centavos" + "\n");
                    #endregion IMPRIMIR TRANSACTIONS

                    #region IMPRIMIR LISTA DE CREDORES
                    Console.Write("\n*************************************Lista de Cocredores por Transaction****************************************");
                    if (listCredorPorTrasacao.Count > 0)
                    {
                        foreach (var credor in listCredorPorTrasacao)
                            Console.Write($"\nNome do credor:{credor.NomeCredor}" + "\t" + $"O CNPJ do credor:" +
                                $" {credor.Cnpj_Credor}" + "\t" + $"Valor recebido por transaçao: {credor.ValorAReceber} centavos" + "\t");

                        Console.Write($"A soma dos valores de cada credor é: {listCredorPorTrasacao.Sum(x => x.ValorAReceber)} centavos");
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
