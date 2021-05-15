using System;

namespace DataAccess.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }


    public static class IAuditableExtension
    {
        public static void Audit(this IAuditable auditable, string by, bool create = false)
        {
            if (auditable == null)
                return;

            if (create)
            {
                auditable.CreatedOn = DateTime.UtcNow;
                auditable.CreatedBy = by;
            }

            auditable.UpdatedOn = DateTime.UtcNow;
            auditable.UpdatedBy = by;
        }

    }
}
