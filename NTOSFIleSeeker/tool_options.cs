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
            // Make default string if file does not exist
            string temp = "ntoskrnl.exe,hal.dll,dxgmms1.sys,dxgmms2.sys,dxgkrnl.sys,watchdog.sys,mssmbios.sys";
            string list = new string (temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());

            // Create file if it doesnt exist
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
            string temp = string.Empty;
            string pass = string.Empty;

            // Config files must exist, if not found
            if (File.Exists ("seeker.conf") == true)
            {
                temp = IniFileHelper.ReadValue("files", "ntcorefiles", ".\\seeker.conf");
                pass = new string(temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                Filelist = pass.Split(',');
                //Filelist = IniFileHelper.ReadValue("files", "ntcorefiles", ".\\seeker.conf").Split(',');               
            }
            else // Create a defauilt config file
            {
                CreateDefaultConfig();
            }
        }

        /// <summary>
        /// Saves all parameters from UI to a file
        /// </summary>
        public void SaveConfiguration()
        {
                      
        }

        #region Accesors

        /// <summary>
        /// Return in read mode only the array of files to copy
        /// </summary>
        public string[] Files
        {
            get { return Filelist; }
        }
        #endregion


    }
}
