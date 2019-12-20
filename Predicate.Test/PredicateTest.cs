using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Predicate.Class;
using Predicate.Class.Interface.Base;
using Predicate.Class.Type;
using Predicate.Class.Value;

namespace Predicate.Test
{
    public class TestObjectClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

    [TestClass]
    public class PredicateTest
    {
        //[TestMethod]
        [DataTestMethod]
        [DataRow(OperatorType.Eq, "Name = 'TestName'")]
        [DataRow(OperatorType.Ne, "Name != 'TestName'")]
        [DataRow(OperatorType.Gt, "Name > 'TestName'")]
        [DataRow(OperatorType.Ge, "Name >= 'TestName'")]
        [DataRow(OperatorType.Lt, "Name < 'TestName'")]
        [DataRow(OperatorType.Le, "Name <= 'TestName'")]
        [DataRow(OperatorType.Like, "Name LIKE 'TestName'")]
        [DataRow(OperatorType.LikeStart, "Name LIKE '%TestName'")]
        [DataRow(OperatorType.LikeEnd, "Name LIKE 'TestName%'")]
        [DataRow(OperatorType.LikeAll, "Name LIKE '%TestName%'")]
        [DataRow(OperatorType.In, "Name IN ('TestName')")]
        [DataRow(OperatorType.NotIn, "Name NOT IN ('TestName')")]
        [DataRow(OperatorType.IsNull, "Name IS NULL")]
        [DataRow(OperatorType.IsNotNull, "Name IS NOT NULL")]
        public void PredicatesFieldThreeParamsTest(OperatorType operatorType, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Name = "TestName" };

            ISqlClass sqlClass = Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(OperatorType.Like, MethodType.Lower, "LOWER(Name) LIKE LOWER('TestName')")]
        [DataRow(OperatorType.Like, MethodType.Upper, "UPPER(Name) LIKE UPPER('TestName')")]
        [DataRow(OperatorType.LikeStart, MethodType.Lower, "LOWER(Name) LIKE LOWER('%TestName')")]
        [DataRow(OperatorType.LikeStart, MethodType.Upper, "UPPER(Name) LIKE UPPER('%TestName')")]
        [DataRow(OperatorType.LikeEnd, MethodType.Lower, "LOWER(Name) LIKE LOWER('TestName%')")]
        [DataRow(OperatorType.LikeEnd, MethodType.Upper, "UPPER(Name) LIKE UPPER('TestName%')")]
        [DataRow(OperatorType.LikeAll, MethodType.Lower, "LOWER(Name) LIKE LOWER('%TestName%')")]
        [DataRow(OperatorType.LikeAll, MethodType.Upper, "UPPER(Name) LIKE UPPER('%TestName%')")]
        [DataRow(OperatorType.In, MethodType.Lower, "LOWER(Name) IN (LOWER('TestName'))")]
        [DataRow(OperatorType.In, MethodType.Upper, "UPPER(Name) IN (UPPER('TestName'))")]
        [DataRow(OperatorType.NotIn, MethodType.Lower, "LOWER(Name) NOT IN (LOWER('TestName'))")]
        [DataRow(OperatorType.NotIn, MethodType.Upper, "UPPER(Name) NOT IN (UPPER('TestName'))")]
        public void PredicatesFieldFourParamsTest(OperatorType operatorType, MethodType methodType, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Name = "TestName" };

            ISqlClass sqlClass = Predicates.Field<TestObjectClass>(e => e.Name, operatorType, methodType, _filter.Name);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(OperatorType.Like, MethodType.Lower, MethodType.Lower, "LOWER(Name) LIKE LOWER('TestName')")]
        [DataRow(OperatorType.Like, MethodType.Upper, MethodType.Lower, "UPPER(Name) LIKE LOWER('TestName')")]
        [DataRow(OperatorType.Like, MethodType.Lower, MethodType.Upper, "LOWER(Name) LIKE UPPER('TestName')")]
        [DataRow(OperatorType.Like, MethodType.Upper, MethodType.Upper, "UPPER(Name) LIKE UPPER('TestName')")]

        [DataRow(OperatorType.LikeStart, MethodType.Lower, MethodType.Lower, "LOWER(Name) LIKE LOWER('%TestName')")]
        [DataRow(OperatorType.LikeStart, MethodType.Upper, MethodType.Lower, "UPPER(Name) LIKE LOWER('%TestName')")]
        [DataRow(OperatorType.LikeStart, MethodType.Lower, MethodType.Upper, "LOWER(Name) LIKE UPPER('%TestName')")]
        [DataRow(OperatorType.LikeStart, MethodType.Upper, MethodType.Upper, "UPPER(Name) LIKE UPPER('%TestName')")]

        [DataRow(OperatorType.LikeEnd, MethodType.Lower, MethodType.Lower, "LOWER(Name) LIKE LOWER('TestName%')")]
        [DataRow(OperatorType.LikeEnd, MethodType.Upper, MethodType.Lower, "UPPER(Name) LIKE LOWER('TestName%')")]
        [DataRow(OperatorType.LikeEnd, MethodType.Lower, MethodType.Upper, "LOWER(Name) LIKE UPPER('TestName%')")]
        [DataRow(OperatorType.LikeEnd, MethodType.Upper, MethodType.Upper, "UPPER(Name) LIKE UPPER('TestName%')")]

        [DataRow(OperatorType.LikeAll, MethodType.Lower, MethodType.Lower, "LOWER(Name) LIKE LOWER('%TestName%')")]
        [DataRow(OperatorType.LikeAll, MethodType.Upper, MethodType.Lower, "UPPER(Name) LIKE LOWER('%TestName%')")]
        [DataRow(OperatorType.LikeAll, MethodType.Lower, MethodType.Upper, "LOWER(Name) LIKE UPPER('%TestName%')")]
        [DataRow(OperatorType.LikeAll, MethodType.Upper, MethodType.Upper, "UPPER(Name) LIKE UPPER('%TestName%')")]

        [DataRow(OperatorType.In, MethodType.Lower, MethodType.Lower, "LOWER(Name) IN (LOWER('TestName'))")]
        [DataRow(OperatorType.In, MethodType.Upper, MethodType.Lower, "UPPER(Name) IN (LOWER('TestName'))")]
        [DataRow(OperatorType.In, MethodType.Lower, MethodType.Upper, "LOWER(Name) IN (UPPER('TestName'))")]
        [DataRow(OperatorType.In, MethodType.Upper, MethodType.Upper, "UPPER(Name) IN (UPPER('TestName'))")]

        [DataRow(OperatorType.NotIn, MethodType.Lower, MethodType.Lower, "LOWER(Name) NOT IN (LOWER('TestName'))")]
        [DataRow(OperatorType.NotIn, MethodType.Upper, MethodType.Lower, "UPPER(Name) NOT IN (LOWER('TestName'))")]
        [DataRow(OperatorType.NotIn, MethodType.Lower, MethodType.Upper, "LOWER(Name) NOT IN (UPPER('TestName'))")]
        [DataRow(OperatorType.NotIn, MethodType.Upper, MethodType.Upper, "UPPER(Name) NOT IN (UPPER('TestName'))")]
        public void PredicatesFieldFiveParamsTest(OperatorType operatorType, MethodType methodType1, MethodType methodType2, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Name = "TestName" };

            ISqlClass sqlClass = Predicates.Field<TestObjectClass>(methodType1, e => e.Name, operatorType, methodType2, _filter.Name);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(OperatorType.Eq, "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') = TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        [DataRow(OperatorType.Ne, "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') != TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        [DataRow(OperatorType.Gt, "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') > TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        [DataRow(OperatorType.Ge, "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') >= TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        [DataRow(OperatorType.Lt, "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') < TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        [DataRow(OperatorType.Le, "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') <= TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        public void PredicatesFieldDateThreeParamsTest(OperatorType operatorType, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Date = new DateTime(2019, 1, 1, 0, 0, 0) };

            ISqlClass sqlClass = Predicates.FieldDate<TestObjectClass>(e => e.Date, operatorType, _filter.Date);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(OperatorType.Eq, "DD.MM.YYYY", "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY'), 'DD.MM.YYYY') = TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY')")]
        [DataRow(OperatorType.Ne, "DD.MM.YYYY HH24:MI", "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI'), 'DD.MM.YYYY HH24:MI') != TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI')")]
        [DataRow(OperatorType.Gt, "DD.MM", "TO_DATE(TO_CHAR(Date, 'DD.MM'), 'DD.MM') > TO_DATE('01.01.2019 0:00:00', 'DD.MM')")]
        [DataRow(OperatorType.Ge, "DD", "TO_DATE(TO_CHAR(Date, 'DD'), 'DD') >= TO_DATE('01.01.2019 0:00:00', 'DD')")]
        [DataRow(OperatorType.Lt, "DD.MM.YYYY HH24", "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24'), 'DD.MM.YYYY HH24') < TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24')")]
        [DataRow(OperatorType.Le, "DD.MM.YYYY HH24:MI:SS", "TO_DATE(TO_CHAR(Date, 'DD.MM.YYYY HH24:MI:SS'), 'DD.MM.YYYY HH24:MI:SS') <= TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY HH24:MI:SS')")]
        public void PredicatesFieldDateWithFormatTest(OperatorType operatorType, string format, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Date = new DateTime(2019, 1, 1, 0, 0, 0) };

            ISqlClass sqlClass = Predicates.FieldDate<TestObjectClass>(e => e.Date, operatorType, _filter.Date, format);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(OperatorType.Eq, "DD.MM.YYYY", "DD.MM.YYYY", "TRUNC(Date, 'DD.MM.YYYY') = TRUNC(TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY'), 'DD.MM.YYYY')")]
        [DataRow(OperatorType.Ne, "DD.MM.YYYY", "DD.MM.YYYY HH24:MI", "TRUNC(Date, 'DD.MM.YYYY HH24:MI') != TRUNC(TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY'), 'DD.MM.YYYY HH24:MI')")]
        [DataRow(OperatorType.Gt, "DD.MM.YYYY", "DD.MM.YYYY", "TRUNC(Date, 'DD.MM.YYYY') > TRUNC(TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY'), 'DD.MM.YYYY')")]
        [DataRow(OperatorType.Ge, "DD.MM.YYYY", "DD.MM.YYYY HH24:MI", "TRUNC(Date, 'DD.MM.YYYY HH24:MI') >= TRUNC(TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY'), 'DD.MM.YYYY HH24:MI')")]
        [DataRow(OperatorType.Lt, "DD.MM.YYYY", "DD.MM.YYYY", "TRUNC(Date, 'DD.MM.YYYY') < TRUNC(TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY'), 'DD.MM.YYYY')")]
        [DataRow(OperatorType.Le, "DD.MM.YYYY", "DD.MM.YYYY HH24:MI", "TRUNC(Date, 'DD.MM.YYYY HH24:MI') <= TRUNC(TO_DATE('01.01.2019 0:00:00', 'DD.MM.YYYY'), 'DD.MM.YYYY HH24:MI')")]
        public void PredicatesFieldDateTruncTest(OperatorType operatorType, string format, string truncFormat, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Date = new DateTime(2019, 1, 1, 0, 0, 0) };

            ISqlClass sqlClass = Predicates.FieldDateTrunc<TestObjectClass>(e => e.Date, operatorType, _filter.Date, format, truncFormat);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(OperatorType.Eq, "Id = Name")]
        [DataRow(OperatorType.Ne, "Id != Name")]
        [DataRow(OperatorType.Gt, "Id > Name")]
        [DataRow(OperatorType.Ge, "Id >= Name")]
        [DataRow(OperatorType.Lt, "Id < Name")]
        [DataRow(OperatorType.Le, "Id <= Name")]
        public void PredicatesPropertyTest(OperatorType operatorType, string result)
        {
            ISqlClass sqlClass = Predicates.Property<TestObjectClass, TestObjectClass>(e => e.Id, operatorType, e => e.Name);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(GroupOperatorType.And, OperatorType.Eq, "(Name = 'TestName')")]
        public void PredicatesGroupTest(GroupOperatorType groupOperatorType, OperatorType operatorType, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Name = "TestName" };

            ISqlClass sqlClass = Predicates.Group(groupOperatorType, Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name));

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(GroupOperatorType.And, OperatorType.Eq, "(Name = 'TestName' AND Name = 'TestName')")]
        [DataRow(GroupOperatorType.Or, OperatorType.Ne, "(Name != 'TestName' OR Name != 'TestName')")]
        public void PredicatesGroup_2Test(GroupOperatorType groupOperatorType, OperatorType operatorType, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Name = "TestName" };

            ISqlClass sqlClass = Predicates.Group(groupOperatorType,
                Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name),
                Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name));

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(GroupOperatorType.And, OperatorType.Eq, "(Name = 'TestName' AND Name = 'TestName' AND (Name = 'TestName' AND Name = 'TestName'))")]
        public void PredicatesGroup_3Test(GroupOperatorType groupOperatorType, OperatorType operatorType, string result)
        {
            TestObjectClass _filter = new TestObjectClass() { Name = "TestName" };

            ISqlClass sqlClass = Predicates.Group(groupOperatorType,
                Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name),
                Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name),
                Predicates.Group(groupOperatorType,
                    Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name),
                    Predicates.Field<TestObjectClass>(e => e.Name, operatorType, _filter.Name)));

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow(1, 2, "Name BETWEEN 1 AND 2")]
        [DataRow(1, 45, "Name BETWEEN 1 AND 45")]
        [DataRow(223, 2, "Name BETWEEN 223 AND 2")]
        public void PredicatesBetweenTest(object v1, object v2, string result)
        {
            BetweenValues betweenValues = new BetweenValues()
            {
                Value1 = v1,
                Value2 = v2
            };

            ISqlClass sqlClass = Predicates.Between<TestObjectClass>(e => e.Name, betweenValues);

            string sqlResult = sqlClass.GetSql();

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow("1", 1)]
        [DataRow("1.3", 1.3)]
        [DataRow("1.3,2", 1.3, 2)]
        [DataRow("1.3,2,'test'", 1.3, 2, "test")]
        [DataRow("'test'", "test")]
        [DataRow("1,2", 1, 2)]
        [DataRow("'name','name2'", "name", "name2")]
        [DataRow("Sql injection", "Select * from")]
        [DataRow("Sql injection", "Select")]
        public void ValueTest(string result, params object[] values)
        {
            ValueClass valueClass;

            if (values.Length == 1)
                valueClass = new ValueClass(values[0]);
            else
                valueClass = new ValueClass(values);

            string sqlResult = "";

            try
            {
                sqlResult = $"{valueClass.Execute()}";
            }
            catch (Exception ex)
            {
                sqlResult = ex.Message;
            }

            Assert.AreEqual(sqlResult, result);
        }

        [DataTestMethod]
        [DataRow("1", 1)]
        [DataRow("1.3", 1.3)]
        [DataRow("1.3,2", 1.3, 2)]
        [DataRow("1.3,2,test", 1.3, 2, "test")]
        [DataRow("test", "test")]
        [DataRow("1,2", 1, 2)]
        [DataRow("name,name2", "name", "name2")]
        [DataRow("Sql injection", "Select * from")]
        [DataRow("Sql injection", "Select")]
        public void IsCodeValueTest(string result, params object[] values)
        {
            IsCodeValueClass valueClass;

            if (values.Length == 1)
                valueClass = new IsCodeValueClass(values[0]);
            else
                valueClass = new IsCodeValueClass(values);

            string sqlResult = "";

            try
            {
                sqlResult = $"{valueClass.Execute()}";
            }
            catch (Exception ex)
            {
                sqlResult = ex.Message;
            }

            Assert.AreEqual(sqlResult, result);
        }
    }
}
