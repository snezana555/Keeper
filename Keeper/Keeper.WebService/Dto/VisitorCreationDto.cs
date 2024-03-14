using KeeperLibrary.Models;
using Microsoft.Identity.Client;

namespace Keeper.WebService.Dto
{
    public class VisitorCreationDto
    {
        public string Surname;
        public string? Patronymic;
        public string? Phone;
        public string Email;
        public string Remark;
        public string? Company;
        public DateTime DateBoth;
        public PassportData PassportData;
        public string? Image;
    }
}
