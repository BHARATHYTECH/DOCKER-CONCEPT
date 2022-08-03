using System;
using System.Collections.Generic;

namespace learncsharp.Models
{
    public partial class Tblemployee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
