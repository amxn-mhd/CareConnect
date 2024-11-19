using CareConnect.Services.AuthApi.models.Dto;

namespace CareConnect.Services.AuthApi.Service
{
    public interface IConsumerService
    {
        Task<List<ConsumerDto>> GetUsersByRole(string role);
    }
}
