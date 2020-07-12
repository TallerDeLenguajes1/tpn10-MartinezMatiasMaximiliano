using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inmobiliaria
{
    class Inmobiliaria
    {
        public enum TipoDeOperacion
        {
            Venta = 0,
            Alquiler = 1
        }

        public enum TipoDePropiedad
        {
            Departamento = 0,
            Casa = 1,
            Duplex = 2,
            Penthouse = 3,
            Terreno = 4
        }

        public class Propiedad
        {
            int id;
            TipoDePropiedad tipoProp;
            TipoDeOperacion tipoOp;
            float tamanio;
            int cantBanios;
            int cantHabitaciones;
            string domicilio;
            float precio;
            bool estado;
            float valorDelInmueble;

            public int Id { get => id; set => id = value; }
            public float Tamanio { get => tamanio; set => tamanio = value; }
            public int CantBanios { get => cantBanios; set => cantBanios = value; }
            public int CantHabitaciones { get => cantHabitaciones; set => cantHabitaciones = value; }
            public string Domicilio { get => domicilio; set => domicilio = value; }
            public float Precio { get => precio; set => precio = value; }
            public bool Estado { get => estado; set => estado = value; }
            public float ValorDelInmueble { get => valorDelInmueble; set => valorDelInmueble = value; }
            public TipoDePropiedad TipoProp { get => tipoProp; set => tipoProp = value; }
            public TipoDeOperacion TipoOp { get => tipoOp; set => tipoOp = value; }

            public float CalcularValor()
            {
                float valor;
                float IVAVen = Convert.ToSingle(precio * 0.21);
                float IBrutoVen = Convert.ToSingle(precio * 0.1);
                float SelloAlq = Convert.ToSingle(precio * 0.02);
                float ContratoAlq = Convert.ToSingle(precio * 0.005);
                float ConstoTran = 10000;

                if (tipoOp == Inmobiliaria.TipoDeOperacion.Venta)
                {
                    valor = precio + IVAVen + IBrutoVen + ConstoTran;
                }
                else
                {
                    valor = precio + SelloAlq + ContratoAlq; 
                }

                return valor;
            }
        }

        public static string[] LeerArchivo()
        {
            

            string ruta = @"C:\Repogit\tpn10-MartinezMatiasMaximiliano\Inmobiliaria\Propiedades.csv";

            StreamReader reader = new StreamReader(File.Open(ruta,FileMode.Open));

            string recibido = reader.ReadToEnd();
            string[] leido = recibido.Split("\r\n");


            return leido;
        }



        public static void EscribirArchivo(List<Inmobiliaria.Propiedad> lista)
        {
            string ruta = @"C:\Repogit\tpn10-MartinezMatiasMaximiliano\Inmobiliaria\PropiedadesFinal.csv";
            StreamWriter writer = new StreamWriter(File.Open(ruta ,FileMode.Create));
            
            foreach (Inmobiliaria.Propiedad item in lista)
            {
                writer.Write($"{item.Id};{item.TipoOp};{item.TipoProp};{item.Tamanio};{item.CantBanios};{item.CantHabitaciones};{item.Domicilio};{item.Precio};{item.ValorDelInmueble}\n");
            }
            writer.Close();
        }
    }
}
