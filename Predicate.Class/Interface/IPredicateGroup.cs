using Predicate.Class.Interface.Base;
using Predicate.Class.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Interface
{
    public abstract class IPredicateGroup : ISqlClass
    {
        public virtual GroupOperatorType Operator { get; set; }
        public virtual IList<ISqlClass> Predicates { get; set; }
        public string GetSql()
        {
            string seperator = Operator == GroupOperatorType.And ? " AND " : " OR ";
            return "(" + Predicates.Aggregate(new StringBuilder(),
                       (sb, p) => (sb.Length == 0 ? sb : sb.Append(seperator)).Append(p.GetSql()),
                       sb =>
                       {
                           var s = sb.ToString();
                           return s;
                       }
                   ) + ")";
        }
    }
}
