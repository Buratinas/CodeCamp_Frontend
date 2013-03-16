using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcamp_Frontend.Data;

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
