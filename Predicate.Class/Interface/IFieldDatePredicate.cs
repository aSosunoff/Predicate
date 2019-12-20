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
    public abstract class IFieldDatePredicate : IFirstPredicate
    {
        public virtual OperatorType Operator { get; set; }
        public virtual string Format { get; set; }
        public override string GetSql()
        {
            if (String.IsNullOrEmpty(Format))
                Format = "DD.MM.YYYY HH24:MI:SS";

            switch (Operator)
            {
                case OperatorType.Eq: return $"TO_DATE(TO_CHAR({PropertyName}, '{Format}'), '{Format}') = TO_DATE('{Value.Execute()}', '{Format}')"; break;
                case OperatorType.Ne: return $"TO_DATE(TO_CHAR({PropertyName}, '{Format}'), '{Format}') != TO_DATE('{Value.Execute()}', '{Format}')"; break;
                case OperatorType.Gt: return $"TO_DATE(TO_CHAR({PropertyName}, '{Format}'), '{Format}') > TO_DATE('{Value.Execute()}', '{Format}')"; break;
                case OperatorType.Ge: return $"TO_DATE(TO_CHAR({PropertyName}, '{Format}'), '{Format}') >= TO_DATE('{Value.Execute()}', '{Format}')"; break;
                case OperatorType.Lt: return $"TO_DATE(TO_CHAR({PropertyName}, '{Format}'), '{Format}') < TO_DATE('{Value.Execute()}', '{Format}')"; break;
                case OperatorType.Le: return $"TO_DATE(TO_CHAR({PropertyName}, '{Format}'), '{Format}') <= TO_DATE('{Value.Execute()}', '{Format}')"; break;
            }
            return String.Empty;
        }
        public virtual IValueClass Value { get; set; }
    }
}
