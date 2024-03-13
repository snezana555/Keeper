using Keeper.Data;
using KeeperLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Keeper.WebService.Services
{
    public class RequestService : IRequestService
    {
        private readonly KeeperDbContext _db;

        public RequestService(KeeperDbContext db)
        {
            _db = db;
        }

        public async Task Add(DateTime dateStart,
                              DateTime dateEnd,
                              string targetVisit,
                              string additionalFiles,
                              Employee employee,
                              List<Visitor> visitors,
                              string status,
                              string statusDescription)
        {
            // TODO: добавление валидации //

            Request request = new Request();
            request.DateStart = dateStart;
            request.DateEnd = dateEnd;
            request.TargetVisit = targetVisit;
            request.AdditionalFiles = additionalFiles;
            request.Employee = employee;
            request.Visitors = visitors;
            request.StatusDescription = statusDescription;
            //request.Status = Status; //
            // TODO: status //
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
    }
}
