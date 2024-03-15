using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Keeper.Data;
using Keeper.WebService.Dto;
using Keeper.WebService.Services;
using Keeper.WebService.Validators;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
namespace Keeper.Test
{

    [TestFixture]
    public class RequestServiceTest
    {
        private readonly ServiceProvider _sp;

        public RequestServiceTest()
        {
            var sc = new ServiceCollection();
            sc.AddDbContext<KeeperDbContext>();
            sc.AddScoped<IValidator<VisitorCreationDto>, VisitorValidator>();
            sc.AddScoped<IValidator<RequestCreationDto>, RequestCreationDtoValidator>();
            sc.AddScoped<RequestService>();
            _sp = sc.BuildServiceProvider();
        }
        [Test]
        public void RequestServiceAdd()
        {
            var service = _sp.GetService<RequestService>();
            // ToDo //
        }
    }
}
