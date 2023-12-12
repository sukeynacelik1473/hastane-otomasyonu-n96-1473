using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_otomasyon_n96
{

    
    public partial class Form1 : Form
    {
       BindingList<Hasta>hastalar=new BindingList<Hasta>();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hasta hasta1 = new Hasta(1, "polat alemdar", "121212454", "göz", false, new DateTime(2023, 11, 12));
            Hasta hasta2 = new Hasta(2, "büşra şahin", "8545645454", "burun", true , new DateTime(2023, 1, 11));
            Hasta hasta3 = new Hasta(3, "rabiya kılıç", "874678454", "kulak", false, new DateTime(2023, 12, 12));
            Hasta hasta4 = new Hasta(4, "deniz baş", "78574812454", "boğaz", true , new DateTime(2023, 11, 11));

            hastalar.Add(hasta1);
            hastalar.Add(hasta2);
            hastalar.Add(hasta3);
            hastalar.Add(hasta4);

            dataGridView1.DataSource = hastalar;//hastalar listenin datagrid içine ekler
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //DataGridView üzerindeki seçili seçili satırı hasta türünde alır.
                //hasta türünde dönüştürmek için (hasta) dönüşümü yapılır.
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = hasta.Id.ToString();
                txtAd.Text = hasta.AdSoyad;
                txtTelefon.Text = hasta.Telefon;
                cmbPolikinlik.Text = hasta.Poliklinik;
                cbSigorta.Checked = hasta.Sigorta;
                dateTimePicker1.Value = hasta.KayitTarih;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string adSoyad = txtAd.Text;
            string telefon = txtTelefon.Text;
            string pol = cmbPolikinlik.Text;
            bool sigorta = cbSigorta.Checked;
            DateTime tarih = DateTime.Now;
            Hasta hasta = new Hasta(id, adSoyad, telefon, pol, sigorta, tarih);

            hastalar.Add(hasta);

            txtId.Clear();
            txtAd.Clear();
            txtTelefon.Clear();
            cbSigorta.Checked=false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                //hasta.Id = Convert.ToInt32(txtId.Text);
                hasta.AdSoyad = txtAd.Text;
                hasta.Telefon = txtTelefon.Text;
                hasta.Poliklinik = cmbPolikinlik.Text ;
                hasta.Sigorta = cbSigorta.Checked;
                hasta.KayitTarih = dateTimePicker1.Value;

                dataGridView1.Refresh();// datagridview yeniden yüklenir
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mesaj = hasta.AdSoyad + "silinsin mi?";
                DialogResult sonuc =  MessageBox.Show( mesaj , "kayıt silme",MessageBoxButtons.YesNo,MessageBoxIcon.Error);

                if(sonuc == DialogResult.Yes)
                {
                    hastalar.Remove(hasta);
                }


            }
        }
    }
}
