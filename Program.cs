using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Headers;
using LaserDay.Controllers;
using System.Collections.Generic;
using ServiceStack;
using LaserDay.Models;

namespace LaserDay
{
    class Program
    {
        static async Task Main(string[] args)
        {
                       
            #region  Menu das linhas de código brooo
            static void showMenu()
            {
                Console.WriteLine("Bem vindo dia do lase sem interface! \n\n" +
                    "1 - Enviar mensagens do laser\n" +
                    "\nDigite 's' para fechar tudo!");
            }            
            String line;
            showMenu();

            do
            {                
                line = System.Console.ReadLine();               
                switch (line)
                {
                    case "1":
                        Console.WriteLine("Dia do laser selecionado, iniciando procedimentos");
                        List<Procedimento> procedimentos = FileResolver.LeituraCSV();
                        if (procedimentos.IsNullOrEmpty())
                        {
                            Console.WriteLine("Falha na leitura do arquivo!");
                            break;
                        }
                        else
                        {
                            //Initialize variables
                            var whats = new WhatsApp();
                            var rnd = new Random(DateTime.Now.Millisecond);
                            int i = 0;
                            int total = procedimentos.Count;
                            
                            Console.WriteLine("\nTemos "+procedimentos.Count+ " pacientes neste laser !\n" +
                                "Começando a enviar mensagens!" );
                            
                            foreach (Procedimento p in procedimentos)
                            {
                                i++;
                                //Send proceeding confirmation
                                whats.contactProcedimento(p).Wait();
                                //Random sleep to avoid ban
                                Thread.Sleep(rnd.Next(2000, 6000)); 
                                Console.WriteLine(i+"/"+total);                                
                            }
                        }
                        Console.WriteLine("Chegamos ao fim. \n+" +
                            "As mensagens do laser foram enviadas");
                        break;                   
                    default:
                        Console.WriteLine("\n Comando não identificado!");
                        showMenu();
                        break;
                }                   
              
            } while (line != "s");
            #endregion            
        }
    }
}