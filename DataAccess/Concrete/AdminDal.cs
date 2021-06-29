using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class AdminDal :BaseDal<Admin>,IAdminDal
    {
        private readonly ExamContext context;

        public AdminDal(ExamContext context) : base(context)
        {
            this.context = context;
        }

        public bool CanLogin(Admin  admin)
        {
            return Any(a => a.UserName == admin.UserName && a.Password ==admin.Password);
        }


    }
}
