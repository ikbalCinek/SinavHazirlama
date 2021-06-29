using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            answers = new List<Answer>();

        }
       
        public string Main { get; set; }

        public List<Answer> answers { get; set; }

        public string TrueAnswer { get; set; }
    }
}
