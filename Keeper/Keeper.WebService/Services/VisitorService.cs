using Azure.Core;
using Keeper.Data;
using KeeperLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.WebService.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly KeeperDbContext _db;

        public VisitorService(KeeperDbContext db)
        {
            _db = db;
        }

        public async Task<Visitor> Add(string surname,
                                    string patronymic,
                                    string phone,
                                    string email,
                                    string remark,
                                    string company,
                                    DateTime dateBoth,
                                    PassportData PassportData,
                                    string image)
        {
            //TO DO: добавление валидации//

            Visitor visitor = new Visitor();
            visitor.Surname = surname;
            visitor.Patronymic = patronymic;
            visitor.Phone = phone;
            visitor.Email = email;
            visitor.Remark = remark;
            visitor.Company = company;
            visitor.DateBoth = dateBoth;
            visitor.PassportData = PassportData;
            visitor.Image = image;
            _db.Visitors.Add(visitor);
            await _db.SaveChangesAsync();
            return visitor;
        }

        public async Task Remove(int id)
        {
            var visitor = _db.Visitors.FindAsync(id);
            _db.Remove(visitor);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Visitor visitor)
        {
            _db.Entry(visitor).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
