using System;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mailsender
{
    public class MailSenderServices : IMailSenderServices
    {
        private readonly HttpClient _httpClient;
        public MailSenderServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(100); // Ajusta el tiempo de espera a 100 segundos (No es tan necesario pero aja pa que no se de cuenta que puede fallar C:)
        }

        public void SendMail(string para, string usuario, string cupon)
        {
            Console.WriteLine("SendMail");
            try
            {
                var requestBody = new
                {
                    from = new
                    {
                        email = "MS_PmYp6t@trial-0p7kx4x8r12g9yjr.mlsender.net"
                    },
                    to = new[]
                    {
                        new {
                            email = para
                        }
                    },
                    subject = "Cupon redimido correctamente",
                    variables = new[]{
                        new {
                            email = para,
                            substitutions = new []{
                                new {
                                    var = "Usuario",
                                    value =  $"{usuario}"
                                }
                            }
                        }
                    },
                    template_id = "3z0vklo02dvl7qrx"
                };

                var body = System.Text.Json.JsonSerializer.Serialize(requestBody);

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailersend.com/v1/email")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Authorization", $"Bearer mlsn.9a2354296918d178648519363440bccb6d9be99c6a8ea0b913bbd1de93a680ad");
                HttpResponseMessage response = _httpClient.Send(request);
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                Console.WriteLine(response);
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al enviar el correo: {e.Message}");
            }
        }
    }
}
