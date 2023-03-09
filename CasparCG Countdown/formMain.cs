using System;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Configuration;
using System.Linq;
//OSC
using System.Net;
using System.Net.Sockets;
using Bespoke.Common.Osc;

//Telnet
using System.IO;
using De.Mud.Telnet;
using Net.Graphite.Telnet;
using System.ComponentModel;
using System.Text;
using System.Threading;
using CasparCG_Countdown;

namespace Caspar_CG_OSC_Monitor


{

    public partial class formMain : Form
    {
        private OscServer _OscServer = null;
        TextWriter _writer = null;
        private TelnetWrapper t = null;
        private bool telnetConnected = false;
        private int data = 0;
        private string channelTime = "";
        private string channelCountdownTime = "";
        private string _ProcessName = Process.GetCurrentProcess().ProcessName;
        private string _ApplicationStartupPath = Application.StartupPath;


        #region console redirect stuff

        public class TextBoxStreamWriter : TextWriter
        {
            TextBox _output = null;

            public TextBoxStreamWriter(TextBox output)
            {
                _output = output;
            }

            public override void Write(char value)
            {
                base.Write(value);
                if (_output.InvokeRequired)
                {
                    _output.Invoke(new MethodInvoker(() =>
                    {
                        _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
                    }));
                }
                else
                {
                    _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
                }
            }

            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }
        }

        #endregion

        #region telnet stuff

        private void backgroundWorker_telnet_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!telnetConnected)
            {
                try
                {

                    t = new TelnetWrapper();
                    t.Disconnected += new DisconnectedEventHandler(this.telnet_OnDisconnect);
                    t.DataAvailable += new DataAvailableEventHandler(this.telnet_OnDataAvailable);
                    //Connect to Kaleido 
                    Thread.Sleep(1000);

                    t.Connect(textBoxKaleidoAddr.Text, (int)Convert.ToDouble(numericUpDownKaleidoPort.Value.ToString()));
                    //enables receiving commands response
                    Thread.Sleep(1000);


                    t.Receive();

                    telnetConnected = true;
                    Console.WriteLine("Telnet Connected");

                    //start OSC receiver
                    _OscServer.Start();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to connect. [" + ex.Message + "]");
                    Thread.Sleep(3000);

                }
            }
        }
        private void telnet_OnDisconnect(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            telnetConnected = false;
            if (_OscServer.IsRunning)
            {
                _OscServer.Stop();
            }
            Console.WriteLine("Telnet Disconnected. Reconnecting...");
            backgroundWorker_telnet.RunWorkerAsync();


        }

        private void telnet_OnDataAvailable(object sender, DataAvailableEventArgs e)
        {
            Console.Write(e.Data);
        }

        private void backgroundWorker_telnet_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        #endregion


        public formMain()
        {
            InitializeComponent();
            string _ConfigarationFileName = _ProcessName + ".exe.config";



            #region GetConfig
            //Gets config parameters from config file

            if (System.IO.File.Exists(System.IO.Path.Combine(_ApplicationStartupPath, _ConfigarationFileName)))
            {
                try
                {
                    checkBoxAutoStart.Checked = ConfigurationManager.AppSettings["AutoStart"] != null && ConfigurationManager.AppSettings["AutoStart"] == "True" ? true : checkBoxAutoStart.Checked;
                    numericUpDownOSCPort.Value = ConfigurationManager.AppSettings["CasparCG_OSC_Port"] == null ? numericUpDownOSCPort.Value : (decimal)Convert.ToDouble(ConfigurationManager.AppSettings["CasparCG_OSC_Port"]);
                    numericUpDownChannel.Value = ConfigurationManager.AppSettings["CasparCG_OSC_Channel"] == null ? numericUpDownChannel.Value : (decimal)Convert.ToDouble(ConfigurationManager.AppSettings["CasparCG_OSC_Channel"]);
                    textBoxKaleidoAddr.Text = ConfigurationManager.AppSettings["KaleidoIP_Address"] == null ? textBoxKaleidoAddr.Text : ConfigurationManager.AppSettings["KaleidoIP_Address"];
                    numericUpDownKaleidoPort.Value = ConfigurationManager.AppSettings["KaleidoPort_Address"] == null ? numericUpDownKaleidoPort.Value : (decimal)Convert.ToDouble(ConfigurationManager.AppSettings["KaleidoPort_Address"]);
                    textBoxCountDownAddr.Text = ConfigurationManager.AppSettings["KaleidoCountdown_DinamicText_Addr"] == null ? textBoxCountDownAddr.Text : ConfigurationManager.AppSettings["KaleidoCountdown_DinamicText_Addr"];
                    textBoxProgressiveTimeAddr.Text = ConfigurationManager.AppSettings["KaleidoProgressiveTime_DinamicText_Addr"] == null ? textBoxProgressiveTimeAddr.Text : ConfigurationManager.AppSettings["KaleidoProgressiveTime_DinamicText_Addr"];
                    checkBoxProgressiveTime.Checked = ConfigurationManager.AppSettings["ProgressiveTime"] != null && ConfigurationManager.AppSettings["ProgressiveTime"] == "True" ? true : checkBoxProgressiveTime.Checked;
                    checkBoxVersion.Checked = ConfigurationManager.AppSettings["Version"] != null && ConfigurationManager.AppSettings["Version"] == "True" ? true : checkBoxVersion.Checked;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Check the Configaration File " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Configaration File is Missing");
            }

            #endregion


            #region WriteConfig
            //writes the configuration file
            if (!System.IO.File.Exists(System.IO.Path.Combine(_ApplicationStartupPath, _ConfigarationFileName)))
            {

                //Creating XmlWriter Settings
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";
                settings.NewLineOnAttributes = true;

                using (XmlWriter writer = XmlWriter.Create(System.IO.Path.Combine(_ApplicationStartupPath, _ConfigarationFileName), settings))
                {
                    writer.WriteStartElement("configuration");
                    writer.WriteStartElement("appSettings");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }

            #endregion

            //Subscribe to events that the OSC server raises, Message and BundleReceived
            //some messages from Caspar are sent as bundles/groups of messages, others as
            //individual messages so we need to listen to both to get all data about what
            //Caspar is doing
            this._OscServer = new OscServer(TransportType.Udp, IPAddress.Any, (int)Convert.ToDouble(numericUpDownOSCPort.Value.ToString()));
            this._OscServer.MessageReceived += _OscServer_MessageReceived;
            this._OscServer.BundleReceived += _OscServer_BundleReceived;

            if (checkBoxAutoStart.Checked)
            {
                //Start receive data from CasparCG and send to Kaleido
                backgroundWorker_telnet.RunWorkerAsync();

            }

        }

        private void SaveConfig()
        {
            //save parameters in config file
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.IO.Path.Combine(_ApplicationStartupPath, _ProcessName + ".exe")); // you can enter either exe or dll if its a class library. 

            config.AppSettings.Settings.Remove("AutoStart");
            config.AppSettings.Settings.Remove("CasparCG_OSC_Port");
            config.AppSettings.Settings.Remove("CasparCG_OSC_Channel");
            config.AppSettings.Settings.Remove("KaleidoIP_Address");
            config.AppSettings.Settings.Remove("KaleidoPort_Address");
            config.AppSettings.Settings.Remove("KaleidoCountdown_DinamicText_Addr");
            config.AppSettings.Settings.Remove("KaleidoProgressiveTime_DinamicText_Addr");
            config.AppSettings.Settings.Remove("ProgressiveTime");
            config.AppSettings.Settings.Remove("Version");

            config.AppSettings.Settings.Add("AutoStart", checkBoxAutoStart.Checked.ToString());
            config.AppSettings.Settings.Add("CasparCG_OSC_Port", numericUpDownOSCPort.Value.ToString());
            config.AppSettings.Settings.Add("CasparCG_OSC_Channel", numericUpDownChannel.Value.ToString());
            config.AppSettings.Settings.Add("KaleidoIP_Address", textBoxKaleidoAddr.Text);
            config.AppSettings.Settings.Add("KaleidoPort_Address", numericUpDownKaleidoPort.Value.ToString());
            config.AppSettings.Settings.Add("KaleidoCountdown_DinamicText_Addr", textBoxCountDownAddr.Text);
            config.AppSettings.Settings.Add("KaleidoProgressiveTime_DinamicText_Addr", textBoxProgressiveTimeAddr.Text);
            config.AppSettings.Settings.Add("ProgressiveTime", checkBoxProgressiveTime.Checked.ToString());
            config.AppSettings.Settings.Add("Version", checkBoxVersion.Checked.ToString());


            config.Save(System.Configuration.ConfigurationSaveMode.Modified);

        }



        #region UpdateLabels

        delegate void SetTextCallback(string text);

        private void SetLabelCountdownText(string text)
        {
            if (this.labelCountdown.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLabelCountdownText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelCountdown.Text = text;
            }

        }
        private void SetLabelProgressiveTimeText(string text)
        {
            if (this.labelProgressiveTime.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLabelProgressiveTimeText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelProgressiveTime.Text = text;
            }
        }
        #endregion



        void _OscServer_BundleReceived(object sender, OscBundleReceivedEventArgs e)
        {
            foreach (OscMessage m in e.Bundle.Messages)
            {
                FilterOscMessage(m);
            }
        }
        void _OscServer_MessageReceived(object sender, OscMessageReceivedEventArgs e)
        {
            //FilterOscMessage(e.Message);
        }
        private void FilterOscMessage(OscMessage m)
        {
            //Console.WriteLine("Teste");

            try
            {
                if (m != null)
                {

                    if (checkBoxVersion.Checked == true)
                    {
                        //Console.WriteLine(m.Address);
                        string chTimeAux = channelTime;
                        string chCountdownAux = channelCountdownTime;
                        string d1 = (m.Data.Count > 1) ? m.Data[1].ToString() : null;
                        string d2 = (m.Data.Count > 1) ? m.Data[0].ToString() : null;

                        string[] address = m.Address.ToString().Split('/');
                        if (m != null && address.Length >= 8)
                        {
                            //Console.WriteLine(address[0]);
                            if (Convert.ToDouble(address[2]) == Convert.ToDouble(numericUpDownChannel.Value.ToString()) && address[4] == "layer" && Convert.ToDouble(address[5]) == 10 && address[6] == "foreground" && address[7] == "file" && address[8] == "time")
                            {
                                if (data != (int)Convert.ToDouble(d1))
                                {

                                    int d1Int = (int)Convert.ToDouble(d1);
                                    int d2Int = (int)Convert.ToDouble(d2);
                                    int d3Int = d1Int - d2Int;

                                    channelTime = (d2Int / 60 / 60).ToString("00") + ":" + (d2Int / 60).ToString("00") + ":" + (d2Int % 60 % 60).ToString("00");
                                    channelCountdownTime = (((d1Int - d2Int) / 60 / 60)).ToString("00") + ":" + ((d1Int - d2Int) / 60).ToString("00") + ":" + ((d1Int - d2Int) % 60 % 60).ToString("00");

                                    SetLabelCountdownText(channelCountdownTime);
                                    SetLabelProgressiveTimeText(channelTime);
                                    // This is an example of command to be sent via telnet
                                    // <setKDynamicText>set address="1" text="Test </setKDynamicText>
                                    // should not be placed the last quote, this is probably a Kaleido's bug 
                                    if (t.Connected && (channelCountdownTime != chCountdownAux || channelTime != chTimeAux))
                                    {
                                        t.Send("<setKDynamicText>set address=\"" + textBoxCountDownAddr.Text + "\" text=\"" + channelCountdownTime + " </setKDynamicText>");
                                        if (checkBoxProgressiveTime.Checked)
                                        {
                                            t.Send("<setKDynamicText>set address=\"" + textBoxProgressiveTimeAddr.Text + "\" text=\"" + channelTime + " </setKDynamicText>");
                                        }
                                        //    data = (int)Convert.ToDouble(d1);
                                        dataGridViewIncomingMessages.Invoke(new MethodInvoker(() =>
                                        {
                                            dataGridViewIncomingMessages.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), m.Address.ToString(), d1, d2, d3Int);
                                        }));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string d1 = m.Data[0].ToString();
                        string d2 = (m.Data.Count > 1) ? m.Data[1].ToString() : null;
                        string d3 = (m.Data.Count > 2) ? m.Data[2].ToString() : null;

                        string[] address = m.Address.ToString().Split('/');
                        if (m != null && address.Length >= 8)
                        {
                            if (Convert.ToDouble(address[2]) == Convert.ToDouble(numericUpDownChannel.Value.ToString()) && address[4] == "layer" && Convert.ToDouble(address[5]) == 10 && address[6] == "file" && address[7] == "time")
                            {
                                if (data != (int)Convert.ToDouble(d1))
                                {

                                    int d1Int = (int)Convert.ToDouble(d1);
                                    int d2Int = (int)Convert.ToDouble(d2);
                                    int d3Int = d1Int - d2Int;


                                    channelTime = (d1Int / 60 / 60).ToString("00") + ":" + (d1Int / 60).ToString("00") + ":" + (d1Int % 60 % 60).ToString("00");
                                    channelCountdownTime = (((d2Int - d1Int) / 60 / 60)).ToString("00") + ":" + ((d2Int - d1Int) / 60).ToString("00") + ":" + ((d2Int - d1Int) % 60 % 60).ToString("00");
                                    SetLabelCountdownText(channelCountdownTime);
                                    SetLabelProgressiveTimeText(channelTime);
                                    // This is an example of command to be sent via telnet
                                    // <setKDynamicText>set address="1" text="Test </setKDynamicText>
                                    // the last quote should not be placed, it is probably a Kaleido bug
                                    t.Send("<setKDynamicText>set address=\"" + textBoxCountDownAddr.Text + "\" text=\"" + channelCountdownTime + " </setKDynamicText>");
                                    if (checkBoxProgressiveTime.Checked)
                                    {
                                        t.Send("<setKDynamicText>set address=\"" + textBoxProgressiveTimeAddr.Text + "\" text=\"" + channelTime + " </setKDynamicText>");
                                    }
                                    data = (int)Convert.ToDouble(d1);
                                    dataGridViewIncomingMessages.Invoke(new MethodInvoker(() =>
                                    {
                                        dataGridViewIncomingMessages.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), m.Address.ToString(), d1, d2, d3);
                                    }));
                                }
                            }

                        }
                    }
                }
                } catch (Exception ex)
            {
                Console.WriteLine("Unable to connect. [" + ex.Message + "]");
            }
        }
        private void buttonStartStopServer_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

        private void splitContainerToolbarLogs_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formMain_Load(object sender, EventArgs e)
        {
            // Instantiate the writer
            _writer = new TextBoxStreamWriter(this.textBoxTelnetStatus);
            // Redirect the out Console stream
            Console.SetOut(_writer);

        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxProgressiveTime_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxProgressiveTimeAddr.Enabled = this.checkBoxProgressiveTime.Checked ? true : false;

        }

        private void textBoxTelnetStatus_TextChanged(object sender, EventArgs e)
        {

            if (textBoxTelnetStatus.Lines.Length > 10)
            {
                //Clears the status box
                textBoxTelnetStatus.Lines = textBoxTelnetStatus.Lines.Skip(textBoxTelnetStatus.Lines.Length - 10).ToArray();
                textBoxTelnetStatus.SelectionStart = textBoxTelnetStatus.Text.Length;
                textBoxTelnetStatus.ScrollToCaret();
            }
        }

        private void toolStripMenuRestore_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

        private void toolStripMenuClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuAbout_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }
    }
}

