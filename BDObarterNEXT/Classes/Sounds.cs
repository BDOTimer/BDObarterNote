using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Media;

using System.Threading;
using System.Threading.Tasks;

using System.Windows.Media; // WindowsBase.dll, PresentationCore.dll

namespace BDObarterNEXT
{
    //-------------------------------------------------------------------------|
    //  MySounds
    //-------------------------------------------------------------------------:
    public class MySounds
    {
        public MySounds()
        {   load_sounds();
        }

        public enum eSND //  sounds.play(MySounds.eSND.MOVE);
        {   MOVE   = 0,
            SHOW      ,
            RESET     ,
            NPANEL    ,
            MOVEBACK  ,
            EXIT      ,
            TOSOURCE  ,
            SHOWRIGHT ,
            AHTUNG    ,
            OPENDIALOG,
            START     ,
            // ...
            end
        }

        private SoundPlayer[]  sp   ;
        private List<string> files;
        private void load_sounds()
        {
            files =
                (   from a in Directory.GetFiles(
                    "./snd",
                    "*.wav",
                    SearchOption.TopDirectoryOnly)
                    select "snd/" + Path.GetFileName(a)
                ).ToList();

            sp = new SoundPlayer[files.Count];

            for(int i  = 0; i < sp.Length; ++i)
            {   sp [i] = new SoundPlayer     ();
                sp [i].SoundLocation = files[i];
              //sp [i].Load     ();
                sp [i].LoadAsync();
              //sp [i].Stream = new FileStream( files[i],
              //                                FileMode.Open,
              //                                FileAccess.Read );
            }
        }

        private List<SoundPlayer> my;
        private void xxxload_sounds()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("./snd");
            my = new List<SoundPlayer>();
            foreach (var file in directoryInfo.GetFiles())
            {
                if (Path.GetExtension(file.FullName) == ".wav")
                {   my.Add(new SoundPlayer(file.FullName));
                    my[my.Count - 1].Load();
                }
            }
        }

        public void play_t      (MySounds.eSND I)
        {   //sp = new System.Media.SoundPlayer("snd/" + files[(int)i]);
            sp [(int)I].Play();
        }
        public void play_sync (MySounds.eSND I)
        {   //sp = new System.Media.SoundPlayer("snd/" + files[(int)i]);
            sp [(int)I].PlaySync();
        }

        public void xplay     (MySounds.eSND I)
        {   my[(int)I].Play();
        }
        public void xplay_sync(MySounds.eSND I)
        {   my[(int)I].PlaySync();
        }

        // Для работы необходимо подключить WindowsBase.dll PresentationCore.dll
        // [System.Runtime.InteropServices.DllImport("winmm.dll")]
        // private static extern
        // Boolean PlaySound(string lpszName, int hModule, int dwFlags);
        static MediaPlayer player = new MediaPlayer();
        public static void xxxtest()
        {   player .Open(new Uri("snd\\boyz.mp3", UriKind.Relative));
            player .Play   ();
          //player .Close  ();
        }

        ///-------------------|
        /// Thread.           |
        ///-------------------:
        MySounds.eSND id_sound;
        public void play(MySounds.eSND n)
        {   
            if(!myForm.dialog.isSound() && eSND.AHTUNG != n)
            {   id_sound = eSND.MOVEBACK;
            }
            else
            {   id_sound = n;
            }
            
            Thread 
            t = new Thread(new ThreadStart(this.foofoo));
            t.Start();
        }

        private void foofoo()
        {   play_t (id_sound);
            //Debug.Out.add("Sound::foofoo - ", id_sound.ToString());
        }
    }
}
