using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Data.Repositories
{
    public class SecurityCodeRepository:GenericRepository<SecurityCode>, ISecurityCodeRepository
    {
        public SecurityCodeRepository(AppDbContext context):base(context)
        {

        }
    }
}
