///-------------------------------------------------------------------------- 01
/// Serialize/Deserialize.
///----------------------------------------------------------------------------:
using (var  stream = File.Create("file.xml"))
{   var serializer = new XmlSerializer(typeof(string[]));
    serializer.Serialize(stream, someArrayOfStrings);
}

//----------------- Создали коллекцию из десяти студентов ---------------------:
List<Студент> stds = new List<Студент>();
for (int i = 0; i < 10; i++)
{   stds.Add(new Студент("фамилия "  + i.ToString(), 
                         "имя "      + i.ToString(), 
                         "отчество " + i.ToString(), 
                         "город "    + i.ToString(), 
                         DateTime.Now, 
                         DateTime.Now, 
                         new int[]{5, 5}));
}
//-----------------------------------------------------------------------------:
using (FileStream fs = new FileStream
                               (@"C:\1.txt", FileMode.Create, FileAccess.Write))
{   XmlSerializer serializer = new XmlSerializer(stds.GetType());
    serializer.Serialize(fs, stds);
}

// для сериализации следующим образом:
private async Task SaveSettings(Settings settings)
{   var folder  = Windows.Storage.ApplicationData.Current.LocalFolder;
    var options = Windows.Storage.CreationCollisionOption.ReplaceExisting;
    var file    = await   folder .CreateFileAsync("Settings.XML", options);
    try
    {   XmlSerializer SerializerObj = new XmlSerializer(typeof(Settings));
        SerializerObj.Serialize(await file.OpenStreamForWriteAsync(), settings);
    }
    catch
    {
        // handle any kind of exceptions
    }
}

// Десериализуйте так:
private async Task<Settings> LoadSettings()
{   Settings settings = new Settings(); 
    var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
    try
    {   var file                    = await folder.GetFileAsync("Settings.XML");
        XmlSerializer SerializerObj = new XmlSerializer(typeof(Settings));
        settings = SerializerObj.Deserialize(await file.OpenStreamForReadAsync()) 
                   as Settings;
        }
        catch (Exception ex)
        {   // handle any kind of exceptions
        }
        return settings;
    }
}

[Serializable] — используется, когда мы помечаем объект как сериализуемый. [NonSerialized] — используется, когда мы не хотим сериализовать поле объекта. [OnSerializing] — используется, когда мы хотим выполнить какое-то действие при сериализации объекта. 
[OnSerialized] — используется, когда мы хотим выполнить какое-то действие после сериализации объекта в поток.

///-------------------------------------------------------------------------- 02
/// Как воспроизвести mp3 файл.
///----------------------------------------------------------------------------:
namespace Form2
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern
            Boolean PlaySound(string lpszName, int hModule, int dwFlags);
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {   InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {   this.Text = WMP.versionInfo;
            WMP.URL = @"http://mp3.nashe.ru/nashe-128.mp3";
            WMP.controls.play();
        }
        private void button2_Click(object sender, EventArgs e)
        {   WMP.controls.stop();
        }
    }
}

///-------------------------------------------------------------------------- 03
/// reflection.
///----------------------------------------------------------------------------:
        void test_01()
        {
            Object          obj = new Point         (11, 22); 
            Type              t = obj.GetType       (      );
            var convertedObject = Convert.ChangeType(obj, t);

            // reflection
            obj.GetType().GetMethod("MyFunction").Invoke(obj, null);
        }


