using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Appcamp_Frontend.DataModel;
using Appcamp_Frontend.Data;

namespace CodecampUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testGetter()
        {
            DataProvider dataProvider = new DataProvider();
            SampleDataGroup dataSource = new SampleDataGroup("1","test","subtest","none","desc");
            

            dataProvider.setGroup(dataSource);

            Assert.AreEqual(dataSource, dataProvider.getGroup(0));
        }
        [TestMethod]
        public void testCount()
        {
            DataProvider dataProvider = new DataProvider();
            SampleDataGroup dataSource = new SampleDataGroup("1", "test", "subtest", "none", "desc");


            dataProvider.setGroup(dataSource);
            dataProvider.setGroup(dataSource);
            dataProvider.setGroup(dataSource);
            dataProvider.setGroup(dataSource);
            dataProvider.setGroup(dataSource);

            Assert.AreEqual(5, dataProvider.getCount());
        }
        [TestMethod]
        public void testPersistence()
        {
            DataProvider dataProvider = new DataProvider();
            SampleDataGroup dataSource = new SampleDataGroup("1", "test", "subtest", "none", "desc"); 
            
            DataProvider dataProvider2 = new DataProvider();
            SampleDataGroup dataSource2 = new SampleDataGroup("2", "test2", "subtest2", "none2", "desc2");

            dataProvider.setGroup(dataSource);
            dataProvider2.setGroup(dataSource2);

            Assert.AreEqual(2, dataProvider2.getCount());
        }
    }
}
