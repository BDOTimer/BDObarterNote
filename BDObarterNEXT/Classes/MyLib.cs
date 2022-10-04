// MyLib.textout.add("MyLib(...)", n);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq.Expressions;

namespace BDObarterNEXT
{
    public sealed class MyLib
    {
        public static Textout textout;

        //--------------------------------------|
        // Удалить Control с формы.             |
        //--------------------------------------:
        public static void ReMove(Control B)
        {
            if(B.Parent == null) return;
            B.Parent.Controls.Remove(B);
        }

        public static void Swap<T>(ref T a, ref T b)
        {   T t = b;
              b = a;
              a = t;
        }

        private static void SwapPosLeft(ref Control a, Control b)
        {   var tmp = a.Left;
             a.Left = b.Left;
             b.Left = tmp   ;
        }

        //--------------------------------------|
        // MoveControlBack.                     |
        //--------------------------------------:
        public static void MoveControlBack(Control a)
        {
            Control p = a.Parent;
            var i = p.Controls.IndexOf(a);

            if (i > 0)
            {   p.Controls.SetChildIndex(a, i - 1);
                SwapPosLeft (ref a, p.Controls[i]);
            }
        }

        //--------------------------------------|
        // resizefont.                          |
        //--------------------------------------:
        public static void resizefont(Control[] CC, fromDipTo conv, int a)
        {
            if(CC.Length == 0) return;

            float r = conv.Convert(a);
            Font  f = CC[0].Font;
            Font  F = new Font(
                  f.FontFamily,
                  r           ,
                  f.Style     ,
                  f.Unit      ,
                  f.GdiCharSet
            );

            foreach(var C in CC) C.Font = F;
        }

        public static Color rgb(int r, int g, int b)
        {   return Color.FromArgb(
                ((int)(((byte)(r)))),
                ((int)(((byte)(g)))),
                ((int)(((byte)(b)))));
        }
    }

    //----------------------------------------|
    //  Textout.                              |
    //----------------------------------------:
    public class Textout
    {
        public Textout(TextBox T) { this.T = T; this.T.Visible = false;  }

        private TextBox T;

        public void Clear() { T.Text = ""; }
        public void add(string s)
        {
            T.AppendText(s + "\r\n");
            T.SelectionStart = T.TextLength;
            T.ScrollToCaret();
        }

        public void add<TT>(string s, TT n)
        {
            string        ss = s + ": " + Convert.ToString(n);
            T.AppendText( ss + "\r\n");
            T.SelectionStart = T.TextLength;
            T.ScrollToCaret();
        }

        public void test()
        {   var world =  2022;
            logd(() => world);
        }

        public void logd<T>(Expression<Func<T>> value)
        {   var me = (MemberExpression)value.Body;
            string variableName  = me.Member.Name;
            var    variableValue = value.Compile()();
            add(variableName, variableValue);
        }

        public void debug()
        {   add("Textout.debug()");
            add("  T.TextLength     ", T.TextLength     );
            add("  T.SelectionStart ", T.SelectionStart );
            add("  T.Lines.Length   ", T.Lines.Length   );
            add("  T.SelectionLength", T.SelectionLength);
            add("");
        }

        public static Point GetScreenResolution()
        {   Screen myScreen = Screen.PrimaryScreen;
            Rectangle  area = myScreen.WorkingArea;
            return new Point(area.Width, area.Height);
        }

        public void on     (){   T.Visible = true      ; }
        public void off    (){   T.Visible = false     ; }
        public bool onoff  (){   T.Visible = !T.Visible; return T.Visible; }
        public bool visible(){   return T.Visible      ; }

        public int height()
        {   if(T.Visible) return T.Height + 4;
            else          return            0;
        }
    }

    //-------------------------------------------------|
    //  source - диапазон изменения входного параметра.|
    //  dest   - диапазон приведение выхода.           |
    //-------------------------------------------------:
    public class fromDipTo
    {   public   fromDipTo(Point   dest, Point source)
                 {  this.dest   =  dest;
                    this.source =  source;
                    d = (float)((source.Y - source.X) /
                                (dest  .Y - dest  .X));
                 }

        public int Convert(int a)
        {   if (a < source.X) return dest.X;
            if (a > source.Y) return dest.Y;
            return (int)(((float)(a - source.X)) / d) + dest.X;
        }

        public static void test()
        {   fromDipTo m = new fromDipTo(new Point( 2,  11),
                                        new Point(21, 100));
            int r = m.Convert(21);
            MyLib.textout.add("r = ", r);
        }

        private Point dest  ;
        private Point source;
        private float d     ;
    }
}
