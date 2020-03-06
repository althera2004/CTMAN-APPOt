using APPOt.Items;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPOt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OtHijasList : ContentPage
	{
        private long userId;
        private long otPadreId;
        private ObservableCollection<OT> _listOfItems;

        public ObservableCollection<OT> ListOfItems
        {
            get
            {
                if (this._listOfItems == null)
                {
                    this._listOfItems = new ObservableCollection<OT>();
                }

                return this._listOfItems;

            }
            set
            {
                if (_listOfItems != value)
                {
                    _listOfItems = value;
                }
            }
        }

        public void LoadData()
        {
            _listOfItems = new ObservableCollection<Items.OT>();
            WebServices appService = new WebServices();
            var res = appService.Get("http://ctman.constraula.com/CustomersFramework/Constraula/data/itemdatabase.aspx?dataservice=appotlisthijas&userId=" + this.userId.ToString() + "&actuacionId=" + this.otPadreId.ToString());
            if (res.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {

            }
            else
            {
                _listOfItems = JsonConvert.DeserializeObject<ObservableCollection<OT>>(res.Content);
            }

            MyListView.ItemsSource = ListOfItems;
            MyListView.IsRefreshing = false;
        }

        public OtHijasList(long userId, long otPadreId)
        {
            this.userId = userId;
            this.otPadreId = otPadreId;
            InitializeComponent();
            LoadData();

            MyListView.ItemsSource = ListOfItems;
            MyListView.ItemSelected += Handle_ItemTapped;
            MyListView.RefreshCommand = new Command(() => {
                MyListView.IsRefreshing = true;
                LoadData(); // Here I loaded some items in my ListView
            });

            MyListView.IsRefreshing = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var item = (OT)e.SelectedItem;
            await Navigation.PushAsync(new OTFicha(item.Id));
        }
    }
}