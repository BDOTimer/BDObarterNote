using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BDObarterNEXT
{
    //-------------------------------------------------------------------------|
    //  Config
    //-------------------------------------------------------------------------:
    [Serializable]
    public class Config
    {
        public Config()
        {   
        }

        public static string filename = "cfg.1";

        //-----------------------------------------------------|
        //  Поля конфига.                                      | 
        //-----------------------------------------------------:
        //---------------------------------|
        //  Координаты позиции окна.       | 
        //---------------------------------:
        private int x = 0;
        public  int X
        {   get { return  x; }
            set { x = value; }
        }

        private int y = 0;
        public  int Y
        {   get { return  y;}
            set { y = value;}
        }

        Point pxy0 = new Point(0, 0);
        public Point PXY0
        {
            get { return pxy0 ; }
            set { pxy0 = value; }
        }

        Point pxy1 = new Point(0, 0);
        public Point PXY1
        {
            get { return pxy1 ; }
            set { pxy1 = value; }
        }

        Point pxy2 = new Point(0, 0);
        public Point PXY2
        {
            get { return pxy2 ; }
            set { pxy2 = value; }
        }

        //---------------------------------|
        //  Показать окно сообщений.       | 
        //---------------------------------:
        private bool b = true;//false;
        public bool is_show_mess_win
        {
            get { return  b; }
            set { b = value; }
        }

        //---------------------------------|
        //  Масштаб == размер картинки.    | 
        //---------------------------------:
        private int scale_ = 40;
        public int scale
        {   get { return  scale_; }
            set { scale_ = value; }
        }

        //---------------------------------|
        //  Блокировка перемещения форм.   |
        //---------------------------------:
        private bool is_block_ = false;
        public  bool is_block
        {   get { return  is_block_; }
            set { is_block_ = value; }
        }

        public FormBorderStyle formBorderStyle = FormBorderStyle.FixedSingle;
        public bool            dialVisible     = true;
        public int             transparency    = 10;
        //-----------------------------------------------------.

        public void InitSizeSquare(Control c)
        {   c.Width  = scale;
            c.Height = scale;
        }

        public static Config load( myForm F, mySerializator ser)
        {   Config       cfg = new Config();
            ser.load(ref cfg);
            return       cfg ;
        } 

        public static Config xxxload()
        {
            MyLib.textout.add("\r\nConfig.load:");

            Config cfg = new Config();

            try
            {
                BinaryFormatter reader = new BinaryFormatter();
                FileStream ffile =
                new FileStream(
                    filename,
                    FileMode.Open,
                    FileAccess.Read);

                cfg = (Config)reader.Deserialize(ffile);

                ffile.Close();
            }
            catch
            {   xxxsave(cfg);
            }

            return cfg;
        }

        public static void xxxsave(Config cfg)
        {
            MyLib.textout.add("\r\nConfig.save(...)");

            FileStream output =
            new FileStream(
                filename,
                FileMode.OpenOrCreate,
                FileAccess.Write);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(output, cfg);

            output.Close();
        }

        public
        void debug(Point dl)
        {   MyLib.textout.add("");
            MyLib.textout.add("cfg.debug():");
            MyLib.textout.add("cfg.X = " + Convert.ToString(X));
            MyLib.textout.add("cfg.Y = " + Convert.ToString(Y));
            MyLib.textout.add("DesktopLocation.X", dl.X);
            MyLib.textout.add("DesktopLocation.Y", dl.Y);
            MyLib.textout.add("");
        }

        public
        void SetDesktopLocation(Form F)
        {   F.SetDesktopLocation(X, Y);
        }

        public
        void set_location_to_cfg(Point dl)
        {   X = dl.X;
            Y = dl.Y;
        }
    }
}
