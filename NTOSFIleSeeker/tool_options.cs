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
        private string[] CustomList;

        private bool opt_default_conf;
        private bool opt_custom_files;
        private bool conf_file_present;
        private string conf_file_path;
        private string default_list_bvalue;
        private string default_list_string;
        private string custom_list_bvalue;
        private string custom_list_string;

        /// <summary>
        /// Class constructor, no overloaded.
        /// </summary>
        public Tool_Config()
        {
            default_list_bvalue = Boolean.TrueString.ToLower();
            custom_list_bvalue = Boolean.FalseString.ToLower();
            custom_list_string = "dummy.1st,dummy.2nd";
            
            conf_file_path = ".//" + Application.ProductName + "_config.conf";
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
            default_list_string = new string (temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());

            // Create file if it doesnt exist
            if (File.Exists(conf_file_path) == false)
            {
                IniFileHelper.WriteValue("files", "ntcorefiles", default_list_string, conf_file_path);
                IniFileHelper.WriteValue("files", "customlist", custom_list_string , conf_file_path);
                IniFileHelper.WriteValue("options", "default_files", default_list_bvalue, conf_file_path);
                IniFileHelper.WriteValue("options", "custom_files", custom_list_bvalue, conf_file_path);
            }
            else
            {
                conf_file_present = true;
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
            if (File.Exists (conf_file_path) == true)
            {
                temp = IniFileHelper.ReadValue("files", "ntcorefiles", conf_file_path);
                pass = new string(temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                Filelist = pass.Split(',');

                temp = IniFileHelper.ReadValue("files", "customlist", conf_file_path);
                pass = new string(temp.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                CustomList = pass.Split(',');

                value = IniFileHelper.ReadValue("options", "default_files", conf_file_path).ToLower();
                if (value.Contains("true"))
                    opt_default_conf = true;
                value = IniFileHelper.ReadValue("options", "custom_files", conf_file_path).ToLower();
                if (value.Contains("true"))
                    opt_custom_files = true;

                conf_file_present = true;
            }
            else // Create a defauilt config file
            {
                conf_file_present = false;
                CreateDefaultConfig();
            }
        }

        /// <summary>
        /// Saves all parameters from UI to a file
        /// </summary>
        public void SaveConfiguration()
        {                       
            if (File.Exists(conf_file_path))
            {
                IniFileHelper.WriteValue("options", "default_files", opt_default_conf.ToString().ToLower(), conf_file_path);
                IniFileHelper.WriteValue("options", "custom_files", opt_custom_files.ToString().ToLower(), conf_file_path);
                IniFileHelper.WriteValue("files", "customlist", string.Join(",",CustomList) , conf_file_path);                
            }
            else
            {
                conf_file_present = false;
                CreateDefaultConfig();
                IniFileHelper.WriteValue("options", "default_files", opt_default_conf.ToString().ToLower(), conf_file_path);
                IniFileHelper.WriteValue("options", "custom_files", opt_custom_files.ToString().ToLower(), conf_file_path);
            }

        }

        #region Accesors

        /// <summary>
        /// Return in read mode only the array of files to copy
        /// </summary>
        public string[] DefaultFilenames
        {
            get { return Filelist; }
        }

        /// <summary>
        /// Can set or get the custom file names array string.
        /// </summary>
        public string[] CustomFilenames
        {
            get { return CustomList; }
            set { CustomList = value; }
        }

        /// <summary>
        /// Can set or get the state for default file names option
        /// </summary>
        public bool using_default_filenames
        {
            get { return opt_default_conf; }
            set { opt_default_conf = value; }
        }

        /// <summary>
        /// Can set and get the state of the custom file names option
        /// </summary>
        public bool Using_custom_filenames
        {
            get { return opt_custom_files; }
            set { opt_custom_files = value; }
        }

        /// <summary>
        /// Value returned if configuratio file exist. Read only
        /// </summary>
        public bool conf_file_exist
        {
            get { return conf_file_present; }
        }
        #endregion

    }
}
