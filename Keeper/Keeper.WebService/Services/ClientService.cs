using Keeper.Data;
using System.Runtime.CompilerServices;
using KeeperLibrary.Models;
using Keeper.WebService.Dto;
using Microsoft.EntityFrameworkCore;

namespace Keeper.WebService.Services
{
    public class ClientService: IClientService
    {
        private readonly KeeperDbContext _db;
        public ClientService(KeeperDbContext db) 
        {
            _db = db;
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _db.Clients.FindAsync(id);
        }

        public async Task<List<Client>> GetClients()
        {
            return await _db.Clients.ToListAsync();
        }

        public async Task<Guid> Add(ClientCreationDto dto)
        {
            Client client = new Client() {
                Login = dto.Login,
                Password = dto.Password,
                Email = dto.Email,
                Role = dto.Role};
            await _db.Clients.AddAsync(client);
            return client.Id;
        }

        public async Task Edit(Guid id,ClientCreationDto dto)
        {

            Client client = _db.Clients.Find(id);
            client.Login = dto.Login;
            client.Password = dto.Password;
            client.Email = dto.Email;
            client.Role = dto.Role;
            await _db.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
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
