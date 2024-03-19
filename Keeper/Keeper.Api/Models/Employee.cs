using System;
using System.Collections.Generic;

namespace Keeper.Api.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Setcion { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
