using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcamp_Frontend.Data;
using System.Xml;
using System.Xml.Linq;

namespace Appcamp_Frontend.DataModel
{
    public sealed class DataProvider
    {
        public DataProvider()
        {
        }
        private static string message;
        public void Log(string msg)
        {
            message = msg;
        }
        public int getCount()
        {
            return _aDataSource.Count();
        }

        public void readXmlNode(XDocument oDoc)
        {
            XElement[] Elements = oDoc.Descendants("story").ToArray();
            string uid ,title, subtitle, imagepath, description;
            foreach (XElement xe in Elements)
            {
                // TODO: add check to see if uid is actualy unique
                uid = xe.Element("uid").Value.ToString();
                title = xe.Element("title").Value.ToString();
                subtitle = xe.Element("subtitle").Value.ToString();
                imagepath = xe.Element("image").Value.ToString();
                description = xe.Element("description").Value.ToString();
                var group = new SampleDataGroup(uid, title, subtitle, imagepath, description);
                this.setGroup(group);
            }
        }
        //var group1 = dataProvider.getGroup(1);
        /*
         * simple dataSource
         */

        private static List<SampleDataGroup> _aDataSource = new List<SampleDataGroup>();
        /**
         * returns group.
         * 
         * @param name="iGroupNumber"
         *  
         * @returns SampleDataSource
         */
        public SampleDataGroup getGroup(int iGroupNumber = 0)
        {
            return _aDataSource.ElementAt<SampleDataGroup>(iGroupNumber);
        }

        /*
         * 
         * 
         */
        public void setGroup(SampleDataGroup oSource)
        {
            _aDataSource.Add(oSource);
        }

    }
}
