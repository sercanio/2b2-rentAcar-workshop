using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomersDal : EfEntityRepositoryBase<Customers, int, RentACarContext>, ICustomersDal
    {
        public EfCustomersDal(RentACarContext context) : base(context)
        {
        }
    }
}
