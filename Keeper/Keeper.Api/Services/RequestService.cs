using AutoMapper.QueryableExtensions;
using FluentValidation;
using Keeper.Api;
using Keeper.Api.Dto;
using Keeper.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Keeper.Api.Services
{
    public class RequestService : IRequestService
    {
        private readonly KeeperContext _db;
        private readonly IValidator<RequestCreationDto> _validator;

        public RequestService(KeeperContext db, IValidator<RequestCreationDto> validator)
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
            var request = _db.Requests.Find(id);
            if (request != null)
                _db.Requests.Remove(request);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(int id, Request req)
        {
            Request request = await _db.Requests.FindAsync(id);
            request.DateStart = req.DateStart;
            request.DateEnd = req.DateEnd;
            request.EmployeeId = req.EmployeeId;
            request.TargetVisit = req.TargetVisit;
            request.AdditionalFiles = req.AdditionalFiles;
            request.Status = req.Status;
            request.StatusDescription = req.StatusDescription;
            request.Visitors = req.Visitors;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ChangeStatus(int id, string status)
        {
            Request request = await _db.Requests.FindAsync(id);
            if (request == null)
                return false;
            request.StatusDescription = "";
            //Todo//


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

        public bool isRequestClient(string email, int idRequest)
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
