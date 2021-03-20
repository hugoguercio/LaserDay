using LaserDay.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace LaserDay.Controllers
{
    class FileResolver
    {
        public static List<Procedimento> LeituraCSV()
        {
            List<Procedimento> procedimentos = new List<Procedimento>();
            try
            {
                using (var reader = new StreamReader(@"C:\\Users\\Hugo\\Desktop\\Laser\\1803a.csv"))
                {
                    Console.WriteLine("Starting CSV parse\n");
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(';');
                        Paciente paciente = new Paciente(data[0], data[1]);
                        Procedimento procedimento = new Procedimento(paciente, TimeSpan.Parse(data[2]));
                        procedimentos.Add(procedimento);
                    }
                    Console.WriteLine("File successfully read.\n");
                }
                return procedimentos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" \n**************************** Error - " + ex.Message);
                return null;
            }
        }

    }
}
