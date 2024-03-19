using Keeper.Api.Dto;
using Keeper.Library.Models;

namespace Keeper.Api.Services
{
    public interface IClientService
    {
        Task<Client> GetClientById(int id);

        Task<List<Client>> GetClients();
        Task<int> Add(ClientCreationDto dto);

        Task Edit(int id, ClientCreationDto dto);

        Task Remove(int id);

        Task<Client> FindByLoginAndPassword(string login, string password);
        bool FindByEmail(string email);
        bool FindByLogin(string login);
    }
}
