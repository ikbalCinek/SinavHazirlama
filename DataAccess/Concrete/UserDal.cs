using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class UserDal : BaseDal<User>, IUserDal
    {
        private readonly ExamContext context;
        public UserDal(ExamContext context) : base(context)
        {
            this.context = context;
        }

        public bool CanLogin(User user)
        {
            return Any(a => a.UserName == user.UserName && a.Password == user.Password);
        }


    }
}
