using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakeGYM.Facades
{
    public interface IUserFacade
    {
        public Task<string> VerifyRegisterAsync(string phone);
    }
}
