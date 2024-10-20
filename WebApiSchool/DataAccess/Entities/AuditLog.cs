using System.ComponentModel.DataAnnotations;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Entities
{
    public class AuditLog
    {
        [Display(Name = "رقم العملية")]
        public int AuditId { get; set; }

        [Display(Name = "اسم الجدول ")]
        public string TableName { get; set; }
        public string TablePK { get; set; }

        [Display(Name = "العملية")]
        public string AuditAction { get; set; }

        [Display(Name = "الوقت والتاريخ")]
        public DateTime AuditDateTime { get; set; }

        [Display(Name = "عنوان الشبكة")]
        public string AuditPcIp { get; set; }

        [Display(Name = "اسم الحاسبة")]
        public string AuditPcName { get; set; }

        [Display(Name = "المستخدم")]
        public User AuditUser { get; set; }

        public string AuditData { get; set; }
    }
}
