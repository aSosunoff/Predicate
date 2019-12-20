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
    public abstract class IFieldDateTruncPredicate : IFirstPredicate
    {
        public virtual OperatorType Operator { get; set; }
        public virtual string Format { get; set; }
        public virtual string FormatTrunc { get; set; }
        public override string GetSql()
        {
            if (String.IsNullOrEmpty(Format))
                Format = "DD.MM.YYYY HH24:MI:SS";

            if (String.IsNullOrEmpty(FormatTrunc))
                FormatTrunc = "DDD";

            switch (Operator)
            {
                case OperatorType.Eq: return $"TRUNC({PropertyName}, '{FormatTrunc}') = TRUNC(TO_DATE('{Value.Execute()}', '{Format}'), '{FormatTrunc}')"; break;
                case OperatorType.Ne: return $"TRUNC({PropertyName}, '{FormatTrunc}') != TRUNC(TO_DATE('{Value.Execute()}', '{Format}'), '{FormatTrunc}')"; break;
                case OperatorType.Gt: return $"TRUNC({PropertyName}, '{FormatTrunc}') > TRUNC(TO_DATE('{Value.Execute()}', '{Format}'), '{FormatTrunc}')"; break;
                case OperatorType.Ge: return $"TRUNC({PropertyName}, '{FormatTrunc}') >= TRUNC(TO_DATE('{Value.Execute()}', '{Format}'), '{FormatTrunc}')"; break;
                case OperatorType.Lt: return $"TRUNC({PropertyName}, '{FormatTrunc}') < TRUNC(TO_DATE('{Value.Execute()}', '{Format}'), '{FormatTrunc}')"; break;
                case OperatorType.Le: return $"TRUNC({PropertyName}, '{FormatTrunc}') <= TRUNC(TO_DATE('{Value.Execute()}', '{Format}'), '{FormatTrunc}')"; break;
            }
            return String.Empty;
        }
        public virtual IValueClass Value { get; set; }
    }
}
