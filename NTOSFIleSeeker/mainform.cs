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

        string save_folder;
        string arch_folder;

        string status;

        string info;

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
            if ( WindowsIdentity.GetCurrent().Owner == WindowsIdentity.GetCurrent().User )   // Check for Admin privileges   
            {
                try
                {
                    this.Visible = false;
                    ProcessStartInfo info = new ProcessStartInfo(Application.ExecutablePath); // my own .exe
                    info.UseShellExecute = true;
                    info.Verb = "runas";   // invoke UAC prompt
                    Process.Start(info);
                }
                catch ( Win32Exception ex )
                {
                    if ( ex.NativeErrorCode == 1223 ) //The operation was canceled by the user.
                    {
                        MessageBox.Show("Why did you not selected Yes?", "WHY?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Application.Exit();
                    }
                    else
                        throw new Exception("Something went wrong :-(");
                }
                Application.Exit();
            }
            else
            {
                //    MessageBox.Show("I have admin privileges :-)");
            }

            status += "App is on" + Environment.NewLine;

            windows_system_path = new string[2];
            pattern_files = new List<string>();
            full_path = new List<string>();
            if (Environment.Is64BitOperatingSystem )
            {
                arch_folder = "amd64";
                windows_system_path[0] = Environment.GetFolderPath(Environment.SpecialFolder.System);
                windows_system_path[1] = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\";
            }
            else
            {
                arch_folder = "x86";
                windows_system_path[0] = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
                windows_system_path[1] = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\drivers\\";
            }

            status += " System is " + arch_folder + Environment.NewLine;
            status += " Path of folders are :" + windows_system_path[0] + Environment.NewLine ;
            status += " Path of folders are :" + windows_system_path[1] + Environment.NewLine ;

            txt_status.AppendText(status);

            notifyIcon1.BalloonTipTitle = " NTOSFILESEEKER";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;

            txt_path_build.Focus();
            btn_copy.Enabled = false;

            pattern_files.Add("ntoskrnl.exe");
            pattern_files.Add("hal.dll");
            pattern_files.Add("dxgmms1.sys");
            pattern_files.Add("dxgmms2.sys");
            pattern_files.Add("dxgkrnl.sys");
            pattern_files.Add("watchdog.sys");

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

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lst_files.DataSource = null;
            lst_files.Items.Clear();
            lst_files.Update();

            full_path = new List<string>();
            full_path.Clear();

            foreach ( string ext in pattern_files )
            {
                foreach ( string path in windows_system_path )
                {
                    foreach ( string file in Directory.GetFiles(path, ext) )
                    {
                        full_path.Add(file);
                    }
                }

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
                    if (Directory.Exists(save_folder) == false)
                    {
                        Directory.CreateDirectory(save_folder);
                    }
                    
                }

                if (full_path.Count > 0 )
                {
                    foreach ( string file in full_path )
                    {
                        File.Copy(file, save_folder + "\\" + Path.GetFileName(file), true);
                    }

                    notifyIcon1.BalloonTipText = " Process is done, check the files on the Desktop folder";
                    notifyIcon1.ShowBalloonTip(1000);
                }
                else
                {
                    MessageBox.Show("No files are found? I'll search them, don't worry", "Missing somenthing ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Application.Exit();
        }
    }
}
