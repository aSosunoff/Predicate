using Predicate.Implementation;
using Predicate.Interface.Base;
using Predicate.Type;
using Predicate.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Predicate
{
    public static class Predicates
    {
        public static ISqlClass Field<T>(Expression<Func<T, object>> expression, OperatorType op, object value) where T : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            return new FieldPredicate()
            {
                PropertyName = propertyInfo.Name,
                Operator = op,
                Value = new ValueClass(value)
            };
        }
        public static ISqlClass Field<T>(Expression<Func<T, object>> expression, OperatorType op, MethodType secondM, object value) where T : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            return new FieldPredicate()
            {
                PropertyName = propertyInfo.Name,
                Operator = op,
                Value = new ValueClass(value),
                firstMethodType = secondM,
                secondM = secondM
            };
        }
        public static ISqlClass Field<T>(MethodType firstM, Expression<Func<T, object>> expression, OperatorType op, MethodType secondM, object value) where T : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            return new FieldPredicate()
            {
                PropertyName = propertyInfo.Name,
                Operator = op,
                Value = new ValueClass(value),
                firstMethodType = firstM,
                secondM = secondM
            };
        }

        public static ISqlClass FieldDate<T>(Expression<Func<T, object>> expression, OperatorType op, object value) where T : class
        {
            return FieldDate<T>(expression, op, value, "DD.MM.YYYY HH24:MI:SS");
        }
        public static ISqlClass FieldDate<T>(Expression<Func<T, object>> expression, OperatorType op, object value, string format) where T : class
        {
            if (value.GetType() != typeof(DateTime))
                throw new Exception($"{value} is not a date value");

            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;

            return new FieldDatePredicate()
            {
                PropertyName = propertyInfo.Name,
                Operator = op,
                Value = new ValueClass(value),
                Format = format
            };
        }

        public static ISqlClass FieldDateTrunc<T>(Expression<Func<T, object>> expression, OperatorType op, object value, string format = "", string truncFormat = "") where T : class
        {
            if (value.GetType() != typeof(DateTime))
                throw new Exception($"{value} is not a date value");

            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;

            return new FieldDateTruncPredicate()
            {
                PropertyName = propertyInfo.Name,
                FormatTrunc = truncFormat,
                Operator = op,
                Value = new ValueClass(value),
                Format = format
            };
        }

        public static ISqlClass Property<T, T2>(Expression<Func<T, object>> expression, OperatorType op, Expression<Func<T2, object>> expression2)
            where T : class
            where T2 : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            PropertyInfo propertyInfo2 = ReflectionHelper.GetProperty(expression2) as PropertyInfo;
            return new PropertyPredicate
            {
                PropertyName = propertyInfo.Name,
                PropertyName2 = propertyInfo2.Name,
                Operator = op
            };
        }
        public static ISqlClass Group(GroupOperatorType op, params ISqlClass[] predicate)
        {
            return new PredicateGroup
            {
                Operator = op,
                Predicates = predicate
            };
        }
        public static ISqlClass Between<T>(Expression<Func<T, object>> expression, BetweenValues values)
            where T : class
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            return new BetweenPredicate
            {
                PropertyName = propertyInfo.Name,
                Value = values
            };
        }
    }
}
