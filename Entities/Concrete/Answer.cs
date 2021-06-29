using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Answer
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsTrue { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
