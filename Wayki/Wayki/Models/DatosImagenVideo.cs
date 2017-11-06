using System;
using System.Collections.Generic;
using System.Text;

namespace Wayki.Models
{
   public class DatosImagenVideo
    {
        public bool IsVideo { get; set; }
        public byte[] Archivo { get; set; }
        public string Nombre { get; set; }
    }
}
