using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcamp_Frontend.Data;

namespace Appcamp_Frontend.DataModel
{
    class DataProvider<T>
    {
        //var group1 = dataProvider.getGroup(1);
        private SampleDataSource[] _dataSource;

        /**
         * returns group.
         * 
         * @param name="iGroupNumber"
         *  
         * @returns SampleDataSource
         */
        public SampleDataSource getGroup(int iGroupNumber)
        {
            return new SampleDataSource();
        }

        /*
         * 
         * 
         */
        public void setGroup(SampleDataSource oSource)
        {

        }

    }
}
