using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.AskedQuestionsManagement
{
    public class AskedQuestion : EntityBase
    {
        [Display(Name = "سوال")]
        [MaxLength(1000,ErrorMessage ="مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Qusetion { get; set; }

        [Display(Name = "جواب")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }

        [Display(Name = "شماره سوال")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public int OrderBy { get; set; }

        [Display(Name = "زبان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Language { get; set; }

        public bool IsRemoved { get; set; }
    }
}
