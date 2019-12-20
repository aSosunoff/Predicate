using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Value
{
    public class IsCodeValueClass : IValueClass
    {
        public IsCodeValueClass(object val) : base(val)
        {
        }

        public override object Execute()
        {
            string result = _value.ToString();

            if (ReflectionHelper.IsList(_value))
            {
                IList iList = (IList)_value;
                IEnumerable<object> valueList = iList.Cast<object>();
                result = String.Join(",", valueList.Select(s => $"{s}".Replace(",", ".")));
                if (isInjection(result))
                    throw new Exception("Sql injection");
            }
            else
            {
                if (isNumberType(_value.GetType()))
                    result = _value.ToString().Replace(",", ".");
                else
                {
                    if (isInjection(_value.ToString()))
                        throw new Exception("Sql injection");

                    if (isStringType(_value.GetType()))
                        result = $"{_value}";

                    Values.Add(result);
                }
            }

            return result;
        }
    }
}
