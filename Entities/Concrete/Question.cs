using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Question
    {
        public int Id { get; set; }


        public virtual ICollection<Answer> Answers { get; set; }

        public string QuestionContent { get; set; }

        public int ExamId { get; set; }

        public Exam Exam { get; set; }  //bir sınavın bir sorusu

    }
}
