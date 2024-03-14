using FluentValidation;
using Keeper.Data;
using Keeper.WebService.Dto;
using KeeperLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Keeper.WebService.Services
{
    public class RequestService : IRequestService
    {
        private readonly KeeperDbContext _db;
        private readonly IValidator<RequestCreationDto> _validator;

        public RequestService(KeeperDbContext db, IValidator<RequestCreationDto> validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task Add(RequestCreationDto dto)
        {
            // TODO: добавление валидации //
            var validationResult = await _validator.ValidateAsync(dto);

            if(validationResult.IsValid) 
            {
                throw new ValidationException(validationResult.Errors);
            }

            Request request = new Request()
            {
                DateStart = dto.DateStart,
                DateEnd = dto.DateEnd,
                TargetVisit = dto.TargetVisit,
                AdditionalFiles = dto.AdditionalFiles,
                EmployeeId = dto.EmployeeId,
                Visitors = _db.Visitors.Where(v => dto.VisitorsIds.Contains(v.Id)).ToList(),
                StatusDescription = dto.StatusDescription,
                //Status = dto.Status
            };

            _db.Requests.Add(request);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var request = _db.Requests.FindAsync(id);
            _db.Remove(request);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Request request)
        {
            _db.Entry(request).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task ChangeStatus(int id)
        {

        }
    }
}
