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
        {   filename  = fname;
            formatter = new BinaryFormatter();
        }

        string          filename     ;
        BinaryFormatter formatter    ;
        bool            error = false;

        //----------------------------------|
        // load.                            |
        //----------------------------------:
        FileStream         ffile;
        public void create_load()
        {
            close();
            try
            {   ffile = new FileStream(
                    filename,
                    FileMode  .Open,
                    FileAccess.Read
                );
            }
            catch
            {   //throw;
                error = true;
            }
        }

        public void load<T>(ref T o)
        {   if(error) return;
            o = (T)formatter.Deserialize(ffile);
        }

        private void close_load() { if (ffile != null) ffile.Close(); }

        //----------------------------------|
        // save.                            |
        //----------------------------------:
        FileStream        output;
        public void create_save()
        {
            close();

            output = new FileStream(
                filename               ,
                FileMode  .OpenOrCreate,
                FileAccess.Write
            );
        }

        public void save<T>(ref T o)
        {   formatter.Serialize(output, o);
        }

        private void close_save() { if (output != null) output.Close(); }

        public void close() 
        {   if (output != null) output.Close();
            if (ffile  != null) ffile .Close();
            error = false;
        }

        //-----------|
        // test.     |
        //-----------:
        void xxxtest_01()
        {
            Object          obj = new     Point     (11, 22);
            Type              t = obj    .GetType   (      );
            var convertedObject = Convert.ChangeType(obj, t);

            // reflection
            obj.GetType().GetMethod("MyFunction").Invoke(obj, null);
        }
    }
}
