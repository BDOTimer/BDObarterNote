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
            if (B.Parent == null) return;
            B.Parent.Controls.Remove(B);
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
        {
            var world = 2022;
            logd(() => world);
        }

        public void logd<T>(Expression<Func<T>> value)
        {
            var me = (MemberExpression)value.Body;
            string variableName  = me.Member.Name;
            var    variableValue = value.Compile()();
            add(variableName, variableValue);
        }

        public void debug()
        {   
            add("Textout.debug()");
            add("  T.TextLength     ", T.TextLength     );
            add("  T.SelectionStart ", T.SelectionStart );
            add("  T.Lines.Length   ", T.Lines.Length   );
            add("  T.SelectionLength", T.SelectionLength);
            add("");
        }

        public static Point GetScreenResolution()
        {
            Screen myScreen = Screen.PrimaryScreen;
            Rectangle area  = myScreen.WorkingArea;
            return new Point(area.Width, area.Height);
        }

        public void on     (){   T.Visible = true      ; }
        public void off    (){   T.Visible = false     ; }
        public bool onoff  (){   T.Visible = !T.Visible; return T.Visible; }
        public bool visible(){   return T.Visible      ; }

        //private bool visible = true;
        public int height()
        {   if(T.Visible) return T.Height + 4;
            else          return            0;
        }
    }
}
