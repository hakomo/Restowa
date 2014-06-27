using Hakomo.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace Save {

    class Save {

        private static void Main() {
            List<WinAPI.Placement> placements = new List<WinAPI.Placement>();
            foreach(IntPtr hw in WinAPI.GetTasks())
                placements.Add(new WinAPI.Placement(hw));
            FileStream fs = null;
            try {
                fs = new FileStream(Application.StartupPath + "\\restowa.dat", FileMode.Create);
                (new DataContractJsonSerializer(typeof(WinAPI.Placement[]))).WriteObject(fs, placements.ToArray());
            } catch {
            } finally {
                if(fs != null)
                    fs.Dispose();
            }
        }
    }
}
