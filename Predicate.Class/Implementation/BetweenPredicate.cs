using Predicate.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Class.Implementation
{
    public class BetweenPredicate : IBetweenPredicate
    {
        public override string GetSql()
        {
            return $"{PropertyName} BETWEEN {Value.Value1} AND {Value.Value2}";
        }
    }
}
