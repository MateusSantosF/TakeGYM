using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakeGYM.Facades.interfaces
{
    public interface ITrainingsheetFacade
    {

        Task<string> GetTrainingSheetByphoneAsync(string phone);
    }
}
