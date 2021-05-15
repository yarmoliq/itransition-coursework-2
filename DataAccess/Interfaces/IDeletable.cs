using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDeletable
    {
        bool isDeleted { get; set; }
    }
}
