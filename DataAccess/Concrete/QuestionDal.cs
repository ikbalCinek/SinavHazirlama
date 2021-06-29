using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class QuestionDal : BaseDal<Question>, IQuestionDal
    {
        private readonly ExamContext context;
        public QuestionDal(ExamContext context) : base(context)
        {
            this.context = context;
        }
    }
}
