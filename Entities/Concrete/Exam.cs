using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Exam
    {
        public Exam()
        {
            IsActive = false;
        }
        public int Id { get; set; }

        [NotMapped]
        public string Url { get; set; }

        [NotMapped]
        [Display(Name = "Sınav Durumu")]
        public bool IsActive { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

      
        public string Content { get; set; }

        [Display(Name = "Tarih")]
        public string CreatedDate { get; set; }

        public virtual ICollection<Question> Questions { get; set; } // bir sınavın çokça sorusu

        public virtual Admin Admin { get; set; }  // bir sınavın bir oluşturanı 

        public int AdminId { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
