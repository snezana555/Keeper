using Azure.Core;
using FluentValidation;
using Keeper.Data;
using Keeper.WebService.Dto;
using KeeperLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.WebService.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly KeeperDbContext _db;
        private readonly IValidator<VisitorCreationDto> _validator;

        public VisitorService(KeeperDbContext db, IValidator<VisitorCreationDto> validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<Guid> Add(VisitorCreationDto dto)
        {

            var validationResult = await _validator.ValidateAsync(dto);

            if (validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Visitor visitor = new Visitor()
            {
                Surname = dto.Surname,
                Patronymic = dto.Patronymic,
                Phone = dto.Phone,
                Email = dto.Email,
                Remark = dto.Remark,
                Company = dto.Company,
                DateBoth = dto.DateBoth,
                PassportData = dto.PassportData,
                Image = dto.Image
            };

            _db.Visitors.Add(visitor);
            await _db.SaveChangesAsync();
            return visitor.Id;
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
