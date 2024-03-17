using System;
using System.Collections.Generic;
using System.Text;
using KeeperLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Data
{
    public class KeeperDbContext: DbContext 
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PassportData> PassportDatas { get; set; }
    }

}
