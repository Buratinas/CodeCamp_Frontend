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
            SampleDataSource dataSource = new SampleDataSource();
            

            dataProvider.setGroup(dataSource);

            Assert.Equals(dataSource, dataProvider.getGroup(1));
        }
    }
}
