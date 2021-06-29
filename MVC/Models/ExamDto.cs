using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ExamDto
    {
        public ExamDto()
        {
            questionDtos = new List<QuestionDto>();
            //Set<QuestionDto> set = new HashSet<QuestionDto>();
        }

        public List<QuestionDto> questionDtos { get; set; }
       
        
        public string Title { get; set; }
        public string Content { get; set; }

      
       

    }
}
