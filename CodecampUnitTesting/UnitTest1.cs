using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Appcamp_Frontend.DataModel;
using Appcamp_Frontend.Data;
using System.Xml;
using System.Xml.Linq;

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

            Assert.AreEqual(6, dataProvider.getCount());
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

            Assert.AreEqual(8, dataProvider2.getCount());
        }
        [TestMethod]
        public void testXmlReading()
        {
            DataProvider dataProvider = new DataProvider();
            XDocument testDoc = XDocument.Parse("<document>                                                                     " +
"                                  <story>                                       " +
"                                    <uid>Tove</uid>                              " +
"                                    <title>Tove</title>                              " +
"                                    <subtitle>Jani</subtitle>                          " +
"                                    <image>Reminder</image>                " +
"                                    <description>Don't forget me this weekend!</description> " +
"                                  </story>                                      " +
"                                  <story>                                       " +
"                                    <uid>Dove</uid>                              " +
"                                    <title>Someone special</title>                   " +
"                                    <subtitle>Janina</subtitle>                        " +
"                                    <image>Miner</image>                   " +
"                                    <description>forget me !</description>                   " +
"                                  </story>                                      " +
"                                </document>");                                  


            //dataProvider.readXmlNode(testDoc);

            //Assert.AreEqual(10, dataProvider.getCount());


        }

       
    }
}
