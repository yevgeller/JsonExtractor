using JSONer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Text;

namespace JsonExtractor.Tests
{
    [TestClass]
    public class JSONConverterTests
    {
        string expected;
        DataTable dt;
        JSONConverter js;


        [TestInitialize]
        public void InitTest()
        {
            expected = "[{\r\n\t\"Prop1\":\"value1\",\r\n\t\"Prop2\":1\r\n},{\r\n\t\"Prop1\":\"value2\",\r\n\t\"Prop2\":2\r\n}]";
            js = new JSONConverter();
            
            dt = new DataTable();
            
            dt.Columns.Add(new DataColumn("Prop1"));
            dt.Columns.Add(new DataColumn("Prop2"));
            
            DataRow dr = dt.NewRow();
            dr[0] = "value1";
            dr[1] = 1;
            dt.Rows.Add(dr);

            DataRow dr2 = dt.NewRow();
            dr2[0] = "value2";
            dr2[1] = 2;
            dt.Rows.Add(dr2);
        }

        [TestCleanup]
        public void CleanUp()
        {
            js = null;
            dt = null;
        }


        [TestMethod]
        public void JSONConverter_TestConversion_IgnoreCase()
        {
            string s = js.ConvertValuesInDataTableToJSON(dt, false).ToString();
            Assert.AreEqual(s, expected);
        }

        [TestMethod]
        public void JSONConverter_TestConversion_HonorCase()
        {
            string s = js.ConvertValuesInDataTableToJSON(dt, true).ToString();
            Assert.AreNotEqual(s, expected);
            s = js.ConvertValuesInDataTableToJSON(dt, false).ToString();
            Assert.AreEqual(s, expected);
        }
    }
}
