using KeeperLibrary.Models;

namespace Keeper.WebService.Services
{
    public interface IRequestService
    {
        Task Add(DateTime dateStart,
                      DateTime dateEnd,
                      string targetVisit,
                      string additionalFiles,
                      Employee employee,
                      List<Visitor> visitors,
                      string status,
                      string statusDescription);
        Task Remove(int id);
        Task Edit(Request request);
    }
}
