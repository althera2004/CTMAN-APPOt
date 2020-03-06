using APPOt.Items;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPOt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OTList : ContentPage
    {
        private long userId;
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
            var res = appService.Get("http://ctman.constraula.com/CustomersFramework/Constraula/data/itemdatabase.aspx?dataservice=appotlist&userId=" + this.userId.ToString());
            if (res.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                
            }
            else
            {
                _listOfItems = JsonConvert.DeserializeObject<ObservableCollection<OT>>(res.Content);                
            }
            /*_listOfItems = new ObservableCollection<Items.OT>
            {
                new Items.OT
                {
                    Id =1,
                     CodigoOT ="weke1",
                     Rosmiman ="338098/ee09/2020",
                     Direccion ="13 rue del percebe",
                     HasHijas=false
                },
                new Items.OT
                {
                    Id =13,
                     CodigoOT ="weke 2",
                     Direccion ="América 89",
                     HasHijas=true
                },
                new Items.OT
                {
                    Id =41,
                     CodigoOT ="weke 3",
                     Rosmiman ="44444/FAD4/2020",
                     Direccion ="weke weke del congost n5",
                     HasHijas=false
                }
            };*/

            MyListView.ItemsSource = ListOfItems;
            MyListView.IsRefreshing = false;
        }

        public OTList(long userId)
        {
            this.userId = userId;
            //var timer = new Timer(TimerMethod, null, 10000, 5000);
            InitializeComponent();
            LoadData();

            /*_listOfItems = new ObservableCollection<Items.OT>
            {
                new Items.OT
                {
                    Id =1,
                     CodigoOT ="LO08-OT 0001",
                     Rosmiman ="338098/ee09/2020",
                     Direccion ="13 rue del percebe",
                     HasHijas=false
                },
                new Items.OT
                {
                    Id =13,
                     CodigoOT ="LO08-OT 23431",
                     Direccion ="América 89",
                     HasHijas=true
                },
                new Items.OT
                {
                    Id =41,
                     CodigoOT ="INH-0001",
                     Rosmiman ="44444/FAD4/2020",
                     Direccion ="weke weke del congost n5",
                     HasHijas=false
                }
            };*/

            MyListView.ItemsSource = ListOfItems;
            MyListView.ItemSelected += Handle_ItemTapped;
            MyListView.RefreshCommand = new Command(() => {
                MyListView.IsRefreshing = true;
                LoadData(); // Here I loaded some items in my ListView
            });
            MyListView.IsRefreshing = false;
        }

        private void TimerMethod(object state)
        {
            LoadData();
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
            if (item.H)
            {
                await Navigation.PushAsync(new OtHijasList(this.userId, item.Id));
            }
            else
            {
                await Navigation.PushAsync(new OTFicha(item.Id));

            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}