using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Keeper.Api;
using Keeper.Library.Dto;
using Keeper.Library.Services;
using Keeper.Library.Validators;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Keeper.Library.Models;
namespace Keeper.Test
{

    [TestFixture]
    public class RequestServiceTest
    {
        private readonly ServiceProvider _sp;

        public RequestServiceTest()
        {
            var sc = new ServiceCollection();
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
