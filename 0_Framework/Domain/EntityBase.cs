using System.ComponentModel.DataAnnotations;

namespace _0_Framework.Domain
{
    public class EntityBase
    {
        [Key]
        [Display(Name = "آیدی")]
        public long Id { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreationDate { get; set; }
        public EntityBase() 
        { 
            CreationDate = DateTime.Now;
        }
    }
}
