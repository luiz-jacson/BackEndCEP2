using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Projeto_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CEPcontroller : ControllerBase
    {

        [HttpGet(Name = "GetCEPcontroller")]


        public async Task<Object> Cep()
        {
            var HttpClient = new HttpClient();
            string query = Request.Query["valor"];
            var response = await HttpClient.GetAsync("http://viacep.com.br/ws/"+query+"/json/");
            var json = await response.Content.ReadAsStringAsync();
            var key = response.Content.Headers.ContentType.MediaType;
            if (key == "text/html")
            {
                var dados_erro = new data();
                dados_erro.status = 404;
                dados_erro.mensagem = "CEP não encontrado!";
                return dados_erro;
            }
            else
            {

                var dados_ok = JsonConvert.DeserializeObject<data>(json);
                dados_ok.status = 200;
                dados_ok.mensagem = "CEP válido!";
                return dados_ok;
            }

        }

        public class data
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string ibge { get; set; }
            public string gia { get; set; }
            public string ddd { get; set; }
            public string siafi { get; set; }
            public int status { get; set; }
            public string mensagem { get; set; }
        }

    }
}
