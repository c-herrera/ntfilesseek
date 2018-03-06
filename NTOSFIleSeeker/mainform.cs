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
    public partial class frm_copy_sys : Form
    {

        string[] windows_system_path;

        List<string> pattern_files;
        List<string> full_path;

        string[] listfiles;

        string save_folder;
        string arch_folder;

        string status;
        string info;

        SimpleLogger log;
        Tool_Config options;

        enum system_path_files
        {
            seek_sys32,
            seek_sys32_drivers
        };

        public frm_copy_sys()
        {
            InitializeComponent();
        }

        private void frm_copy_sys_Load(object sender, EventArgs e)
        {
            log = new SimpleLogger();
            options = new Tool_Config();            
            
            log.Info("Application form load");
            log.Info("Trying to get Admin privileges");

            rd_default_files.Checked = options.using_default_filenames;
            rd_custom_opt.Checked = options.Using_custom_filenames;

            if (WindowsIdentity.GetCurrent().Owner == WindowsIdentity.GetCurrent().User)   // Check for Admin privileges   
            {
                try
                {
                    this.Visible = false;
                    ProcessStartInfo info = new ProcessStartInfo(Application.ExecutablePath); // my own .exe
                    info.UseShellExecute = true;
                    info.Verb = "runas";   // invoke UAC prompt
                    Process.Start(info);
                    log.Info("Application has admin privileges");
                }
                catch (Win32Exception ex)
                {
                    if (ex.NativeErrorCode == 1223) //The operation was canceled by the user.
                    {
                        MessageBox.Show("Why did you not selected Yes?", "WHY?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        log.Debug("Canceled the Admin privileges");
                        Application.Exit();
                    }
                    else
                        throw new Exception("Something went wrong :-(");
                }
                Application.Exit();
            }
            else
            {
                log.Info("I have admin privileges :-)");
            }

            status += "App is on" + Environment.NewLine;

            windows_system_path = new string[2];
            pattern_files = new List<string>();
            full_path = new List<string>();

            log.Info("Vars are initialazed ok!");

            if (Environment.Is64BitOperatingSystem )
            {
                arch_folder = "amd64";
                windows_system_path[0] = Environment.GetFolderPath(Environment.SpecialFolder.System);
                windows_system_path[1] = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\";
                log.Trace("64 bit system ?:" + Environment.Is64BitOperatingSystem);
                log.Warning("System is 64 bits, this may change the files path");
                for (int i = 0; i < windows_system_path.Length; i++)
                    log.Trace("Path  found " + windows_system_path[i]);
            }
            else
            {
                arch_folder = "x86";
                windows_system_path[0] = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
                windows_system_path[1] = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\drivers\\";
                log.Trace("64 bit system ?:" + Environment.Is64BitOperatingSystem);
                log.Warning("System is not 64 bits, this may change the files path");
                for (int i = 0; i < windows_system_path.Length; i++)
                    log.Trace("Path  found " + windows_system_path[i]);
            }

            log.Info("Status seems ok");

            notifyIcon1.BalloonTipTitle = " NTOSFILESEEKER";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;
            txt_path_build.Focus();
            btn_copy.Enabled = false;

            log.Info("Notification did its job");

            if (options.using_default_filenames == true)
                listfiles = options.DefaultFilenames;

            if (options.Using_custom_filenames == true)
               listfiles = options.CustomFilenames;

            try
            {
                for (int i = 0; i < listfiles.Length; i++)
                {
                    pattern_files.Add(listfiles[i]);
                }

                if (pattern_files.Count > 0)
                    log.Trace("List of files copied to search pattern");
                else
                    log.Error("Not enough files to search, unexepected ehaviour");
            }
            catch (Exception ex)
            {
                log.Debug("Error while trying to set the required pattern of files");
                log.Debug("Error from exception" + ex.Message);
            }

            info += "NTOSFileSeeker v" + Application.ProductVersion + Environment.NewLine;
            info += "How to use this tool :" + Environment.NewLine;
            info += "1. Copy this tool to the target OS system :" + Environment.NewLine;
            info += "2. Run the tool, click on the textbox, and type the OS Build number, e.g 14393" + Environment.NewLine;
            info += "3. Click on the 'Search Button', the files will be listed " + Environment.NewLine;
            info += "4. Once the files apppear, you can click the Copy button, the files will be copied to the " + Environment.NewLine;
            info += "<os build number\\arch_type> folder" + Environment.NewLine;
            info += " " + Environment.NewLine + Environment.NewLine + Environment.NewLine ;
            info += "Tool developer : C. A. Herrera" + Environment.NewLine;

            txt_info.Text = info;

            log.Info("Application started normal.");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lst_files.DataSource = null;
            lst_files.Items.Clear();
            lst_files.Update();

            if (lst_files.Items.Count == 0)
                log.Trace("No items in the list box");

            pattern_files.Clear();

            full_path = new List<string>();
            full_path.Clear();

            // Load on demand the file list
            if (rd_default_files.Checked == true)
                listfiles = options.DefaultFilenames;

            if (rd_custom_opt.Checked == true)
                listfiles = options.CustomFilenames;

            try
            {
                for (int i = 0; i < listfiles.Length; i++)
                {
                    pattern_files.Add(listfiles[i]);
                }

                if (pattern_files.Count > 0)
                    log.Trace("List of files copied to search pattern");
                else
                    log.Error("Not enough files to search, unexepected behaviour");
            }
            catch (Exception ex)
            {
                log.Debug("Error while trying to set the required pattern of files");
                log.Debug("Error from exception" + ex.Message);
            }

            try
            {
                foreach (string ext in pattern_files)
                {
                    log.Trace("Searching for " + ext);
                    foreach (string path in windows_system_path)
                    {
                        log.Trace("Looking in path :" + path);
                        foreach (string file in Directory.GetFiles(path, ext))
                        {
                            full_path.Add(file);
                            log.Info(" File path : " + file);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("An error ocurred while loading files call is  frm_copy_sys::btn_search_Click");
                MessageBox.Show("Error message" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            lst_files.Items.Clear();
            lst_files.DataSource = full_path;
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            save_folder = string.Empty;
            if ( txt_path_build.Text != string.Empty || txt_path_build.Text != "" )
            {
                save_folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + txt_path_build.Text + "\\" + arch_folder;
                if ( Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) )
                {
                    log.Trace("Called : btn_copy_Click, Desktop folder is " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) );
                    if (Directory.Exists(save_folder) == false)
                    {
                        Directory.CreateDirectory(save_folder);
                        log.Trace("Save folder created succesfully.");
                        log.Trace("Current save path is " + save_folder);
                    }
                    
                }

                if (full_path.Count > 0 )
                {
                    foreach ( string file in full_path )
                    {
                        File.Copy(file, save_folder + "\\" + Path.GetFileName(file), true);
                        log.Trace("Copying file " + file + " To  ==>" + save_folder); 
                    }

                    notifyIcon1.BalloonTipText = " Process is done, check the files on the Desktop folder";
                    notifyIcon1.ShowBalloonTip(1000);
                    log.Info(" Files seem to be copied to the target directory");
                }
                else
                {
                    MessageBox.Show("No files are found? I'll search them, don't worry", "Missing somenthing ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.Trace(" Clicked on copy instead of search, executing the search button Event"); 
                    btn_search.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Fill the textbox with the build name", "Missing something ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_path_build.Focus();
            }
        }

        private void txt_path_build_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_path_build.Text.Length > 1)
                btn_copy.Enabled = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            log.Info("Application exit.");
            Application.Exit();
        }

        private void rd_custom_opt_CheckedChanged(object sender, EventArgs e)
        {
            txt_filelist.Text = string.Empty;
            txt_filelist.Enabled = true;
            chk_file_add.Checked = true;

            lbl_file_notice.Text = "Using Custom list";
            lst_filenames.Items.Clear();
            lst_filenames.Items.AddRange(options.CustomFilenames);

            log.Trace("Switched to custom");
        }

        private void btn_apply_conf_Click(object sender, EventArgs e)
        {
            string temp = string.Empty;

            if (txt_filelist.Text == string.Empty || txt_filelist.Text.Length ==0 )
            {
                log.Warning("Textbox for file list is empty");
            }
            else
            {
                options.Using_custom_filenames = rd_custom_opt.Checked;
                options.using_default_filenames = rd_default_files.Checked;

                options.CustomFilenames = txt_filelist.Text.Split(',');
                log.Info("Saving the options.");
                options.SaveConfiguration();
                log.Info("Writing custom file values to file");
            }


        }

        private void rd_default_files_Click(object sender, EventArgs e)
        {
            txt_filelist.Text = string.Empty;
            txt_filelist.Enabled = false;
            chk_file_add.Checked = false;

            lbl_file_notice.Text = "Using default list";
            lst_filenames.Items.Clear();
            lst_filenames.Items.AddRange(options.DefaultFilenames);

            log.Trace("Switched to default");
        }

        private void rd_custom_opt_Click(object sender, EventArgs e)
        {
            txt_filelist.Text = string.Empty;
            txt_filelist.Enabled = true;
            chk_file_add.Checked = true;

            lbl_file_notice.Text = "Using Custom list";
            lst_filenames.Items.Clear();
            lst_filenames.Items.AddRange(options.CustomFilenames);

            log.Trace("Switched to custom");
        }

        private void chk_file_add_Click(object sender, EventArgs e)
        {
            log.Trace("Check state of " + this.chk_file_add.ToString() + " State : " + chk_file_add.Checked);
            txt_filelist.Enabled = (chk_file_add.Checked == true) ? true : false;
        }
    }
}
