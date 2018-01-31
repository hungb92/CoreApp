using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Infrastructure.Helpers
{
    public static class EmailHelpers
    {
        /// <summary>
        /// Check string input is email
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>Bool</returns>
        public static bool CheckIsEmail(string strInput)
        {
            var isEmail = strInput.IndexOf('@') > -1;
            return isEmail;
        }
    }
}
