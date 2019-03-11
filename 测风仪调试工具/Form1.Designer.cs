namespace 测风仪调试工具
{
    partial class HCXSerialPortTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCXSerialPortTool));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtnNet = new System.Windows.Forms.RadioButton();
            this.rBtnSerialPort = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbxNetPort = new System.Windows.Forms.ComboBox();
            this.cbxNetIP = new System.Windows.Forms.ComboBox();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.cbxSerialPort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearReEdit = new System.Windows.Forms.Button();
            this.btnSent = new System.Windows.Forms.Button();
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatusCode = new System.Windows.Forms.Label();
            this.lblIventedTemp = new System.Windows.Forms.Label();
            this.lblCalibrationTemp = new System.Windows.Forms.Label();
            this.lblDiffTimeEW = new System.Windows.Forms.Label();
            this.lblDiffTimeNS = new System.Windows.Forms.Label();
            this.lblHeatDown = new System.Windows.Forms.Label();
            this.lblHeatUP = new System.Windows.Forms.Label();
            this.lblVirtualValue = new System.Windows.Forms.Label();
            this.lblWindSpeed = new System.Windows.Forms.Label();
            this.lblWindDirection = new System.Windows.Forms.Label();
            this.btnReset_GO = new System.Windows.Forms.Button();
            this.btnInfo_E1 = new System.Windows.Forms.Button();
            this.btnRestart_BB = new System.Windows.Forms.Button();
            this.cbxAverageTime = new System.Windows.Forms.ComboBox();
            this.cbxHeatTemp = new System.Windows.Forms.ComboBox();
            this.btnSetAverageTime_4 = new System.Windows.Forms.Button();
            this.btnSetHeatTemp_5 = new System.Windows.Forms.Button();
            this.rBtnSpeed90 = new System.Windows.Forms.RadioButton();
            this.rBtnSpeed180 = new System.Windows.Forms.RadioButton();
            this.btnWind1Minus = new System.Windows.Forms.Button();
            this.btnWind1Add = new System.Windows.Forms.Button();
            this.lblFS1 = new System.Windows.Forms.Label();
            this.lblFS2 = new System.Windows.Forms.Label();
            this.btnWind2Add = new System.Windows.Forms.Button();
            this.btnWind2Minus = new System.Windows.Forms.Button();
            this.lblFS3 = new System.Windows.Forms.Label();
            this.btnWind3Add = new System.Windows.Forms.Button();
            this.btnWind3Minus = new System.Windows.Forms.Button();
            this.lblFS4 = new System.Windows.Forms.Label();
            this.btnWind4Add = new System.Windows.Forms.Button();
            this.btnWind4Minus = new System.Windows.Forms.Button();
            this.lblFS5 = new System.Windows.Forms.Label();
            this.btnWind5Add = new System.Windows.Forms.Button();
            this.btnWind5Minus = new System.Windows.Forms.Button();
            this.lblFS6 = new System.Windows.Forms.Label();
            this.btnWind6Add = new System.Windows.Forms.Button();
            this.btnWind6Minus = new System.Windows.Forms.Button();
            this.lblFS7 = new System.Windows.Forms.Label();
            this.btnWind7Add = new System.Windows.Forms.Button();
            this.btnWind7Minus = new System.Windows.Forms.Button();
            this.lblFS8 = new System.Windows.Forms.Label();
            this.btnWind8Add = new System.Windows.Forms.Button();
            this.btnWind8Minus = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSpeed4Add_0 = new System.Windows.Forms.Button();
            this.btnSpeed4Minus_0 = new System.Windows.Forms.Button();
            this.btnDeriction4Add_1 = new System.Windows.Forms.Button();
            this.btnDirection4Minus_1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnSpeed20Add_2 = new System.Windows.Forms.Button();
            this.btnSpeed20Minus_2 = new System.Windows.Forms.Button();
            this.btnDirection20Add_3 = new System.Windows.Forms.Button();
            this.btnDirection20Minus_3 = new System.Windows.Forms.Button();
            this.btnTestModel_CC = new System.Windows.Forms.Button();
            this.btnDisplayCurrent_AA = new System.Windows.Forms.Button();
            this.btnInfo_E0 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Setting = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.windspeed = new System.Windows.Forms.TabPage();
            this.windDirection = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Direction0 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_M = new System.Windows.Forms.Button();
            this.btnDirectionMinusM = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_L = new System.Windows.Forms.Button();
            this.btnDirectionMinusL = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_K = new System.Windows.Forms.Button();
            this.btnDirectionMinusK = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_J = new System.Windows.Forms.Button();
            this.btnDirectionMinusJ = new System.Windows.Forms.Button();
            this.btnDirectionMinusI = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_I = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_H = new System.Windows.Forms.Button();
            this.btnDirectionMinusH = new System.Windows.Forms.Button();
            this.btnDirectionMinusA = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_A = new System.Windows.Forms.Button();
            this.btnDirectionAdd_G = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnDirectionMinusG = new System.Windows.Forms.Button();
            this.btnDirectionMinusB = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_B = new System.Windows.Forms.Button();
            this.btnDirectionAdd_F = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnDirectionMinusF = new System.Windows.Forms.Button();
            this.btnDirectionMinusC = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_C = new System.Windows.Forms.Button();
            this.btnDirectionAdd_E = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.btnDirectionMinusE = new System.Windows.Forms.Button();
            this.btnDirectionMinusD = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_D = new System.Windows.Forms.Button();
            this.Direction360 = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_Y = new System.Windows.Forms.Button();
            this.btnDirectionMinusY = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_X = new System.Windows.Forms.Button();
            this.btnDirectionMinusX = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_W = new System.Windows.Forms.Button();
            this.btnDirectionMinusW = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_V = new System.Windows.Forms.Button();
            this.btnDirectionMinusV = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_U = new System.Windows.Forms.Button();
            this.btnDirectionMinusU = new System.Windows.Forms.Button();
            this.btnDirectionMinusN = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_N = new System.Windows.Forms.Button();
            this.btnDirectionAdd_T = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDirectionMinusT = new System.Windows.Forms.Button();
            this.btnDirectionMinusO = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_O = new System.Windows.Forms.Button();
            this.btnDirectionAdd_S = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDirectionMinusS = new System.Windows.Forms.Button();
            this.btnDirectionMinusP = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_P = new System.Windows.Forms.Button();
            this.btnDirectionAdd_R = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDirectionMinusR = new System.Windows.Forms.Button();
            this.btnDirectionMinusQ = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnDirectionAdd_Q = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新串口列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存接收信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入发送信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.升级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolupDataFW = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Setting.SuspendLayout();
            this.windspeed.SuspendLayout();
            this.windDirection.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Direction0.SuspendLayout();
            this.Direction360.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtnNet);
            this.groupBox1.Controls.Add(this.rBtnSerialPort);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cbxNetPort);
            this.groupBox1.Controls.Add(this.cbxNetIP);
            this.groupBox1.Controls.Add(this.cbxBaudRate);
            this.groupBox1.Controls.Add(this.cbxSerialPort);
            this.groupBox1.Location = new System.Drawing.Point(25, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "端口信息";
            // 
            // rBtnNet
            // 
            this.rBtnNet.AutoSize = true;
            this.rBtnNet.Location = new System.Drawing.Point(9, 55);
            this.rBtnNet.Name = "rBtnNet";
            this.rBtnNet.Size = new System.Drawing.Size(47, 16);
            this.rBtnNet.TabIndex = 8;
            this.rBtnNet.TabStop = true;
            this.rBtnNet.Text = "网络";
            this.rBtnNet.UseVisualStyleBackColor = true;
            // 
            // rBtnSerialPort
            // 
            this.rBtnSerialPort.AutoSize = true;
            this.rBtnSerialPort.Location = new System.Drawing.Point(9, 18);
            this.rBtnSerialPort.Name = "rBtnSerialPort";
            this.rBtnSerialPort.Size = new System.Drawing.Size(47, 16);
            this.rBtnSerialPort.TabIndex = 7;
            this.rBtnSerialPort.TabStop = true;
            this.rBtnSerialPort.Text = "串口";
            this.rBtnSerialPort.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(250, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 53);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "连接设备";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbxNetPort
            // 
            this.cbxNetPort.FormattingEnabled = true;
            this.cbxNetPort.Items.AddRange(new object[] {
            "10001",
            "10002",
            "10003",
            "10004",
            "10005",
            "10006",
            "10007",
            "10008"});
            this.cbxNetPort.Location = new System.Drawing.Point(170, 54);
            this.cbxNetPort.Name = "cbxNetPort";
            this.cbxNetPort.Size = new System.Drawing.Size(64, 20);
            this.cbxNetPort.TabIndex = 5;
            this.cbxNetPort.Text = "10001";
            // 
            // cbxNetIP
            // 
            this.cbxNetIP.FormattingEnabled = true;
            this.cbxNetIP.Items.AddRange(new object[] {
            "192.168.0.231",
            "192.168.0.232",
            "192.168.0.233"});
            this.cbxNetIP.Location = new System.Drawing.Point(61, 54);
            this.cbxNetIP.Name = "cbxNetIP";
            this.cbxNetIP.Size = new System.Drawing.Size(103, 20);
            this.cbxNetIP.TabIndex = 4;
            this.cbxNetIP.Text = "192.168.0.233";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.AutoCompleteCustomSource.AddRange(new string[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "115200"});
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(170, 17);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(64, 20);
            this.cbxBaudRate.TabIndex = 3;
            this.cbxBaudRate.Text = "4800";
            // 
            // cbxSerialPort
            // 
            this.cbxSerialPort.FormattingEnabled = true;
            this.cbxSerialPort.Location = new System.Drawing.Point(61, 17);
            this.cbxSerialPort.Name = "cbxSerialPort";
            this.cbxSerialPort.Size = new System.Drawing.Size(103, 20);
            this.cbxSerialPort.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearReEdit);
            this.groupBox2.Controls.Add(this.btnSent);
            this.groupBox2.Controls.Add(this.txtEdit);
            this.groupBox2.Controls.Add(this.txtMessage);
            this.groupBox2.Location = new System.Drawing.Point(25, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 382);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收发送信息";
            // 
            // btnClearReEdit
            // 
            this.btnClearReEdit.Location = new System.Drawing.Point(283, 239);
            this.btnClearReEdit.Name = "btnClearReEdit";
            this.btnClearReEdit.Size = new System.Drawing.Size(49, 23);
            this.btnClearReEdit.TabIndex = 3;
            this.btnClearReEdit.Text = "清空";
            this.btnClearReEdit.UseVisualStyleBackColor = true;
            this.btnClearReEdit.Click += new System.EventHandler(this.btnClearReEdit_Click);
            // 
            // btnSent
            // 
            this.btnSent.Location = new System.Drawing.Point(283, 302);
            this.btnSent.Name = "btnSent";
            this.btnSent.Size = new System.Drawing.Size(49, 51);
            this.btnSent.TabIndex = 2;
            this.btnSent.Text = "发送";
            this.btnSent.UseVisualStyleBackColor = true;
            this.btnSent.Click += new System.EventHandler(this.btnSent_Click);
            // 
            // txtEdit
            // 
            this.txtEdit.Location = new System.Drawing.Point(10, 233);
            this.txtEdit.Multiline = true;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(261, 120);
            this.txtEdit.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(10, 20);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(328, 178);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "\r\n";
            this.txtMessage.WordWrap = false;
            this.txtMessage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatusCode);
            this.groupBox3.Controls.Add(this.lblIventedTemp);
            this.groupBox3.Controls.Add(this.lblCalibrationTemp);
            this.groupBox3.Controls.Add(this.lblDiffTimeEW);
            this.groupBox3.Controls.Add(this.lblDiffTimeNS);
            this.groupBox3.Controls.Add(this.lblHeatDown);
            this.groupBox3.Controls.Add(this.lblHeatUP);
            this.groupBox3.Controls.Add(this.lblVirtualValue);
            this.groupBox3.Controls.Add(this.lblWindSpeed);
            this.groupBox3.Controls.Add(this.lblWindDirection);
            this.groupBox3.Location = new System.Drawing.Point(400, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 212);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测风仪信息";
            // 
            // lblStatusCode
            // 
            this.lblStatusCode.AutoSize = true;
            this.lblStatusCode.Location = new System.Drawing.Point(13, 183);
            this.lblStatusCode.Name = "lblStatusCode";
            this.lblStatusCode.Size = new System.Drawing.Size(65, 12);
            this.lblStatusCode.TabIndex = 9;
            this.lblStatusCode.Text = "故障代码：";
            // 
            // lblIventedTemp
            // 
            this.lblIventedTemp.AutoSize = true;
            this.lblIventedTemp.Location = new System.Drawing.Point(13, 165);
            this.lblIventedTemp.Name = "lblIventedTemp";
            this.lblIventedTemp.Size = new System.Drawing.Size(65, 12);
            this.lblIventedTemp.TabIndex = 8;
            this.lblIventedTemp.Text = "虚拟温度：";
            // 
            // lblCalibrationTemp
            // 
            this.lblCalibrationTemp.AutoSize = true;
            this.lblCalibrationTemp.Location = new System.Drawing.Point(13, 147);
            this.lblCalibrationTemp.Name = "lblCalibrationTemp";
            this.lblCalibrationTemp.Size = new System.Drawing.Size(65, 12);
            this.lblCalibrationTemp.TabIndex = 7;
            this.lblCalibrationTemp.Text = "标校温度：";
            // 
            // lblDiffTimeEW
            // 
            this.lblDiffTimeEW.AutoSize = true;
            this.lblDiffTimeEW.Location = new System.Drawing.Point(13, 129);
            this.lblDiffTimeEW.Name = "lblDiffTimeEW";
            this.lblDiffTimeEW.Size = new System.Drawing.Size(59, 12);
            this.lblDiffTimeEW.TabIndex = 6;
            this.lblDiffTimeEW.Text = "时差-EW：";
            // 
            // lblDiffTimeNS
            // 
            this.lblDiffTimeNS.AutoSize = true;
            this.lblDiffTimeNS.Location = new System.Drawing.Point(13, 111);
            this.lblDiffTimeNS.Name = "lblDiffTimeNS";
            this.lblDiffTimeNS.Size = new System.Drawing.Size(59, 12);
            this.lblDiffTimeNS.TabIndex = 5;
            this.lblDiffTimeNS.Text = "时差-NS：";
            // 
            // lblHeatDown
            // 
            this.lblHeatDown.AutoSize = true;
            this.lblHeatDown.Location = new System.Drawing.Point(13, 93);
            this.lblHeatDown.Name = "lblHeatDown";
            this.lblHeatDown.Size = new System.Drawing.Size(59, 12);
            this.lblHeatDown.TabIndex = 4;
            this.lblHeatDown.Text = "加热-下：";
            // 
            // lblHeatUP
            // 
            this.lblHeatUP.AutoSize = true;
            this.lblHeatUP.Location = new System.Drawing.Point(13, 75);
            this.lblHeatUP.Name = "lblHeatUP";
            this.lblHeatUP.Size = new System.Drawing.Size(59, 12);
            this.lblHeatUP.TabIndex = 3;
            this.lblHeatUP.Text = "加热-上：";
            // 
            // lblVirtualValue
            // 
            this.lblVirtualValue.AutoSize = true;
            this.lblVirtualValue.Location = new System.Drawing.Point(13, 57);
            this.lblVirtualValue.Name = "lblVirtualValue";
            this.lblVirtualValue.Size = new System.Drawing.Size(53, 12);
            this.lblVirtualValue.TabIndex = 2;
            this.lblVirtualValue.Text = "有效值：";
            // 
            // lblWindSpeed
            // 
            this.lblWindSpeed.AutoSize = true;
            this.lblWindSpeed.Location = new System.Drawing.Point(13, 39);
            this.lblWindSpeed.Name = "lblWindSpeed";
            this.lblWindSpeed.Size = new System.Drawing.Size(41, 12);
            this.lblWindSpeed.TabIndex = 1;
            this.lblWindSpeed.Text = "风速：";
            // 
            // lblWindDirection
            // 
            this.lblWindDirection.AutoSize = true;
            this.lblWindDirection.Location = new System.Drawing.Point(13, 21);
            this.lblWindDirection.Name = "lblWindDirection";
            this.lblWindDirection.Size = new System.Drawing.Size(41, 12);
            this.lblWindDirection.TabIndex = 0;
            this.lblWindDirection.Text = "风向：";
            // 
            // btnReset_GO
            // 
            this.btnReset_GO.Location = new System.Drawing.Point(26, 393);
            this.btnReset_GO.Name = "btnReset_GO";
            this.btnReset_GO.Size = new System.Drawing.Size(131, 36);
            this.btnReset_GO.TabIndex = 0;
            this.btnReset_GO.Text = "初始化";
            this.btnReset_GO.UseVisualStyleBackColor = true;
            this.btnReset_GO.Click += new System.EventHandler(this.btnReset_GO_Click);
            // 
            // btnInfo_E1
            // 
            this.btnInfo_E1.Location = new System.Drawing.Point(12, 118);
            this.btnInfo_E1.Name = "btnInfo_E1";
            this.btnInfo_E1.Size = new System.Drawing.Size(137, 32);
            this.btnInfo_E1.TabIndex = 1;
            this.btnInfo_E1.Text = "附加信息开";
            this.btnInfo_E1.UseVisualStyleBackColor = true;
            this.btnInfo_E1.Click += new System.EventHandler(this.btnInfo_E1_Click);
            // 
            // btnRestart_BB
            // 
            this.btnRestart_BB.Location = new System.Drawing.Point(12, 26);
            this.btnRestart_BB.Name = "btnRestart_BB";
            this.btnRestart_BB.Size = new System.Drawing.Size(137, 32);
            this.btnRestart_BB.TabIndex = 2;
            this.btnRestart_BB.Text = "设备重启";
            this.btnRestart_BB.UseVisualStyleBackColor = true;
            this.btnRestart_BB.Click += new System.EventHandler(this.btnRestart_BB_Click);
            // 
            // cbxAverageTime
            // 
            this.cbxAverageTime.FormattingEnabled = true;
            this.cbxAverageTime.Items.AddRange(new object[] {
            "1秒",
            "2秒",
            "3秒",
            "5秒",
            "10秒"});
            this.cbxAverageTime.Location = new System.Drawing.Point(28, 293);
            this.cbxAverageTime.Name = "cbxAverageTime";
            this.cbxAverageTime.Size = new System.Drawing.Size(75, 20);
            this.cbxAverageTime.TabIndex = 4;
            this.cbxAverageTime.Text = "1秒";
            // 
            // cbxHeatTemp
            // 
            this.cbxHeatTemp.FormattingEnabled = true;
            this.cbxHeatTemp.Items.AddRange(new object[] {
            "5℃",
            "10℃",
            "15℃",
            "20℃",
            "25℃",
            "30℃",
            "35℃",
            "40℃"});
            this.cbxHeatTemp.Location = new System.Drawing.Point(28, 351);
            this.cbxHeatTemp.Name = "cbxHeatTemp";
            this.cbxHeatTemp.Size = new System.Drawing.Size(75, 20);
            this.cbxHeatTemp.TabIndex = 5;
            this.cbxHeatTemp.Text = "20℃";
            // 
            // btnSetAverageTime_4
            // 
            this.btnSetAverageTime_4.Location = new System.Drawing.Point(108, 291);
            this.btnSetAverageTime_4.Name = "btnSetAverageTime_4";
            this.btnSetAverageTime_4.Size = new System.Drawing.Size(46, 23);
            this.btnSetAverageTime_4.TabIndex = 6;
            this.btnSetAverageTime_4.Text = "设置";
            this.btnSetAverageTime_4.UseVisualStyleBackColor = true;
            this.btnSetAverageTime_4.Click += new System.EventHandler(this.btnSetAverageTime_4_Click);
            // 
            // btnSetHeatTemp_5
            // 
            this.btnSetHeatTemp_5.Location = new System.Drawing.Point(108, 349);
            this.btnSetHeatTemp_5.Name = "btnSetHeatTemp_5";
            this.btnSetHeatTemp_5.Size = new System.Drawing.Size(46, 23);
            this.btnSetHeatTemp_5.TabIndex = 7;
            this.btnSetHeatTemp_5.Text = "设置";
            this.btnSetHeatTemp_5.UseVisualStyleBackColor = true;
            this.btnSetHeatTemp_5.Click += new System.EventHandler(this.btnSetHeatTemp_5_Click);
            // 
            // rBtnSpeed90
            // 
            this.rBtnSpeed90.AutoSize = true;
            this.rBtnSpeed90.Checked = true;
            this.rBtnSpeed90.Location = new System.Drawing.Point(38, 7);
            this.rBtnSpeed90.Name = "rBtnSpeed90";
            this.rBtnSpeed90.Size = new System.Drawing.Size(35, 16);
            this.rBtnSpeed90.TabIndex = 0;
            this.rBtnSpeed90.TabStop = true;
            this.rBtnSpeed90.Text = "90";
            this.rBtnSpeed90.UseVisualStyleBackColor = true;
            this.rBtnSpeed90.CheckedChanged += new System.EventHandler(this.rBtnSpeed90_CheckedChanged);
            // 
            // rBtnSpeed180
            // 
            this.rBtnSpeed180.AutoSize = true;
            this.rBtnSpeed180.Location = new System.Drawing.Point(124, 7);
            this.rBtnSpeed180.Name = "rBtnSpeed180";
            this.rBtnSpeed180.Size = new System.Drawing.Size(41, 16);
            this.rBtnSpeed180.TabIndex = 1;
            this.rBtnSpeed180.Text = "180";
            this.rBtnSpeed180.UseVisualStyleBackColor = true;
            this.rBtnSpeed180.CheckedChanged += new System.EventHandler(this.rBtnSpeed180_CheckedChanged);
            // 
            // btnWind1Minus
            // 
            this.btnWind1Minus.Location = new System.Drawing.Point(11, 30);
            this.btnWind1Minus.Name = "btnWind1Minus";
            this.btnWind1Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind1Minus.TabIndex = 2;
            this.btnWind1Minus.Text = "减";
            this.btnWind1Minus.UseVisualStyleBackColor = true;
            this.btnWind1Minus.Click += new System.EventHandler(this.btnWind1Minus_Click);
            // 
            // btnWind1Add
            // 
            this.btnWind1Add.Location = new System.Drawing.Point(124, 30);
            this.btnWind1Add.Name = "btnWind1Add";
            this.btnWind1Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind1Add.TabIndex = 3;
            this.btnWind1Add.Text = "加";
            this.btnWind1Add.UseVisualStyleBackColor = true;
            this.btnWind1Add.Click += new System.EventHandler(this.btnWind1Add_Click);
            // 
            // lblFS1
            // 
            this.lblFS1.AutoSize = true;
            this.lblFS1.Location = new System.Drawing.Point(82, 35);
            this.lblFS1.Name = "lblFS1";
            this.lblFS1.Size = new System.Drawing.Size(23, 12);
            this.lblFS1.TabIndex = 4;
            this.lblFS1.Text = "$11";
            // 
            // lblFS2
            // 
            this.lblFS2.AutoSize = true;
            this.lblFS2.Location = new System.Drawing.Point(82, 66);
            this.lblFS2.Name = "lblFS2";
            this.lblFS2.Size = new System.Drawing.Size(23, 12);
            this.lblFS2.TabIndex = 7;
            this.lblFS2.Text = "$12";
            // 
            // btnWind2Add
            // 
            this.btnWind2Add.Location = new System.Drawing.Point(124, 61);
            this.btnWind2Add.Name = "btnWind2Add";
            this.btnWind2Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind2Add.TabIndex = 6;
            this.btnWind2Add.Text = "加";
            this.btnWind2Add.UseVisualStyleBackColor = true;
            this.btnWind2Add.Click += new System.EventHandler(this.btnWind2Add_Click);
            // 
            // btnWind2Minus
            // 
            this.btnWind2Minus.Location = new System.Drawing.Point(11, 61);
            this.btnWind2Minus.Name = "btnWind2Minus";
            this.btnWind2Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind2Minus.TabIndex = 5;
            this.btnWind2Minus.Text = "减";
            this.btnWind2Minus.UseVisualStyleBackColor = true;
            this.btnWind2Minus.Click += new System.EventHandler(this.btnWind2Minus_Click);
            // 
            // lblFS3
            // 
            this.lblFS3.AutoSize = true;
            this.lblFS3.Location = new System.Drawing.Point(82, 97);
            this.lblFS3.Name = "lblFS3";
            this.lblFS3.Size = new System.Drawing.Size(23, 12);
            this.lblFS3.TabIndex = 10;
            this.lblFS3.Text = "$13";
            // 
            // btnWind3Add
            // 
            this.btnWind3Add.Location = new System.Drawing.Point(124, 92);
            this.btnWind3Add.Name = "btnWind3Add";
            this.btnWind3Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind3Add.TabIndex = 9;
            this.btnWind3Add.Text = "加";
            this.btnWind3Add.UseVisualStyleBackColor = true;
            this.btnWind3Add.Click += new System.EventHandler(this.btnWind3Add_Click);
            // 
            // btnWind3Minus
            // 
            this.btnWind3Minus.Location = new System.Drawing.Point(11, 92);
            this.btnWind3Minus.Name = "btnWind3Minus";
            this.btnWind3Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind3Minus.TabIndex = 8;
            this.btnWind3Minus.Text = "减";
            this.btnWind3Minus.UseVisualStyleBackColor = true;
            this.btnWind3Minus.Click += new System.EventHandler(this.btnWind3Minus_Click);
            // 
            // lblFS4
            // 
            this.lblFS4.AutoSize = true;
            this.lblFS4.Location = new System.Drawing.Point(82, 128);
            this.lblFS4.Name = "lblFS4";
            this.lblFS4.Size = new System.Drawing.Size(23, 12);
            this.lblFS4.TabIndex = 13;
            this.lblFS4.Text = "$14";
            // 
            // btnWind4Add
            // 
            this.btnWind4Add.Location = new System.Drawing.Point(124, 123);
            this.btnWind4Add.Name = "btnWind4Add";
            this.btnWind4Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind4Add.TabIndex = 12;
            this.btnWind4Add.Text = "加";
            this.btnWind4Add.UseVisualStyleBackColor = true;
            this.btnWind4Add.Click += new System.EventHandler(this.btnWind4Add_Click);
            // 
            // btnWind4Minus
            // 
            this.btnWind4Minus.Location = new System.Drawing.Point(11, 123);
            this.btnWind4Minus.Name = "btnWind4Minus";
            this.btnWind4Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind4Minus.TabIndex = 11;
            this.btnWind4Minus.Text = "减";
            this.btnWind4Minus.UseVisualStyleBackColor = true;
            this.btnWind4Minus.Click += new System.EventHandler(this.btnWind4Minus_Click);
            // 
            // lblFS5
            // 
            this.lblFS5.AutoSize = true;
            this.lblFS5.Location = new System.Drawing.Point(82, 159);
            this.lblFS5.Name = "lblFS5";
            this.lblFS5.Size = new System.Drawing.Size(23, 12);
            this.lblFS5.TabIndex = 16;
            this.lblFS5.Text = "$15";
            // 
            // btnWind5Add
            // 
            this.btnWind5Add.Location = new System.Drawing.Point(124, 154);
            this.btnWind5Add.Name = "btnWind5Add";
            this.btnWind5Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind5Add.TabIndex = 15;
            this.btnWind5Add.Text = "加";
            this.btnWind5Add.UseVisualStyleBackColor = true;
            this.btnWind5Add.Click += new System.EventHandler(this.btnWind5Add_Click);
            // 
            // btnWind5Minus
            // 
            this.btnWind5Minus.Location = new System.Drawing.Point(11, 154);
            this.btnWind5Minus.Name = "btnWind5Minus";
            this.btnWind5Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind5Minus.TabIndex = 14;
            this.btnWind5Minus.Text = "减";
            this.btnWind5Minus.UseVisualStyleBackColor = true;
            this.btnWind5Minus.Click += new System.EventHandler(this.btnWind5Minus_Click);
            // 
            // lblFS6
            // 
            this.lblFS6.AutoSize = true;
            this.lblFS6.Location = new System.Drawing.Point(82, 190);
            this.lblFS6.Name = "lblFS6";
            this.lblFS6.Size = new System.Drawing.Size(23, 12);
            this.lblFS6.TabIndex = 19;
            this.lblFS6.Text = "$16";
            // 
            // btnWind6Add
            // 
            this.btnWind6Add.Location = new System.Drawing.Point(124, 185);
            this.btnWind6Add.Name = "btnWind6Add";
            this.btnWind6Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind6Add.TabIndex = 18;
            this.btnWind6Add.Text = "加";
            this.btnWind6Add.UseVisualStyleBackColor = true;
            this.btnWind6Add.Click += new System.EventHandler(this.btnWind6Add_Click);
            // 
            // btnWind6Minus
            // 
            this.btnWind6Minus.Location = new System.Drawing.Point(11, 185);
            this.btnWind6Minus.Name = "btnWind6Minus";
            this.btnWind6Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind6Minus.TabIndex = 17;
            this.btnWind6Minus.Text = "减";
            this.btnWind6Minus.UseVisualStyleBackColor = true;
            this.btnWind6Minus.Click += new System.EventHandler(this.btnWind6Minus_Click);
            // 
            // lblFS7
            // 
            this.lblFS7.AutoSize = true;
            this.lblFS7.Location = new System.Drawing.Point(82, 221);
            this.lblFS7.Name = "lblFS7";
            this.lblFS7.Size = new System.Drawing.Size(23, 12);
            this.lblFS7.TabIndex = 22;
            this.lblFS7.Text = "$17";
            // 
            // btnWind7Add
            // 
            this.btnWind7Add.Location = new System.Drawing.Point(124, 216);
            this.btnWind7Add.Name = "btnWind7Add";
            this.btnWind7Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind7Add.TabIndex = 21;
            this.btnWind7Add.Text = "加";
            this.btnWind7Add.UseVisualStyleBackColor = true;
            this.btnWind7Add.Click += new System.EventHandler(this.btnWind7Add_Click);
            // 
            // btnWind7Minus
            // 
            this.btnWind7Minus.Location = new System.Drawing.Point(11, 216);
            this.btnWind7Minus.Name = "btnWind7Minus";
            this.btnWind7Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind7Minus.TabIndex = 20;
            this.btnWind7Minus.Text = "减";
            this.btnWind7Minus.UseVisualStyleBackColor = true;
            this.btnWind7Minus.Click += new System.EventHandler(this.btnWind7Minus_Click);
            // 
            // lblFS8
            // 
            this.lblFS8.AutoSize = true;
            this.lblFS8.Location = new System.Drawing.Point(82, 252);
            this.lblFS8.Name = "lblFS8";
            this.lblFS8.Size = new System.Drawing.Size(23, 12);
            this.lblFS8.TabIndex = 25;
            this.lblFS8.Text = "$18";
            // 
            // btnWind8Add
            // 
            this.btnWind8Add.Location = new System.Drawing.Point(124, 247);
            this.btnWind8Add.Name = "btnWind8Add";
            this.btnWind8Add.Size = new System.Drawing.Size(52, 23);
            this.btnWind8Add.TabIndex = 24;
            this.btnWind8Add.Text = "加";
            this.btnWind8Add.UseVisualStyleBackColor = true;
            this.btnWind8Add.Click += new System.EventHandler(this.btnWind8Add_Click);
            // 
            // btnWind8Minus
            // 
            this.btnWind8Minus.Location = new System.Drawing.Point(11, 247);
            this.btnWind8Minus.Name = "btnWind8Minus";
            this.btnWind8Minus.Size = new System.Drawing.Size(52, 23);
            this.btnWind8Minus.TabIndex = 23;
            this.btnWind8Minus.Text = "减";
            this.btnWind8Minus.UseVisualStyleBackColor = true;
            this.btnWind8Minus.Click += new System.EventHandler(this.btnWind8Minus_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSpeed4Add_0);
            this.groupBox6.Controls.Add(this.btnSpeed4Minus_0);
            this.groupBox6.Controls.Add(this.btnDeriction4Add_1);
            this.groupBox6.Controls.Add(this.btnDirection4Minus_1);
            this.groupBox6.Location = new System.Drawing.Point(22, 71);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(143, 75);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "零位";
            // 
            // btnSpeed4Add_0
            // 
            this.btnSpeed4Add_0.Location = new System.Drawing.Point(75, 49);
            this.btnSpeed4Add_0.Name = "btnSpeed4Add_0";
            this.btnSpeed4Add_0.Size = new System.Drawing.Size(63, 23);
            this.btnSpeed4Add_0.TabIndex = 3;
            this.btnSpeed4Add_0.Text = "风速+";
            this.btnSpeed4Add_0.UseVisualStyleBackColor = true;
            this.btnSpeed4Add_0.Click += new System.EventHandler(this.btnSpeed4Add_0_Click);
            // 
            // btnSpeed4Minus_0
            // 
            this.btnSpeed4Minus_0.Location = new System.Drawing.Point(6, 49);
            this.btnSpeed4Minus_0.Name = "btnSpeed4Minus_0";
            this.btnSpeed4Minus_0.Size = new System.Drawing.Size(63, 23);
            this.btnSpeed4Minus_0.TabIndex = 2;
            this.btnSpeed4Minus_0.Text = "风速-";
            this.btnSpeed4Minus_0.UseVisualStyleBackColor = true;
            this.btnSpeed4Minus_0.Click += new System.EventHandler(this.btnSpeed4Minus_0_Click);
            // 
            // btnDeriction4Add_1
            // 
            this.btnDeriction4Add_1.Location = new System.Drawing.Point(75, 20);
            this.btnDeriction4Add_1.Name = "btnDeriction4Add_1";
            this.btnDeriction4Add_1.Size = new System.Drawing.Size(63, 23);
            this.btnDeriction4Add_1.TabIndex = 1;
            this.btnDeriction4Add_1.Text = "风向+";
            this.btnDeriction4Add_1.UseVisualStyleBackColor = true;
            this.btnDeriction4Add_1.Click += new System.EventHandler(this.btnDeriction4Add_1_Click);
            // 
            // btnDirection4Minus_1
            // 
            this.btnDirection4Minus_1.Location = new System.Drawing.Point(6, 20);
            this.btnDirection4Minus_1.Name = "btnDirection4Minus_1";
            this.btnDirection4Minus_1.Size = new System.Drawing.Size(63, 23);
            this.btnDirection4Minus_1.TabIndex = 0;
            this.btnDirection4Minus_1.Text = "风向-";
            this.btnDirection4Minus_1.UseVisualStyleBackColor = true;
            this.btnDirection4Minus_1.Click += new System.EventHandler(this.btnDirection4Minus_1_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnSpeed20Add_2);
            this.groupBox7.Controls.Add(this.btnSpeed20Minus_2);
            this.groupBox7.Controls.Add(this.btnDirection20Add_3);
            this.groupBox7.Controls.Add(this.btnDirection20Minus_3);
            this.groupBox7.Location = new System.Drawing.Point(22, 161);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(151, 86);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "满量程";
            // 
            // btnSpeed20Add_2
            // 
            this.btnSpeed20Add_2.Location = new System.Drawing.Point(75, 50);
            this.btnSpeed20Add_2.Name = "btnSpeed20Add_2";
            this.btnSpeed20Add_2.Size = new System.Drawing.Size(63, 23);
            this.btnSpeed20Add_2.TabIndex = 3;
            this.btnSpeed20Add_2.Text = "风速+";
            this.btnSpeed20Add_2.UseVisualStyleBackColor = true;
            this.btnSpeed20Add_2.Click += new System.EventHandler(this.btnSpeed20Add_2_Click);
            // 
            // btnSpeed20Minus_2
            // 
            this.btnSpeed20Minus_2.Location = new System.Drawing.Point(6, 50);
            this.btnSpeed20Minus_2.Name = "btnSpeed20Minus_2";
            this.btnSpeed20Minus_2.Size = new System.Drawing.Size(63, 23);
            this.btnSpeed20Minus_2.TabIndex = 2;
            this.btnSpeed20Minus_2.Text = "风速-";
            this.btnSpeed20Minus_2.UseVisualStyleBackColor = true;
            this.btnSpeed20Minus_2.Click += new System.EventHandler(this.btnSpeed20Minus_2_Click);
            // 
            // btnDirection20Add_3
            // 
            this.btnDirection20Add_3.Location = new System.Drawing.Point(75, 21);
            this.btnDirection20Add_3.Name = "btnDirection20Add_3";
            this.btnDirection20Add_3.Size = new System.Drawing.Size(63, 23);
            this.btnDirection20Add_3.TabIndex = 1;
            this.btnDirection20Add_3.Text = "风向+";
            this.btnDirection20Add_3.UseVisualStyleBackColor = true;
            this.btnDirection20Add_3.Click += new System.EventHandler(this.btnDirection20Add_3_Click);
            // 
            // btnDirection20Minus_3
            // 
            this.btnDirection20Minus_3.Location = new System.Drawing.Point(6, 21);
            this.btnDirection20Minus_3.Name = "btnDirection20Minus_3";
            this.btnDirection20Minus_3.Size = new System.Drawing.Size(63, 23);
            this.btnDirection20Minus_3.TabIndex = 0;
            this.btnDirection20Minus_3.Text = "风向-";
            this.btnDirection20Minus_3.UseVisualStyleBackColor = true;
            this.btnDirection20Minus_3.Click += new System.EventHandler(this.btnDirection20Minus_3_Click);
            // 
            // btnTestModel_CC
            // 
            this.btnTestModel_CC.Location = new System.Drawing.Point(12, 72);
            this.btnTestModel_CC.Name = "btnTestModel_CC";
            this.btnTestModel_CC.Size = new System.Drawing.Size(137, 32);
            this.btnTestModel_CC.TabIndex = 8;
            this.btnTestModel_CC.Text = "测试模式";
            this.btnTestModel_CC.UseVisualStyleBackColor = true;
            this.btnTestModel_CC.Click += new System.EventHandler(this.btnTestModel_CC_Click);
            // 
            // btnDisplayCurrent_AA
            // 
            this.btnDisplayCurrent_AA.Location = new System.Drawing.Point(26, 23);
            this.btnDisplayCurrent_AA.Name = "btnDisplayCurrent_AA";
            this.btnDisplayCurrent_AA.Size = new System.Drawing.Size(131, 36);
            this.btnDisplayCurrent_AA.TabIndex = 9;
            this.btnDisplayCurrent_AA.Text = "显示零位";
            this.btnDisplayCurrent_AA.UseVisualStyleBackColor = true;
            this.btnDisplayCurrent_AA.Click += new System.EventHandler(this.btnDisplayCurrent_AA_Click);
            // 
            // btnInfo_E0
            // 
            this.btnInfo_E0.Location = new System.Drawing.Point(12, 164);
            this.btnInfo_E0.Name = "btnInfo_E0";
            this.btnInfo_E0.Size = new System.Drawing.Size(137, 32);
            this.btnInfo_E0.TabIndex = 10;
            this.btnInfo_E0.Text = "附加信息关";
            this.btnInfo_E0.UseVisualStyleBackColor = true;
            this.btnInfo_E0.Click += new System.EventHandler(this.btnInfo_E0_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Setting);
            this.tabControl1.Controls.Add(this.windspeed);
            this.tabControl1.Controls.Add(this.windDirection);
            this.tabControl1.Location = new System.Drawing.Point(594, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 480);
            this.tabControl1.TabIndex = 7;
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.label10);
            this.Setting.Controls.Add(this.label9);
            this.Setting.Controls.Add(this.groupBox7);
            this.Setting.Controls.Add(this.groupBox6);
            this.Setting.Controls.Add(this.btnDisplayCurrent_AA);
            this.Setting.Controls.Add(this.btnSetHeatTemp_5);
            this.Setting.Controls.Add(this.cbxAverageTime);
            this.Setting.Controls.Add(this.btnSetAverageTime_4);
            this.Setting.Controls.Add(this.btnReset_GO);
            this.Setting.Controls.Add(this.cbxHeatTemp);
            this.Setting.Location = new System.Drawing.Point(4, 22);
            this.Setting.Name = "Setting";
            this.Setting.Padding = new System.Windows.Forms.Padding(3);
            this.Setting.Size = new System.Drawing.Size(192, 454);
            this.Setting.TabIndex = 1;
            this.Setting.Text = "系统设置";
            this.Setting.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "加热启动温度:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "平均时间:";
            // 
            // windspeed
            // 
            this.windspeed.Controls.Add(this.lblFS8);
            this.windspeed.Controls.Add(this.rBtnSpeed180);
            this.windspeed.Controls.Add(this.btnWind8Add);
            this.windspeed.Controls.Add(this.rBtnSpeed90);
            this.windspeed.Controls.Add(this.btnWind8Minus);
            this.windspeed.Controls.Add(this.btnWind1Minus);
            this.windspeed.Controls.Add(this.lblFS7);
            this.windspeed.Controls.Add(this.btnWind1Add);
            this.windspeed.Controls.Add(this.btnWind7Add);
            this.windspeed.Controls.Add(this.lblFS1);
            this.windspeed.Controls.Add(this.btnWind7Minus);
            this.windspeed.Controls.Add(this.btnWind2Minus);
            this.windspeed.Controls.Add(this.lblFS6);
            this.windspeed.Controls.Add(this.btnWind2Add);
            this.windspeed.Controls.Add(this.btnWind6Add);
            this.windspeed.Controls.Add(this.lblFS2);
            this.windspeed.Controls.Add(this.btnWind6Minus);
            this.windspeed.Controls.Add(this.btnWind3Minus);
            this.windspeed.Controls.Add(this.lblFS5);
            this.windspeed.Controls.Add(this.btnWind3Add);
            this.windspeed.Controls.Add(this.btnWind5Add);
            this.windspeed.Controls.Add(this.lblFS3);
            this.windspeed.Controls.Add(this.btnWind5Minus);
            this.windspeed.Controls.Add(this.btnWind4Minus);
            this.windspeed.Controls.Add(this.lblFS4);
            this.windspeed.Controls.Add(this.btnWind4Add);
            this.windspeed.Location = new System.Drawing.Point(4, 22);
            this.windspeed.Name = "windspeed";
            this.windspeed.Padding = new System.Windows.Forms.Padding(3);
            this.windspeed.Size = new System.Drawing.Size(192, 454);
            this.windspeed.TabIndex = 0;
            this.windspeed.Text = "风速校准";
            this.windspeed.UseVisualStyleBackColor = true;
            // 
            // windDirection
            // 
            this.windDirection.Controls.Add(this.tabControl2);
            this.windDirection.Location = new System.Drawing.Point(4, 22);
            this.windDirection.Name = "windDirection";
            this.windDirection.Padding = new System.Windows.Forms.Padding(3);
            this.windDirection.Size = new System.Drawing.Size(192, 454);
            this.windDirection.TabIndex = 2;
            this.windDirection.Text = "风向校准";
            this.windDirection.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Direction0);
            this.tabControl2.Controls.Add(this.Direction360);
            this.tabControl2.Location = new System.Drawing.Point(-3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(199, 455);
            this.tabControl2.TabIndex = 0;
            // 
            // Direction0
            // 
            this.Direction0.Controls.Add(this.label27);
            this.Direction0.Controls.Add(this.btnDirectionAdd_M);
            this.Direction0.Controls.Add(this.btnDirectionMinusM);
            this.Direction0.Controls.Add(this.label28);
            this.Direction0.Controls.Add(this.btnDirectionAdd_L);
            this.Direction0.Controls.Add(this.btnDirectionMinusL);
            this.Direction0.Controls.Add(this.label29);
            this.Direction0.Controls.Add(this.btnDirectionAdd_K);
            this.Direction0.Controls.Add(this.btnDirectionMinusK);
            this.Direction0.Controls.Add(this.label30);
            this.Direction0.Controls.Add(this.btnDirectionAdd_J);
            this.Direction0.Controls.Add(this.btnDirectionMinusJ);
            this.Direction0.Controls.Add(this.btnDirectionMinusI);
            this.Direction0.Controls.Add(this.label31);
            this.Direction0.Controls.Add(this.btnDirectionAdd_I);
            this.Direction0.Controls.Add(this.label19);
            this.Direction0.Controls.Add(this.btnDirectionAdd_H);
            this.Direction0.Controls.Add(this.btnDirectionMinusH);
            this.Direction0.Controls.Add(this.btnDirectionMinusA);
            this.Direction0.Controls.Add(this.label20);
            this.Direction0.Controls.Add(this.btnDirectionAdd_A);
            this.Direction0.Controls.Add(this.btnDirectionAdd_G);
            this.Direction0.Controls.Add(this.label21);
            this.Direction0.Controls.Add(this.btnDirectionMinusG);
            this.Direction0.Controls.Add(this.btnDirectionMinusB);
            this.Direction0.Controls.Add(this.label22);
            this.Direction0.Controls.Add(this.btnDirectionAdd_B);
            this.Direction0.Controls.Add(this.btnDirectionAdd_F);
            this.Direction0.Controls.Add(this.label23);
            this.Direction0.Controls.Add(this.btnDirectionMinusF);
            this.Direction0.Controls.Add(this.btnDirectionMinusC);
            this.Direction0.Controls.Add(this.label24);
            this.Direction0.Controls.Add(this.btnDirectionAdd_C);
            this.Direction0.Controls.Add(this.btnDirectionAdd_E);
            this.Direction0.Controls.Add(this.label25);
            this.Direction0.Controls.Add(this.btnDirectionMinusE);
            this.Direction0.Controls.Add(this.btnDirectionMinusD);
            this.Direction0.Controls.Add(this.label26);
            this.Direction0.Controls.Add(this.btnDirectionAdd_D);
            this.Direction0.Location = new System.Drawing.Point(4, 22);
            this.Direction0.Name = "Direction0";
            this.Direction0.Padding = new System.Windows.Forms.Padding(3);
            this.Direction0.Size = new System.Drawing.Size(191, 429);
            this.Direction0.TabIndex = 0;
            this.Direction0.Text = "0--180";
            this.Direction0.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(81, 388);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 12);
            this.label27.TabIndex = 88;
            this.label27.Text = "180°";
            // 
            // btnDirectionAdd_M
            // 
            this.btnDirectionAdd_M.Location = new System.Drawing.Point(123, 383);
            this.btnDirectionAdd_M.Name = "btnDirectionAdd_M";
            this.btnDirectionAdd_M.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_M.TabIndex = 87;
            this.btnDirectionAdd_M.Text = "加";
            this.btnDirectionAdd_M.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_M.Click += new System.EventHandler(this.btnDirectionAdd_M_Click);
            // 
            // btnDirectionMinusM
            // 
            this.btnDirectionMinusM.Location = new System.Drawing.Point(10, 383);
            this.btnDirectionMinusM.Name = "btnDirectionMinusM";
            this.btnDirectionMinusM.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusM.TabIndex = 86;
            this.btnDirectionMinusM.Text = "减";
            this.btnDirectionMinusM.UseVisualStyleBackColor = true;
            this.btnDirectionMinusM.Click += new System.EventHandler(this.btnDirectionMinusM_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(81, 357);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 12);
            this.label28.TabIndex = 85;
            this.label28.Text = "165°";
            // 
            // btnDirectionAdd_L
            // 
            this.btnDirectionAdd_L.Location = new System.Drawing.Point(123, 352);
            this.btnDirectionAdd_L.Name = "btnDirectionAdd_L";
            this.btnDirectionAdd_L.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_L.TabIndex = 84;
            this.btnDirectionAdd_L.Text = "加";
            this.btnDirectionAdd_L.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_L.Click += new System.EventHandler(this.btnDirectionAdd_L_Click);
            // 
            // btnDirectionMinusL
            // 
            this.btnDirectionMinusL.Location = new System.Drawing.Point(10, 352);
            this.btnDirectionMinusL.Name = "btnDirectionMinusL";
            this.btnDirectionMinusL.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusL.TabIndex = 83;
            this.btnDirectionMinusL.Text = "减";
            this.btnDirectionMinusL.UseVisualStyleBackColor = true;
            this.btnDirectionMinusL.Click += new System.EventHandler(this.btnDirectionMinusL_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(81, 326);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 12);
            this.label29.TabIndex = 82;
            this.label29.Text = "150°";
            // 
            // btnDirectionAdd_K
            // 
            this.btnDirectionAdd_K.Location = new System.Drawing.Point(123, 321);
            this.btnDirectionAdd_K.Name = "btnDirectionAdd_K";
            this.btnDirectionAdd_K.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_K.TabIndex = 81;
            this.btnDirectionAdd_K.Text = "加";
            this.btnDirectionAdd_K.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_K.Click += new System.EventHandler(this.btnDirectionAdd_K_Click);
            // 
            // btnDirectionMinusK
            // 
            this.btnDirectionMinusK.Location = new System.Drawing.Point(10, 321);
            this.btnDirectionMinusK.Name = "btnDirectionMinusK";
            this.btnDirectionMinusK.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusK.TabIndex = 80;
            this.btnDirectionMinusK.Text = "减";
            this.btnDirectionMinusK.UseVisualStyleBackColor = true;
            this.btnDirectionMinusK.Click += new System.EventHandler(this.btnDirectionMinusK_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(81, 295);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 12);
            this.label30.TabIndex = 79;
            this.label30.Text = "135°";
            // 
            // btnDirectionAdd_J
            // 
            this.btnDirectionAdd_J.Location = new System.Drawing.Point(123, 290);
            this.btnDirectionAdd_J.Name = "btnDirectionAdd_J";
            this.btnDirectionAdd_J.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_J.TabIndex = 78;
            this.btnDirectionAdd_J.Text = "加";
            this.btnDirectionAdd_J.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_J.Click += new System.EventHandler(this.btnDirectionAdd_J_Click);
            // 
            // btnDirectionMinusJ
            // 
            this.btnDirectionMinusJ.Location = new System.Drawing.Point(10, 290);
            this.btnDirectionMinusJ.Name = "btnDirectionMinusJ";
            this.btnDirectionMinusJ.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusJ.TabIndex = 77;
            this.btnDirectionMinusJ.Text = "减";
            this.btnDirectionMinusJ.UseVisualStyleBackColor = true;
            this.btnDirectionMinusJ.Click += new System.EventHandler(this.btnDirectionMinusJ_Click);
            // 
            // btnDirectionMinusI
            // 
            this.btnDirectionMinusI.Location = new System.Drawing.Point(10, 259);
            this.btnDirectionMinusI.Name = "btnDirectionMinusI";
            this.btnDirectionMinusI.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusI.TabIndex = 74;
            this.btnDirectionMinusI.Text = "减";
            this.btnDirectionMinusI.UseVisualStyleBackColor = true;
            this.btnDirectionMinusI.Click += new System.EventHandler(this.btnDirectionMinusI_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(81, 264);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 12);
            this.label31.TabIndex = 76;
            this.label31.Text = "120°";
            // 
            // btnDirectionAdd_I
            // 
            this.btnDirectionAdd_I.Location = new System.Drawing.Point(123, 259);
            this.btnDirectionAdd_I.Name = "btnDirectionAdd_I";
            this.btnDirectionAdd_I.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_I.TabIndex = 75;
            this.btnDirectionAdd_I.Text = "加";
            this.btnDirectionAdd_I.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_I.Click += new System.EventHandler(this.btnDirectionAdd_I_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(81, 233);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 73;
            this.label19.Text = "105°";
            // 
            // btnDirectionAdd_H
            // 
            this.btnDirectionAdd_H.Location = new System.Drawing.Point(123, 228);
            this.btnDirectionAdd_H.Name = "btnDirectionAdd_H";
            this.btnDirectionAdd_H.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_H.TabIndex = 72;
            this.btnDirectionAdd_H.Text = "加";
            this.btnDirectionAdd_H.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_H.Click += new System.EventHandler(this.btnDirectionAdd_H_Click);
            // 
            // btnDirectionMinusH
            // 
            this.btnDirectionMinusH.Location = new System.Drawing.Point(10, 228);
            this.btnDirectionMinusH.Name = "btnDirectionMinusH";
            this.btnDirectionMinusH.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusH.TabIndex = 71;
            this.btnDirectionMinusH.Text = "减";
            this.btnDirectionMinusH.UseVisualStyleBackColor = true;
            this.btnDirectionMinusH.Click += new System.EventHandler(this.btnDirectionMinusH_Click);
            // 
            // btnDirectionMinusA
            // 
            this.btnDirectionMinusA.Location = new System.Drawing.Point(10, 11);
            this.btnDirectionMinusA.Name = "btnDirectionMinusA";
            this.btnDirectionMinusA.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusA.TabIndex = 50;
            this.btnDirectionMinusA.Text = "减";
            this.btnDirectionMinusA.UseVisualStyleBackColor = true;
            this.btnDirectionMinusA.Click += new System.EventHandler(this.btnDirectionMinusA_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(81, 202);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 70;
            this.label20.Text = "90°";
            // 
            // btnDirectionAdd_A
            // 
            this.btnDirectionAdd_A.Location = new System.Drawing.Point(123, 11);
            this.btnDirectionAdd_A.Name = "btnDirectionAdd_A";
            this.btnDirectionAdd_A.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_A.TabIndex = 51;
            this.btnDirectionAdd_A.Text = "加";
            this.btnDirectionAdd_A.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_A.Click += new System.EventHandler(this.btnDirectionAdd_A_Click);
            // 
            // btnDirectionAdd_G
            // 
            this.btnDirectionAdd_G.Location = new System.Drawing.Point(123, 197);
            this.btnDirectionAdd_G.Name = "btnDirectionAdd_G";
            this.btnDirectionAdd_G.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_G.TabIndex = 69;
            this.btnDirectionAdd_G.Text = "加";
            this.btnDirectionAdd_G.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_G.Click += new System.EventHandler(this.btnDirectionAdd_G_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(81, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 12);
            this.label21.TabIndex = 52;
            this.label21.Text = "0°";
            // 
            // btnDirectionMinusG
            // 
            this.btnDirectionMinusG.Location = new System.Drawing.Point(10, 197);
            this.btnDirectionMinusG.Name = "btnDirectionMinusG";
            this.btnDirectionMinusG.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusG.TabIndex = 68;
            this.btnDirectionMinusG.Text = "减";
            this.btnDirectionMinusG.UseVisualStyleBackColor = true;
            this.btnDirectionMinusG.Click += new System.EventHandler(this.btnDirectionMinusG_Click);
            // 
            // btnDirectionMinusB
            // 
            this.btnDirectionMinusB.Location = new System.Drawing.Point(10, 42);
            this.btnDirectionMinusB.Name = "btnDirectionMinusB";
            this.btnDirectionMinusB.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusB.TabIndex = 53;
            this.btnDirectionMinusB.Text = "减";
            this.btnDirectionMinusB.UseVisualStyleBackColor = true;
            this.btnDirectionMinusB.Click += new System.EventHandler(this.btnDirectionMinusB_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(81, 171);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 67;
            this.label22.Text = "75°";
            // 
            // btnDirectionAdd_B
            // 
            this.btnDirectionAdd_B.Location = new System.Drawing.Point(123, 42);
            this.btnDirectionAdd_B.Name = "btnDirectionAdd_B";
            this.btnDirectionAdd_B.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_B.TabIndex = 54;
            this.btnDirectionAdd_B.Text = "加";
            this.btnDirectionAdd_B.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_B.Click += new System.EventHandler(this.btnDirectionAdd_B_Click);
            // 
            // btnDirectionAdd_F
            // 
            this.btnDirectionAdd_F.Location = new System.Drawing.Point(123, 166);
            this.btnDirectionAdd_F.Name = "btnDirectionAdd_F";
            this.btnDirectionAdd_F.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_F.TabIndex = 66;
            this.btnDirectionAdd_F.Text = "加";
            this.btnDirectionAdd_F.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_F.Click += new System.EventHandler(this.btnDirectionAdd_F_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(81, 47);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 55;
            this.label23.Text = "15°";
            // 
            // btnDirectionMinusF
            // 
            this.btnDirectionMinusF.Location = new System.Drawing.Point(10, 166);
            this.btnDirectionMinusF.Name = "btnDirectionMinusF";
            this.btnDirectionMinusF.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusF.TabIndex = 65;
            this.btnDirectionMinusF.Text = "减";
            this.btnDirectionMinusF.UseVisualStyleBackColor = true;
            this.btnDirectionMinusF.Click += new System.EventHandler(this.btnDirectionMinusF_Click);
            // 
            // btnDirectionMinusC
            // 
            this.btnDirectionMinusC.Location = new System.Drawing.Point(10, 73);
            this.btnDirectionMinusC.Name = "btnDirectionMinusC";
            this.btnDirectionMinusC.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusC.TabIndex = 56;
            this.btnDirectionMinusC.Text = "减";
            this.btnDirectionMinusC.UseVisualStyleBackColor = true;
            this.btnDirectionMinusC.Click += new System.EventHandler(this.btnDirectionMinusC_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(81, 140);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 64;
            this.label24.Text = "60°";
            // 
            // btnDirectionAdd_C
            // 
            this.btnDirectionAdd_C.Location = new System.Drawing.Point(123, 73);
            this.btnDirectionAdd_C.Name = "btnDirectionAdd_C";
            this.btnDirectionAdd_C.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_C.TabIndex = 57;
            this.btnDirectionAdd_C.Text = "加";
            this.btnDirectionAdd_C.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_C.Click += new System.EventHandler(this.btnDirectionAdd_C_Click);
            // 
            // btnDirectionAdd_E
            // 
            this.btnDirectionAdd_E.Location = new System.Drawing.Point(123, 135);
            this.btnDirectionAdd_E.Name = "btnDirectionAdd_E";
            this.btnDirectionAdd_E.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_E.TabIndex = 63;
            this.btnDirectionAdd_E.Text = "加";
            this.btnDirectionAdd_E.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_E.Click += new System.EventHandler(this.btnDirectionAdd_E_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(81, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 58;
            this.label25.Text = "30°";
            // 
            // btnDirectionMinusE
            // 
            this.btnDirectionMinusE.Location = new System.Drawing.Point(10, 135);
            this.btnDirectionMinusE.Name = "btnDirectionMinusE";
            this.btnDirectionMinusE.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusE.TabIndex = 62;
            this.btnDirectionMinusE.Text = "减";
            this.btnDirectionMinusE.UseVisualStyleBackColor = true;
            this.btnDirectionMinusE.Click += new System.EventHandler(this.btnDirectionMinusE_Click);
            // 
            // btnDirectionMinusD
            // 
            this.btnDirectionMinusD.Location = new System.Drawing.Point(10, 104);
            this.btnDirectionMinusD.Name = "btnDirectionMinusD";
            this.btnDirectionMinusD.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusD.TabIndex = 59;
            this.btnDirectionMinusD.Text = "减";
            this.btnDirectionMinusD.UseVisualStyleBackColor = true;
            this.btnDirectionMinusD.Click += new System.EventHandler(this.btnDirectionMinusD_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(81, 109);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 61;
            this.label26.Text = "45°";
            // 
            // btnDirectionAdd_D
            // 
            this.btnDirectionAdd_D.Location = new System.Drawing.Point(123, 104);
            this.btnDirectionAdd_D.Name = "btnDirectionAdd_D";
            this.btnDirectionAdd_D.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_D.TabIndex = 60;
            this.btnDirectionAdd_D.Text = "加";
            this.btnDirectionAdd_D.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_D.Click += new System.EventHandler(this.btnDirectionAdd_D_Click);
            // 
            // Direction360
            // 
            this.Direction360.Controls.Add(this.label32);
            this.Direction360.Controls.Add(this.btnDirectionAdd_Y);
            this.Direction360.Controls.Add(this.btnDirectionMinusY);
            this.Direction360.Controls.Add(this.label33);
            this.Direction360.Controls.Add(this.btnDirectionAdd_X);
            this.Direction360.Controls.Add(this.btnDirectionMinusX);
            this.Direction360.Controls.Add(this.label34);
            this.Direction360.Controls.Add(this.btnDirectionAdd_W);
            this.Direction360.Controls.Add(this.btnDirectionMinusW);
            this.Direction360.Controls.Add(this.label35);
            this.Direction360.Controls.Add(this.btnDirectionAdd_V);
            this.Direction360.Controls.Add(this.btnDirectionMinusV);
            this.Direction360.Controls.Add(this.label11);
            this.Direction360.Controls.Add(this.btnDirectionAdd_U);
            this.Direction360.Controls.Add(this.btnDirectionMinusU);
            this.Direction360.Controls.Add(this.btnDirectionMinusN);
            this.Direction360.Controls.Add(this.label12);
            this.Direction360.Controls.Add(this.btnDirectionAdd_N);
            this.Direction360.Controls.Add(this.btnDirectionAdd_T);
            this.Direction360.Controls.Add(this.label13);
            this.Direction360.Controls.Add(this.btnDirectionMinusT);
            this.Direction360.Controls.Add(this.btnDirectionMinusO);
            this.Direction360.Controls.Add(this.label14);
            this.Direction360.Controls.Add(this.btnDirectionAdd_O);
            this.Direction360.Controls.Add(this.btnDirectionAdd_S);
            this.Direction360.Controls.Add(this.label15);
            this.Direction360.Controls.Add(this.btnDirectionMinusS);
            this.Direction360.Controls.Add(this.btnDirectionMinusP);
            this.Direction360.Controls.Add(this.label16);
            this.Direction360.Controls.Add(this.btnDirectionAdd_P);
            this.Direction360.Controls.Add(this.btnDirectionAdd_R);
            this.Direction360.Controls.Add(this.label17);
            this.Direction360.Controls.Add(this.btnDirectionMinusR);
            this.Direction360.Controls.Add(this.btnDirectionMinusQ);
            this.Direction360.Controls.Add(this.label18);
            this.Direction360.Controls.Add(this.btnDirectionAdd_Q);
            this.Direction360.Location = new System.Drawing.Point(4, 22);
            this.Direction360.Name = "Direction360";
            this.Direction360.Padding = new System.Windows.Forms.Padding(3);
            this.Direction360.Size = new System.Drawing.Size(191, 429);
            this.Direction360.TabIndex = 1;
            this.Direction360.Text = "195--359";
            this.Direction360.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(84, 362);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 12);
            this.label32.TabIndex = 61;
            this.label32.Text = "360°";
            // 
            // btnDirectionAdd_Y
            // 
            this.btnDirectionAdd_Y.Location = new System.Drawing.Point(126, 357);
            this.btnDirectionAdd_Y.Name = "btnDirectionAdd_Y";
            this.btnDirectionAdd_Y.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_Y.TabIndex = 60;
            this.btnDirectionAdd_Y.Text = "加";
            this.btnDirectionAdd_Y.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_Y.Click += new System.EventHandler(this.btnDirectionAdd_Y_Click);
            // 
            // btnDirectionMinusY
            // 
            this.btnDirectionMinusY.Location = new System.Drawing.Point(13, 357);
            this.btnDirectionMinusY.Name = "btnDirectionMinusY";
            this.btnDirectionMinusY.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusY.TabIndex = 59;
            this.btnDirectionMinusY.Text = "减";
            this.btnDirectionMinusY.UseVisualStyleBackColor = true;
            this.btnDirectionMinusY.Click += new System.EventHandler(this.btnDirectionMinusY_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(84, 331);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 12);
            this.label33.TabIndex = 58;
            this.label33.Text = "345°";
            // 
            // btnDirectionAdd_X
            // 
            this.btnDirectionAdd_X.Location = new System.Drawing.Point(126, 326);
            this.btnDirectionAdd_X.Name = "btnDirectionAdd_X";
            this.btnDirectionAdd_X.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_X.TabIndex = 57;
            this.btnDirectionAdd_X.Text = "加";
            this.btnDirectionAdd_X.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_X.Click += new System.EventHandler(this.btnDirectionAdd_X_Click);
            // 
            // btnDirectionMinusX
            // 
            this.btnDirectionMinusX.Location = new System.Drawing.Point(13, 326);
            this.btnDirectionMinusX.Name = "btnDirectionMinusX";
            this.btnDirectionMinusX.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusX.TabIndex = 56;
            this.btnDirectionMinusX.Text = "减";
            this.btnDirectionMinusX.UseVisualStyleBackColor = true;
            this.btnDirectionMinusX.Click += new System.EventHandler(this.btnDirectionMinusX_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(84, 300);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 12);
            this.label34.TabIndex = 55;
            this.label34.Text = "330°";
            // 
            // btnDirectionAdd_W
            // 
            this.btnDirectionAdd_W.Location = new System.Drawing.Point(126, 295);
            this.btnDirectionAdd_W.Name = "btnDirectionAdd_W";
            this.btnDirectionAdd_W.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_W.TabIndex = 54;
            this.btnDirectionAdd_W.Text = "加";
            this.btnDirectionAdd_W.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_W.Click += new System.EventHandler(this.btnDirectionAdd_W_Click);
            // 
            // btnDirectionMinusW
            // 
            this.btnDirectionMinusW.Location = new System.Drawing.Point(13, 295);
            this.btnDirectionMinusW.Name = "btnDirectionMinusW";
            this.btnDirectionMinusW.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusW.TabIndex = 53;
            this.btnDirectionMinusW.Text = "减";
            this.btnDirectionMinusW.UseVisualStyleBackColor = true;
            this.btnDirectionMinusW.Click += new System.EventHandler(this.btnDirectionMinusW_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(84, 269);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 12);
            this.label35.TabIndex = 52;
            this.label35.Text = "315°";
            // 
            // btnDirectionAdd_V
            // 
            this.btnDirectionAdd_V.Location = new System.Drawing.Point(126, 264);
            this.btnDirectionAdd_V.Name = "btnDirectionAdd_V";
            this.btnDirectionAdd_V.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_V.TabIndex = 51;
            this.btnDirectionAdd_V.Text = "加";
            this.btnDirectionAdd_V.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_V.Click += new System.EventHandler(this.btnDirectionAdd_V_Click);
            // 
            // btnDirectionMinusV
            // 
            this.btnDirectionMinusV.Location = new System.Drawing.Point(13, 264);
            this.btnDirectionMinusV.Name = "btnDirectionMinusV";
            this.btnDirectionMinusV.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusV.TabIndex = 50;
            this.btnDirectionMinusV.Text = "减";
            this.btnDirectionMinusV.UseVisualStyleBackColor = true;
            this.btnDirectionMinusV.Click += new System.EventHandler(this.btnDirectionMinusV_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(84, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "300°";
            // 
            // btnDirectionAdd_U
            // 
            this.btnDirectionAdd_U.Location = new System.Drawing.Point(126, 233);
            this.btnDirectionAdd_U.Name = "btnDirectionAdd_U";
            this.btnDirectionAdd_U.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_U.TabIndex = 48;
            this.btnDirectionAdd_U.Text = "加";
            this.btnDirectionAdd_U.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_U.Click += new System.EventHandler(this.btnDirectionAdd_U_Click);
            // 
            // btnDirectionMinusU
            // 
            this.btnDirectionMinusU.Location = new System.Drawing.Point(13, 233);
            this.btnDirectionMinusU.Name = "btnDirectionMinusU";
            this.btnDirectionMinusU.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusU.TabIndex = 47;
            this.btnDirectionMinusU.Text = "减";
            this.btnDirectionMinusU.UseVisualStyleBackColor = true;
            this.btnDirectionMinusU.Click += new System.EventHandler(this.btnDirectionMinusU_Click);
            // 
            // btnDirectionMinusN
            // 
            this.btnDirectionMinusN.Location = new System.Drawing.Point(13, 16);
            this.btnDirectionMinusN.Name = "btnDirectionMinusN";
            this.btnDirectionMinusN.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusN.TabIndex = 26;
            this.btnDirectionMinusN.Text = "减";
            this.btnDirectionMinusN.UseVisualStyleBackColor = true;
            this.btnDirectionMinusN.Click += new System.EventHandler(this.btnDirectionMinusN_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 46;
            this.label12.Text = "285°";
            // 
            // btnDirectionAdd_N
            // 
            this.btnDirectionAdd_N.Location = new System.Drawing.Point(126, 16);
            this.btnDirectionAdd_N.Name = "btnDirectionAdd_N";
            this.btnDirectionAdd_N.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_N.TabIndex = 27;
            this.btnDirectionAdd_N.Text = "加";
            this.btnDirectionAdd_N.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_N.Click += new System.EventHandler(this.btnDirectionAdd_N_Click);
            // 
            // btnDirectionAdd_T
            // 
            this.btnDirectionAdd_T.Location = new System.Drawing.Point(126, 202);
            this.btnDirectionAdd_T.Name = "btnDirectionAdd_T";
            this.btnDirectionAdd_T.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_T.TabIndex = 45;
            this.btnDirectionAdd_T.Text = "加";
            this.btnDirectionAdd_T.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_T.Click += new System.EventHandler(this.btnDirectionAdd_T_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(84, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "195°";
            // 
            // btnDirectionMinusT
            // 
            this.btnDirectionMinusT.Location = new System.Drawing.Point(13, 202);
            this.btnDirectionMinusT.Name = "btnDirectionMinusT";
            this.btnDirectionMinusT.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusT.TabIndex = 44;
            this.btnDirectionMinusT.Text = "减";
            this.btnDirectionMinusT.UseVisualStyleBackColor = true;
            this.btnDirectionMinusT.Click += new System.EventHandler(this.btnDirectionMinusT_Click);
            // 
            // btnDirectionMinusO
            // 
            this.btnDirectionMinusO.Location = new System.Drawing.Point(13, 47);
            this.btnDirectionMinusO.Name = "btnDirectionMinusO";
            this.btnDirectionMinusO.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusO.TabIndex = 29;
            this.btnDirectionMinusO.Text = "减";
            this.btnDirectionMinusO.UseVisualStyleBackColor = true;
            this.btnDirectionMinusO.Click += new System.EventHandler(this.btnDirectionMinusO_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(84, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 43;
            this.label14.Text = "270°";
            // 
            // btnDirectionAdd_O
            // 
            this.btnDirectionAdd_O.Location = new System.Drawing.Point(126, 47);
            this.btnDirectionAdd_O.Name = "btnDirectionAdd_O";
            this.btnDirectionAdd_O.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_O.TabIndex = 30;
            this.btnDirectionAdd_O.Text = "加";
            this.btnDirectionAdd_O.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_O.Click += new System.EventHandler(this.btnDirectionAdd_O_Click);
            // 
            // btnDirectionAdd_S
            // 
            this.btnDirectionAdd_S.Location = new System.Drawing.Point(126, 171);
            this.btnDirectionAdd_S.Name = "btnDirectionAdd_S";
            this.btnDirectionAdd_S.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_S.TabIndex = 42;
            this.btnDirectionAdd_S.Text = "加";
            this.btnDirectionAdd_S.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_S.Click += new System.EventHandler(this.btnDirectionAdd_S_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(84, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 31;
            this.label15.Text = "210°";
            // 
            // btnDirectionMinusS
            // 
            this.btnDirectionMinusS.Location = new System.Drawing.Point(13, 171);
            this.btnDirectionMinusS.Name = "btnDirectionMinusS";
            this.btnDirectionMinusS.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusS.TabIndex = 41;
            this.btnDirectionMinusS.Text = "减";
            this.btnDirectionMinusS.UseVisualStyleBackColor = true;
            this.btnDirectionMinusS.Click += new System.EventHandler(this.btnDirectionMinusS_Click);
            // 
            // btnDirectionMinusP
            // 
            this.btnDirectionMinusP.Location = new System.Drawing.Point(13, 78);
            this.btnDirectionMinusP.Name = "btnDirectionMinusP";
            this.btnDirectionMinusP.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusP.TabIndex = 32;
            this.btnDirectionMinusP.Text = "减";
            this.btnDirectionMinusP.UseVisualStyleBackColor = true;
            this.btnDirectionMinusP.Click += new System.EventHandler(this.btnDirectionMinusP_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(84, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 40;
            this.label16.Text = "255°";
            // 
            // btnDirectionAdd_P
            // 
            this.btnDirectionAdd_P.Location = new System.Drawing.Point(126, 78);
            this.btnDirectionAdd_P.Name = "btnDirectionAdd_P";
            this.btnDirectionAdd_P.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_P.TabIndex = 33;
            this.btnDirectionAdd_P.Text = "加";
            this.btnDirectionAdd_P.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_P.Click += new System.EventHandler(this.btnDirectionAdd_P_Click);
            // 
            // btnDirectionAdd_R
            // 
            this.btnDirectionAdd_R.Location = new System.Drawing.Point(126, 140);
            this.btnDirectionAdd_R.Name = "btnDirectionAdd_R";
            this.btnDirectionAdd_R.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_R.TabIndex = 39;
            this.btnDirectionAdd_R.Text = "加";
            this.btnDirectionAdd_R.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_R.Click += new System.EventHandler(this.btnDirectionAdd_R_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(84, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 34;
            this.label17.Text = "225°";
            // 
            // btnDirectionMinusR
            // 
            this.btnDirectionMinusR.Location = new System.Drawing.Point(13, 140);
            this.btnDirectionMinusR.Name = "btnDirectionMinusR";
            this.btnDirectionMinusR.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusR.TabIndex = 38;
            this.btnDirectionMinusR.Text = "减";
            this.btnDirectionMinusR.UseVisualStyleBackColor = true;
            this.btnDirectionMinusR.Click += new System.EventHandler(this.btnDirectionMinusR_Click);
            // 
            // btnDirectionMinusQ
            // 
            this.btnDirectionMinusQ.Location = new System.Drawing.Point(13, 109);
            this.btnDirectionMinusQ.Name = "btnDirectionMinusQ";
            this.btnDirectionMinusQ.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionMinusQ.TabIndex = 35;
            this.btnDirectionMinusQ.Text = "减";
            this.btnDirectionMinusQ.UseVisualStyleBackColor = true;
            this.btnDirectionMinusQ.Click += new System.EventHandler(this.btnDirectionMinusQ_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(84, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 37;
            this.label18.Text = "240°";
            // 
            // btnDirectionAdd_Q
            // 
            this.btnDirectionAdd_Q.Location = new System.Drawing.Point(126, 109);
            this.btnDirectionAdd_Q.Name = "btnDirectionAdd_Q";
            this.btnDirectionAdd_Q.Size = new System.Drawing.Size(52, 23);
            this.btnDirectionAdd_Q.TabIndex = 36;
            this.btnDirectionAdd_Q.Text = "加";
            this.btnDirectionAdd_Q.UseVisualStyleBackColor = true;
            this.btnDirectionAdd_Q.Click += new System.EventHandler(this.btnDirectionAdd_Q_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRestart_BB);
            this.groupBox4.Controls.Add(this.btnInfo_E0);
            this.groupBox4.Controls.Add(this.btnTestModel_CC);
            this.groupBox4.Controls.Add(this.btnInfo_E1);
            this.groupBox4.Location = new System.Drawing.Point(400, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 217);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设备控制指令";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(35, 515);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 12);
            this.label36.TabIndex = 12;
            this.label36.Text = "收到的字节";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 333;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.刷新串口列表ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "设备管理器";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 刷新串口列表ToolStripMenuItem
            // 
            this.刷新串口列表ToolStripMenuItem.Name = "刷新串口列表ToolStripMenuItem";
            this.刷新串口列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.刷新串口列表ToolStripMenuItem.Text = "刷新串口列表";
            this.刷新串口列表ToolStripMenuItem.Click += new System.EventHandler(this.刷新串口列表ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.升级ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(806, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存接收信息ToolStripMenuItem,
            this.导入发送信息ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 保存接收信息ToolStripMenuItem
            // 
            this.保存接收信息ToolStripMenuItem.Name = "保存接收信息ToolStripMenuItem";
            this.保存接收信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存接收信息ToolStripMenuItem.Text = "保存接收信息";
            // 
            // 导入发送信息ToolStripMenuItem
            // 
            this.导入发送信息ToolStripMenuItem.Name = "导入发送信息ToolStripMenuItem";
            this.导入发送信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导入发送信息ToolStripMenuItem.Text = "导入发送信息";
            this.导入发送信息ToolStripMenuItem.Click += new System.EventHandler(this.导入发送信息ToolStripMenuItem_Click);
            // 
            // 升级ToolStripMenuItem
            // 
            this.升级ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolOpenFile,
            this.ToolupDataFW});
            this.升级ToolStripMenuItem.Name = "升级ToolStripMenuItem";
            this.升级ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.升级ToolStripMenuItem.Text = "固件升级";
            this.升级ToolStripMenuItem.Click += new System.EventHandler(this.升级ToolStripMenuItem_Click);
            // 
            // ToolOpenFile
            // 
            this.ToolOpenFile.Name = "ToolOpenFile";
            this.ToolOpenFile.Size = new System.Drawing.Size(180, 22);
            this.ToolOpenFile.Text = "打开文件";
            this.ToolOpenFile.Click += new System.EventHandler(this.ToolOpenFile_Click);
            // 
            // ToolupDataFW
            // 
            this.ToolupDataFW.Name = "ToolupDataFW";
            this.ToolupDataFW.Size = new System.Drawing.Size(180, 22);
            this.ToolupDataFW.Text = "一键升级";
            this.ToolupDataFW.Click += new System.EventHandler(this.一键升级ToolStripMenuItem_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // HCXSerialPortTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 539);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HCXSerialPortTool";
            this.Text = "测风仪调试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HCXSerialPortTool_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            this.windspeed.ResumeLayout(false);
            this.windspeed.PerformLayout();
            this.windDirection.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Direction0.ResumeLayout(false);
            this.Direction0.PerformLayout();
            this.Direction360.ResumeLayout(false);
            this.Direction360.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbxNetPort;
        private System.Windows.Forms.ComboBox cbxNetIP;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.ComboBox cbxSerialPort;
        private System.Windows.Forms.Button btnSent;
        private System.Windows.Forms.TextBox txtEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblWindDirection;
        private System.Windows.Forms.Label lblStatusCode;
        private System.Windows.Forms.Label lblIventedTemp;
        private System.Windows.Forms.Label lblCalibrationTemp;
        private System.Windows.Forms.Label lblDiffTimeEW;
        private System.Windows.Forms.Label lblDiffTimeNS;
        private System.Windows.Forms.Label lblHeatDown;
        private System.Windows.Forms.Label lblHeatUP;
        private System.Windows.Forms.Label lblVirtualValue;
        private System.Windows.Forms.Label lblWindSpeed;
        private System.Windows.Forms.Button btnReset_GO;
        private System.Windows.Forms.Button btnInfo_E1;
        private System.Windows.Forms.ComboBox cbxHeatTemp;
        private System.Windows.Forms.ComboBox cbxAverageTime;
        private System.Windows.Forms.Button btnRestart_BB;
        private System.Windows.Forms.Button btnSetHeatTemp_5;
        private System.Windows.Forms.Button btnSetAverageTime_4;
        private System.Windows.Forms.RadioButton rBtnSpeed180;
        private System.Windows.Forms.RadioButton rBtnSpeed90;
        private System.Windows.Forms.Label lblFS8;
        private System.Windows.Forms.Button btnWind8Add;
        private System.Windows.Forms.Button btnWind8Minus;
        private System.Windows.Forms.Label lblFS7;
        private System.Windows.Forms.Button btnWind7Add;
        private System.Windows.Forms.Button btnWind7Minus;
        private System.Windows.Forms.Label lblFS6;
        private System.Windows.Forms.Button btnWind6Add;
        private System.Windows.Forms.Button btnWind6Minus;
        private System.Windows.Forms.Label lblFS5;
        private System.Windows.Forms.Button btnWind5Add;
        private System.Windows.Forms.Button btnWind5Minus;
        private System.Windows.Forms.Label lblFS4;
        private System.Windows.Forms.Button btnWind4Add;
        private System.Windows.Forms.Button btnWind4Minus;
        private System.Windows.Forms.Label lblFS3;
        private System.Windows.Forms.Button btnWind3Add;
        private System.Windows.Forms.Button btnWind3Minus;
        private System.Windows.Forms.Label lblFS2;
        private System.Windows.Forms.Button btnWind2Add;
        private System.Windows.Forms.Button btnWind2Minus;
        private System.Windows.Forms.Label lblFS1;
        private System.Windows.Forms.Button btnWind1Add;
        private System.Windows.Forms.Button btnWind1Minus;
        private System.Windows.Forms.Button btnDisplayCurrent_AA;
        private System.Windows.Forms.Button btnTestModel_CC;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSpeed4Add_0;
        private System.Windows.Forms.Button btnSpeed4Minus_0;
        private System.Windows.Forms.Button btnDeriction4Add_1;
        private System.Windows.Forms.Button btnDirection4Minus_1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnSpeed20Add_2;
        private System.Windows.Forms.Button btnSpeed20Minus_2;
        private System.Windows.Forms.Button btnDirection20Add_3;
        private System.Windows.Forms.Button btnDirection20Minus_3;
        private System.Windows.Forms.Button btnInfo_E0;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Setting;
        private System.Windows.Forms.TabPage windspeed;
        private System.Windows.Forms.TabPage windDirection;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Direction0;
        private System.Windows.Forms.TabPage Direction360;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnDirectionAdd_M;
        private System.Windows.Forms.Button btnDirectionMinusM;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnDirectionAdd_L;
        private System.Windows.Forms.Button btnDirectionMinusL;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnDirectionAdd_K;
        private System.Windows.Forms.Button btnDirectionMinusK;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnDirectionAdd_J;
        private System.Windows.Forms.Button btnDirectionMinusJ;
        private System.Windows.Forms.Button btnDirectionMinusI;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnDirectionAdd_I;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnDirectionAdd_H;
        private System.Windows.Forms.Button btnDirectionMinusH;
        private System.Windows.Forms.Button btnDirectionMinusA;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnDirectionAdd_A;
        private System.Windows.Forms.Button btnDirectionAdd_G;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnDirectionMinusG;
        private System.Windows.Forms.Button btnDirectionMinusB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnDirectionAdd_B;
        private System.Windows.Forms.Button btnDirectionAdd_F;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnDirectionMinusF;
        private System.Windows.Forms.Button btnDirectionMinusC;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnDirectionAdd_C;
        private System.Windows.Forms.Button btnDirectionAdd_E;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnDirectionMinusE;
        private System.Windows.Forms.Button btnDirectionMinusD;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnDirectionAdd_D;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnDirectionAdd_Y;
        private System.Windows.Forms.Button btnDirectionMinusY;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnDirectionAdd_X;
        private System.Windows.Forms.Button btnDirectionMinusX;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnDirectionAdd_W;
        private System.Windows.Forms.Button btnDirectionMinusW;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnDirectionAdd_V;
        private System.Windows.Forms.Button btnDirectionMinusV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDirectionAdd_U;
        private System.Windows.Forms.Button btnDirectionMinusU;
        private System.Windows.Forms.Button btnDirectionMinusN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDirectionAdd_N;
        private System.Windows.Forms.Button btnDirectionAdd_T;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDirectionMinusT;
        private System.Windows.Forms.Button btnDirectionMinusO;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnDirectionAdd_O;
        private System.Windows.Forms.Button btnDirectionAdd_S;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDirectionMinusS;
        private System.Windows.Forms.Button btnDirectionMinusP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnDirectionAdd_P;
        private System.Windows.Forms.Button btnDirectionAdd_R;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDirectionMinusR;
        private System.Windows.Forms.Button btnDirectionMinusQ;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnDirectionAdd_Q;
        private System.Windows.Forms.RadioButton rBtnNet;
        private System.Windows.Forms.RadioButton rBtnSerialPort;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClearReEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 刷新串口列表ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 升级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolOpenFile;
        private System.Windows.Forms.ToolStripMenuItem ToolupDataFW;
        private System.Windows.Forms.ToolStripMenuItem 保存接收信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入发送信息ToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
    }
}

