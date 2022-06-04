using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper 
    { 
        IBookRepository Book { get; } 
        IUserRepository User { get; } 

        IUserBookRepository UserBook { get; }
        void Save(); 
    }
}
