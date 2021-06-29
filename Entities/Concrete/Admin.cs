using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Admin
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [StringLength(25, ErrorMessage = "Karakter sayısını lütfen kontrol ediniz.", MinimumLength = 3)]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Şifre karakter sayısını lütfen kontrol ediniz.", MinimumLength = 3)]
        public string Password { get; set; }

    

        public virtual ICollection<Exam> AdminExams { get; set; }

    }
}
