using System;
using System.Collections.Generic;
using System.IO;


namespace Inmobiliaria
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Inmobiliaria.Propiedad> lista = new List<Inmobiliaria.Propiedad>();
            string[] recibido = Inmobiliaria.LeerArchivo();
            int ContProp = 0;


            foreach (string item in recibido)
            {
                ContProp++;
                string[] dire = item.Split(";");
                Inmobiliaria.Propiedad nuevo = new Inmobiliaria.Propiedad();
                nuevo.Id = ContProp;
                nuevo.TipoProp = dire[1];

                Random rand = new Random();
                nuevo.TipoOp = Convert.ToString(rand.Next(0,1));

                nuevo.Tamanio = rand.Next(100,300);

                nuevo.CantBanios = rand.Next(1,3);

                nuevo.CantHabitaciones = rand.Next(1, 3);

                nuevo.Domicilio = dire[0];

                nuevo.Precio = rand.Next(20000, 30000);

                nuevo.ValorDelInmueble = nuevo.CalcularValor();

                lista.Add(nuevo);

            }

        }
    }
}
