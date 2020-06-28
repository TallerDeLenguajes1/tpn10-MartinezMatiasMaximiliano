using System;
using System.Linq;
using System.IO;
using Helpers;

namespace Morse
{
    class Program
    {
        static void Main(string[] args)
        {

            int seleccion = 0;

            do
            {
                Console.WriteLine("Ingrese opcion:\n [0]Texto a Morse \n [1]Morse a Texto \n [2]Crear Archivo de audio");
                seleccion = Convert.ToInt32(Console.ReadLine());
            } while (seleccion < 0 || seleccion > 2);

            Console.WriteLine("");

            if (seleccion == 0)
            {
                Console.WriteLine(@"Texto que quiere traducir a morse: ");
                string TextoInser = Console.ReadLine(); // ... --- ... / 
                ConversorDeMorse.CrearArchivoTAM(TextoInser);
            }
            else if (seleccion == 1)
            {
                Console.WriteLine(@"Morse que quiere traducir a texto: ");
                string MorseInser = Console.ReadLine();
                string MorseTraducido = ConversorDeMorse.MorseATexto(MorseInser);
                Console.WriteLine($"{MorseInser}---->{MorseTraducido}");
            }
            else
            {
                Console.WriteLine(@"Texto que quiere traducir a morse: ");
                string TextoInser = Console.ReadLine(); // ... --- ... / 
                ConversorDeMorse.CrearArchivoTAM(TextoInser);
                string TextoLeido = ConversorDeMorse.LeerArchivo(TextoInser);
                ConversorDeMorse.CrearArchivoAudio(TextoInser);


            }

        }
    }
}
