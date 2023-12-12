using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane_otomasyon_n96
{
    internal class Hasta
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Poliklinik {  get; set; }
        public bool Sigorta {  get; set; }
        public DateTime KayitTarih {  get; set; }

        public Hasta(int id, string adsoyad, string tel, string pol, bool sigorta, DateTime tarih) {
            Id = id;
            AdSoyad = adsoyad;
            Telefon = tel;
            Poliklinik = pol;
            Sigorta = sigorta;
            KayitTarih = tarih;
        }
    }
}
