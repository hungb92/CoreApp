using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CoreApp.Base.Models
{
    public class StoreProcedure
    {
        private object _parameterObj;

        public StoreProcedure(string name, object parameterObj)
        {
            this.Name = name;
            _parameterObj = parameterObj;
        }

        public object[] GetParameters()
        {
            var props = _parameterObj.GetType().GetProperties();
            var parameters = new object[props.Length];
            SqlParameter parameter;
            var arrIndex = 0;
            foreach (var prop in props)
            {
                parameter = new SqlParameter(prop.Name, prop.GetValue(props));
                parameters[arrIndex] = parameter;
                arrIndex++;
            }
            return parameters;
        }

        public string Name { get; internal set; }
    }
}
