using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intern.Models;

public partial class LoginDetail
{
    public string EmailId { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
