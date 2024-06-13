using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    // Sunucu uygulamasının ana metodu
    public static void ServerMain(string[] args)
    {
        TcpListener server = null;
        try
        {
            // Bağlantıların dinleneceği port numarası
            Int32 port = 23000;
            // Sunucunun IP adresi
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener nesnesi oluşturarak belirtilen portta bağlantıları dinlemeye başla
            server = new TcpListener(localAddr, port);
            server.Start();

            // Alınacak veri için byte dizisi ve string
            Byte[] bytes = new Byte[256];
            String data = null;

            // İstemciden gelen ilk bağlantıyı kabul et
            Console.Write("Bağlantı bekleniyor... ");
            TcpClient client1 = server.AcceptTcpClient();
            Console.WriteLine("Bağlandı!");


            
            // İstemciyle iletişim kurmak için ağ akışı oluştur
            using (NetworkStream stream1 = client1.GetStream())
            {
                while(true){
                   int i;
                while ((i = stream1.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Gelen veriyi stringe çevir
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("CLIENT: {0}", data);

                    if (data.Trim().ToLower() == "tamam")
                    {
                        System.Console.WriteLine("Sonlandırıldı...");
                        client1.Close();
                        server.Stop();
                        break;
                    }

                    // Veri gönder
                    string girdi = Console.ReadLine();
                    byte[] msg = Encoding.ASCII.GetBytes(girdi);
                    stream1.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Geri gönderildi: {0}", girdi);

                    if (girdi.Trim().ToLower() == "tamam")
                        {
                            System.Console.WriteLine("Sonlandırıldı...");
                            break;
                            
                        }  
                } 
                
                
            }

            
        }}
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Sunucuyu durdur
            server.Stop();
        }
    }
}
