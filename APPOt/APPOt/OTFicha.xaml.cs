using APPOt.Items;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPOt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OTFicha : ContentPage
	{
        private Image image;
        private OT ot;
        private int gallerId = 0;
        public OTFicha (long actuacionId)
		{
			InitializeComponent ();
            LoadData(actuacionId); 
        }

        private void LoadData(long actuacionId)
        {
            WebServices appService = new WebServices();
            var res = appService.Get("http://ctman.constraula.com/CustomersFramework/Constraula/data/itemdatabase.aspx?dataservice=appotbyid&actuacionId=" + actuacionId.ToString());
            if (res.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {

            }
            else
            {
                this.ot = JsonConvert.DeserializeObject<OT>(res.Content);

                this.BtnGaleria1.Text = "Fotos inicio (" + this.ot.I.ToString() + ")";
                this.BtnGaleria2.Text = "Fotos proceso (" + this.ot.P.ToString() + ")";
                this.BtnGaleria3.Text = "Fotos final (" + this.ot.F.ToString() + ")";

                this.LabelCodigoOT.Text = ot.C;
                this.LabelRosiman.Text = ot.R;
                this.LabelDireccion.Text = ot.D;

                if (string.IsNullOrEmpty(this.ot.R))
                {
                    this.RowRosmiman.Height = 0;
                }
            }
        }

        async void BtnGallery1_Clicked(object sender, System.EventArgs e)
        {
            this.gallerId = 1;
            var result = await CapturePhoto();
        }

        async void BtnGallery2_Clicked(object sender, System.EventArgs e)
        {
            this.gallerId = 2;
            var result = await CapturePhoto();
        }

        async void BtnGallery3_Clicked(object sender, System.EventArgs e)
        {
            this.gallerId = 3;
            var result = await CapturePhoto();
        }

        async void TakePhoto_Clicked(object sender, System.EventArgs e)
        {
            if(this.ot.F == 0)
            {
                await DisplayAlert("Atención", "No se puede acabar si no hay imágenes del final", "Aceptar");
                return;
            }

            var answer = await DisplayAlert("Finalizar fotos", "¿Está seguro que ha acabo de capturar imágenes?", "Sí", "No");
            if (answer)
            {
                var url = string.Format(
                           CultureInfo.InvariantCulture,
                           "http://ctman.constraula.com/CustomersFramework/Constraula/data/itemdatabase.aspx?DataService=appotacabar&actuacionId={0}",
                           this.ot.Id);

                WebServices appService = new WebServices();
                var res = appService.Get(url);
                if (res.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {

                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
        }

        async Task<bool> CapturePhoto()
        {
            var res = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        await DisplayAlert("Camera Permission", "Allow Gestión OTs to access your camera", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                    status = results[Permission.Camera];
                }

                if (status == PermissionStatus.Granted)
                {

                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return false;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        PhotoSize = PhotoSize.Medium,

                    });

                    if (file == null)
                    {
                        return false;
                    }

                    async Task SendFileToServer()
                    {
                        var content = new MultipartFormDataContent();
                        content.Add(new StreamContent(file.GetStream()), "\"file\"", $"\"{file.Path}\"");

                        var httpClient = new HttpClient();
                        // OTPhotoFromApp(image, codigoOT, actuacionId, adjudicacionId, galleryId)
                        var url = string.Format(
                            CultureInfo.InvariantCulture,
                            "http://ctman.constraula.com/CustomersFramework/Constraula/data/itemdatabase.aspx?DataService=appuploadImage&actuacionId={0}&galleryId={1}&codigoOT={2}&adjudicacionId={3}",
                            this.ot.Id,
                            this.gallerId,
                            this.ot.C,
                            this.ot.A);

                        var responseMsg = await httpClient.PostAsync(url, content);
                        var remotePath = await responseMsg.Content.ReadAsStringAsync();
                        LoadData(this.ot.Id);
                    }

                    await SendFileToServer();
                    res = true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            return res;
        }
    }
}