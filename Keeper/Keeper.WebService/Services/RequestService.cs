using AutoMapper.QueryableExtensions;
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

        public async Task<bool> ChangeStatus(int id, StatusChangeDto sData)
        {
            Request request = await _db.Requests.FindAsync(id);
            if (request == null)
                return false;
            request.StatusDescription = sData.StatusDescription;


            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Request>> GetRequests()
        {
              List<Request> requests = _db.Requests.ToList();
              return requests;
        }

        public async Task<Request?> GetItem(int id)
        {
            return _db.Requests.Find(id);
        }

        public bool isRequestClient(string email, Guid idRequest)
        {
            Request req = _db.Requests.Find(idRequest);
            foreach(var vis in req.Visitors)
            {
                if (vis.Email == email)
                    return true;
            }
            return false;
        }

        public async Task<List<Request>> GetRequestsByClientEmail(string email)
        {
            List<Request> requests = null;
            foreach(var req in _db.Requests)
            {
                if(isRequestClient(email, req.Id))
                {
                    requests.Add(req);
                }
            }
            return requests;
        }
    }
}
