using RLab.Core.Entities;
using RLab.DTO;
using RLab.Interface;
using System.Net.Http;
using System.Net.Http.Json;

namespace RLab.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;

        public UserRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ReqResClient");
        }

        public Task<IEnumerable<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
