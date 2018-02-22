using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTOSFIleSeeker
{
    /// <summary>
    /// ToolConf contains all the preferences the user can set on the ui
    /// </summary>

    class Tool_Config
    {
        private string[] Filelist;

        public string [] Files
        {
            get { return Filelist; }
        }
        /// <summary>
        /// Class constructor, no overloaded.
        /// </summary>
        public Tool_Config()
        {
            CreateDefaultConfig();
            LoadConfiguration();

        }

        /// <summary>
        /// Creates a file with the default preferences, used by tool and user 
        /// </summary>
        private void CreateDefaultConfig()
        {
            string list = "ntoskrnl.exe, hal.dll, dxgmms1.sys, dxgmms2.sys , dxgkrnl.sys, watchdog.sys, mssmbios.sys";
            string temp = string.Empty;

            if (File.Exists("seeker.conf") == false)
            {
                IniFileHelper.WriteValue("files", "ntcorefiles", list, ".\\seeker.conf");
            }
        }


        /// <summary>
        /// Loads the configuration parameters from the config file
        /// </summary>
        public void LoadConfiguration()
        {
            if (File.Exists ("seeker.conf") == true)
            {
                //temp = IniFileHelper.ReadValue("files", "ntcorefiles", "seeker.conf");
                Filelist = IniFileHelper.ReadValue("files", "ntcorefiles", ".\\seeker.conf").Split(',');
                //Filelist = temp.Split(',');
            }
        }

        /// <summary>
        /// Saves all parameters from UI to a file
        /// </summary>
        public void SaveConfiguration()
        {
                      
        }

        #region Accesors


        #endregion


    }
}
