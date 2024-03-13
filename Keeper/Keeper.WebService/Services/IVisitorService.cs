using KeeperLibrary.Models;

namespace Keeper.WebService.Services

{
    public interface IVisitorService
    {
        Task<Visitor> Add(string surname,
                            string patronymic,
                            string phone,
                            string email,
                            string remark,
                            string company,
                            DateTime dateBoth,
                            PassportData PassportData,
                            string image);
        Task Remove(int id);
        Task Edit(Visitor visitor);
    }
}
