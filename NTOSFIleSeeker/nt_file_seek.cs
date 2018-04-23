using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTOSFIleSeeker
{
    enum system_path_files
    {
        seek_sys32, seek_sys32_drivers
    };

    class NT_file_seek
    {
        private string[] windows_syspath;

        private List<string> pattern_files;
        private List<string> full_path;

        private string[] listfiles;

        private string save_folder;
        private string arch_folder;

        SimpleLogger log;
        Tool_Config options;

        public NT_file_seek()
        {
            windows_syspath = new string[2];
            pattern_files = new List<string>();
            full_path = new List<string>();

            Win32Path = new string[2];
            TargetFilesPath = new List<string>();
            FilesToGet = new string[sizeof(system_path_files)];

            SaveFolder = string.Empty;
            ArchFolder = string.Empty;

            log = new SimpleLogger();
            options = new Tool_Config();

            if (Environment.Is64BitOperatingSystem)
            {
                arch_folder = "amd64";
                Win32Path[0] = Environment.GetFolderPath(Environment.SpecialFolder.System);
                Win32Path[1] = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\";
                log.Trace("64 bit system ?:" + Environment.Is64BitOperatingSystem);
                log.Warning("System is 64 bits, this may change the files path");
                for (int i = 0; i < windows_syspath.Length; i++)
                    log.Trace("Path  found " + windows_syspath[i]);
            }
            else
            {
                arch_folder = "x86";
                Win32Path[0] = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
                Win32Path[1] = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\drivers\\";
                log.Trace("64 bit system ?:" + Environment.Is64BitOperatingSystem);
                log.Warning("System is not 64 bits, this may change the files path");
                for (int i = 0; i < Win32Path.Length; i++)
                    log.Trace("Path  found " + Win32Path[i]);
            }


        }



        /// <summary>
        /// Has the windows system 32 path = windows syspath var
        /// </summary>
        public string[] Win32Path { get; set; }

        /// <summary>
        /// Has the File Pattern to search = pattern files
        /// </summary>
        public List<string>FilePattern { get; set; }

        /// <summary>
        /// Has the full file path =  full path
        /// </summary>
        public List<string> TargetFilesPath { get; set; }

        /// <summary>
        /// Has the full list of files = listfiles
        /// </summary>
        public string[] FilesToGet { get; set; }

        /// <summary>
        /// Has the path of the save folder = save folder var
        /// </summary>
        public string SaveFolder { get; set; }

        /// <summary>
        /// Has the Architecture folder path =  arch folder var
        /// </summary>
        public string ArchFolder { get; set; }


    }
}
