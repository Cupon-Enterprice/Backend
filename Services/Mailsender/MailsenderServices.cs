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
                        email = "MS_GAkw8I@trial-k68zxl21xnm4j905.mlsender.net"
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
                                },
                                new {
                                    var = "Cupon",
                                    value =  $"{cupon}"
                                }
                            }
                        }
                    },
                    template_id = "neqvygmovjwl0p7w"
                };

                var body = System.Text.Json.JsonSerializer.Serialize(requestBody);

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailersend.com/v1/email")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Authorization", $"Bearer mlsn.884063689a77b5c48b65054df305ba5d493292f52d70951ba214570bcc273e1a");
                HttpResponseMessage response = _httpClient.Send(request);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al enviar el correo: {e.Message}");
            }
        }
    }
}
