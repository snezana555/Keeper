
using FluentValidation;
using Keeper.Api.Dto;
using Keeper.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Api.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly KeeperContext _db;
        private readonly IValidator<VisitorCreationDto> _validator;

        public VisitorService(KeeperContext db, IValidator<VisitorCreationDto> validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<int> Add(VisitorCreationDto dto)
        {

            var validationResult = await _validator.ValidateAsync(dto);

            if (validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Visitor visitor = new Visitor()
            {
                Surname = dto.Surname,
                Name = dto.Name,
                Patronymic = dto.Patronymic,
                Phone = dto.Phone,
                Email = dto.Email,
                Remark = dto.Remark,
                Company = dto.Company,
                DateBoth = dto.DateBoth,
                Number = dto.Number,
                Series = dto.Series,
                Image = dto.Image
            };

            _db.Visitors.Add(visitor);
            await _db.SaveChangesAsync();
            return visitor.Id;
        }

        public async Task Remove(int id)
        {
            var visitor = _db.Visitors.Find(id);
            if (visitor != null)
                _db.Visitors.Remove(visitor);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(int id, VisitorCreationDto dto)
        {
            Visitor visitor = await _db.Visitors.FindAsync(id);

            var validationResult = await _validator.ValidateAsync(dto);

            if (validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (visitor == null)
                return;

            visitor.Surname = dto.Surname;
            visitor.Name = dto.Name;
            visitor.Patronymic = dto.Patronymic;
            visitor.Phone = dto.Phone;
            visitor.Email = dto.Email;
            visitor.Remark = dto.Remark;
            visitor.Company = dto.Company;
            visitor.DateBoth = dto.DateBoth;
            visitor.Number = dto.Number;
            visitor.Series = dto.Series;
            visitor.Image = dto.Image;
            await _db.SaveChangesAsync();
        }

        public async Task<Visitor> GetVisitorById(int id)
        {
            return await _db.Visitors.FindAsync(id);
        }

        public async Task<List<Visitor>> GetVisitors()
        {
            return await _db.Visitors.ToListAsync();
        }

    }
}
