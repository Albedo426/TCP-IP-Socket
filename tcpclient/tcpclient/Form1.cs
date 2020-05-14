using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace tcpclient
{
    public partial class Form1 : Form
    {
        private bool Kapatsorgu;
        DialogResult dr = DialogResult.No;
        Thread connents;
        static Socket dinleyiciSoket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //sohey oluşuruyorum  protokolüm tcp 
        //ıP Adresi için InterNetwork baglantısı üzerinde çalışacağımızı söylüyoruz
        TcpClient client;//client için bağlantı
         int whereToSend = 0; //0  server //1 client //nerden baglandığım için
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //soketim bağlıysa işlem yapıcam öncelikle kontrol ediyorum
            if (whereToSend == 1)
            {
                NetworkStream networkStream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(networkStream);
                writer.Write(crativepacket(1));
            }
            else {
               dinleyiciSoket.Send(crativepacket(1));
            }
            //Console.WriteLine(reader.ReadString());
        }
        private void clientconnent(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(connentnetwork_client));
            th.Start();
        }
        public void connentnetwork_client()
        {
            try
            {
                whereToSend = 1;//client şekilde bağlantı kurdum
                serverconnent.Enabled = false;
                // soket.Connect(new IPEndPoint(IPAddress.Parse(clientip.Text), Convert.ToInt16(clientport.Text)));//127.0.0.1 ip adresinden bizim belirlediğimiz porta  bağlanıyoruz
                //herhangi bir ip adresinden belli bir portu dinlesin diye yapıyoruz
                client = new TcpClient();
                //client.Connect(IPAddress.Parse(clientip.Text), Convert.ToInt16(clientport.Text));
                //NetworkStream networkStream = client.GetStream();
                //BinaryReader read = new BinaryReader(networkStream);
                //while (true) {
                //    if (networkStream.DataAvailable) {
                //        byte[] a = read.ReadBytes(3);
                //        drawmessage(read.ReadBytes(a[2]));
                //    }
                //}
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(clientip.Text), Convert.ToInt16(clientport.Text));//baglantı noktası
                client.Connect(remoteEP);
                NetworkStream stream = client.GetStream();
                MessageBox.Show("bağlantı tamamlandı client");
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRec = stream.Read(buffer, 0, 1024);
                    if (bytesRec != 0)//veri varsa 0dan farklıysa
                    {
                        drawmessage(buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("bağlantı sırasında bi hata oluştur tekrar deneyin hata ex=>" + ex);
            }
        }
        public void connentnetwork()
        {
            clientconnetn.Enabled = false;
            whereToSend = 0;
            //thareda bağlı şekilde düzenlenicek tamamı nedeni from gelmeden önce bağlantı  bağlanmalı be mesaj gönderilmeli öbür türlü form gelmiyor 
            // Ayrıca gönderici ile aynı PORT üzerinden dinlemesi gerekiyor  başka türlü çalışmıyor
            TcpListener dinle = new TcpListener(IPAddress.Parse(serverip.Text), Convert.ToInt16(serverport.Text));
            //herhangi bir ip adresinden belli bir portu dinlesin diye yapıyoruz
            dinle.Start();
            // Buradan aşağısı bağlantı teklifi geldiğinde çalışacaktır. 
            dinleyiciSoket = dinle.AcceptSocket();
            if (dinleyiciSoket.Connected)
            {
                MessageBox.Show("servere birisi bağlandı");
            }
          
            while (true)
            {
                try
                {
                    // Receive() metodu TCP bağlantısı üzerinden gelecek mesajları beklemeye ve
                    // geldiğinde okumaya yarar.  gelenleri de gelen dataya atıyoruz
                    //mesaj gelmesse devamı çalışmıyor 
                    //o yüzden thread kullandım
                    byte[] gelenData = new byte[256];
                    dinleyiciSoket.Receive(gelenData);
                    drawmessage(gelenData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hata oldu" + ex);
                    break;
                }
            }
        }
        public void drawmessage(byte[] gelenData)
        {
            byte[] bytes1 = gelenData;
            byte[] bytes = new byte[bytes1[2]];
            for (int i = 0; i < bytes1[2] - 1; i++)//toplamı buluyoruz
            {
                bytes[i] = bytes1[i];
            }
            int top = 0;
            for (int i = 0; i < bytes[2] - 1; i++)//toplamı buluyoruz
            {
                top += bytes[i];
            }
            int crc = (top - bytes[2]) % 127;//crcyi biliyoruz
            if (crc != 0)//kontrol ediyoruz
            {
                byte[] buffer = new byte[bytes[2] - 4];//bufer boyutunu oluşturuyoruz burda -4  benim en sonrdan 4. değerim yani boyutum
                String s = "";//doldurulucak stringim
                if (bytes[0] == 1)//comut 1 se yani mesaj  yollanıysa
                {
                    for (int i = 3; i < bytes[2] - 1; i++)//3ün gerisi comut  verileri sonundcu veri de  crc olduğu için onları stringe almadan yapıyorum
                    {
                        s += (char)bytes[i];
                    }
                }
                else {
                    String filenames="";
                    String fileText = "";
                    for (int i = 0; i < bytes[1]; i++)//3ün gerisi comut  verileri sonundcu veri de  crc olduğu için onları stringe almadan yapıyorum
                    {
                        fileText += (char)bytes[i+3];
                    }
                    for (int i = bytes[1] + 3; i < bytes[2]-1; i++)//3ün gerisi comut  verileri sonundcu veri de  crc olduğu için onları stringe almadan yapıyorum
                     {
                        filenames += (char)bytes[i];
                    }
                    FileStream fs = new FileStream("C:\\Users\\Fatih Yılmaz\\source\\repos\\" + filenames, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                    File.AppendAllText("C:\\Users\\Fatih Yılmaz\\source\\repos\\" + filenames,fileText);
                }
                getmessage.Text += s + "\n";
            }
            else
            {
                MessageBox.Show("hata oluştu");
                for (int i =0;i<1;i++) {
                    getmessage.Text += (char)bytes[i];
                }
            }
        }
        private void connentServer(object sender, EventArgs e)
        {
            Thread connent = new Thread(new ThreadStart(connentnetwork));// server bağlantıı için thread 
            connents = connent;
            Threadoparetion(true);
        }
        public void Threadoparetion(bool islem)
        {// çıkış işlemi  için thared açık kalmasın diye func oluşturudum
            if (islem)
            {
                connents.Start();
            }
            else {
                connents.Abort();
            }
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Kapatsorgu) // ! False ise 
            {
                dr = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Kapatsorgu = dr == DialogResult.Yes;
            }
            if (dr == DialogResult.Yes)
            {
                if (Kapatsorgu) // True ise
                {
                    if (whereToSend==0) {
                        Threadoparetion(false);
                    }
                    Application.Exit();
                }
                Kapatsorgu = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private byte[] crativepacket(int com)
        {
            if (com == 1)
            {
                int maxleng = massegebox.Text.Length + clientname.Text.Length + 5;//toplam gönderilicek veri adeti
                int dataleng = massegebox.Text.Length + clientname.Text.Length + 1;//sadece string olan kısım yani ad ve text
                byte[] bytes = new byte[maxleng];
                //0=>komut
                //1=>boş
                //2=>topuzunluk
                //3+n=>data 
                //3+n1=>bölük//ad ile mesajı ayırmak için
                //4+n+m=>komut 
                bytes[0] = Convert.ToByte(com);
                bytes[1] = 2;
                bytes[2] = Convert.ToByte(maxleng);

                String strdata = clientname.Text + ":" + massegebox.Text;
                getmessage.Text += clientname.Text + ":" + massegebox.Text + " \n"; //gönderdiğimiz mesajı kendi  kutumuzda da görmemiz için

                for (int i = 0; i < dataleng; i++)//data=>bayta atıyoruz
                    bytes[i + 3] = (byte)strdata[i];

                int top = 0;
                for (int i = 0; i < dataleng + 3; i++)//toplamı buluyoruz
                {
                    top += bytes[i];
                }

                bytes[maxleng - 1] = Convert.ToByte(top % 127);//toplamı byta atıyoruz
                return bytes;
            }
            else
            {
                int maxleng = file.Length + fileName.Length + 4;
                int dataleng = file.Length;
                byte[] bytes = new byte[maxleng];
               
                bytes[0] = Convert.ToByte(com);
                bytes[1] = Convert.ToByte(file.Length);
                bytes[2] = Convert.ToByte(maxleng);


                for (int i = 0; i < dataleng; i++)//data=>bayta atıyoruz
                    bytes[i + 3] = (byte)file[i];


                int top = 0;
                for (int i = 0; i < fileName.Length; i++)//toplamı buluyoruz
                {
                    bytes[i + dataleng +3] +=(byte)fileName[i];
                }

                for (int i = 0; i < maxleng-1; i++)//toplamı buluyoruz
                {
                    top += bytes[i];
                }
                bytes[maxleng - 1] = Convert.ToByte(top % 127);//toplamı byta atıyoruz
                return bytes;
            }
        }
        byte[] file;
        String fileName;
        private void denemfile_Click(object sender, EventArgs e)
        {
            byte[] bytes = File.ReadAllBytes(@"C:\Users\Fatih Yılmaz\source\repos\tcpclient\aa.txt");//byte olarak okudum
            file = bytes;
            fileName = "aa.txt";
            //soketim bağlıysa işlem yapıcam öncelikle kontrol ediyorum
            if (whereToSend == 1)
            {
                NetworkStream networkStream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(networkStream);
                writer.Write(crativepacket(2));
            }
            else
            {
                dinleyiciSoket.Send(crativepacket(2));
            }
            //Console.WriteLine(reader.ReadString());

          
        }
    }
}
