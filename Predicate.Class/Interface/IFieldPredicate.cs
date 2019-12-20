using Predicate.Class.Interface.Base;
using Predicate.Class.Type;
using Predicate.Class.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Interface
{
    public abstract class IFieldPredicate : IFirstPredicate
    {
        public virtual MethodType? secondM { get; set; }
        public virtual OperatorType Operator { get; set; }
        private string getMethod(MethodType? m, object v, bool quotes = true)
        {
            if (quotes)
                v = v.ToString().Replace("\'", "");

            if (m != null)
            {
                switch (m)
                {
                    case MethodType.Lower: return quotes ? $"LOWER('{v}')" : $"LOWER({v})"; break;
                    case MethodType.Upper: return quotes ? $"UPPER('{v}')" : $"UPPER({v})"; break;
                }
            }

            return quotes ? $"'{v}'" : $"{v}";
        }
        public override string GetSql()
        {
            switch (Operator)
            {
                case OperatorType.Eq: return $"{PropertyName} = {Value.Execute()}"; break;
                case OperatorType.Ne: return $"{PropertyName} != {Value.Execute()}"; break;
                case OperatorType.Gt: return $"{PropertyName} > {Value.Execute()}"; break;
                case OperatorType.Ge: return $"{PropertyName} >= {Value.Execute()}"; break;
                case OperatorType.Lt: return $"{PropertyName} < {Value.Execute()}"; break;
                case OperatorType.Le: return $"{PropertyName} <= {Value.Execute()}"; break;
                case OperatorType.Like:
                    return $"{getMethod(firstMethodType, PropertyName, false)} LIKE {getMethod(secondM, Value.Execute())}"; break;
                case OperatorType.LikeStart:
                    return $"{getMethod(firstMethodType, PropertyName, false)} LIKE {getMethod(secondM, $"%{Value.Execute()}")}"; break;
                case OperatorType.LikeEnd:
                    return $"{getMethod(firstMethodType, PropertyName, false)} LIKE {getMethod(secondM, $"{Value.Execute()}%")}"; break;
                case OperatorType.LikeAll:
                    return $"{getMethod(firstMethodType, PropertyName, false)} LIKE {getMethod(secondM, $"%{Value.Execute()}%")}"; break;
                case OperatorType.In:
                    object In = Value.Execute();
                    string vIn = Value.Values.Aggregate("", (r, l) =>
                    {
                        string res = getMethod(secondM, l.ToString(), true);

                        if (r.Length == 0)
                            return res;
                        else
                            return $"{r},{res}";
                    });
                    return $"{getMethod(firstMethodType, PropertyName, false)} IN ({vIn})";
                    break;
                case OperatorType.NotIn:
                    object NotIn = Value.Execute();
                    string vNotIn = Value.Values.Aggregate("", (r, l) =>
                    {
                        string res = getMethod(secondM, l.ToString(), true);

                        if (r.Length == 0)
                            return res;
                        else
                            return $"{r},{res}";
                    });
                    return $"{getMethod(firstMethodType, PropertyName, false)} NOT IN ({vNotIn})";
                    break;
                case OperatorType.IsNull: return $"{PropertyName} IS NULL"; break;
                case OperatorType.IsNotNull: return $"{PropertyName} IS NOT NULL"; break;
            }
            return String.Empty;
        }
        public virtual IValueClass Value { get; set; }
    }
}
