using Hakomo.Library;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace Restore {

    class Restore {

        private static WinAPI.Placement[] File {
            get {
                FileStream fs = null;
                try {
                    fs = new FileStream(Application.StartupPath + "\\restowa.dat", FileMode.Open);
                    return (WinAPI.Placement[])(new DataContractJsonSerializer(typeof(WinAPI.Placement[]))).ReadObject(fs);
                } catch {
                    return new WinAPI.Placement[0];
                } finally {
                    if(fs != null)
                        fs.Dispose();
                }
            }
        }

        private static void Main() {
            foreach(WinAPI.Placement p in File)
                p.Restore();
        }
    }
}
