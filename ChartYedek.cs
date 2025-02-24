using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Para
{
    public partial class ChartYedek : Form
    {
        public ChartYedek()
        {
            InitializeComponent();
        }

        private void ChartYedek_Load(object sender, EventArgs e)
        {
            /* try
             {
                 stopwatch.Reset();
                 stopwatch.Start();
             }
             catch { }
             try
             {
                 label14.Text = "Chart Hesap: Hesaplanıyor..";

                 chartControl1.Series[0].Points.Clear();
                 chartControl2.Series[0].Points.Clear();
                 chartControl2.Series[1].Points.Clear();

                 DataTable dt = new DataTable();//DS OLUR CHART YAPICAKSAN
                 using (SqlDataAdapter al = new SqlDataAdapter("select * from dbo.fn_ChartControl1() ", bag))
                 {
                     bag.Open();
                     al.Fill(dt);
                     bag.Close();
                 }

                 //-- EN SON HESAPTAKİ YUZDEORT eğer CHART1DEKİ yüzdelerden 1TANESİ BİLE - olursa yuzdeort'lere 0 yaz.
                 bool contains = dt.AsEnumerable().Any(row => row.Field<double>("tugcanBarHesap") < 0);
                 if (contains == false)//eğer EKSİ bir yüzde yoksa hesaplamaya devam et
                 {
                     riskyuzde = (double)dt.Compute("AVG([tugcanBarHesap])", "");
                     GENELriskyuzde = Convert.ToDouble(dt.Rows[0]["tugcanBarHesap"]);
                 }
                 else//EKSİ yüzde var o yüzden risk yüzdesi hesaplama
                 {
                     riskyuzde = 0;
                     GENELriskyuzde = 0;
                 }
                 stopwatch.Stop();

                 try
                 {
                     DataTable d = ds.Tables[0];
                     if (d != null && d.Rows.Count >= 0)
                     {
                         for (int i = 0; i < d.Rows.Count; i++)
                         {
                             if (i == 0)//SON SATIR ORTALAMA
                                 chartControl1.Series[0].Points.AddPoint("%" + Convert.ToString(d.Rows[i]["zamanDil"]), Convert.ToDouble(d.Rows[i]["tugcanBarHesap"]));
                             else
                                 chartControl1.Series[0].Points.AddPoint(Convert.ToString(d.Rows[i]["zamanDil"]) + "H", Convert.ToDouble(d.Rows[i]["tugcanBarHesap"]));
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     Log(ex, "BackGroundWorker CHARTCONTROL DT=d2 chart2 eklerken hata.");
                     chartControl1.Series[0].Points.Clear();
                 }

                 try
                 {
                     DataTable d2 = ds.Tables[1];
                     if (d2 != null && d2.Rows.Count >= 0)
                     {
                         for (int i = 0; i < d2.Rows.Count; i++)
                         {
                             chartControl2.Series[0].Points.AddRangePoint(Convert.ToInt32(d2.Rows[i]["zamanDil"]) + "H", Convert.ToDouble(d2.Rows[i]["MIN_Yuzde"]), Convert.ToDouble(d2.Rows[i]["MAX_Yuzde"]));

                             chartControl2.Series[1].Points.AddPoint(Convert.ToInt32(d2.Rows[i]["zamanDil"]) + "H", Math.Round(Convert.ToDouble(d2.Rows[i]["Ortalama_Yuzde"]), 2));
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     Log(ex, "BackGroundWorker CHARTCONTROL DT=d2 chart2 eklerken hata.");
                     chartControl2.Series[0].Points.Clear();
                     chartControl2.Series[1].Points.Clear();
                 }

             }
             catch (Exception ex)
             {
                 Log(ex, "BackGroundWorkerHESAPYUZDE ChartSeriesSıfırlayamadı veya dataset dolduramadı. Kontrol edilmeli");
                 chartControl1.Series[0].Points.Clear();
                 chartControl2.Series[0].Points.Clear();
                 chartControl2.Series[1].Points.Clear();
             }

             try
             {
                 stopwatch.Stop();
                 TimeSpan ts = stopwatch.Elapsed;
                 label14.Text = "Chart Hesap: " + ts.Seconds + "." + (ts.Milliseconds / 10) + " sn";
             }
             catch (Exception ex) { Log(ex, "BackGroundWorker STOPWATCH STOP Hata!"); }*/
        }
    }
}
