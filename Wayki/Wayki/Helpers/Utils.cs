using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wayki.Helpers
{
    public class Utils
    {
        public static bool TieneInternet()
        {
            string CheckUrl = "http://google.com";
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 5000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                iNetResponse.Close();
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }
        public enum TipoSubida
        {
            FotoDeGaleria = 0,
            FotoDeCamara = 1,
            VideoDeGaleria = 2,
            VideoDeCamara = 3
        }



        public static async Task<bool> InicializarCamara(TipoSubida tipo, Page pagina)
        {
            await CrossMedia.Current.Initialize();
            switch (tipo)
            {
                case TipoSubida.FotoDeCamara:
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await pagina.DisplayAlert("Cámara no detectada", "No hemos detectado una cámara en tu dispositivo.", "Aceptar");
                        return false;
                    }
                    break;
                case TipoSubida.FotoDeGaleria:
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await pagina.DisplayAlert("Servicio no disponible", "Tu dispositivo no nos permite acceder a tu galería, por favor reinstala la aplicación.", "Aceptar");
                        return false;
                    }
                    break;
                case TipoSubida.VideoDeCamara:
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                    {
                        await pagina.DisplayAlert("Cámara no detectada", "No hemos detectado una cámara o tu dispositivo no nos permite usar la cámara para tomar videos.", "Aceptar");
                        return false;
                    }
                    break;
                case TipoSubida.VideoDeGaleria:
                    if (!CrossMedia.Current.IsPickVideoSupported)
                    {
                        await pagina.DisplayAlert("Servicio no disponible", "Tu dispositivo no nos permite acceder a tu galería para seleccionar un video, por favor reinstala la aplicación.", "Aceptar");
                        return false;
                    }
                    break;
            }
            return true;
        }
    }
}
