using Keeper.WebService.Dto;
using KeeperLibrary.Models;

namespace Keeper.WebService.Services
{
    public interface IClientService
    {
        Task<Client> GetClientById(Guid id);

        Task<List<Client>> GetClients();
        Task<Guid> Add(ClientCreationDto dto);

        Task Edit(Guid id, ClientCreationDto dto);

        Task Remove(Guid id);

        Task<Client> FindByLoginAndPassword(string login, string password);
        bool FindByEmail(string email);
        bool FindByLogin(string login);
    }
}
