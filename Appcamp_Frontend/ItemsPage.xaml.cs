using Appcamp_Frontend.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Appcamp_Frontend.DataModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Appcamp_Frontend
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class ItemsPage : Appcamp_Frontend.Common.LayoutAwarePage
    {
        public ItemsPage()
        {
            this.InitializeComponent();
          
        }
        public async void httpRequest(string sParams) 
        {
            //Task<string> sResponse;
            try
            {
                var httpClient = new HttpClient();
                var url = new Uri("http://codecamp/index.php?"+sParams);
                var accessToken = "1234";
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                
                httpRequestMessage.Headers.Add(System.Net.HttpRequestHeader.Authorization.ToString(), string.Format("Bearer {0}", accessToken));
                httpRequestMessage.Headers.Add("User-Agent", "My user-Agent");
                var response = await httpClient.SendAsync(httpRequestMessage);
                DataProvider dataProvider = new DataProvider();
                
                var sStream = await response.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(sStream);
                dataProvider.readXmlNode(doc);



                //sResponse = response.ToString();
            }
            catch (Exception e)
            {

            }
        }
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override async void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            // TODO: Add dynamic data here
            DataProvider dataProvider = new DataProvider();

            String ITEM_CONTENT = String.Format("Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
                       "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");
            var group = new SampleDataGroup("Awesome group",
                    "Group Title: 1",
                    "Group Subtitle: 1",
                    "Assets/DarkGray.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            group.Items.Add(new SampleDataItem("Group-1-Item-1",
                    "Item Title: 1",
                    "Item Subtitle: 1",
                    "Assets/LightGray.png",
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    ITEM_CONTENT,
                    group));
            group.Items.Add(new SampleDataItem("Group-1-Item-2",
                    "Item Title: 2",
                    "Item Subtitle: 2",
                    "Assets/DarkGray.png",
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    ITEM_CONTENT,
                    group));

            dataProvider.setGroup(group);
            //httpRequest to fetch all data
            //httpRequest("titles");
            httpRequest("something");
            
            var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            
            this.DefaultViewModel["Items"] = sampleDataGroups;
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var groupId = ((SampleDataGroup)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(SplitPage), groupId);
        }
    }
}
