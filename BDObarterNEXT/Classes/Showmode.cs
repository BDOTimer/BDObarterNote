﻿//  TODO
//-----------------------------------------------------------------------------|
//  Три режима отображения:
//      1. Двухпанельный.
//      2. Однопанельный.
//      3. Свёрнутый в иконку на экране.
//-----------------------------------------------------------------------------| 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using MLF = BDObarterNEXT.MyLib;

namespace BDObarterNEXT
{
    public sealed class Showmode
    {
        public Showmode(myForm F)
        {
            myform  = F;
            setborder(F.FormBorderStyle);

            idp    = new Datapos[(int)Showmode.eMode.end];
            idp[0] = new DataposMax(F);
            idp[1] = new DataposMid(F);
            idp[2] = new DataposMin(F);

            idp[mode].set();
        }

        private myForm myform;
        private IDP[]  idp   ;

        public void tocfg()
        {   idp[mode].PF = myform.DesktopLocation;

            foreach (var e in idp)
            {   e.tocfg();
            }
        }

        public enum eMode
        {   MAX = 0,
            MID,
            MIN,
            ///
            end
        }

        private int mode = 0;
        public void set()
        {   idp  [mode].save();
            if( ++mode ==  (int)eMode.end ) mode = 0;
            idp  [mode].set(   );

            if (mode == (int)eMode.MAX) 
                 myForm.dialog.dialButtonTextOut.Enabled = true ;
            else myForm.dialog.dialButtonTextOut.Enabled = false;
        }

        public void setborder(FormBorderStyle FBS)
        {   Datapos.fbs_static =              FBS;
        }

        private void save(){ idp[mode].save(); }

        //--------------------------------------|
        // Test.                                |<-----------------------: Тест.
        //--------------------------------------:
        private void set(Showmode.eMode MODE)
        {   idp[(int)MODE].set();
        }

        public static void test(myForm myform)
        {
            Showmode smode = new Showmode(myform);

            for (Showmode.eMode i = Showmode.eMode.MAX;
                                i < Showmode.eMode.end; ++i)
            {   smode.set      (i);
            }
        }
    }

    //---------------------------------|
    // Геометрия.                      |
    //---------------------------------:
    public interface IDP
    {
        void save ();
        void set  ();
        void tocfg();

        Point PF{ get; set; }
    }

    //---------------------------------|
    // Datapos                         |
    //---------------------------------:
    [Serializable]
    public class Datapos : IDP
    {
        protected myForm F;

        //--------------------|
        // Позиция формы.     |
        //--------------------:
        protected Point     pf;
        public    Point     PF
        {   get { return pf ; }
            set { pf = value; }
        }

        public void init(myForm F)
        {   fbs = F.FormBorderStyle;
        }

        //--------------------|
        // ClientRectangle.   |
        //--------------------:
        public virtual void save (){}
        public virtual void set  (){}
        public virtual void tocfg(){}

        //-----------------------------|
        // Common methods.             |
        //-----------------------------:
        protected     FormBorderStyle fbs;
        public static FormBorderStyle fbs_static;

        public void pushpos(){   this.pf = F.DesktopLocation;      }
        public void poppos (){   F.SetDesktopLocation(pf.X, pf.Y); }

        [NonSerialized]
        public string xxxtest;
    }

    //---------------------------------|
    // DataposMax                      |<---: Max
    //---------------------------------:
    public class DataposMax : Datapos
    {
        public DataposMax(myForm F)
        {   this.F = F ;
            init    (F);
          //calc    ( );
            F.DesktopLocation = pf = myForm.cfg.PXY0;
        }

        public override void save()
        {   pushpos();
        }

        public override void set()
        {   poppos();
            calc  ();
            F.FormBorderStyle = fbs_static;
        }

        private void calc()
        {
            Panel   p = F.get_panelDest();
            int scale = myForm.cfg.scale ;

            int Th = MyLib.textout.height();

            F.ClientSize = new Size(
                p.Width  + scale + 10,
                p.Height * 2     + Th
            );

            Point bb   = F.buttonShow.Location;
                  bb.X = p.Width + 5;

            F.buttonShow.Location   = bb;
            F.buttonShow.ClientSize = new Size(scale, scale);

            if (MyLib.textout.visible())
            {
                Panel   P       = F.get_panelDest();
                TextBox T       = F.get_textOut  ();
                        T.Top   = P.Height + P.Height + 2;
                        T.Width = P.Width;

                //MLF.textout.add("correctForm:TextBox.Top", T.Top);
            }
        }

        public override void tocfg()
        {   myForm.cfg.PXY0 = pf;
        }
    }

    //---------------------------------|
    // DataposMid                      |<---: Mid
    //---------------------------------:
    public class DataposMid : Datapos
    {
        public DataposMid(myForm F)
        {
            this.F = F;
            init(F);
          //calc( )   ;
            F.DesktopLocation = pf = myForm.cfg.PXY1;
        }

        public override void save()
        {   pushpos();
        }

        public override void set()
        {   poppos();
            calc  ();
            F.FormBorderStyle = fbs_static;
        }

        private void calc()
        {   Panel   p = F.get_panelDest();
            int scale = myForm.cfg.scale;

            F.ClientSize = new Size(
                p.Width  + scale + 10, 
                p.Height
            );

            Point bb     = F.buttonShow.Location;
                  bb.X   = p.Width + 5;

            F.buttonShow.Location   = bb;
            F.buttonShow.ClientSize = new Size(scale, scale);
        }

        public override void tocfg()
        {   myForm.cfg.PXY1 = pf;
        }
    }

    //---------------------------------|
    // DataposMin                      |<---: Min
    //---------------------------------:
    public class DataposMin : Datapos
    {
        public DataposMin(myForm F)
        {
            this.F = F;
            init(F);
            fbs    = FormBorderStyle.None;
            F.DesktopLocation = pf = myForm.cfg.PXY2;
        }

        public override void save()
        {   pushpos();
        }

        public override void set()
        {   poppos();
            calc  ();
            F.FormBorderStyle = fbs;
        }

        private void calc()
        {   F.buttonShow.Location   = new Point(0, 0);
            F.buttonShow.ClientSize = new Size(50, 50);
            F.ClientSize            = new Size(50, 50);
        }

        public override void tocfg()
        {   myForm.cfg.PXY2 = pf;
        }
    }
    //---------------------------------.
}


