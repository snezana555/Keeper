using Keeper.Library.Models;

namespace Keeper.Api.Dto
{
    public class VisitorCreationDto
    {
        public string Surname;
        public string Name;
        public string? Patronymic;
        public string? Phone;
        public string Email;
        public string Remark;
        public string? Company;
        public DateTime DateBoth;
        public int Number;
        public int Series;
        public string? Image;
    }
}
