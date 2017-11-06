using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Wayki.Models
{
    public class AudioVisualItem
    {
        public ImageSource AudioVisual
        {
            get
            {
                if (EsVideo)
                {
                    return ImageSource.FromFile("video.png");
                }
                return ImageSource.FromFile(Ruta); //.FromStream(() => { return FotoStream; });
            }
        }
        public MediaFile mediFile { get; set; }
        public bool EsVideo { get; set; }
        private string _ruta;
        public string Ruta
        {
            get
            {
                return _ruta;
            }
            set
            {
                _ruta = value;
                Bytes = File.ReadAllBytes(_ruta);
            }
        }
        public string Titulo { get; set; }

        public byte[] Bytes { set; get; }
    }
}
