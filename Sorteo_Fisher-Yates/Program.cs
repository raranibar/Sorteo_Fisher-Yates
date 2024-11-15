using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sorteo_Fisher_Yates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //intercambio
            //int a = 50;
            //int b = 15;
            //Console.WriteLine(" a= {0} - b= {1} ",a , b);
            //(a, b) = (b, a);
            //Console.WriteLine(" a= {0} - b= {1} ", a, b);
            int option = 0;

            // Lista de expedientes (simulación, reemplazar con datos reales)
            List<string> expedientes = Enumerable.Range(100000, 500).Select(x => x.ToString("D6")).ToList();

            // Lista de personas
            List<string> personas = new List<string> { "Persona1", "Persona2", "Persona3"};

            // Solicitar la cantidad de expedientes por persona
            Console.Write("Ingrese la cantidad de expedientes por persona: ");
            int expedientesPorPersona = int.Parse(Console.ReadLine());

            do
            {
                Console.Clear();

                BarajaFisherYates(expedientesPorPersona, expedientes, personas);

                Console.WriteLine("quiere volver a sortear? 0 Para salir");
                option = Convert.ToInt32(Console.ReadLine());
            }
            while (option != 0);
            
            Console.ReadLine();
        }

        static void BarajaFisherYates(int expedientesPorPersona,List<string> expedientes, List<string> personas) {
            // Barajar los expedientes usando Fisher-Yates
            Random random = new Random();
            for (int i = expedientes.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (expedientes[i], expedientes[j]) = (expedientes[j], expedientes[i]);
            }

            // Asignar expedientes a las personas
            int indiceExpediente = 0;
            foreach (var persona in personas)
            {
                Console.WriteLine($"Expedientes para {persona}:");
                for (int i = 0; i < expedientesPorPersona && indiceExpediente < expedientes.Count; i++)
                {
                    Console.WriteLine(expedientes[indiceExpediente]);
                    indiceExpediente++;
                }
                Console.WriteLine();
            }

        }
    }
}
