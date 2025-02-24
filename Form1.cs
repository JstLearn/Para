using DevExpress.Utils.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Para
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=IP;Initial Catalog=..;User Id=..;Password=..;");
        string SqlConnectionSTRING = "";
        string tabload = "Para";
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch stopwatchCANLIVERI = new Stopwatch();
        public Boolean cmdCanlıVeri(string str)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                using (SqlCommand kmt = new SqlCommand(str, bag))
                {
                    if (bag.State == ConnectionState.Closed)
                        bag.Open();

                    kmt.ExecuteNonQuery();

                    if (bag.State == ConnectionState.Open)
                        bag.Close();
                }
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                label18.Text = "Canlı DB Write: " + ts.Seconds + "." + (ts.Milliseconds / 10) + " sn";
            }
            catch (Exception ex)
            { Log(ex, "CMD CANLIVERİ WRİTE"); }

            return false;
        }



        public Boolean cmdMessageboxNO(string str)
        {
            //try
            //{
            //    backgroundWorkerHESAPYUZDESI.CancelAsync();
            //}
            //catch (Exception ex)
            //{ Log(ex, "CMD WRİTE BACKGORUNDWORKET CANCEL YAPILAMADI"); }
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                using (SqlCommand kmt = new SqlCommand(str, bag))
                {
                    bag.Open();
                    kmt.ExecuteNonQuery();
                    bag.Close();
                }
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                label15.Text = "DB Write: " + ts.Seconds + "." + (ts.Milliseconds / 10) + " sn";

                //try
                //{
                //    int say = 0;
                //groundtekrar:
                //    if (say <= 3)
                //    {
                //        if (backgroundWorkerHESAPYUZDESI.IsBusy == true)
                //        {
                //            Thread.Sleep(50);
                //            say++;
                //            goto groundtekrar;
                //        }


                //        backgroundWorkerHESAPYUZDESI.RunWorkerAsync();
                //    }
                //    else
                //        return false;
                //}
                //catch (Exception ex)
                //{ Log(ex, "CMD WRİTE BACKGORUNDWORKET RUN YAPILAMADI"); }


                return true;
            }
            catch (Exception ex)
            {
                if (bag.State == ConnectionState.Open)
                    bag.Close();

                listBox1.Items.Add(ex.Message);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                Log(ex, "CMD DB Veri basamadı");
                return false;
            }

        }

        IWebDriver driver;
        NotifyIcon notify_Icon = new NotifyIcon();

        bool misliENTER(string username, string password)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.misli.com/");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN NAVIGATE URL misli HATA");
                return false;

            }

            try
            {
                IWebElement btnCEREZ = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
                btnCEREZ.Click();
            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN btncerezclick");
                return false;
            }

            try
            {
                //loginBtn txtWhite bgOrange login
                IWebElement btnGiris = driver.FindElement(By.XPath("/html/body/div[1]/div/div/header/div[1]/div/div/div/div/div[3]/div/button"));
                btnGiris.Click();

            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN btnGiris click");
                return false;
            }

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20) ");
                return false;
            }
            try
            {
                IWebElement userName = driver.FindElement(By.Name("username"));
                userName.SendKeys(username);

                IWebElement passWord = driver.FindElement(By.Name("password"));
                passWord.SendKeys(password);

            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN userName,password hatası ");
                return false;
            }

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN USERNAME VE PASSWORDAN SONRAKİ SATIR driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20) ");
                return false;
            }

            //#m-login > div > div.v--modal-box.v--modal > div > div.m-body > form > div:nth-child(6) > div > button

            try
            {
                IWebElement btnGiris2 = driver.FindElement(By.CssSelector("#m-login > div > div.v--modal-box.v--modal > div > div.m-body > form > div:nth-child(6) > div > button"));
                btnGiris2.Click();
            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver LOGIN btnGiris2 ");
                return false;
            }


            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                wait.Until(drv => drv.FindElement(By.Id("userBalance")));
            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE driver USERBALANCE WAİT ");
                return false;
            }


            try
            {
                driver.Navigate().GoToUrl("https://www.misli.com/dijital-oyunlar/ZEPPELIN");

            }
            catch (Exception ex)
            {
                Log(ex, "MISLIDEN EXE zeppelin link yüklenirken hata ");
                return false;
            }

            return true;
        }
        bool nesineENTER(string username, string password)
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.nesine.com/");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver LOGIN NAVIGATE URL misli HATA");
                return false;

            }

            try
            {
                IWebElement btnCEREZ = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div/button"));
                btnCEREZ.Click();
            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver LOGIN btncerezclick");
                return false;
            }

            /*  */

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver LOGIN driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20) ");
                return false;
            }
            try
            {
                IWebElement userName = driver.FindElement(By.Id("txtUsername"));
                userName.SendKeys(username);

                IWebElement passWord = driver.FindElement(By.Id("realpass"));
                passWord.SendKeys(password);

            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver LOGIN userName,password hatası ");
                return false;
            }

            try
            {
                //loginBtn txtWhite bgOrange login
                IWebElement btnGiris = driver.FindElement(By.XPath("/html/body/div[1]/header/div[3]/div/div[2]/div[2]/div[1]/form/a"));
                btnGiris.Click();
            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver LOGIN btnGiris click");
                return false;
            }


            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver LOGIN USERNAME VE PASSWORDAN SONRAKİ SATIR driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20) ");
                return false;
            }

            //#m-login > div > div.v--modal-box.v--modal > div > div.m-body > form > div:nth-child(6) > div > button




            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                wait.Until(drv => drv.FindElement(By.Id("spnMemberName")));
            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE driver USERBALANCE WAİT ");
                return false;
            }


            try
            {
                driver.Navigate().GoToUrl("https://www.nesine.com/sans-oyunlari/zeplin");

            }
            catch (Exception ex)
            {
                Log(ex, "NESINE EXE zeppelin link yüklenirken hata ");
                return false;
            }

            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            notify_Icon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);



            StreamReader Kayit = new StreamReader(@"ayarlar.txt");
            string[] veri = Kayit.ReadToEnd().Split(',');
            Kayit.Dispose();
            if (veri.Length != 5) { MessageBox.Show("Ayarlarda 5tane veri olması gerekir. KULAD,KULPW,SQLCONNECTİON,TİMERSANİYESİ,TABLOADI"); return; }

            if (string.IsNullOrEmpty(veri[0]) || string.IsNullOrEmpty(veri[1]) || string.IsNullOrEmpty(veri[2]))
            {
                MessageBox.Show("Boş alan bırakma babaoğlu");
                return;

            }
            else
            {
                bag.ConnectionString = veri[2];
                SqlConnectionSTRING = veri[2];
                try
                {
                    bag.Open();
                    bag.Close();
                }
                catch (Exception ex) { Log(ex, "EXE start bağlantı conn"); return; }
            }

            timer1.Interval = Convert.ToInt32(veri[3]);

            Random rnd = new Random();
            this.Text = "Yolunda A.Ş. User: " + veri[0].Substring(0, 4) + " RND: " + rnd.Next(0, 100);



            // this.BackColor = Color.Gray;
            label20.Text = "Oyun yükleniyor..";
            tabload = Convert.ToString(veri[4]);

            Exception ex2 = null;
            Log(ex2, "EXE Başlatıldı.");


            try
            {
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                var options = new ChromeOptions();
                // options.AddArgument("--headless=new");//browser hide 111 güncelleyince bu
                //options.AddArgument("headless");
                options.AddArgument("mute-audio");//SES
                options.AddArgument("no-sandbox");
                driver = new ChromeDriver(service, options);


            }
            catch (Exception ex)
            {
                Log(ex, "EXE driver options hata");
                EXERetry();
            }

            if (false == misliENTER(veri[0], veri[1]))
            {
                if (false == nesineENTER(veri[0], veri[1]))
                {
                }
                else
                    this.Text = "NESINE " + this.Text;
            }
            else
                this.Text = "MISLI " + this.Text;

            try
            {
                IWebElement detailFrame = driver.FindElement(By.XPath("//iframe[@id='gameIFrame']"));
                driver.SwitchTo().Frame(detailFrame);
            }
            catch (Exception ex)
            {
                Log(ex, "EXE driver LOGIN  IFRAME= gameIfarame ");
                EXERetry();
            }


            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(drv => drv.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[1]"))); // oyun yüklenmesini bekle !!
            }
            catch (Exception ex)
            {
                Log(ex, "EXE oyun yüklenmesini beklerken hata");
                EXERetry();
            }



            timer1.Start();
            timerSAAT.Start();
            timerBaslangicEXEHide.Start();
        }


        double gercekXdegerimiz = 0;
        bool yazayimmi = false;
        int sayfayenilenmesayi = 0;
        int sayfayenielemedene = 0;
        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
        void sayfaYenile()
        {
            try
            {

                var baglanti = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[2]/div/span").FirstOrDefault();
                if (baglanti != null)
                    if (!string.IsNullOrEmpty(baglanti.InnerText))
                    {
                        try
                        {
                        tekrarla:
                            if (sayfayenielemedene <= 3)//2 kere dönücek toplam 20saniye
                            {
                                driver.Navigate().Refresh();
                                try
                                {
                                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                                }
                                catch { }


                                //try
                                //{
                                //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                                //    wait.Until(drv => drv.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[1]"))); // oyun yüklenmesini bekle !!
                                //    sayfayenielemedene = 0;
                                //    //  sayfayenielemedene = 0;
                                //}
                                //catch (Exception ex)
                                //{
                                //    Log(ex, "Sayfa Yenileme Tekrarlamada");
                                //    sayfayenielemedene++;
                                //    goto tekrarla;
                                //}
                            }
                            else
                            { //##UYGULAMAYI YENİDEN BAŞLAT BUNU KAPAT
                                EXERetry();
                            }


                            IWebElement detailFrame = driver.FindElement(By.XPath("//iframe[@id='gameIFrame']"));
                            driver.SwitchTo().Frame(detailFrame);
                            sayfayenilenmesayi++;
                            label12.Text = "Sayfa Yenilenme Sayısı: " + sayfayenilenmesayi;


                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                            wait.Until(drv => drv.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-left-content/div[1]/div")));

                            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                            listBox1.Items.Add("Sayfa Yenileme Fonksiyonunda HATA değil!! - " + DateTime.Now.ToShortTimeString());
                            listBox1.SelectedIndex = listBox1.Items.Count - 1;

                        }
                        catch (Exception ex)
                        {
                            Log(ex, "SayfaYenilemeFonksiyonuHATA");
                            sayfayenielemedene++;
                            listBox1.Items.Add("SayfaYenilemeFonksiyonu HATA - " + DateTime.Now.ToShortTimeString() + " - " + ex.Message);
                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        }

                    }


            }
            catch
            {

            }
        }

        void EXERetry()
        {
            try
            {
                Exception ex = null;
                Log(ex, "EXE Yeniden Başlatıldı.");

                /* int arkaplanBEKLE = 0;

                 while (backgroundWorkerLOGWRITE.IsBusy)
                 {
                     Thread.Sleep(50);//MS

                     arkaplanBEKLE++;
                     if (arkaplanBEKLE >= 50)
                         break;
                 }
                 Process.Start(Application.ExecutablePath);
                 Thread.Sleep(1000);//MS
               */
            }
            catch { }
            try
            {
                //this.Close();//formu kapatıyoruz formClosing eventi için
            }
            catch
            { }
            try
            {
                //Application.Exit();
            }
            catch
            { }
            try
            {
                // Application.Exit();
            }
            catch
            { }
        }

        int trvarmiERROR = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();
            try
            {
                htmlDoc.LoadHtml(driver.PageSource);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no such window"))
                {
                    EXERetry();
                    return;
                }
            }

            sayfaYenile();
            // iframevarmı();
            double xdegerimiz = 0;
            double bahismiktari = 0, karlisatismiktari = 0, karlisatisadet = 0, satilmamismiktarTL = 0, cmdicinSatilmamisEnbuyukmiktar = 0;

            try
            {
                try
                {
                    var trvarmı = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody").Descendants("tr").Any();
                    //var trvarmı = htmlDoc.DocumentNode.Descendants("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody");
                    if (trvarmı == false)
                    {
                        trvarmiERROR = 0;//hata vermez ise errorsayi 0 la
                        timer1.Start();
                        return;
                    }

                }
                catch (Exception ex)
                {
                    trvarmiERROR++; //10kere hata verirse exe yeniden başlat.

                    if (trvarmiERROR >= 10)
                    {
                        EXERetry();
                        return;
                    }
                    //##BURADA TR ETİKETİNİ KONTROL ETMEN GEREKLİ HATAYA DÜŞMEMEK İÇİN ARAŞTIR !!
                    Log(ex, "trvarmı");
                    return;
                }
                //############# OYUN DURUMU SORGULAMA

                var oyundurumu2 = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-game-content/div/div[1]/span")[0];
                if (oyundurumu2 != null)
                {
                    var hidden = oyundurumu2.Attributes["hidden"];
                    if (hidden != null)
                    {


                        yazayimmi = true;
                        //############# SARI HİDDEN
                        //  cmdCanlıVeri("IF EXISTS (select CanliX FROM CanliVeri) BEGIN update CanliVeri set CanliX=0,OyunDurumu='Yellow',RiskYuzde=" + riskyuzde.ToString().Replace(",", ".") + ",GenelRiskYuzde=" + GENELriskyuzde.ToString().Replace(",", ".") + ",WriteTime=getdate() END ELSE BEGIN insert into CanliVeri (CanliX,OyunDurumu,RiskYuzde,GenelRiskYuzde) values (0,'Yellow'," + riskyuzde.ToString().Replace(",", ".") + "," + GENELriskyuzde.ToString().Replace(",", ".") + ") end");

                        label1.Text = "X: " + xdegerimiz;
                        if (gercekXdegerimiz != 0)
                            label1.Text += " Gerçek X:" + gercekXdegerimiz;

                        //this.BackColor = Color.Gold;
                        label20.Text = "Oyun Başlatılıyor.";
                        gercekXdegerimiz = 0;

                        int tablouzunluk = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody/tr").Count();
                        if (tablouzunluk != 0)
                        {
                            for (int i = 0; i < tablouzunluk; i++)
                            {
                                var tr = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody/tr")[i];
                                if (tr != null)
                                {
                                    string bahisadetiSTR = tr.SelectNodes("td")[1].InnerText.Replace(".", ",");
                                    bahismiktari += Convert.ToDouble(bahisadetiSTR);
                                }

                            }

                            label5.Text = "Bahis ADET: " + tablouzunluk;
                            label8.Text = "Bahis Miktar: " + Math.Round(bahismiktari, 2) + " TL";
                        }
                        //yedekHtmlDOC = htmlDoc;

                        //############# SARI BİTTİ
                    }
                    else
                    {

                        var BahisADET = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody/tr").Count();
                        string X = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-game-content/div/div[1]/span/b")[0].InnerText;
                        string ximi = Convert.ToString(X).Trim().Replace(".", ",");
                        ximi = ximi.Substring(0, ximi.Length - 1);
                        xdegerimiz = Convert.ToDouble(ximi);
                        label1.Text = "X: " + xdegerimiz.ToString();
                        if (gercekXdegerimiz != 0)
                            label1.Text += " Gerçek X:" + gercekXdegerimiz;

                        for (int i = 0; i < BahisADET; i++)
                        {
                            //############# BAHİSLER TABLOSUNDAN TR TAGLARININ İÇİNİ OKUYORUZ
                            var tr = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody/tr")[i];
                            if (tr != null)
                            {
                                string bahisadetiSTR = tr.SelectNodes("td")[1].InnerText.Replace(".", ",");
                                bahismiktari += Convert.ToDouble(bahisadetiSTR);

                                var d2 = tr.Attributes["class"];
                                if (d2 != null)
                                {
                                    //############# KARLI SATIŞLAR
                                    string a = Convert.ToString(d2.Value);
                                    if (a == "active-row")
                                    {
                                        string karlisatisTL = tr.SelectNodes("td")[3].SelectSingleNode("span").InnerText.Trim().Replace(".", ",");
                                        karlisatisTL = karlisatisTL.Substring(0, karlisatisTL.Length - 1);
                                        karlisatismiktari += Convert.ToDouble(karlisatisTL);
                                        karlisatisadet++;
                                    }
                                    //############# KARLI SATIŞLAR ##BİTTİ


                                }
                                else
                                {
                                    //############# SATILMAMIŞLAR
                                    string satilmamisTL = tr.SelectNodes("td")[1].SelectSingleNode("span").InnerText.Trim().Replace(".", ",");
                                    satilmamisTL = satilmamisTL.Substring(0, satilmamisTL.Length - 1);
                                    satilmamismiktarTL += Convert.ToDouble(satilmamisTL);
                                    //############# SATILMAMIŞLAR ## BİTTİ
                                }


                            }
                            //############# BAHİSLER TABLOSUNDAN TR TAGLARININ İÇİNİ OKUYORUZ ## BİTTİ

                        }


                        label5.Text = "Bahis ADET: " + BahisADET;
                        label8.Text = "Bahis Miktar: " + Math.Round(bahismiktari, 2) + " TL";

                        label6.Text = "Karlı Satış Adet: " + karlisatisadet;
                        label9.Text = "Karlı Satış Miktar: " + Math.Round(karlisatismiktari, 2) + " TL";

                        label7.Text = "Satılmamış Adet: " + (BahisADET - karlisatisadet);

                        label2.Text = "Kasa kâr: " + Math.Round(bahismiktari - karlisatismiktari, 2) + " TL";

                        if (karlisatisadet == BahisADET && gercekXdegerimiz == 0)
                        {
                            gercekXdegerimiz = xdegerimiz;
                        }
                        label10.Text = "Satılmamış Miktar: " + Math.Round(satilmamismiktarTL * (Convert.ToDouble(ximi)), 2) + " TL";

                        string satilmamismiktarENBUYUK = "0";
                        var tr0 = htmlDoc.DocumentNode.SelectNodes("/html/body/app-root/div[1]/div/app-left-content/div[1]/div/div[2]/div[1]/div/div/table/tbody/tr")[0];
                        var tr0Class = tr0.Attributes["class"];
                        if (tr0Class != null)
                        {
                            string classValue = "";
                            try
                            {
                                classValue = Convert.ToString(tr0Class.Value);
                            }
                            catch { }

                            if (classValue == "active-row")
                            {
                                satilmamismiktarENBUYUK = "0";
                            }
                            else
                            {
                                satilmamismiktarENBUYUK = tr0.SelectNodes("td")[1].InnerText.Replace(".", ",").Trim();
                                satilmamismiktarENBUYUK = satilmamismiktarENBUYUK.Substring(0, satilmamismiktarENBUYUK.Length - 1);
                            }



                        }
                        else
                        {
                            satilmamismiktarENBUYUK = tr0.SelectNodes("td")[1].InnerText.Replace(".", ",").Trim();
                            satilmamismiktarENBUYUK = satilmamismiktarENBUYUK.Substring(0, satilmamismiktarENBUYUK.Length - 1);
                        }
                        cmdicinSatilmamisEnbuyukmiktar = Convert.ToDouble(satilmamismiktarENBUYUK);

                        label11.Text = "Satılmamış En Büyük Miktar: " + satilmamismiktarENBUYUK + " TL" + " - X Katı: " + Math.Round(Convert.ToDouble(satilmamismiktarENBUYUK) * (Convert.ToDouble(ximi)), 2) + " TL";
                        label3.Text = "Kasa kâr En Büyük Satarsa: " + Math.Round(bahismiktari - karlisatismiktari - Convert.ToDouble(satilmamismiktarENBUYUK) * (Convert.ToDouble(ximi)), 2) + " TL";
                        label4.Text = "Kasa kâr Herkes satarsa: " + Math.Round((bahismiktari - karlisatismiktari - (satilmamismiktarTL * (Convert.ToDouble(ximi)))), 2) + " TL";




                        var OyunDurumu2 = oyundurumu2.Attributes["class"].Value;
                        if (OyunDurumu2 == "game-box__container-inner-text")
                        {
                            // yedekHtmlDOC = htmlDoc;
                            //   cmdCanlıVeri("IF EXISTS (select CanliX FROM CanliVeri) BEGIN update CanliVeri set CanliX=" + xdegerimiz.ToString().Replace(",", ".") + ",OyunDurumu='Green',RiskYuzde=" + riskyuzde.ToString().Replace(",", ".") + ",GenelRiskYuzde=" + GENELriskyuzde.ToString().Replace(",", ".") + ",WriteTime=getdate() END ELSE BEGIN insert into CanliVeri (CanliX,OyunDurumu,RiskYuzde,GenelRiskYuzde) values (" + xdegerimiz.ToString().Replace(",", ".") + ",'Green'," + riskyuzde.ToString().Replace(",", ".") + "," + GENELriskyuzde.ToString().Replace(",", ".") + ") end");
                            // this.BackColor = Color.DarkSeaGreen;
                            label20.Text = "Oyunda..";
                            yazayimmi = true;
                        }
                        else
                        {

                            // this.BackColor = Color.IndianRed;
                            label20.Text = "Oyun Bitti.";
                            riskyuzde = 0;
                            GENELriskyuzde = 0;/*çalışmaya başladığı gibi sıfırlaki hata oluşturmuyalım*/

                            if (yazayimmi == true)
                            {
                                //cmdCanlıVeri("IF EXISTS (select CanliX FROM CanliVeri) BEGIN update CanliVeri set CanliX=0,OyunDurumu='Red',RiskYuzde=" + riskyuzde.ToString().Replace(",", ".") + ",GenelRiskYuzde=" + GENELriskyuzde.ToString().Replace(",", ".") + ",WriteTime=getdate() END ELSE BEGIN insert into CanliVeri (CanliX,OyunDurumu,RiskYuzde,GenelRiskYuzde) values (0,'Red'," + riskyuzde.ToString().Replace(",", ".") + "," + GENELriskyuzde.ToString().Replace(",", ".") + ") end");

                                double yazilanx = 0;
                                if (gercekXdegerimiz == 0)
                                    yazilanx = xdegerimiz;
                                else
                                    yazilanx = gercekXdegerimiz;


                                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(4000));
                                try //### MODAL AÇIK KALDIYSA KAPAT
                                {

                                    var element = wait.Until(condition =>
                                    {
                                        try
                                        {
                                            var elementToBeDisplayed = driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]"));
                                            if (elementToBeDisplayed.Displayed == true)
                                            {
                                                driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]/div/div/div[1]/button")).Click();
                                                return false;
                                            }
                                            else
                                                return true;
                                            //return elementToBeDisplayed.Displayed;
                                        }
                                        catch (StaleElementReferenceException)
                                        {
                                            return false;
                                        }
                                        catch (NoSuchElementException)
                                        {
                                            return false;
                                        }
                                        catch
                                        { return false; }
                                    });

                                }
                                catch
                                { }

                                Thread.Sleep(50);//DENİZ TUR NO KAÇIRMAMASI İÇİN KOYULDU MANTIK BİLMİYORUZ test edilecek çalışıyormu diye
                                try
                                {

                                    var element = wait.Until(condition =>
                                    {
                                        try
                                        {
                                            var elementToBeDisplayed = driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]"));
                                            if (elementToBeDisplayed.Displayed == false)
                                            {
                                                driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[1]/ul/li[2]")).Click();//#SON OYUN TIKLA

                                            }
                                            return elementToBeDisplayed.Displayed;
                                        }
                                        catch (StaleElementReferenceException)
                                        {
                                            return false;
                                        }
                                        catch (NoSuchElementException)
                                        {
                                            return false;
                                        }
                                        catch { return false; }
                                    });
                                }
                                catch (Exception ex)
                                { Log(ex, "SON OYUN GEÇMİŞİ TIKLA"); }

                                Thread.Sleep(50);//19.01.2024te koyuldu

                                // Thread.Sleep(1000);
                                string turno = "";
                                try
                                {
                                    var element = wait.Until(condition =>
                                    {
                                        try
                                        {
                                            var elementToBeDisplayed = driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]"));
                                            if (elementToBeDisplayed != null && elementToBeDisplayed.Displayed == true)
                                            {
                                                turno = driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]/div/div/div[2]/div/div[1]/div[2]/div/span")).Text;
                                                driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]/div/div/div[1]/button")).Click();//modal kapat

                                            }
                                            return elementToBeDisplayed.Displayed;
                                        }
                                        catch (StaleElementReferenceException)
                                        {
                                            return false;
                                        }
                                        catch (NoSuchElementException)
                                        {
                                            return false;
                                        }
                                    });

                                    //   turno = driver.FindElement(By.XPath("/html/body/app-root/div[1]/div/app-game-content/div/app-rounds-history/div[3]/div/div/div[2]/div/div[1]/div[2]/div/span")).Text;
                                }
                                catch (Exception ex) { Log(ex, "TURNO AL VE MODAL KAPAT"); }


                                string[] list = turno.Split('_');

                                if (list.Length <= 1)
                                {
                                    Exception ex = null;
                                    Log(ex, "TURNO GELMEDİYSE");
                                    timer1.Start();
                                    return;
                                }

                                if (!string.IsNullOrEmpty(list[0]))
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        string str = "IF EXISTS (select turno from " + tabload + " where turno=" + list[0] + ") BEGIN update " + tabload + " set x='" + yazilanx + "',KasaKar='" + Math.Round(bahismiktari - karlisatismiktari, 2).ToString().Replace(",", ".") + "',KasaHerkesSatarsa='" + Math.Round((bahismiktari - karlisatismiktari - (satilmamismiktarTL * (Convert.ToDouble(ximi)))), 2).ToString().Replace(",", ".") + "',KasaEnBuyukSatarsa='" + Math.Round(bahismiktari - karlisatismiktari - Convert.ToDouble(cmdicinSatilmamisEnbuyukmiktar) * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "',BahisAdet='" + BahisADET + "',BahisMiktar='" + Math.Round(bahismiktari, 2).ToString().Replace(",", ".") + "',KarliSatisAdet='" + karlisatisadet + "',KarliSatisMiktar='" + Math.Round(karlisatismiktari, 2).ToString().Replace(",", ".") + "',SatilmamisAdet='" + (BahisADET - karlisatisadet).ToString().Replace(",", ".") + "',SatilmamisMiktar='" + Math.Round(satilmamismiktarTL * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "',SatilmamisEnBuyukMiktar='" + Math.Round(Convert.ToDouble(cmdicinSatilmamisEnbuyukmiktar) * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "',turno='" + list[0] + "' WHERE turno=" + list[0] + " END ELSE BEGIN insert into " + tabload + " (x,KasaKar,KasaHerkesSatarsa,KasaEnBuyukSatarsa,BahisAdet,BahisMiktar,KarliSatisAdet,KarliSatisMiktar,SatilmamisAdet,SatilmamisMiktar,SatilmamisEnBuyukMiktar,turno) values ('" + yazilanx + "','" + Math.Round(bahismiktari - karlisatismiktari, 2).ToString().Replace(",", ".") + "','" + Math.Round((bahismiktari - karlisatismiktari - (satilmamismiktarTL * (Convert.ToDouble(ximi)))), 2).ToString().Replace(",", ".") + "','" + Math.Round(bahismiktari - karlisatismiktari - Convert.ToDouble(cmdicinSatilmamisEnbuyukmiktar) * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "','" + BahisADET + "','" + Math.Round(bahismiktari, 2).ToString().Replace(",", ".") + "','" + karlisatisadet + "','" + Math.Round(karlisatismiktari, 2).ToString().Replace(",", ".") + "','" + (BahisADET - karlisatisadet).ToString().Replace(",", ".") + "','" + Math.Round(satilmamismiktarTL * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "','" + Math.Round(Convert.ToDouble(cmdicinSatilmamisEnbuyukmiktar) * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "','" + list[0] + "' ) END";
                                        if (true == cmdMessageboxNO(str))
                                            yazayimmi = false;
                                    }).Wait();
                                }

                                /*  if (true == cmdMessageboxNO("insert into " + tabload + " (x,KasaKar,KasaHerkesSatarsa,KasaEnBuyukSatarsa,BahisAdet,BahisMiktar,KarliSatisAdet,KarliSatisMiktar,SatilmamisAdet,SatilmamisMiktar,SatilmamisEnBuyukMiktar,turno) values ('" + yazilanx + "','" + Math.Round(bahismiktari - karlisatismiktari, 2).ToString().Replace(",", ".") + "','" + Math.Round((bahismiktari - karlisatismiktari - (satilmamismiktarTL * (Convert.ToDouble(ximi)))), 2).ToString().Replace(",", ".") + "','" + Math.Round(bahismiktari - karlisatismiktari - Convert.ToDouble(cmdicinSatilmamisEnbuyukmiktar) * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "','" + BahisADET + "','" + Math.Round(bahismiktari, 2).ToString().Replace(",", ".") + "','" + karlisatisadet + "','" + Math.Round(karlisatismiktari, 2).ToString().Replace(",", ".") + "','" + (BahisADET - karlisatisadet).ToString().Replace(",", ".") + "','" + Math.Round(satilmamismiktarTL * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "','" + Math.Round(Convert.ToDouble(cmdicinSatilmamisEnbuyukmiktar) * (Convert.ToDouble(ximi)), 2).ToString().Replace(",", ".") + "','" + list[0] + "' )"))
                                    yazayimmi = false;*/
                            }
                        }


                    }

                }

            }
            catch (Exception ex)
            {// Get stack trace for the exception with source file information

                try
                {
                    var st = new StackTrace(ex, true);
                    var frame = st.GetFrame(0);
                    // Get the line number from the stack frame
                    var line = frame.GetFileLineNumber();
                    //int line = (new StackTrace(ex, true)).GetFrame(0).GetFileLineNumber();

                    listBox1.Items.Add(line.ToString() + "Satırında - " + DateTime.Now.ToShortTimeString() + " hata: " + ex.Message);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                catch { }
                try
                {
                    Log(ex, "Genel Fonksiyon");
                }
                catch { }

            }
            //############# OYUN DURUMU SORGULAMA BİTİŞ



            timer1.Start();
        }

        string fileName = "Logs.txt";
        void Log(Exception ex, string fonk)
        {
            try
            {
                backgroundWorkerLOGWRITE.CancelAsync();
            }
            catch (Exception ex1)
            {
                Log(ex1, "EX1 LOG YAZILAMADI - " + ex.Message);
            }

            try
            {
                if (ex != null)
                {
                    string send = ex.Message + " **** Fonksiyon: " + fonk;
                    backgroundWorkerLOGWRITE.RunWorkerAsync(send);
                }
                else
                {
                    string send = "ex NULL **** Fonksiyon: " + fonk;
                    backgroundWorkerLOGWRITE.RunWorkerAsync(send);
                }
            }
            catch (Exception ex1)
            {

            }

        }

        private void timerSAAT_Tick(object sender, EventArgs e)
        {
            timerSAAT.Stop();
            label13.Text = "Saat: " + DateTime.Now.ToString("HH:mm:ss");
            timerSAAT.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timerSAAT.Stop();
            try
            {
                driver.Close();
            }
            catch { }
            try
            {
                driver.Quit();
            }
            catch { }
            try
            {
                driver.Dispose();
            }
            catch { }
            Application.Exit();

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            //NotifyIcon();
        }
        void NotifyIcon()
        {
            // notifyIcon için event ataması yaptık
            notify_Icon.MouseDoubleClick += new MouseEventHandler(notify_Icon_MouseDoubleClick);

            this.Hide();
            notify_Icon.Visible = true;
            notify_Icon.Text = "Para Çalışıyor..";
            notify_Icon.BalloonTipTitle = "Para çalışıyor..";
            notify_Icon.BalloonTipText = "Program sağ alt köşede konumlandı.";
            notify_Icon.BalloonTipIcon = ToolTipIcon.Info;
            notify_Icon.ShowBalloonTip(10000);


        }

        void notify_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notify_Icon.Visible = false;
        }


        private void timerBaslangicEXEHide_Tick(object sender, EventArgs e)
        {
            NotifyIcon();
            timerBaslangicEXEHide.Stop();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            NotifyIcon();
        }

        double riskyuzde = 0, GENELriskyuzde = 0;
        private void backgroundWorkerHESAPYUZDESI_DoWork(object sender, DoWorkEventArgs e)
        {
            riskyuzde = 0;
            GENELriskyuzde = 0;/*çalışmaya başladığı gibi sıfırlaki hata oluşturmuyalım*/
            label16.Text = "Risk Yüzde: Hesaplanıyor..";
            label17.Text = "Genel Risk Yüzde: Hesaplanıyor..";

            SqlConnection bagYUZDE = new SqlConnection(SqlConnectionSTRING);


            try
            {
                stopwatch.Reset();
                stopwatch.Start();
            }
            catch { }
            try
            {
                label14.Text = "Chart Hesap: Hesaplanıyor..";

                /*chartControl1.Series[0].Points.Clear();
                chartControl2.Series[0].Points.Clear();
                chartControl2.Series[1].Points.Clear();*/

                DataTable dt = new DataTable();
                try
                {
                    using (SqlDataAdapter al = new SqlDataAdapter("select * from dbo.fn_ChartControl1() ", bagYUZDE))
                    {
                        bagYUZDE.Open();
                        al.Fill(dt);
                        bagYUZDE.Close();
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
                }
                catch (Exception ex)
                {
                    riskyuzde = 0;
                    GENELriskyuzde = 0;
                    Log(ex, "SQLDataAdapter DataTable döndürürken hata.");
                }


                try
                {
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    label14.Text = "Chart Hesap: " + ts.Seconds + "." + (ts.Milliseconds / 10) + " sn";
                }
                catch (Exception ex) { Log(ex, "BackGroundWorker STOPWATCH STOP Hata!"); }

                label16.Text = "Risk Yüzde: %" + Math.Round(riskyuzde, 2).ToString();
                label17.Text = "Genel Risk Yüzde: %" + Math.Round(GENELriskyuzde, 2).ToString();


                bagYUZDE.Dispose();

            }
            catch (Exception ex)
            {
                Log(ex, "BackGroundWorkerHESAPYUZDE ChartSeriesSıfırlayamadı veya dataset dolduramadı. Kontrol edilmeli");
                /* chartControl1.Series[0].Points.Clear();
                 chartControl2.Series[0].Points.Clear();
                 chartControl2.Series[1].Points.Clear();*/
            }


        }

        private void backgroundWorkerLOGWRITE_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string msj = (string)e.Argument;
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    string writeText = "";
                    if (!string.IsNullOrEmpty(msj))
                        writeText = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " - " + msj + "\n------------------\n";
                    else
                        writeText = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " - Hata Mesajı YOK **** Fonksiyon: " + msj + "\n------------------\n";

                    fs.Close();
                    File.AppendAllText(fileName, Environment.NewLine + writeText);
                }
            }
            catch (Exception ex)
            { listBox1.Items.Add(DateTime.Now.ToShortTimeString() + " - backgroundWorkerLOGWRITE " + ex.Message); }
        }

        /*  private void backgroundWorkerHESAPYUZDESI_ProgressChanged(object sender, ProgressChangedEventArgs e)
          {
              label14.Text = "Chart Hesap (" + e.ProgressPercentage + "%)";
          }

          private void backgroundWorkerHESAPYUZDESI_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
          {
              if (e.Cancelled)
              {
                  label14.Text = "İşlem yetişemedi iptal edildi.";
              }
              else
              {
                  label14.Text = "Chart Hesap: " + e.Result;
              }
          }*/
    }
}
