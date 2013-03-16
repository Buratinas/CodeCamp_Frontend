using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcamp_Frontend.Data;

namespace Appcamp_Frontend.DataModel
{
    public class DataProvider
    {
        //var group1 = dataProvider.getGroup(1);
        /*
         * simple dataSource
         */
        private SampleDataSource[] _dataSource;

        // current _dataSource element
        private int _currentItem = 0;
        /**
         * returns group.
         * 
         * @param name="iGroupNumber"
         *  
         * @returns SampleDataSource
         */
        public SampleDataSource getGroup(int iGroupNumber = 0)
        {
            return new SampleDataSource();
        }

        /*
         * 
         * 
         */
        public void setGroup(SampleDataSource oSource)
        {
            this._dataSource[this._currentItem++] = oSource;
        }

    }
}
