using Predicate.Interface.Base;
using Predicate.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Interface
{
    public abstract class IBetweenPredicate : IFirstPredicate
    {
        public virtual BetweenValues Value { get; set; }
    }
}
