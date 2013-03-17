using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcamp_Frontend.Data;
using System.Xml;
using System.Xml.Linq;
using Windows.Storage;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace Appcamp_Frontend.DataModel
{
    public sealed class DataProvider
    {
        public DataProvider()
        {
        }
        public static string message 
        {
            get { return message; }
            private set { }
        }

        
        public int getCount()
        {
            return _aDataSource.Count();
        }

        public static async void readData()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                var file = await localFolder.GetFileAsync("data.txt");

                //var file = localFolder.GetFileAsync("data.txt");

                var read = await FileIO.ReadTextAsync(file);
                readXmlNode(XDocument.Parse(read));
                message = "Success";
                return;
            }
            catch ( Exception e )
            {
                message = e.Message;
            }
            try
            {
                var sFile = await localFolder.CreateFileAsync("data.txt");
            }
            catch (Exception e)
            {
                message = e.Message;
            }

        }

        public static void readXmlNode(XDocument oDoc)
        {
            XElement[] Elements = oDoc.Descendants("Titles").ToArray();
            string uid ,title, subtitle, imagepath, description;
            foreach (XElement xe in Elements)
            {
                // TODO: add check to see if uid is actualy unique
                uid = xe.Element("uid").Value.ToString();
                if (SampleDataSource.GetGroup(uid) != null) continue;
                title = xe.Element("title").Value.ToString();
                subtitle = xe.Element("subtitle").Value.ToString();
                imagepath = xe.Element("image").Value.ToString();
                description = xe.Element("description").Value.ToString();
                var group = new SampleDataGroup(uid, title, subtitle, imagepath, description);
                //this.setGroup(group);
                
                SampleDataSource.setGroup(group);
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
        public async void httpRequest(string sParams)
        {
            //Task<string> sResponse;
            try
            {
                var httpClient = new HttpClient();
                var url = new Uri("http://codecamp/index.php?" + sParams);
                var accessToken = "1234";
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                httpRequestMessage.Headers.Add(System.Net.HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", accessToken));
                httpRequestMessage.Headers.Add("User-Agent", "My user-Agent");
                var response = await httpClient.SendAsync(httpRequestMessage);
                DataProvider dataProvider = new DataProvider();

                var sStream = await response.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(sStream);

                DataProvider.readXmlNode(doc);



                //sResponse = response.ToString();
            }
            catch (Exception e)
            {

            }
        }
    }
}
