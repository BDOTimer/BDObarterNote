using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Linq.Expressions;

namespace BDObarterNEXT
{
    public partial class myForm : Form
    {
        public myForm()
        {
            MySounds.xxxtest();

            InitializeComponent ();
          //this.KeyPreview = true;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            mySerial      = new mySerializator(filenamecfg);
            mySerial.create_load();
            
            cfg           = Config.load  (mySerial);
            MyLib.textout = new Textout  (textOut);
            apbox         = new AllPicBox(this);
            dialog        = Dialog.Create(this);
            showmode      = new Showmode (this);
            sounds        = new MySounds (    );

            MyLib.textout.add("cfg.scale", cfg.scale);

            init_move_myform();

            mySerial.close();

            if (apbox.is_correct_ifbig_sizeform_thenscreen(this))
            {   MyLib.textout.add("is_correct_ifbig_sizeform_thenscreen(.)");
            }

            fromdipto_font = new fromDipTo(
                new Point(8, 35),
                dialog.getdialTrackBarScaleRange()
            );

            dialog.resizefont();
        }

        public  static fromDipTo fromdipto_font;
        public  static Config               cfg;
        public  static AllPicBox          apbox;
        public  static Dialog            dialog;
        public  static Showmode        showmode;
        public  static MySounds          sounds;
        private static mySerializator  mySerial;

        public Panel   get_panelDest   () { return panelDest   ;}
        public Panel   get_panelSources() { return panelSources;}
        public TextBox get_textOut     () { return textOut     ;}

        private void myForm_Load(object sender, EventArgs e)
        {   MyLib.textout.add("myForm_Load(...)");
          //Showmode.test(this);
        }

        private void buttonDial_Click(object sender, EventArgs e)
        {   dialog.OnOff();
        }

        private void myForm_FormClosing(object sender, FormClosingEventArgs e)
        {   if (dialog.isclickexit)
            {   // EXIT!
                sounds.play_sync(MySounds.eSND.EXIT);
              //Config.save(cfg);
                myForm.showmode.tocfg();
                this  .tofile( );
            }
            else
            {   dialog.Visible   = false;
                e      .Cancel   = true; //<<<---...
                this.WindowState = FormWindowState.Minimized;
            }
        }

        //-----------------------------------------------------|
        //  Двигаем PictureBox'ы.                              |
        //-----------------------------------------------------:
        public void dlgPicBox_Click(object sender, EventArgs e)
        { //MyLib.textout.add("dlgPicBox_Click(...)");

            PictureBox     B = (PictureBox)sender  ;
            Panel          P =      (Panel)B.Parent;
            MouseEventArgs E = (MouseEventArgs)   e;

            switch (P.Name)
            {
                //--------------|
                // panelDest.   |
                //--------------:
                case "panelDest":
                {   switch (E.Button)
                    {   case MouseButtons.Left :
                        {   sounds.play(MySounds.eSND.MOVEBACK);
                            MyLib.MoveControlBack(B);
                            break; 
                        }
                        case MouseButtons.Right:
                        {   
                            break;
                        }
                    }
                    break;
                }

                //--------------|
                // panelSource. |
                //--------------:
                case "source":
                {   switch (E.Button)
                    {   case MouseButtons.Left :
                        {   sounds.play(MySounds.eSND.MOVE);
                            AllPicBox.moveTo(B,  panelDest);
                            break; 
                        }
                        case MouseButtons.Right:
                        {   
                            break;
                        }
                    }
                    break;
                }
            }
        }

        //-----------------------------------------------------|
        //  MyLib.textout.add("buttonNP_MouseUp(.)");          |
        //-----------------------------------------------------:
        private void buttonNP_MouseUp(object sender, MouseEventArgs e)
        {   sounds.play(MySounds.eSND.NPANEL);
            switch (e.Button)
            {   case MouseButtons.Left : { apbox.rollNPV     (); break; }
                case MouseButtons.Right: { apbox.rollNPV_back(); break; }
            }
        }

        //-----------------------------------------------------|
        //  Двигаем окно у которого нет стиля.                 |
        //-----------------------------------------------------:
        bool  mcur = false;
        Point Cursorpos   ;
        private void buttonShow_MouseDown(object sender, MouseEventArgs e)
        {   mcur      = true           ;
            Cursorpos = Cursor.Position;
        }

        bool mcurdone = true;
        private void buttonShow_MouseUp(object sender, MouseEventArgs e)
        {   mcur = false;
            if (mcurdone)
            {
                if (((Control)sender).Name == "buttonShow")
                {   sounds  .play(MySounds.eSND.SHOW);
                    showmode.set ();
                }
            }
            else mcurdone = true;
        }

        private void buttonShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (mcur)
            {
                Point cp    = Cursor.Position;
                      cp.X -= Cursorpos.X;
                      cp.Y -= Cursorpos.Y;

                if (  cp.X == 0   && 
                      cp.Y == 0 ) return;
                else              mcurdone = false;

                Point dl    = this.DesktopLocation;
                      dl.X += cp.X;
                      dl.Y += cp.Y;

                Cursorpos   = Cursor.Position;
                this    .SetDesktopLocation(dl.X, dl.Y);
            }
        }

        void init_move_myform()
        {   this.panelDest.MouseDown += 
                 new MouseEventHandler(this.buttonShow_MouseDown);
            this.panelDest.MouseMove +=
                 new MouseEventHandler(this.buttonShow_MouseMove);
            this.panelDest.MouseUp   += 
                 new MouseEventHandler(this.buttonShow_MouseUp);
        }

        private void myForm_Move(object sender, EventArgs e)
        {   
        }

        //-----------------------------------------------------|
        //  Сериализация.                                      |--------------->
        //-----------------------------------------------------:
        private static string filenamecfg = "cfg.3";
        private void xxxfromfile(mySerializator ser)
        {
            mySerial = new mySerializator(filenamecfg);
            mySerial.create_load();

            mySerial.load(ref cfg);

            mySerial.close();
        }

        private void tofile()
        {
            mySerial.create_save();

            mySerial.save(ref cfg);
            //showmode.xxxsave(mySerial);

            mySerial.close();
        }
    }
}
