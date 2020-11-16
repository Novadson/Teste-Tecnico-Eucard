using System;
using System.Linq;
using TesteEucard.Entitades;

namespace TesteEucard
{
    public class Program
    {
        static void Main(string[] args)
        {
            Eucard eucard = new Eucard();

            for (int i = 0; i < eucard.numberLenght; i++)
            {
                Console.WriteLine("Informe um número:");
                eucard.media.Add(Convert.ToInt32(Console.ReadLine()));
            }
            eucard.result = eucard.media.Average();
            Console.WriteLine($"A media dos valores é:" + eucard.result);

        }
    }
}
