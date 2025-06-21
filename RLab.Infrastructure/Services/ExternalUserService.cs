using RLab.Core.Entities;
using RLab.DTO;
using RLab.DTO.Common;
using RLab.Infrastructure.Infrastructure.Exceptions;
using RLab.Infrastructure.Infrastructure.Extensions;
using RLab.Interface;

namespace RLab.Infrastructure.Services;

public class ExternalUserService : IExternalUserService
{
    private readonly HttpClient _httpClient;
    private readonly IUserMapper _mapper;

    public ExternalUserService(IHttpClientFactory httpClientFactory, IUserMapper mapper)
    {
        _httpClient = httpClientFactory.CreateClient("ReqResClient");
        _mapper = mapper;
    }

    public async Task<ApiResponse<User?>> GetUserById(int id)
    {
        var response = await _httpClient.SafeSendAsync($"users/{id}");
        if (!response.IsSuccessStatusCode)
            return ApiResponse<User?>.Failure(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);

        var userDto = (await response.Content.SafeReadFromJsonAsync<ExternalUserResponse>())?.Data;
        return ApiResponse<User?>.SuccessResponse(_mapper.MapToEntity(userDto));
    }

    public async Task<ApiResponse<IEnumerable<User>>> GetUserByPage(int page)
    {
        var response = await _httpClient.SafeSendAsync($"users?page={page}");
        if (!response.IsSuccessStatusCode)
            return ApiResponse<IEnumerable<User>>.Failure(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);

        var userDtos = (await response.Content.SafeReadFromJsonAsync<ExternalUserListResponse>())?.Data;
        var users = userDtos?.Select(_mapper.MapToEntity) ?? Enumerable.Empty<User>();
        return ApiResponse<IEnumerable<User>>.SuccessResponse(users);
    }
}