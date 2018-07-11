using System;
namespace Cheeteye.Models
{
    public class EnrollResponseModel : BaseModel
    {
        public int ResponseType { get; set; }
        public string Pin { get; set; }
        public string Message { get; set; }
    }
}
