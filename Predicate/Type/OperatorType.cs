using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate.Type
{
    public enum OperatorType
    {
        Eq = 0,
        Ne = 1,
        Gt = 2,
        Ge = 3,
        Lt = 4,
        Le = 5,
        Like = 6,
        LikeStart = 7,
        LikeEnd = 8,
        LikeAll = 9,
        In = 10,
        NotIn = 11,
        IsNull = 12,
        IsNotNull = 13
    }
}
