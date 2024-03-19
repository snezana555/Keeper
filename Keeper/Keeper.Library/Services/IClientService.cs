using Keeper.Library.Dto;
using Keeper.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keeper.Library.Services
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
