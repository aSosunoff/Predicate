using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Predicate.Value
{
    public abstract class IValueClass
    {
        protected IValueClass(object val)
        {
            _value = val;
        }
        protected static List<System.Type> simpleTypeString = new List<System.Type>
        {
            typeof(string),
            typeof(char),
        };
        protected static List<System.Type> simpleTypeNumber = new List<System.Type>
        {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
        };

        protected object _value;

        protected bool isStringType(System.Type type)
        {
            System.Type actualType = type;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                actualType = type.GetGenericArguments()[0];
            }

            return simpleTypeString.Contains(actualType);
        }
        protected bool isNumberType(System.Type type)
        {
            System.Type actualType = type;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                actualType = type.GetGenericArguments()[0];
            }

            return simpleTypeNumber.Contains(actualType);
        }

        protected bool isInjection(string stroke)
        {
            Regex regex = new Regex("select|from|where|join|with|or|and|insert|delete|updare", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return regex.IsMatch(stroke);
        }

        public List<object> Values { get; } = new List<object>();

        public virtual object Execute()
        {
            object result = "";

            if (ReflectionHelper.IsList(_value))
            {
                IList iList = (IList)_value;
                IEnumerable<object> valueList = iList.Cast<object>();

                result = valueList.Aggregate("", (f, l) =>
                {
                    string res = l.ToString();

                    if (isInjection(res))
                        throw new Exception("Sql injection");

                    if (isStringType(l.GetType()))
                    {
                        res = $"'{res}'";
                        Values.Add(res);
                    }
                    else if (isNumberType(l.GetType()))
                    {
                        res = $"{res.Replace(",", ".")}";
                        Values.Add(res);
                    }

                    if (f.Length == 0)
                        return res;

                    return $"{f},{res}";
                });
            }
            else
            {
                if (isNumberType(_value.GetType()))
                {
                    result = _value.ToString().Replace(",", ".");
                    Values.Add(result);
                }
                else
                {
                    result = _value;

                    if (isInjection(_value.ToString()))
                        throw new Exception("Sql injection");

                    if (isStringType(_value.GetType()))
                        result = $"'{_value}'";

                    Values.Add(result);
                }
            }

            return result;
        }
    }
}
