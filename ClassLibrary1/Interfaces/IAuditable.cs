using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Interfaces
{
    interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
    }
}
