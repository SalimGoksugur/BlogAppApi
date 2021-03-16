using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.IUnitOfWork
{
    public interface IUnitOfWork
    {
        bool Save();
        void Dispose();
    }
}
