using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Infrastructure.Constants
{
    public class StoreProcedure : IStoreProcedure
    {
        public string SPName => "EXEC sp_StoreProcedure @param";
    }
}
