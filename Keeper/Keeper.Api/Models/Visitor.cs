using System;
using System.Collections.Generic;

namespace Keeper.Api.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Remark { get; set; } = null!;

    public string? Company { get; set; }

    public DateOnly DateBoth { get; set; }

    public int Number { get; set; }

    public int Series { get; set; }

    public string Image { get; set; } = null!;
}
