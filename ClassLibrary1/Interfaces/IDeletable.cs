using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    interface IDeletable
    {
        bool isDeleted { get; set; }
    }
}
