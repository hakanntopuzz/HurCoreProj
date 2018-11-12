using System;

namespace HurCoreProj.Service.DTO
{
    public class NewDetailDto
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Icerik { get; set; }
        public string Baslik { get; set; }
    }
}
