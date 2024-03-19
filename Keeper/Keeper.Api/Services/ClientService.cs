using Keeper.Api;
using System.Runtime.CompilerServices;
using Keeper.Library.Models;
using Keeper.Api.Dto;
using Keeper.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Api.Services
{
    public class ClientService: IClientService
    {
        private readonly KeeperContext _db;
        public ClientService(KeeperContext db) 
        {
            _db = db;
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _db.Clients.FindAsync(id);
        }

        public async Task<List<Client>> GetClients()
        {
            return await _db.Clients.ToListAsync();
        }

        public async Task<int> Add(ClientCreationDto dto)
        {
            Client client = new Client() {
                Login = dto.Login,
                Password = dto.Password,
                Email = dto.Email,
                Role = dto.Role};
             _db.Clients.Add(client);
            return client.Id;
        }

        public async Task Edit(int id,ClientCreationDto dto)
        {

            Client client = _db.Clients.Find(id);
            client.Login = dto.Login;
            client.Password = dto.Password;
            client.Email = dto.Email;
            client.Role = dto.Role;
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            Client client = await _db.Clients.FindAsync(id);
            if (client == null)
                return;
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
        }

        public async Task<Client> FindByLoginAndPassword(string login, string password)
        {
            Client client = _db.Clients.FirstOrDefault(p => p.Login.Equals(login) && p.Password.Equals(password));
            return client;

        }

        public bool FindByEmail(string email)
        {
            Client client = _db.Clients.FirstOrDefault(p => p.Email.Equals(email));
            if (client != null)
                return true;
            return false;
        }

        public bool FindByLogin(string login)
        {
            Client client = _db.Clients.FirstOrDefault(p => p.Login.Equals(login));
            if (client != null)
                return true;
            return false;
        }
    }
}
