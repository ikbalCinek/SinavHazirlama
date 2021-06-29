using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class AnswerDal : BaseDal<Answer>, IAnswerDal
    {
        private readonly ExamContext context;

        public AnswerDal(ExamContext context) : base(context)
        {
            this.context = context;
        }
    }
}
