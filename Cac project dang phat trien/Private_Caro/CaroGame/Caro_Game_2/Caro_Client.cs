using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Caro_Game_2
{
    public static class Caro_Client
    {
        public static TcpClient client = new TcpClient();
        public static Stream stream;
        public static void KetNoiServer(string ip, int port)
        {
            try
            {
                client.Connect(ip, port);
                stream = client.GetStream();
                Console.WriteLine("Ket noi CaroServer thanh cong.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi ket noi den Server : " + ex);
            }

        }
        public static void Gui(string dl)
        {
            try
            {
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.WriteLine(dl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        public static void GuiToaDo(int x, int y, string doithu)
        {

           Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:TD:/{1},{2}</content>", doithu, x, y));
        }
        public static void GuiTinNhan(string doithu,string noidung)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:TN:/{1}</content>", doithu,noidung));
        }
        public static void GuiAlias(string ten)
        {
            Gui(string.Format("/:AL:/{0}",ten));
        }
        public static string NhanDuLieu()
        {
            try
            {
                var reader = new StreamReader(stream);
                string str = reader.ReadLine();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            return null;
        }
        public static void NgatKetNoi()
        {
            Gui("/:DC:/");
        }
    }
}
