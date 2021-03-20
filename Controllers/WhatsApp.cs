using LaserDay.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LaserDay.Controllers
{
    class WhatsApp
    {
        public async Task sendTextMessage(string phone, string horario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("sendMessage/" + phone + '/' + horario);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Mensagem de confirmação enviada. \n");
                }
            }
        }
        public async Task sendMedia(string phone)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("sendMedia/" + phone);
                if (response.IsSuccessStatusCode)
                {  //GET
                    Console.WriteLine("PDF de orientações enviado. \n");
                }
            }
        }
        public async Task sendMedia2(string phone)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("sendMedia2/" + phone);
                if (response.IsSuccessStatusCode)
                {  //GET
                    Console.WriteLine("Imagem de orientações enviada. \n");
                }
            }
        }

        public async Task contactProcedimento(Procedimento p)
        {
            sendMedia(p.paciente.telefone);
            sendMedia2(p.paciente.telefone);
            sendTextMessage(p.paciente.telefone, p.horario.ToString(@"hh\:mm"));
        }
    }
}

