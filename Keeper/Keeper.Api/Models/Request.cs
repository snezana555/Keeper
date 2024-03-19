using System;
using System.Collections.Generic;

namespace Keeper.Api.Models;

public partial class Request
{
    public int Id { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string TargetVisit { get; set; } = null!;

    public string AdditionalFiles { get; set; } = null!;

    public int EmployeeId { get; set; }

    public string? Status { get; set; }

    public string StatusDescription { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
