using System;
using System.IO;

namespace Impuestos
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\laboratorio.txt";

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo no existe.");
                return;
            }

            string[] lineas = File.ReadAllLines(rutaArchivo);

            // Variables para contabilizar todas las facturas
            int facturasPagadasEnero = 0;
            int totalFacturasPagadas = 0;
            int totalFacturasNoPagadas = 0;
            int facturasPagadasPrimerSemestre = 0;
            int facturasPagadasSegundoSemestre = 0;

            foreach (string linea in lineas)
            {

                string[] campos = linea.Split(';');

                // Extraer datos relevantes
                string numeroFactura = campos[0];
                string mesFactura = campos[4];
                string pagada = campos[5];

                // Mostrar detalles de las facturas pagadas en enero
                if (mesFactura.Equals("Enero") && pagada.Equals("SI"))
                {
                    Console.WriteLine($"Factura {numeroFactura} - Pagada en Enero");
                    facturasPagadasEnero++;
                }

                
                if (pagada.Equals("SI"))
                {
                    totalFacturasPagadas++;
                }
                else
                {
                    totalFacturasNoPagadas++;
                }

                // Verifico facturas pagadas del 1 y 2 semestre
                if (pagada.Equals("SI"))
                {
                    switch (mesFactura)
                    {
                        case "Enero":
                        case "Febrero":
                        case "Marzo":
                        case "Abril":
                        case "Mayo":
                        case "Junio":
                            facturasPagadasPrimerSemestre++;
                            break;
                        case "Julio":
                        case "Agosto":
                        case "Septiembre":
                        case "Octubre":
                        case "Noviembre":
                        case "Diciembre":
                            facturasPagadasSegundoSemestre++;
                            break;
                    }
                }
            }

            // Muestro los  resultados
            Console.WriteLine();
            Console.WriteLine($"Total de Facturas Pagadas en Enero: {facturasPagadasEnero}");

            // Total de Facturas Pagadas
            int totalFacturasPagadasFinal = totalFacturasPagadas + facturasPagadasEnero;
            Console.WriteLine($"Total de Facturas Pagadas: {totalFacturasPagadasFinal}");

            Console.WriteLine($"Total de Facturas NO Pagadas: {totalFacturasNoPagadas}");
            Console.WriteLine($"Facturas Pagadas en el Primer Semestre: {facturasPagadasPrimerSemestre}");
            Console.WriteLine($"Facturas Pagadas en el Segundo Semestre: {facturasPagadasSegundoSemestre}");
        }
    }
}
