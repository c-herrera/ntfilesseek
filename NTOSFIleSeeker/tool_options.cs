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

        private bool use_default_options;
        private bool use_custom_filelist;
        private bool opt_default_conf;
        private bool opt_custom_files;

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
            string defopt = "true";
            string custopt = "false";
            string temp = "ntoskrnl.exe,hal.dll,dxgmms1.sys,dxgmms2.sys,dxgkrnl.sys,watchdog.sys,mssmbios.sys";
            string list = new string (temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());

            // Create file if it doesnt exist
            if (File.Exists("seeker.conf") == false)
            {
                IniFileHelper.WriteValue("files", "ntcorefiles", list, ".\\seeker.conf");
                IniFileHelper.WriteValue("options", "default_files", defopt, ".\\seeker.conf");
                IniFileHelper.WriteValue("options", "custom_files", custopt, ".\\seeker.conf");
            }
        }


        /// <summary>
        /// Loads the configuration parameters from the config file
        /// </summary>
        public void LoadConfiguration()
        {
            string temp = string.Empty;
            string pass = string.Empty;
            string value = string.Empty;

            // Config files must exist, if not found
            if (File.Exists ("seeker.conf") == true)
            {
                temp = IniFileHelper.ReadValue("files", "ntcorefiles", ".\\seeker.conf");
                pass = new string(temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                Filelist = pass.Split(',');

                value = IniFileHelper.ReadValue("options", "default_files", ".\\seeker.conf").ToLower();
                if (value.Contains("true"))
                    opt_default_conf = true;
                value = IniFileHelper.ReadValue("options", "custom_files", ".\\seeker.conf").ToLower();
                if (value.Contains("true"))
                    opt_custom_files = true;
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
            IniFileHelper.WriteValue("files", "default_files", opt_default_conf.ToString(), ".\\seeker.conf");
            IniFileHelper.WriteValue("files", "custom_files", opt_custom_files.ToString(), ".\\seeker.conf");
        }

        #region Accesors

        /// <summary>
        /// Return in read mode only the array of files to copy
        /// </summary>
        public string[] Files
        {
            get { return Filelist; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool set_use_default_options
        {
            get { return opt_default_conf; }
            set { opt_default_conf = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool set_custom_filenames
        {
            get { return opt_custom_files; }
            set { opt_custom_files = value; }
        }


        #endregion

    }
}
