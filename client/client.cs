using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    // İstemci uygulamasının ana metodu
    public static void ClientMain(string[] args)
    {
        try
        {
            // Sunucuya bağlanmak için kullanılacak port numarası
            Int32 port = 23000;
            // Sunucunun IP adresi
            string serverIP = "127.0.0.1";

            // TcpClient nesnesi oluşturarak sunucuya bağlanma
            using (TcpClient client = new TcpClient(serverIP, port))
            {
                // Ağ akışını al
                using (NetworkStream stream = client.GetStream())
                {
                    while(true){
                    // System.Console.WriteLine("Mesaj gir");
                    string message = Console.ReadLine();
  
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    
                    
                    // Mesajı sunucuya gönder
                    stream.Write(data, 0, data.Length);
                    //Console.WriteLine("Gönderildi: {0}", message);
                    if (message.ToLower() == "tamam")
                    {
                        System.Console.WriteLine("Sonlandırıldı...");
                        break; 
                    }

                    // Sunucudan gelen yanıtı al
                    data = new Byte[256];
                    String responseData = String.Empty;
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("SERVER: {0}", responseData);
                    
                     if (responseData.ToLower() == "tamam")
                    {
                        System.Console.WriteLine("Sonlandırıldı...");
                        break; 
                    }

                    }  
                    
                }
            }
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        
    }
}
