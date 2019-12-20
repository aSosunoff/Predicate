using Predicate.Class.Interface.Base;
using Predicate.Class.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Interface
{
    public abstract class IPropertyPredicate : IFirstPredicate
    {
        public OperatorType Operator { get; set; }
        public virtual string PropertyName2 { get; set; }
        public virtual MethodType? secondMethodType { get; set; }
        public override string GetSql()
        {
            switch (Operator)
            {
                case OperatorType.Eq: return $"{PropertyName} = {PropertyName2}"; break;
                case OperatorType.Ne: return $"{PropertyName} != {PropertyName2}"; break;
                case OperatorType.Gt: return $"{PropertyName} > {PropertyName2}"; break;
                case OperatorType.Ge: return $"{PropertyName} >= {PropertyName2}"; break;
                case OperatorType.Lt: return $"{PropertyName} < {PropertyName2}"; break;
                case OperatorType.Le: return $"{PropertyName} <= {PropertyName2}"; break;
            }
            return String.Empty;
        }
    }
}
