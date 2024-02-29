using System.Net;

namespace FormFuncionario.Models
{
    public class PierResposta
    {
        public string Header { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }

        public PierResposta()
        {

        }

        public PierResposta(string header, string content, HttpStatusCode statusCode, bool isSuccess)
        {
            Header = header;
            Content = content;
            StatusCode = statusCode;
            IsSuccessStatusCode = isSuccess;
        }
    }
}
