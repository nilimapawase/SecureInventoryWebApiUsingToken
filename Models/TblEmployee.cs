using System;
using System.Collections.Generic;

namespace SecureInventoryWebApiUsingToken.Models;

public partial class TblEmployee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmailAddress { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string? Password { get; set; }

    public string? Designation { get; set; }
}
