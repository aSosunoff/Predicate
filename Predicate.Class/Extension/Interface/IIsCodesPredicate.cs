using Predicate.Class.Interface.Base;
using Predicate.Class.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Extension.Interface
{
    public abstract class IIsCodesPredicate : IFirstPredicate
    {
        public virtual IValueClass Value { get; set; }
        public override string GetSql()
        {
            return $"IS_CODES('{Value.Execute()}', {PropertyName}) > 0";
        }
    }
}
