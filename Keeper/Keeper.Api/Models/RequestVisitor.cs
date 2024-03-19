using System;
using System.Collections.Generic;

namespace Keeper.Api.Models;

public partial class RequestVisitor
{
    public int RequestId { get; set; }

    public int VisitorId { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual Visitor Visitor { get; set; } = null!;
}
