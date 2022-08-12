using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BDObarterNEXT
{
    //--------------------------------------|
    // mySerializator.                      |
    //--------------------------------------:
    public class mySerializator
    {
        public mySerializator(string fname)
        {
            filename = fname;
            formatter = new BinaryFormatter();
        }

        string          filename;
        BinaryFormatter formatter;

        public enum eMODE
        {
            LOAD,
            SAVE
        }

        //----------------------------------|
        // load.                            |
        //----------------------------------:
        FileStream ffile;
        public void create_load()
        {
            try
            {
                mode  = eMODE.LOAD;
                ffile = new FileStream(
                    filename,
                    FileMode  .Open,
                    FileAccess.Read
                );
            }
            catch
            {   create_save();
                Console.WriteLine("catch");
            }
        }

        private eMODE mode = eMODE.LOAD;
        public void load<T>(ref T o)
        {
            switch (mode)
            {   case eMODE.LOAD: o = (T)formatter.Deserialize(ffile)  ; break;
                case eMODE.SAVE:        formatter.Serialize(output, o); break;
            }
        }

        private void close_load() { if (ffile != null) ffile.Close(); }

        //----------------------------------|
        // save.                            |
        //----------------------------------:
        FileStream output;
        public void create_save()
        {
            mode = eMODE.SAVE;
            output = new FileStream(
                filename               ,
                FileMode  .OpenOrCreate,
                FileAccess.Write
            );
        }

        public void save<T>(ref T o)
        {   formatter.Serialize(output, o);
        }

        public void save2(ref object o)
        {   formatter.Serialize(output, o);
        }

        private void close_save() { if (output != null) output.Close(); }

        public void close()
        {   switch   (mode)
            {   case eMODE.LOAD: close_load();  break;
                case eMODE.SAVE: close_save();  break;
            }
        }
    }
}
