using Predicate.Class.Interface.Base;
using Predicate.Class.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Interface
{
    public abstract class IBetweenPredicate : IFirstPredicate
    {
        public virtual BetweenValues Value { get; set; }
    }
}
