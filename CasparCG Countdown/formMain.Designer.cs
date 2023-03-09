using System;
using System.Windows.Forms;

namespace Caspar_CG_OSC_Monitor
{
    partial class formMain
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.splitContainerToolbarLogs = new System.Windows.Forms.SplitContainer();
            this.checkBoxVersion = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.labelCasparCGChannel = new System.Windows.Forms.Label();
            this.numericUpDownChannel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartStopServer = new System.Windows.Forms.Button();
            this.numericUpDownOSCPort = new System.Windows.Forms.NumericUpDown();
            this.labelCountdown = new System.Windows.Forms.Label();
            this.numericUpDownKaleidoPort = new System.Windows.Forms.NumericUpDown();
            this.labelProgressiveTime = new System.Windows.Forms.Label();
            this.groupBoxDynamicText = new System.Windows.Forms.GroupBox();
            this.labelDynamicTextAddr = new System.Windows.Forms.Label();
            this.checkBoxProgressiveTime = new System.Windows.Forms.CheckBox();
            this.textBoxCountDownAddr = new System.Windows.Forms.TextBox();
            this.textBoxProgressiveTimeAddr = new System.Windows.Forms.TextBox();
            this.labelKaleidoPort = new System.Windows.Forms.Label();
            this.labelKaleidoAddr = new System.Windows.Forms.Label();
            this.textBoxKaleidoAddr = new System.Windows.Forms.TextBox();
            this.textBoxTelnetStatus = new System.Windows.Forms.TextBox();
            this.dataGridViewIncomingMessages = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker_telnet = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerToolbarLogs)).BeginInit();
            this.splitContainerToolbarLogs.Panel1.SuspendLayout();
            this.splitContainerToolbarLogs.Panel2.SuspendLayout();
            this.splitContainerToolbarLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOSCPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKaleidoPort)).BeginInit();
            this.groupBoxDynamicText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncomingMessages)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerToolbarLogs
            // 
            this.splitContainerToolbarLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerToolbarLogs.IsSplitterFixed = true;
            this.splitContainerToolbarLogs.Location = new System.Drawing.Point(0, 0);
            this.splitContainerToolbarLogs.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerToolbarLogs.Name = "splitContainerToolbarLogs";
            this.splitContainerToolbarLogs.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerToolbarLogs.Panel1
            // 
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.checkBoxVersion);
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.checkBoxAutoStart);
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.labelCasparCGChannel);
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.numericUpDownChannel);
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.label1);
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.buttonStartStopServer);
            this.splitContainerToolbarLogs.Panel1.Controls.Add(this.numericUpDownOSCPort);
            // 
            // splitContainerToolbarLogs.Panel2
            // 
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.labelCountdown);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.numericUpDownKaleidoPort);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.labelProgressiveTime);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.groupBoxDynamicText);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.labelKaleidoPort);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.labelKaleidoAddr);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.textBoxKaleidoAddr);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.textBoxTelnetStatus);
            this.splitContainerToolbarLogs.Panel2.Controls.Add(this.dataGridViewIncomingMessages);
            this.splitContainerToolbarLogs.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerToolbarLogs_Panel2_Paint);
            this.splitContainerToolbarLogs.Size = new System.Drawing.Size(813, 320);
            this.splitContainerToolbarLogs.SplitterWidth = 3;
            this.splitContainerToolbarLogs.TabIndex = 0;
            // 
            // checkBoxVersion
            // 
            this.checkBoxVersion.AutoSize = true;
            this.checkBoxVersion.Location = new System.Drawing.Point(447, 15);
            this.checkBoxVersion.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxVersion.Name = "checkBoxVersion";
            this.checkBoxVersion.Size = new System.Drawing.Size(128, 17);
            this.checkBoxVersion.TabIndex = 9;
            this.checkBoxVersion.Text = "Server Version 2.0.8+";
            this.checkBoxVersion.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(608, 15);
            this.checkBoxAutoStart.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(73, 17);
            this.checkBoxAutoStart.TabIndex = 6;
            this.checkBoxAutoStart.Text = "Auto Start";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // labelCasparCGChannel
            // 
            this.labelCasparCGChannel.AutoSize = true;
            this.labelCasparCGChannel.Location = new System.Drawing.Point(181, 17);
            this.labelCasparCGChannel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCasparCGChannel.Name = "labelCasparCGChannel";
            this.labelCasparCGChannel.Size = new System.Drawing.Size(100, 13);
            this.labelCasparCGChannel.TabIndex = 4;
            this.labelCasparCGChannel.Text = "CasparCG Channel:";
            // 
            // numericUpDownChannel
            // 
            this.numericUpDownChannel.Location = new System.Drawing.Point(282, 15);
            this.numericUpDownChannel.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownChannel.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownChannel.Name = "numericUpDownChannel";
            this.numericUpDownChannel.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownChannel.TabIndex = 3;
            this.numericUpDownChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monitor Port:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonStartStopServer
            // 
            this.buttonStartStopServer.Location = new System.Drawing.Point(708, 10);
            this.buttonStartStopServer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartStopServer.Name = "buttonStartStopServer";
            this.buttonStartStopServer.Size = new System.Drawing.Size(85, 27);
            this.buttonStartStopServer.TabIndex = 1;
            this.buttonStartStopServer.Text = "Save Config";
            this.buttonStartStopServer.UseVisualStyleBackColor = true;
            this.buttonStartStopServer.Click += new System.EventHandler(this.buttonStartStopServer_Click);
            // 
            // numericUpDownOSCPort
            // 
            this.numericUpDownOSCPort.Location = new System.Drawing.Point(85, 15);
            this.numericUpDownOSCPort.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownOSCPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownOSCPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOSCPort.Name = "numericUpDownOSCPort";
            this.numericUpDownOSCPort.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownOSCPort.TabIndex = 0;
            this.numericUpDownOSCPort.Value = new decimal(new int[] {
            6251,
            0,
            0,
            0});
            // 
            // labelCountdown
            // 
            this.labelCountdown.AutoSize = true;
            this.labelCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountdown.ForeColor = System.Drawing.Color.Red;
            this.labelCountdown.Location = new System.Drawing.Point(658, 5);
            this.labelCountdown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.Size = new System.Drawing.Size(135, 33);
            this.labelCountdown.TabIndex = 6;
            this.labelCountdown.Text = "00:00:00";
            // 
            // numericUpDownKaleidoPort
            // 
            this.numericUpDownKaleidoPort.Location = new System.Drawing.Point(366, 18);
            this.numericUpDownKaleidoPort.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownKaleidoPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownKaleidoPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKaleidoPort.Name = "numericUpDownKaleidoPort";
            this.numericUpDownKaleidoPort.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownKaleidoPort.TabIndex = 11;
            this.numericUpDownKaleidoPort.Value = new decimal(new int[] {
            13000,
            0,
            0,
            0});
            // 
            // labelProgressiveTime
            // 
            this.labelProgressiveTime.AutoSize = true;
            this.labelProgressiveTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgressiveTime.ForeColor = System.Drawing.Color.Lime;
            this.labelProgressiveTime.Location = new System.Drawing.Point(506, 4);
            this.labelProgressiveTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProgressiveTime.Name = "labelProgressiveTime";
            this.labelProgressiveTime.Size = new System.Drawing.Size(135, 33);
            this.labelProgressiveTime.TabIndex = 5;
            this.labelProgressiveTime.Text = "00:00:00";
            // 
            // groupBoxDynamicText
            // 
            this.groupBoxDynamicText.Controls.Add(this.labelDynamicTextAddr);
            this.groupBoxDynamicText.Controls.Add(this.checkBoxProgressiveTime);
            this.groupBoxDynamicText.Controls.Add(this.textBoxCountDownAddr);
            this.groupBoxDynamicText.Controls.Add(this.textBoxProgressiveTimeAddr);
            this.groupBoxDynamicText.Location = new System.Drawing.Point(471, 49);
            this.groupBoxDynamicText.Name = "groupBoxDynamicText";
            this.groupBoxDynamicText.Size = new System.Drawing.Size(335, 90);
            this.groupBoxDynamicText.TabIndex = 10;
            this.groupBoxDynamicText.TabStop = false;
            this.groupBoxDynamicText.Text = "Kaleido DynamicText";
            // 
            // labelDynamicTextAddr
            // 
            this.labelDynamicTextAddr.AutoSize = true;
            this.labelDynamicTextAddr.Location = new System.Drawing.Point(57, 28);
            this.labelDynamicTextAddr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDynamicTextAddr.Name = "labelDynamicTextAddr";
            this.labelDynamicTextAddr.Size = new System.Drawing.Size(105, 13);
            this.labelDynamicTextAddr.TabIndex = 9;
            this.labelDynamicTextAddr.Text = "Countdown Address:";
            // 
            // checkBoxProgressiveTime
            // 
            this.checkBoxProgressiveTime.AutoSize = true;
            this.checkBoxProgressiveTime.Location = new System.Drawing.Point(41, 53);
            this.checkBoxProgressiveTime.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxProgressiveTime.Name = "checkBoxProgressiveTime";
            this.checkBoxProgressiveTime.Size = new System.Drawing.Size(148, 17);
            this.checkBoxProgressiveTime.TabIndex = 5;
            this.checkBoxProgressiveTime.Text = "Progressive Time Address";
            this.checkBoxProgressiveTime.UseVisualStyleBackColor = true;
            this.checkBoxProgressiveTime.CheckedChanged += new System.EventHandler(this.checkBoxProgressiveTime_CheckedChanged);
            // 
            // textBoxCountDownAddr
            // 
            this.textBoxCountDownAddr.Location = new System.Drawing.Point(203, 25);
            this.textBoxCountDownAddr.Name = "textBoxCountDownAddr";
            this.textBoxCountDownAddr.Size = new System.Drawing.Size(64, 20);
            this.textBoxCountDownAddr.TabIndex = 6;
            this.textBoxCountDownAddr.Text = "1";
            // 
            // textBoxProgressiveTimeAddr
            // 
            this.textBoxProgressiveTimeAddr.Enabled = false;
            this.textBoxProgressiveTimeAddr.Location = new System.Drawing.Point(203, 51);
            this.textBoxProgressiveTimeAddr.Name = "textBoxProgressiveTimeAddr";
            this.textBoxProgressiveTimeAddr.Size = new System.Drawing.Size(64, 20);
            this.textBoxProgressiveTimeAddr.TabIndex = 5;
            // 
            // labelKaleidoPort
            // 
            this.labelKaleidoPort.AutoSize = true;
            this.labelKaleidoPort.Location = new System.Drawing.Point(279, 21);
            this.labelKaleidoPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKaleidoPort.Name = "labelKaleidoPort";
            this.labelKaleidoPort.Size = new System.Drawing.Size(67, 13);
            this.labelKaleidoPort.TabIndex = 8;
            this.labelKaleidoPort.Text = "Kaleido Port:";
            // 
            // labelKaleidoAddr
            // 
            this.labelKaleidoAddr.AutoSize = true;
            this.labelKaleidoAddr.Location = new System.Drawing.Point(14, 21);
            this.labelKaleidoAddr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKaleidoAddr.Name = "labelKaleidoAddr";
            this.labelKaleidoAddr.Size = new System.Drawing.Size(86, 13);
            this.labelKaleidoAddr.TabIndex = 7;
            this.labelKaleidoAddr.Text = "Kaleido Address:";
            // 
            // textBoxKaleidoAddr
            // 
            this.textBoxKaleidoAddr.Location = new System.Drawing.Point(105, 18);
            this.textBoxKaleidoAddr.Name = "textBoxKaleidoAddr";
            this.textBoxKaleidoAddr.Size = new System.Drawing.Size(159, 20);
            this.textBoxKaleidoAddr.TabIndex = 3;
            this.textBoxKaleidoAddr.Text = "192.168.100.50";
            // 
            // textBoxTelnetStatus
            // 
            this.textBoxTelnetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTelnetStatus.Location = new System.Drawing.Point(17, 49);
            this.textBoxTelnetStatus.Multiline = true;
            this.textBoxTelnetStatus.Name = "textBoxTelnetStatus";
            this.textBoxTelnetStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTelnetStatus.Size = new System.Drawing.Size(434, 90);
            this.textBoxTelnetStatus.TabIndex = 2;
            this.textBoxTelnetStatus.TextChanged += new System.EventHandler(this.textBoxTelnetStatus_TextChanged);
            // 
            // dataGridViewIncomingMessages
            // 
            this.dataGridViewIncomingMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncomingMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Address,
            this.Data1,
            this.Data2,
            this.Data3});
            this.dataGridViewIncomingMessages.Location = new System.Drawing.Point(6, 156);
            this.dataGridViewIncomingMessages.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewIncomingMessages.Name = "dataGridViewIncomingMessages";
            this.dataGridViewIncomingMessages.RowHeadersVisible = false;
            this.dataGridViewIncomingMessages.RowTemplate.Height = 28;
            this.dataGridViewIncomingMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewIncomingMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIncomingMessages.Size = new System.Drawing.Size(800, 100);
            this.dataGridViewIncomingMessages.TabIndex = 0;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.HeaderText = "OSC Message Address";
            this.Address.Name = "Address";
            // 
            // Data1
            // 
            this.Data1.HeaderText = "Data 1";
            this.Data1.Name = "Data1";
            // 
            // Data2
            // 
            this.Data2.HeaderText = "Data 2";
            this.Data2.Name = "Data2";
            // 
            // Data3
            // 
            this.Data3.HeaderText = "Data 3";
            this.Data3.Name = "Data3";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CasparCG Countdown";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuRestore,
            this.toolStripMenuClose,
            this.toolStripMenuAbout});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuRestore
            // 
            this.toolStripMenuRestore.Name = "toolStripMenuRestore";
            this.toolStripMenuRestore.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuRestore.Text = "Restore";
            this.toolStripMenuRestore.Click += new System.EventHandler(this.toolStripMenuRestore_Click);
            // 
            // toolStripMenuClose
            // 
            this.toolStripMenuClose.Name = "toolStripMenuClose";
            this.toolStripMenuClose.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuClose.Text = "Close";
            this.toolStripMenuClose.Click += new System.EventHandler(this.toolStripMenuClose_Click);
            // 
            // toolStripMenuAbout
            // 
            this.toolStripMenuAbout.Name = "toolStripMenuAbout";
            this.toolStripMenuAbout.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuAbout.Text = "About...";
            this.toolStripMenuAbout.Click += new System.EventHandler(this.toolStripMenuAbout_Click);
            // 
            // backgroundWorker_telnet
            // 
            this.backgroundWorker_telnet.WorkerReportsProgress = true;
            this.backgroundWorker_telnet.WorkerSupportsCancellation = true;
            this.backgroundWorker_telnet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_telnet_DoWork);
            this.backgroundWorker_telnet.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_telnet_ProgressChanged);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 320);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainerToolbarLogs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CasparCG Countdown";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Resize += new System.EventHandler(this.formMain_Resize);
            this.splitContainerToolbarLogs.Panel1.ResumeLayout(false);
            this.splitContainerToolbarLogs.Panel1.PerformLayout();
            this.splitContainerToolbarLogs.Panel2.ResumeLayout(false);
            this.splitContainerToolbarLogs.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerToolbarLogs)).EndInit();
            this.splitContainerToolbarLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOSCPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKaleidoPort)).EndInit();
            this.groupBoxDynamicText.ResumeLayout(false);
            this.groupBoxDynamicText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncomingMessages)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerToolbarLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartStopServer;
        private System.Windows.Forms.NumericUpDown numericUpDownOSCPort;
        private System.Windows.Forms.DataGridView dataGridViewIncomingMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data3;
        private System.Windows.Forms.CheckBox checkBoxProgressiveTime;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRestore;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAbout;
        private TextBox textBoxTelnetStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker_telnet;
        private Label labelKaleidoPort;
        private Label labelKaleidoAddr;
        private TextBox textBoxCountDownAddr;
        private TextBox textBoxProgressiveTimeAddr;
        private TextBox textBoxKaleidoAddr;
        private GroupBox groupBoxDynamicText;
        private Label labelDynamicTextAddr;
        private Label labelCountdown;
        private Label labelProgressiveTime;
        private Label labelCasparCGChannel;
        private NumericUpDown numericUpDownChannel;
        private NumericUpDown numericUpDownKaleidoPort;
        private CheckBox checkBoxAutoStart;
        private CheckBox checkBoxVersion;
    }
}

