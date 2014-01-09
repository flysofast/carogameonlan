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
        public static void GuiTinNhan(string doithu, string noidung)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:TN:/{1}</content>", doithu, noidung));
        }
        public static void GuiAlias(string ten)
        {
            Gui(string.Format("/:AL:/{0}", ten));
        }
        public static void GuiLoiMoi(string doithu, string tenminh, string noidung)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:LM:/{1},{2}</content>", doithu, tenminh, noidung));
        }

        public static void HuyLoiMoi(string doithu, string tenminh)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:LM:/{1}</content>", doithu, tenminh));
        }

        public static void DongY(string tenminh,string doithu)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:DY:/{1}</content>", doithu,tenminh));
        }
        public static void TuChoi(string doithu, string lydo)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:TC:/{1}</content>", doithu, lydo));
        }


        public static void XinHoa(string doithu)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:XH:/</content>", doithu));
        }
        public static void ChapNhanHoa(string doithu)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:CN:/</content>", doithu));
        }
        public static void KoChapNhanHoa(string doithu)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:KK:/</content>", doithu));
        }

        public static void BoCuoc(string doithu)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:KK:/</content>", doithu));
        }

        public static void RoiBanChoi(string doithu)
        {
            Gui(string.Format("/:MS:/<recipient>{0}</recipient><content>/:RB:/</content>", doithu));
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
        public static string MaHoa(string rtf)
        {
            string a = rtf;
            return a.Replace("\r\n", "$^");
        }
        public static string GiaiMa(string str)
        {
            return str.Replace("$^", "\r\n");
        }
        public static void NgatKetNoi()
        {
            Gui("/:DC:/");
        }
    }
}
