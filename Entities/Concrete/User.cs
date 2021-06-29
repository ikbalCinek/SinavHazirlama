using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; } // bir kullanıcının çokça sınavı olabilir.

    }
}
