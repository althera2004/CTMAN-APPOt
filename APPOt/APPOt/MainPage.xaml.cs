using APPOt.Items;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace APPOt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.BtnLogin.Text = "Accediendo...";
            this.ErrorMessage.Text = string.Empty;
            var code = string.Empty;
            if (this.TxtCode.Text != null)
            {
                code = this.TxtCode.Text.Trim().ToUpperInvariant();
            }

            var pin = string.Empty;
            if (this.TxtPIN.Text != null)
            {
                pin = this.TxtPIN.Text.Trim().ToUpperInvariant();
            }

            if(string.IsNullOrEmpty(code) || string.IsNullOrEmpty(pin))
            {
                this.BtnLogin.Text = "ACCEDER";
                this.ErrorMessage.Text = "Código y PIN obligatorios";
                return;
            }

            WebServices appService = new WebServices();
            var res = appService.Get("http://ctman.constraula.com/CustomersFramework/Constraula/data/itemdatabase.aspx?dataservice=applogin&code=" + code + "&pin=" + pin);
            if (res.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                this.BtnLogin.Text = "ACCEDER";
                this.ErrorMessage.Text = "Servicio no disponible";
            }
            else
            {
                this.ErrorMessage.Text = res.Content;
                var loginResult = JsonConvert.DeserializeObject<LoginResult>(res.Content);
                if (loginResult.Success)
                {
                    this.ErrorMessage.Text = string.Empty;
                    this.BtnLogin.Text = "ACCEDER";
                    Navigation.PushAsync(new OTList(loginResult.Id));
                }
                else
                {
                    this.BtnLogin.Text = "ACCEDER";
                    this.ErrorMessage.Text = "Acceso no valido";
                }
            }
        }
    }
}