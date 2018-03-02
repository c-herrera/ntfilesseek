namespace NTOSFIleSeeker
{
    partial class frm_copy_sys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_copy_sys));
            this.btn_copy = new System.Windows.Forms.Button();
            this.txt_path_build = new System.Windows.Forms.TextBox();
            this.lbl_text_1 = new System.Windows.Forms.Label();
            this.lst_files = new System.Windows.Forms.ListBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_results = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_info = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_apply_conf = new System.Windows.Forms.Button();
            this.lbl_file_notice = new System.Windows.Forms.Label();
            this.txt_filelist = new System.Windows.Forms.TextBox();
            this.rd_custom_opt = new System.Windows.Forms.RadioButton();
            this.rd_default_files = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lst_filenames = new System.Windows.Forms.ListBox();
            this.chk_file_add = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_copy
            // 
            this.btn_copy.Image = ((System.Drawing.Image)(resources.GetObject("btn_copy.Image")));
            this.btn_copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_copy.Location = new System.Drawing.Point(127, 205);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(75, 23);
            this.btn_copy.TabIndex = 0;
            this.btn_copy.Text = "Copy";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // txt_path_build
            // 
            this.txt_path_build.Location = new System.Drawing.Point(37, 37);
            this.txt_path_build.Name = "txt_path_build";
            this.txt_path_build.Size = new System.Drawing.Size(189, 20);
            this.txt_path_build.TabIndex = 1;
            this.txt_path_build.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_path_build_KeyDown);
            // 
            // lbl_text_1
            // 
            this.lbl_text_1.AutoSize = true;
            this.lbl_text_1.Location = new System.Drawing.Point(34, 17);
            this.lbl_text_1.Name = "lbl_text_1";
            this.lbl_text_1.Size = new System.Drawing.Size(75, 13);
            this.lbl_text_1.TabIndex = 2;
            this.lbl_text_1.Text = "Copy to Folder";
            // 
            // lst_files
            // 
            this.lst_files.FormattingEnabled = true;
            this.lst_files.Location = new System.Drawing.Point(37, 104);
            this.lst_files.Name = "lst_files";
            this.lst_files.Size = new System.Drawing.Size(321, 95);
            this.lst_files.TabIndex = 3;
            // 
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(37, 205);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_results
            // 
            this.lbl_results.AutoSize = true;
            this.lbl_results.Location = new System.Drawing.Point(34, 72);
            this.lbl_results.Name = "lbl_results";
            this.lbl_results.Size = new System.Drawing.Size(227, 13);
            this.lbl_results.TabIndex = 5;
            this.lbl_results.Text = "Click \'Search\' to look for requested system files";
            // 
            // btn_exit
            // 
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_exit.Image")));
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.Location = new System.Drawing.Point(304, 282);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 276);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_text_1);
            this.tabPage1.Controls.Add(this.btn_copy);
            this.tabPage1.Controls.Add(this.lbl_results);
            this.tabPage1.Controls.Add(this.txt_path_build);
            this.tabPage1.Controls.Add(this.btn_search);
            this.tabPage1.Controls.Add(this.lst_files);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_info);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_info
            // 
            this.txt_info.Location = new System.Drawing.Point(38, 42);
            this.txt_info.Multiline = true;
            this.txt_info.Name = "txt_info";
            this.txt_info.ReadOnly = true;
            this.txt_info.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_info.Size = new System.Drawing.Size(335, 193);
            this.txt_info.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chk_file_add);
            this.tabPage3.Controls.Add(this.lst_filenames);
            this.tabPage3.Controls.Add(this.btn_apply_conf);
            this.tabPage3.Controls.Add(this.lbl_file_notice);
            this.tabPage3.Controls.Add(this.txt_filelist);
            this.tabPage3.Controls.Add(this.rd_custom_opt);
            this.tabPage3.Controls.Add(this.rd_default_files);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(379, 249);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_apply_conf
            // 
            this.btn_apply_conf.Location = new System.Drawing.Point(15, 220);
            this.btn_apply_conf.Name = "btn_apply_conf";
            this.btn_apply_conf.Size = new System.Drawing.Size(75, 23);
            this.btn_apply_conf.TabIndex = 4;
            this.btn_apply_conf.Text = "Apply";
            this.btn_apply_conf.UseVisualStyleBackColor = true;
            this.btn_apply_conf.Click += new System.EventHandler(this.btn_apply_conf_Click);
            // 
            // lbl_file_notice
            // 
            this.lbl_file_notice.AutoSize = true;
            this.lbl_file_notice.Location = new System.Drawing.Point(12, 88);
            this.lbl_file_notice.Name = "lbl_file_notice";
            this.lbl_file_notice.Size = new System.Drawing.Size(10, 13);
            this.lbl_file_notice.TabIndex = 3;
            this.lbl_file_notice.Text = "-";
            // 
            // txt_filelist
            // 
            this.txt_filelist.Enabled = false;
            this.txt_filelist.Location = new System.Drawing.Point(12, 184);
            this.txt_filelist.Name = "txt_filelist";
            this.txt_filelist.Size = new System.Drawing.Size(343, 20);
            this.txt_filelist.TabIndex = 2;
            // 
            // rd_custom_opt
            // 
            this.rd_custom_opt.AutoSize = true;
            this.rd_custom_opt.Location = new System.Drawing.Point(12, 55);
            this.rd_custom_opt.Name = "rd_custom_opt";
            this.rd_custom_opt.Size = new System.Drawing.Size(117, 17);
            this.rd_custom_opt.TabIndex = 1;
            this.rd_custom_opt.TabStop = true;
            this.rd_custom_opt.Text = "Load custom file list";
            this.rd_custom_opt.UseVisualStyleBackColor = true;
            this.rd_custom_opt.CheckedChanged += new System.EventHandler(this.rd_custom_opt_CheckedChanged);
            // 
            // rd_default_files
            // 
            this.rd_default_files.AutoSize = true;
            this.rd_default_files.Checked = true;
            this.rd_default_files.Location = new System.Drawing.Point(12, 20);
            this.rd_default_files.Name = "rd_default_files";
            this.rd_default_files.Size = new System.Drawing.Size(115, 17);
            this.rd_default_files.TabIndex = 0;
            this.rd_default_files.TabStop = true;
            this.rd_default_files.Text = "Load default file list";
            this.rd_default_files.UseVisualStyleBackColor = true;
            this.rd_default_files.CheckedChanged += new System.EventHandler(this.rd_default_files_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Audio-Cd-icon.png");
            this.imageList1.Images.SetKeyName(1, "Document-Text-icon.png");
            this.imageList1.Images.SetKeyName(2, "Tools-icon.png");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // lst_filenames
            // 
            this.lst_filenames.FormattingEnabled = true;
            this.lst_filenames.Location = new System.Drawing.Point(173, 33);
            this.lst_filenames.Name = "lst_filenames";
            this.lst_filenames.Size = new System.Drawing.Size(182, 95);
            this.lst_filenames.TabIndex = 5;
            // 
            // chk_file_add
            // 
            this.chk_file_add.AutoSize = true;
            this.chk_file_add.Location = new System.Drawing.Point(15, 151);
            this.chk_file_add.Name = "chk_file_add";
            this.chk_file_add.Size = new System.Drawing.Size(90, 17);
            this.chk_file_add.TabIndex = 6;
            this.chk_file_add.Text = "Add to the list";
            this.chk_file_add.UseVisualStyleBackColor = true;
            this.chk_file_add.CheckedChanged += new System.EventHandler(this.chk_file_add_CheckedChanged);
            // 
            // frm_copy_sys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 326);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_copy_sys";
            this.Text = "Copy System Files";
            this.Load += new System.EventHandler(this.frm_copy_sys_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.TextBox txt_path_build;
        private System.Windows.Forms.Label lbl_text_1;
        private System.Windows.Forms.ListBox lst_files;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_results;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_info;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton rd_custom_opt;
        private System.Windows.Forms.RadioButton rd_default_files;
        private System.Windows.Forms.Label lbl_file_notice;
        private System.Windows.Forms.TextBox txt_filelist;
        private System.Windows.Forms.Button btn_apply_conf;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chk_file_add;
        private System.Windows.Forms.ListBox lst_filenames;
    }
}

