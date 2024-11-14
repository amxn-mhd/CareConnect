namespace CareConnect.Services.AuthApi.models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool Issuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }

}
