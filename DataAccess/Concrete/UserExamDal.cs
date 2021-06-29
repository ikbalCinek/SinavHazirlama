using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class UserExamDal : BaseDal<UserExam>, IUserExamDal
    {
        private readonly ExamContext context;
        public UserExamDal(ExamContext context) : base(context)
        {
            this.context = context;
        }
    }
}
