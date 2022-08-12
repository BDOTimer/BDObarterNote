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
        }

        public  static Config              cfg;
        public  static AllPicBox         apbox;
        public  static Dialog           dialog;
        public  static Showmode       showmode;
        private static MySounds         sounds;
        private static mySerializator mySerial;

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

        public void dlgPicBox_Click(object sender, EventArgs e)
        { //MyLib.textout.add("dlgPicBox_Click(...)");

            sounds.play(MySounds.eSND.MOVE);
            AllPicBox.moveTo((PictureBox)sender, panelDest);
        }

        private void buttonNP_MouseUp(object sender, MouseEventArgs e)
        {
          //MyLib.textout.add("buttonNP_MouseClick1(.)");
            sounds.play(MySounds.eSND.NPANEL);
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
                sounds.play(MySounds.eSND.SHOW);
                showmode.set ();
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
