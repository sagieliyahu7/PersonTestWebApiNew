using PersonTestWebApi.Utils;
using System.ComponentModel.DataAnnotations;

namespace PersonTestWebApi.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Result { get; set; }
    }
}
