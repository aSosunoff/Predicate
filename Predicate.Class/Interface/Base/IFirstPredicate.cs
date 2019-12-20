using Predicate.Class.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Interface.Base
{
    public abstract class IFirstPredicate : ISqlClass
    {
        public abstract string GetSql();
        public virtual string PropertyName { get; set; }
        public virtual MethodType? firstMethodType { get; set; }
    }
}
