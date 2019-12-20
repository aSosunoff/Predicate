using Predicate.Class.Extension.Implementation;
using Predicate.Class.Extension.Interface;
using Predicate.Class.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Extension
{
    public static class PredicatesEx
    {
        public static IIsCodesPredicate IsMalfunctionCodes<T>(Expression<Func<T, object>> expression, object value) where T : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;

            return new IsCodesPredicate()
            {
                PropertyName = propertyInfo.Name,
                Value = new IsCodeValueClass(value)
            };
        }
        public static IXmlTablePredicate XmlTable<T>(Expression<Func<T, object>> expression, object value) where T : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            return new XmlTablePredicate()
            {
                PropertyName = propertyInfo.Name,
                Value = new ValueClass(value)
            };
        }
    }
}
