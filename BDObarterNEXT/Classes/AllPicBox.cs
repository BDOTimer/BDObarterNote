using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using MLF = BDObarterNEXT.MyLib;

namespace BDObarterNEXT
{
    public sealed class AllPicBox
    {
        public AllPicBox(myForm F)
        {
            myform = F;
          //MLF.textout.add("new AllPicBox(...)");
          //MLF.textout.add("AllPicBox.Config.scale", myform.cfg.scale);

            colorButtonHolder = new ColorButtonHolder();

            MLF.ReMove  (F.get_panelSources());

            loadPictures(F);
            reOder  (cargo);
            add  (F, cargo);
            setNPV      (3);

            correctForm (F);

          //debug(cargo);

          //MLF.textout.add("cargo.Count", cargo.Count);
        }

        myForm              myform;
        List<Panel>          cargo;
        List<PictureBox>[] cargoPB; // Нужно для reset().

        ColorButtonHolder colorButtonHolder;

        public Panel getNowPanel(){ return cargo[nowPanelVis]; }

        //-------------------|
        // Шаг между боксами.|
        //-------------------:
        static int Step   = 2;

        private void loadPictures (myForm F)
        {
            List<System.IO.FileInfo[]>
                namefiles = findFileNames("img", "*.jpg");

            //debug(namefiles);

            int cnt = 0;
            cargo   = new List<Panel>     (namefiles.Count);
            cargoPB = new List<PictureBox>[namefiles.Count];

            MLF.textout.add("cargo.Count", cargo.Count);

            foreach (var names in namefiles)
            {
                Panel     panel = new Panel();
                cargo.Add(panel);

                cargoPB[cnt] = new List<PictureBox>();

                for (int i = 0; i < names.Length; ++i)
                {   PictureBox pb       = createPictureBox(F);

                    using (var stream = File.Open(names[i].FullName, FileMode.Open))
                    {   pb.Image = Image.FromStream(stream);
                    }

                    panel.Controls.Add(pb);

                    cargoPB[cnt].Add(pb);
                }

                cnt++;
            }

            initGeomPanels(F, cargo, F.get_panelDest());
        }

        private static
        List<System.IO.FileInfo[]>
            findFileNames(string path, string filtr)
        {
            List<FileInfo[]> namefiles = new List<FileInfo[]>();
            DirectoryInfo    root      = Directory.CreateDirectory("./" + path);
            DirectoryInfo[]  subDirs   = root.GetDirectories ();

            foreach (DirectoryInfo dir in subDirs)
            {
                try
                {   namefiles.Add(dir.GetFiles(filtr));
                }
                catch (UnauthorizedAccessException e)
                {   MLF.textout.add(e.Message);
                }
                catch (DirectoryNotFoundException e)
                {   MLF.textout.add(e.Message);
                }
            }
            return namefiles;
        }

        private static
        void debug(List<System.IO.FileInfo[]> m)
        {
            MLF.textout.add("List file names ---------------:");

            Int32 cntpanel = 0;

            foreach(var e in m)
            {
                MLF.textout.add(cntpanel.ToString(), " -----:");

                for(int i = 0; i < e.Length; ++i)
                {
                    MLF.textout.add(e[i].Name);
                }   cntpanel++;
            }
            MLF.textout.add("");
        }

        private static
        void debug(List<Panel> PP)
        {
            MLF.textout.add("List Panel's ---------------:");

            Int32 cntpanel = 0;

            foreach (var P in PP)
            {
                MLF.textout.add(cntpanel.ToString() + " ---", P.Controls.Count);
                foreach (PictureBox B in  P.Controls)
                { //MLF.textout.add("B.Left", B.Left);
                    MLF.textout.add("B.Top" , B.Top );
                }
                
                cntpanel++;
            }
            MLF.textout.add("");
        }

        private static
        PictureBox createPictureBox(myForm F)
        {
            PictureBox           pb = new PictureBox();
            setgeomPictureBox(F, pb);
            return               pb ;
        }

        private static
        void setgeomPictureBox(myForm F, PictureBox pb)
        {   pb.Width       = myForm.cfg.scale;
            pb.Height      = myForm.cfg.scale;
            pb.MouseClick += F.dlgPicBox_Click;
            pb.SizeMode    = PictureBoxSizeMode.StretchImage;
            pb.Name        = "pbox";
        }

        //--------------------------------------|
        //  Max PictureBox in Panel.            |------------------------------>
        //--------------------------------------:
        private static
        int findmaxcount(List<Panel> PP)
        {
            int cnt = PP[0].Controls.Count;
            foreach (Panel p in PP)
            {   if  (cnt < p.Controls.Count)
                     cnt = p.Controls.Count;
            }
            return cnt;
        }

        //--------------------------------------|
        //  Вычисдение ширины + высоты Panel's. |
        //--------------------------------------:
        private static
        Size calcWidthPanel(int step, int cnt)
        {   Size   sz = new Size(
                (myForm.cfg.scale + step) * cnt + step,
                 myForm.cfg.scale + step  + step);
            return sz;
        }

        //--------------------------------------|
        //  Установка размеров Panel's.         |
        //--------------------------------------:
        private static
        void initGeomPanels(myForm F, List<Panel> PP, Panel D)
        {
            int  cnt = findmaxcount  (PP);
            Size sz  = calcWidthPanel(Step, cnt);

            D.Width  = sz.Width ;
            D.Height = sz.Height;

            foreach (var p in PP)
            {            p.Width     = sz.Width ;
                         p.Height    = sz.Height;
                         p.Top       = sz.Height;
                         p.BackColor = F.get_panelSources().BackColor;
                         p.Name      = "source";
                         p.Visible   = false;
            }
        }
        //<--------------------------------------------------------------------|

        //--------------------------------------|
        //  Если форма больше экрана.           |------------------------------>
        //--------------------------------------:
        public bool is_correct_ifbig_sizeform_thenscreen(myForm F)
        {
            Point scr = Textout.GetScreenResolution(   );
            int   cnt = findmaxcount             (cargo);
            Size   sz = calcWidthPanel       (Step, cnt);
            int width = sz.Width + myForm.cfg.scale + 10;

            if(width > scr.X)
            {
                int correcting = scr.X / (cnt + 2) - 1;
                myForm.dialog.set_dialTrackBarScale(correcting);

                reCorrected(F);
                return true;
            }
            return false; 
        }

        private int  nowPanelVis = 0;
        private void setNPV(int  n)
        {   cargo[nowPanelVis].Visible = false;
            nowPanelVis = n;
            cargo        [n].Visible = true ;

            viewNPV();
        }

        public void rollNPV()
        {   cargo[nowPanelVis].Visible = false;
            if (++nowPanelVis == cargo.Count) nowPanelVis = 0;
            cargo[nowPanelVis].Visible = true;

            viewNPV();
        }

        public void rollNPV_back()
        {   cargo[nowPanelVis].Visible = false;
            if (--nowPanelVis < 0) nowPanelVis = cargo.Count - 1;
            cargo[nowPanelVis].Visible = true;

            viewNPV();
        }

        private void viewNPV()
        {   myForm        F = (myForm)cargo[0].Parent;
            F.buttonNP.Text = Convert.ToString(nowPanelVis);
            colorButtonHolder.setColorForegraound(F.buttonNP, nowPanelVis);
        }

        //--------------------------------------|
        //  Расстановка PictureBox's на Panel's.|------------------------------>
        //--------------------------------------:
        public void reOder_all()
        {   reOder(cargo);
            reOder(myform.get_panelDest());
        }

        private static
        void  reOder(List<Panel> PP)
        {   foreach (Panel P in PP)
            {   reOder(P);
            }
        }

        public static
        void reOder(Panel P)
        {
            if (P.Controls.Count == 0) return;

            int W = P.Controls[0].Width  + Step;
            int H = P.Controls[0].Height + Step;

            {   int x = Step;
                int y = Step;
                foreach (PictureBox B in P.Controls)
                {
                    B.Left = x;
                    B.Top  = y;

                    x += W;
                }
            }
        }

        //--------------------------------------|
        //  Добавить Panel's. на myForm         |------------------------------>
        //--------------------------------------:
        private static
        void add(myForm F, List<Panel> PP)
        {   foreach (Panel P in PP)
            {   F.Controls.Add  (P);
            }
        }

        //--------------------------------------|
        //  Коррекция размеров myForm.          |------------------------------>
        //--------------------------------------:
        private static
        void correctForm(myForm F)
        {   int SCALE =  myForm.cfg.scale;
            int Th    =  MyLib .textout.height  ();

            Panel   P        = F.get_panelDest  ();
                    P.Height = SCALE + Step + Step;

            F.buttonShow.Left     =  P.Width + 5;
            F.buttonShow.Width    =  P.Height   ;
            F.buttonShow.Height   =  P.Height   ;

            F.buttonDialog.Left   =  P.Width + 5;
            F.buttonDialog.Width  = (F.buttonShow  .Width * 5) / 10;
            F.buttonDialog.Height =  F.buttonDialog.Width;

            F.buttonDialog.Top    = F.buttonShow.Height - F.buttonDialog.Width;

            F.buttonNP.Left       = F.buttonShow.Left  ;
            F.buttonNP.Width      = F.buttonShow.Width ;
            F.buttonNP.Height     = F.buttonShow.Height;
            F.buttonNP.Top        = P.Height;

            int x = P.Width  + SCALE + 5 + 5 ;
            int y = P.Height + P.Height  + Th;

            F.ClientSize = new Size(x, y);

          //if(MyLib.textout.visible())
            {   TextBox T       = F.get_textOut();
                        T.Top   = P.Height + P.Height + 2;
                        T.Width = P.Width;
            }
        }

        public static 
        void moveTo(PictureBox B, Panel P)
        {   Panel o =  (Panel)B.Parent;
                  o.Controls.Remove(B);
                  P.Controls.Add   (B);
                  reOder(P);
        }

        // MyLib.textout.add("reCorrected(...)");
        //--------------------------------------|
        //  Рекоррекция размеров myForm.        |------------------------------>
        //--------------------------------------:
        public void reCorrected(myForm F)
        {   initGeomPanels(F, cargo, F.get_panelDest());

            foreach (PictureBox B in F.get_panelDest().Controls)
            {   B.Width      = myForm.cfg.scale;
                B.Height     = myForm.cfg.scale;
            }

            foreach     (var        P in cargo)
            {   foreach (PictureBox B in P.Controls)
                {   B.Width  = myForm.cfg.scale;
                    B.Height = myForm.cfg.scale;
                }
            }

            correctForm(F);
            reOder_all ( );
            setNPV(nowPanelVis);
        }

        //--------------------------------------|                          reset
        // +++                                  |------------------------------>
        //--------------------------------------:
        public void reset()
        {   foreach     (var        pn in cargoPB)
            {   foreach (PictureBox pb in pn     )
                {   MyLib.ReMove(pb);
                }
            }

            int i = 0;
            foreach    (var P  in cargo       )
            {   foreach(var pb in cargoPB[i++])
                {   P.Controls.Add(pb);
                }
                reOder(P);
            }
        }
    }

    public class ColorButtonHolder
    {   public   ColorButtonHolder()
        {   color    = new Color[6];
            color[0] = MyLib.rgb(128, 128, 128);
            color[1] = MyLib.rgb( 64,  64,  64);
            color[2] = MyLib.rgb(  0, 200,   0);
            color[3] = MyLib.rgb(  0,   0, 250);
            color[4] = MyLib.rgb(250, 200,   0);
            color[5] = MyLib.rgb(200,   0,   0);
        }

        Color[] color;

        public void setColorForegraound(Control C, int i)
        {
            if (i > 5)
            {   C.ForeColor = MyLib.rgb(0, 0, 0); return;
            }   C.ForeColor = color[i];
        }
    }
}
