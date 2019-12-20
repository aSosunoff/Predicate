using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Predicate
{
    public static class ReflectionHelper
    {
        public static MemberInfo GetProperty(LambdaExpression lambda)
        {
            Expression expr = lambda;
            for (; ; )
            {
                switch (expr.NodeType)
                {
                    case ExpressionType.Lambda:
                        expr = ((LambdaExpression)expr).Body;
                        break;
                    case ExpressionType.Convert:
                        expr = ((UnaryExpression)expr).Operand;
                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpression = (MemberExpression)expr;
                        MemberInfo mi = memberExpression.Member;
                        return mi;
                    default:
                        return null;
                }
            }
        }

        public static MethodInfo GetMethod(System.Type objectType, string mrthodName, System.Type[] types)
        {
            MethodInfo method = objectType.GetMethod(mrthodName, types);

            if (method == null) throw new Exception($"Method ({mrthodName}) is not found");

            return method;
        }

        public static PropertyInfo GetProperty(System.Type objectType, string propertyName)
        {
            PropertyInfo propertyInfo = objectType.GetProperty(propertyName);

            if (propertyInfo == null) throw new Exception($"Property ({ propertyName }) is not found to a Type");

            return propertyInfo;
        }

        public static bool IsList<T>(T item)
        {
            if (item is string) return false;
            return item.GetType().GetInterfaces().Any(a => a.Name == typeof(IList<>).Name || a.Name == typeof(IEnumerable<>).Name);
        }

        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this System.Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static T GetAttribute<T>(this PropertyInfo value) where T : Attribute
        {
            var attributes = value.GetCustomAttributes(typeof(T), true);

            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }

            return null;
        }

        public static T GetAttribute<T>(this FieldInfo value)
        {
            var attributes = value.GetCustomAttributes(typeof(T), true);

            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }

            return default(T);
        }

        public static object GetAttribute(FieldInfo value, System.Type T)
        {
            var attributes = value.GetCustomAttributes(T, true);

            if (attributes.Length > 0)
            {
                return attributes[0];
            }

            return null;
        }
    }
}
