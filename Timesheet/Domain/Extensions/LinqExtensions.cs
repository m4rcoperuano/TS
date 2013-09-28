using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public static class LinqExtensions
    {
        public static void FillInNulls<T>(this T model) where T : class
        {
            var projectProperties = model.GetType().GetProperties();
            foreach (var property in projectProperties)
            {
                if (property.GetValue(model, null) == null)
                {
                    if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(model, "", null);
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(model, 0, null);
                    }
                }
            }
        }
    }
}