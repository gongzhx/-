using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;

namespace 测风仪调试工具
{
    public partial class HCXSerialPortTool : Form
    {
        const int ALLBytes = 16384;
        SerialPort mSerialPort;
        TcpClient mTcp;
        int ReceiveBytes;
        int SentBytes;
        string Recordstr;
        byte[] recvBytes = new byte[0x4010];
        byte[] bufferBytes = new byte[ALLBytes];
        Boolean HoldData;
        Boolean isUpdata;
        Boolean isReading;
        Boolean isCloseSerialPort;
        Boolean isCloseNet;
        Thread thrFirmwareUpdata;
        Thread thrSerialPortSend;
        Thread thrNetReceiveData;
        int iStep;
        System.Windows.Forms.Timer WindTimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer InfoTimer = new System.Windows.Forms.Timer();


        public HCXSerialPortTool()
        {
            InitializeComponent();
            mSerialPort = serialPort1;
            GetSerialPortList();
            rBtnSerialPort.Checked = true;
            rBtnSpeed180.Checked = true;
            txtMessage.MaxLength = 0;
            WindTimer.Tick += timerWind_Tick;
            InfoTimer.Tick += timerInfo_Tick;


        }
        private void GetSerialPortList()
        {
            string[] ArryPort = SerialPort.GetPortNames();
            cbxSerialPort.Items.Clear();
            for (int i = 0; i < ArryPort.Length; i++)
            {
                cbxSerialPort.Items.Add(ArryPort[i]);
            }
            if (ArryPort.Length == 0)
            {
                cbxSerialPort.Text = "";
                txtMessage.AppendText(">>串口列表中无可用串口，请刷新串口列表\r\n");
            }
            else
            { cbxSerialPort.SelectedIndex = 0; }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private Boolean serialPort1_Connect(string strPort, int iBaudRate)
        {
            try
            {
                mSerialPort.PortName = strPort;
                mSerialPort.BaudRate = iBaudRate;
                mSerialPort.ReadBufferSize = 4096;
                mSerialPort.WriteBufferSize = 1024;
                mSerialPort.Encoding = Encoding.ASCII;
                mSerialPort.ReadTimeout = -1;
                mSerialPort.WriteTimeout = -1;
                mSerialPort.Open();
                if (mSerialPort.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //string[] arr = ex.ToString().Split((char)0x0D);
                txtMessage.AppendText(">>Error:" + ex.Message +"\r\n");
                return false;
            }


        }
        private Boolean Tcp_Connect(string strIP, int iPort)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(strIP, 120);//第一个参数为ip地址，第二个参数为ping的时间 
            Thread.Sleep(400);
            if (reply.Status == IPStatus.Success)
            {
                try
                {
                    TcpClient TcpTemp = new TcpClient();
                    TcpTemp.Connect(strIP, iPort);
                    if (TcpTemp.Connected)
                    {
                        mTcp = TcpTemp;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //string[] arr = ex.ToString().Split((char)0x0D);
                    txtMessage.AppendText(">>Error:" + ex.Message + "\r\n");
                    return false;
                }
            }
            else
            {
                txtMessage.AppendText(">>Error:" + strIP + "不在线！\r\n");
                return false;
            }


        }
        private void serialPort1_SentMessage(string strMessage)
        {
            try
            {
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(strMessage);
                mSerialPort.Write(byteArray, 0, byteArray.Length);
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    //string[] arr = ex.ToString().Split((char)0x0D);
                    txtMessage.AppendText(">>Error:" + ex.Message+ "\r\n");
                }));
            }
        }
        private void serialPort1_SentMessage(byte[] send_arr,int n,int i)
        {
            try
            {
                //byte[] byteArray = System.Text.Encoding.Default.GetBytes(strMessage);
                mSerialPort.Write(send_arr, n, i);
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    //string[] arr = ex.ToString().Split((char)0x0D);
                    txtMessage.AppendText("\r\n>>Error:" + ex.Message);
                }));
                
            }
        }
        private void TCP_SentMessage(string strMessage)
        {
            try
            {
                NetworkStream ntwStream = mTcp.GetStream();
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(strMessage);
                ntwStream.Write(byteArray, 0, byteArray.Length);
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    //string[] arr = ex.ToString().Split((char)0x0D);
                    txtMessage.AppendText(">>Error:" + ex.Message + "\r\n");
                }));
            }
        }
        private void TCP_SentMessage(byte[] send_arr, int n, int i)
        {
            try
            {
                NetworkStream ntwStream = mTcp.GetStream();
                //byte[] byteArray = System.Text.Encoding.Default.GetBytes(strMessage);
                ntwStream.Write(send_arr, n, i);
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    //string[] arr = ex.ToString().Split((char)0x0D);
                    txtMessage.AppendText(">>Error:" + ex.Message + "\r\n");
                }));
            }
        }
        private void Net_DataReceived()
        {
            int i, j;
            int n;
            NetworkStream ntwStream = mTcp.GetStream();
            while (mTcp.Connected)
            {
                n = mTcp.Available;
                if (isUpdata)
                {
                    
                    ntwStream.Read(recvBytes, ReceiveBytes, n);
                    ReceiveBytes += n;
                    //此处要处理0xff
                }
                else
                {
                    byte[] reBytes = new byte[n];
                    ntwStream.Read(reBytes, 0, n);
                    ReceiveBytes += n;
                    j = 0;

                    for (i = 0; i < n; i++) //去取所有的"0"
                    {
                        if (reBytes[i] > 0)
                        {
                            reBytes[i] = reBytes[j];
                            j++;
                        }
                        else
                        {
                            reBytes[i] = reBytes[j];
                        }
                    }

                    string strTmp = System.Text.Encoding.Default.GetString(reBytes);
                    //Recordstr += strTmp;
                    Invoke(new Action(() =>
                    {
                        //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                        txtMessage.AppendText(strTmp);
                    }));
                    AnalysisNMEA(strTmp);
                }
                if (isCloseNet)
                {
                    ntwStream.Close();
                    mTcp.Close();
                }
            }

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int i, j;
            isReading = true;
            int n = mSerialPort.BytesToRead;
            if (isUpdata)
            {
                //mSerialPort.Read(recvBytes, ReceiveBytes, n);
                //ReceiveBytes = n;
                //Thread.Sleep(50);
                //while (mSerialPort.BytesToRead - n > 0)
                //{
                //    n = mSerialPort.BytesToRead;
                //    ReceiveBytes = n;
                //    Thread.Sleep(50);
                //}
                ////n = mSerialPort.BytesToRead;
                ////ReceiveBytes = n;
                //mSerialPort.Read(recvBytes, 0, 1);
                //while (mSerialPort.BytesToRead > 0 && recvBytes[0] == 0xff)
                //{
                //    mSerialPort.Read(recvBytes, 0, 1);
                //}
                //n = mSerialPort.BytesToRead;
                //ReceiveBytes = n;
                try
                {
                    mSerialPort.Read(recvBytes, ReceiveBytes, n);
                    ReceiveBytes += n;
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        //string[] arr = ex.ToString().Split((char)0x0D);
                        txtMessage.AppendText(">>Error:" + ex.Message + "\r\n");
                    }));
                }

            }
            else
            {
                byte[] reBytes = new byte[n];
                try
                {
                    mSerialPort.Read(reBytes, 0, n);
                    ReceiveBytes += n;
                    j = 0;

                    for (i = 0; i < n; i++) //去取所有的"0"
                    {
                        if (reBytes[i] > 0)
                        {
                            reBytes[i] = reBytes[j];
                            j++;
                        }
                        else
                        {
                            reBytes[i] = reBytes[j];
                        }
                    }

                    string strTmp = System.Text.Encoding.Default.GetString(reBytes);
                    //Recordstr += strTmp;
                    Invoke(new Action(() =>
                    {
                        //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                        txtMessage.AppendText(strTmp);
                    }));
                    AnalysisNMEA(strTmp);
                }
                catch(Exception ex)
                {

                }
                
            }
            isReading = false;
            if (isCloseSerialPort)
            {
                mSerialPort.Close();
            }




        }
        private string GetAndRemoveNMEA()
        {
            //int iStart,iEnd;
            if (Recordstr.IndexOf('$') != 0)  //如果$不在第一位，则删前$前面所有的字符
            {
                Recordstr = Recordstr.Remove(0, Recordstr.IndexOf('$'));
            }
            string[] strTmp = Recordstr.Split((char)0x0D); // 以0x0D字符对字符串进行分割，返回字符串数组

            Recordstr = Recordstr.Remove(0, Recordstr.IndexOf((char)0x0D) + 1); //删除第一个0x0D之前所有的数据
            if (Recordstr.IndexOf('$') == -1)
            {
                Recordstr = "";
            }
            return strTmp[0];
        }
        private void AnalysisNMEA(string Tmp)
        {
            string strTmp, Status;
            float WindDeriction, WindSpeed, Temp1, Temp2;
            int VV, HeatUP, HeatDown;
            int i;
            Recordstr += Tmp;
            i = Recordstr.IndexOf('$');
            while (i >= 0 && Recordstr.LastIndexOf((char)0x0d) > i)
            {
                strTmp = GetAndRemoveNMEA();
                string[] arr1 = strTmp.Split('*');
                //此处做校验
                string[] arr2 = arr1[0].Split(',');

                try
                {
                    switch (arr2[0])
                    {
                        case "$WIMWV":
                            if (float.TryParse(arr2[1], out WindDeriction))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                                    SetWindDeriction(WindDeriction);
                                    WindTimer.Enabled = false;
                                    WindTimer.Interval =5000;
                                    WindTimer.Enabled = true;
                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                                    SetWindDeriction(arr2[1]);
                                }));
                            }
                            if (float.TryParse(arr2[3], out WindSpeed))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                                    SetWindSpeed(WindSpeed);
                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                                    SetWindSpeed(arr2[3]);
                                }));
                            }

                            //WindSpeed = float.Parse(arr2[3]);
                            //WindDeriction = float.Parse(arr2[1]);

                            //Invoke(new Action(() =>
                            //{
                            //    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                            //    HCXWind[i].SetWindSpeed(WindSpeed);
                            //    HCXWind[i].SetWindDeriction(WindDeriction);
                            //}));
                            break;
                        case "$WMHCX":
                            if (int.TryParse(arr2[1], out VV))
                            {
                                //if (VV < MinVirtualValue)
                                //{
                                //    strTmp = string.Format("{0},WIND{1},{2}\r\n", DateTime.Now.ToLongTimeString(), (i + 1).ToString(), strTmp);
                                //    WriteToTextFile(strMyPath + ErrorFiles + DateTime.Now.ToLongDateString() + "_ERROR" + ".txt", strTmp);
                                //}
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetVirtualValue(VV);
                                    InfoTimer.Enabled = false;
                                    InfoTimer.Interval = 5000;
                                    InfoTimer.Enabled = true;
                                }));
                            }
                            else
                            {
                                //strTmp = string.Format("{0},WIND{1},{2}", DateTime.Now.ToLongTimeString(), i.ToString(), strTmp);
                                ///WriteToTextFile(strMyPath + ErrorFiles + DateTime.Now.ToLongDateString() + "_ERROR" + ".txt", strTmp);
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetVirtualValue(arr2[1]);


                                }));
                            }

                            if (int.TryParse(arr2[2], out HeatUP))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetHeatUP(HeatUP);

                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetHeatUP(arr2[2]);

                                }));
                            }
                            if (int.TryParse(arr2[3], out HeatDown))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetHeatDown(HeatDown);

                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetHeatDown(arr2[3]);

                                }));
                            }
                            if (float.TryParse(arr2[4], out Temp1))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetDiffTime_NS(Temp1);
                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetDiffTime_NS(arr2[4]);
                                }));
                            }
                            if (float.TryParse(arr2[5], out Temp1))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetDiffTime_EW(Temp1);
                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetDiffTime_EW(arr2[5]);
                                }));
                            }
                            if (float.TryParse(arr2[6], out Temp1))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetCalibrationTemp(Temp1);

                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetCalibrationTemp(arr2[7]);
                                }));
                            }
                            if (float.TryParse(arr2[7], out Temp2))
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetIventedTemp(Temp2);

                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);
                                    SetIventedTemp(arr2[7]);
                                }));
                            }

                            Status = arr2[8];
                            //if (Status != "00")
                            //{
                            //    strTmp = string.Format("{0},WIND{1},{2}\r\n", DateTime.Now.ToLongTimeString(), (i + 1).ToString(), strTmp);
                            //    WriteToTextFile(strMyPath + ErrorFiles + DateTime.Now.ToLongDateString() + "_ERROR" + ".txt", strTmp);
                            //}

                            Invoke(new Action(() =>
                            {
                                //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                                SetStatus(Status);
                            }));
                            break;
                        default:
                            break;
                    }




                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        //string[] arr = ex.ToString().Split((char)0x0D);
                        txtMessage.AppendText(">>Error:" + ex.Message + "\r\n");
                    }));
                }
            }
            if (Recordstr.IndexOf('$') < 0 && Recordstr.IndexOf((char)0x0d) < 0)
            {
                Recordstr = "";
            }
            //Thread.Sleep(10);
        }
        public void SetWindDeriction(float fTmp)
        {
            
            lblWindDirection.Text = "风向：" + fTmp.ToString() + "°";
            lblWindDirection.Visible = true;
            //timer.Stop();
            //timer.Interval = 2200;
            //timer.Start();
        }
        public void SetWindDeriction(string strtmp)
        {
            lblWindDirection.Text = "风向：" + strtmp + "°";
            lblWindDirection.Visible = true;
            //timer.Stop();
            //timer.Interval = 2200;
            //timer.Start();
        }
        public void SetWindSpeed(float fTmp)
        {
            lblWindSpeed.Text = "风速：" + fTmp.ToString() + "m/s";
            lblWindSpeed.Visible = true;
        }
        public void SetWindSpeed(string strTmp)
        {
            lblWindSpeed.Text = "风速：" + strTmp + "m/s";
            lblWindSpeed.Visible = true;
        }
        public void SetVirtualValue(int iTmp)
        {
            lblVirtualValue.Text = "有效值：" + iTmp.ToString();
            lblVirtualValue.Visible = true;
            //timer1.Stop();
            //timer1.Interval = 2200;
            //timer1.Start();
        }
        public void SetVirtualValue(string strTmp)
        {
            lblVirtualValue.Text = "有效值：" + strTmp;
            lblVirtualValue.Visible = true;
            //timer1.Stop();
            //timer1.Interval = 2200;
            //timer1.Start();
        }
        public void SetHeatUP(int iTmpUP)
        {
            lblHeatUP.Text = "加热-上：" + iTmpUP.ToString();
            lblHeatUP.Visible = true;
        }
        public void SetHeatUP(string strTmpUP)
        {
            lblHeatUP.Text = "加热-上：" + strTmpUP;
            lblHeatUP.Visible = true;
        }
        public void SetHeatDown(int iTmpDown)
        {
            lblHeatDown.Text = "加热-下："  + iTmpDown.ToString();
            lblHeatDown.Visible = true;
        }
        public void SetHeatDown(string strTmpDown)
        {
            lblHeatDown.Text = "加热-下：" + strTmpDown.ToString();
            lblHeatDown.Visible = true;
        }
        public void SetDiffTime_NS(float fTmp1)
        {
            
            lblDiffTimeNS.Text = "时差-NS：" + fTmp1;
            lblDiffTimeNS.Visible = true;
        }
        public void SetDiffTime_NS(string strTmp)
        {
            lblDiffTimeNS.Text = "时差-NS：" + strTmp;
            lblDiffTimeNS.Visible = true;
        }
        public void SetDiffTime_EW(float fTmp1)
        {

            lblDiffTimeEW.Text = "时差-EW：" + fTmp1;
            lblDiffTimeEW.Visible = true;
        }
        public void SetDiffTime_EW(string strTmp)
        {
            lblDiffTimeEW.Text = "时差-EW：" + strTmp;
            lblDiffTimeEW.Visible = true;
        }
        public void SetCalibrationTemp(float fTmp1)
        {
            lblCalibrationTemp.Text = "标校温度：" + fTmp1.ToString() ;
            lblCalibrationTemp.Visible = true;
        }
        public void SetCalibrationTemp(string strTmp1)
        {
            lblCalibrationTemp.Text = "标校温度：" + strTmp1 ;
            lblCalibrationTemp.Visible = true;
        }
        public void SetIventedTemp(float fTmp2)
        {
            lblIventedTemp.Text = "虚拟温度："  + fTmp2;
            lblIventedTemp.Visible = true;
        }
        public void SetIventedTemp(string strTmp2)
        {
            lblIventedTemp.Text = "虚拟温度：" + strTmp2;
            lblIventedTemp.Visible = true;
        }
        public void SetStatus(string strTmp)
        {
            lblStatusCode.Text = "故障代码：" + strTmp;
            lblStatusCode.Visible = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "连接设备")
            {
                if (rBtnSerialPort.Checked)
                {
                    string tmpSP, tmpBR;
                    int iBR;
                    tmpSP = cbxSerialPort.Text;
                    tmpBR = cbxBaudRate.Text;
                    int.TryParse(tmpBR, out iBR);
                    if (serialPort1_Connect(tmpSP, iBR))
                    {
                        btnConnect.Text = "已连接串口";
                        rBtnNet.Enabled = false;
                        rBtnSerialPort.Enabled = false;
                        cbxSerialPort.Enabled = false;
                        cbxBaudRate.Enabled = false;
                        cbxNetIP.Enabled = false;
                        cbxNetPort.Enabled = false;
                        isCloseSerialPort = false;

                    }
                }
                if (rBtnNet.Checked)
                {
                    try
                    {
                        //mTcp = new TcpClient();
                        //mTcp.Connect(cbxNetIP.Text, int.Parse(cbxNetPort.Text));
                        if (Tcp_Connect(cbxNetIP.Text, int.Parse(cbxNetPort.Text)))
                        {
                            btnConnect.Text = "已连接网络";
                            rBtnNet.Enabled = false;
                            rBtnSerialPort.Enabled = false;
                            cbxSerialPort.Enabled = false;
                            cbxBaudRate.Enabled = false;
                            cbxNetIP.Enabled = false;
                            cbxNetPort.Enabled = false;
                            thrNetReceiveData = new  Thread(Net_DataReceived);
                            thrNetReceiveData.Start();
                            isCloseNet = false;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>Connected:" + mTcp.Client.RemoteEndPoint.ToString() + "\r\n");
                            }));
                        }
                    }
                    catch(Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            txtMessage.AppendText(">>Error:" + ex.Message + "\r\n");
                        }));
                    }
                }
            }
            else
            {
                btnConnect.Text = "连接设备";
                rBtnNet.Enabled = true;
                rBtnSerialPort.Enabled = true;
                cbxSerialPort.Enabled = true;
                cbxBaudRate.Enabled = true;
                cbxNetIP.Enabled = true;
                cbxNetPort.Enabled = true;
 //               
                isCloseNet = true;
                //timer2.Interval=1500;
                //timer2.Start();
                //Thread.Sleep(500);
                if (mSerialPort.IsOpen && isReading == false)
                {
                    mSerialPort.Close();
                    mSerialPort.Dispose();
                }
                else
                {
                    isCloseSerialPort = true;
                }

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label36.Text = "接收字节数:" + ReceiveBytes.ToString();
        }

       
        private void timerWind_Tick(object sender, EventArgs e)
        {
            SetWindDeriction("");
            SetWindSpeed("");
            WindTimer.Enabled = false;
        }
        private void timerInfo_Tick(object sender, EventArgs e)
        {
            SetVirtualValue("");
            //SetVisibleCore(0);
            SetDiffTime_EW("");
            SetDiffTime_NS("");
            SetHeatDown("");
            SetHeatUP("");
            SetIventedTemp("");
            SetCalibrationTemp("");
            SetStatus("");
            InfoTimer.Enabled = false;
        }
        private void Send_Message(string str)
        {
            if (rBtnSerialPort.Checked)
            {
                serialPort1_SentMessage(str);
            }
            if (rBtnNet.Checked)
            {
                TCP_SentMessage(str);
            }
        }
        private void Send_Message(byte[] send_arr, int n, int i)
        {
            if (rBtnSerialPort.Checked)
            {
                serialPort1_SentMessage(send_arr,n,i);
            }
            if (rBtnNet.Checked)
            {
                TCP_SentMessage(send_arr, n, i);
            }
        }
        private void btnRestart_BB_Click(object sender, EventArgs e)
        {
            Send_Message("*BB\r\n");
        }

        private void btnTestModel_CC_Click(object sender, EventArgs e)
        {
            Send_Message("*CC\r\n");
        }

        private void btnInfo_E1_Click(object sender, EventArgs e)
        {
            Send_Message("*E1\r\n");
        }

        private void btnInfo_E0_Click(object sender, EventArgs e)
        {
            Send_Message("*E0\r\n");
        }

        private void HCXSerialPortTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mSerialPort.IsOpen)
            {
                mSerialPort.Close();
            }
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            Send_Message(txtEdit.Text);
        }

        private void btnClearReEdit_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            ReceiveBytes = 0;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("rundll32.exe", @"devmgr.dll DeviceManager_Execute");
        }

        private void btnDisplayCurrent_AA_Click(object sender, EventArgs e)
        {
            Send_Message("*AA\r\n");
        }

        private void btnDirection4Minus_1_Click(object sender, EventArgs e)
        {
            Send_Message("#1-\r\n");
        }

        private void btnDeriction4Add_1_Click(object sender, EventArgs e)
        {
            Send_Message("#1+\r\n");
        }

        private void btnSpeed4Minus_0_Click(object sender, EventArgs e)
        {
            Send_Message("#0-\r\n");
        }

        private void btnSpeed4Add_0_Click(object sender, EventArgs e)
        {
            Send_Message("#0+\r\n");
        }

        private void btnDirection20Minus_3_Click(object sender, EventArgs e)
        {
            Send_Message("#3-\r\n");
        }

        private void btnDirection20Add_3_Click(object sender, EventArgs e)
        {
            Send_Message("#3+\r\n");
        }

        private void btnSpeed20Minus_2_Click(object sender, EventArgs e)
        {
            Send_Message("#2-\r\n");
        }

        private void btnSpeed20Add_2_Click(object sender, EventArgs e)
        {
            Send_Message("#2+\r\n");
        }

        private void btnReset_GO_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("是否要初始化设备？", "初始化", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
            { Send_Message("*GO\r\n"); }
            
        }

        private void btnSetAverageTime_4_Click(object sender, EventArgs e)
        {
            switch (cbxAverageTime.Text)
            {
                case "1秒":
                    Send_Message("#41\r\n");
                    break;
                case "2秒":
                    Send_Message("#42\r\n");
                    break;
                case "3秒":
                    Send_Message("#43\r\n");
                    break;
                case "5秒":
                    Send_Message("#45\r\n");
                    break;
                case "10秒":
                    Send_Message("#4A\r\n");
                    break;

            }
        }

        private void btnSetHeatTemp_5_Click(object sender, EventArgs e)
        {
            switch (cbxHeatTemp.Text)
            {
                case "5℃":
                    Send_Message("#51\r\n");
                    break;
                case "10℃":
                    Send_Message("#52\r\n");
                    break;
                case "15℃":
                    Send_Message("#53\r\n");
                    break;
                case "20℃":
                    Send_Message("#54\r\n");
                    break;
                case "25℃":
                    Send_Message("#55\r\n");
                    break;
                case "30℃":
                    Send_Message("#56\r\n");
                    break;
                case "35℃":
                    Send_Message("#57\r\n");
                    break;
                case "40℃":
                    Send_Message("#58\r\n");
                    break;
                    

            }
        }

        private void rBtnSpeed90_CheckedChanged(object sender, EventArgs e)
        {
            FSlblChanged();
        }
        private void FSlblChanged()
        {
            if (rBtnSpeed90.Checked)
            {
                lblFS1.Text = "$21";
                lblFS2.Text = "$22";
                lblFS3.Text = "$23";
                lblFS4.Text = "$24";
                lblFS5.Text = "$25";
                lblFS6.Text = "$26";
                lblFS7.Text = "$27";
                lblFS8.Text = "$28";

            }
            else
                if (rBtnSpeed180.Checked)
            {
                lblFS1.Text = "$11";
                lblFS2.Text = "$12";
                lblFS3.Text = "$13";
                lblFS4.Text = "$14";
                lblFS5.Text = "$15";
                lblFS6.Text = "$16";
                lblFS7.Text = "$17";
                lblFS8.Text = "$18";
            }
        }

        private void rBtnSpeed180_CheckedChanged(object sender, EventArgs e)
        {
            FSlblChanged();
        }

        private void 刷新串口列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSerialPortList();
        }

        private void btnWind1Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS1.Text + "-\r\n");
        }

        private void btnWind1Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS1.Text + "+\r\n");
        }

        private void btnWind2Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS2.Text + "-\r\n");
        }

        private void btnWind3Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS3.Text + "-\r\n");
        }

        private void btnWind4Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS4.Text + "-\r\n");
        }

        private void btnWind5Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS5.Text + "-\r\n");
        }

        private void btnWind6Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS6.Text + "-\r\n");
        }

        private void btnWind7Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS7.Text + "-\r\n");
        }

        private void btnWind8Minus_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS8.Text + "-\r\n");
        }

        private void btnWind2Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS2.Text + "+\r\n");
        }

        private void btnWind3Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS3.Text + "+\r\n");
        }

        private void btnWind4Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS4.Text + "+\r\n");
        }

        private void btnWind5Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS5.Text + "+\r\n");
        }

        private void btnWind6Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS6.Text + "+\r\n");
        }

        private void btnWind7Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS7.Text + "+\r\n");
        }

        private void btnWind8Add_Click(object sender, EventArgs e)
        {
            Send_Message(lblFS8.Text + "+\r\n");
        }

        private void btnDirectionMinusA_Click(object sender, EventArgs e)
        {
            Send_Message("%A-\r\n");
        }

        private void btnDirectionMinusB_Click(object sender, EventArgs e)
        {
            Send_Message("%B-\r\n");
        }

        private void btnDirectionMinusC_Click(object sender, EventArgs e)
        {
            Send_Message("%C-\r\n");
        }

        private void btnDirectionMinusD_Click(object sender, EventArgs e)
        {
            Send_Message("%D-\r\n");
        }

        private void btnDirectionMinusE_Click(object sender, EventArgs e)
        {
            Send_Message("%E-\r\n");
        }

        private void btnDirectionMinusF_Click(object sender, EventArgs e)
        {
            Send_Message("%F-\r\n");
        }

        private void btnDirectionMinusG_Click(object sender, EventArgs e)
        {
            Send_Message("%G-\r\n");
        }

        private void btnDirectionMinusH_Click(object sender, EventArgs e)
        {
            Send_Message("%H-\r\n");
        }

        private void btnDirectionMinusI_Click(object sender, EventArgs e)
        {
            Send_Message("%I-\r\n");
        }

        private void btnDirectionMinusJ_Click(object sender, EventArgs e)
        {
            Send_Message("%J-\r\n");
        }

        private void btnDirectionMinusK_Click(object sender, EventArgs e)
        {
            Send_Message("%K-\r\n");
        }

        private void btnDirectionMinusL_Click(object sender, EventArgs e)
        {
            Send_Message("%L-\r\n");
        }

        private void btnDirectionMinusM_Click(object sender, EventArgs e)
        {
            Send_Message("%M-\r\n");
        }

        private void btnDirectionMinusN_Click(object sender, EventArgs e)
        {
            Send_Message("%N-\r\n");
        }

        private void btnDirectionMinusO_Click(object sender, EventArgs e)
        {
            Send_Message("%O-\r\n");
        }

        private void btnDirectionMinusP_Click(object sender, EventArgs e)
        {
            Send_Message("%P-\r\n");
        }

        private void btnDirectionMinusQ_Click(object sender, EventArgs e)
        {
            Send_Message("%Q-\r\n");
        }

        private void btnDirectionMinusR_Click(object sender, EventArgs e)
        {
            Send_Message("%R-\r\n");
        }

        private void btnDirectionMinusS_Click(object sender, EventArgs e)
        {
            Send_Message("%S-\r\n");
        }

        private void btnDirectionMinusT_Click(object sender, EventArgs e)
        {
            Send_Message("%T-\r\n");
        }

        private void btnDirectionMinusU_Click(object sender, EventArgs e)
        {
            Send_Message("%U-\r\n");
        }

        private void btnDirectionMinusV_Click(object sender, EventArgs e)
        {
            Send_Message("%V-\r\n");
        }

        private void btnDirectionMinusW_Click(object sender, EventArgs e)
        {
            Send_Message("%W-\r\n");
        }

        private void btnDirectionMinusX_Click(object sender, EventArgs e)
        {
            Send_Message("%X-\r\n");
        }

        private void btnDirectionMinusY_Click(object sender, EventArgs e)
        {
            Send_Message("%Y-\r\n");
        }

        private void btnDirectionAdd_Y_Click(object sender, EventArgs e)
        {
            Send_Message("%Y+\r\n"); 
        }

        private void btnDirectionAdd_X_Click(object sender, EventArgs e)
        {
            Send_Message("%X+\r\n");
        }

        private void btnDirectionAdd_W_Click(object sender, EventArgs e)
        {
            Send_Message("%W+\r\n");
        }

        private void btnDirectionAdd_V_Click(object sender, EventArgs e)
        {
            Send_Message("%V+\r\n");
        }

        private void btnDirectionAdd_U_Click(object sender, EventArgs e)
        {
            Send_Message("%U+\r\n");
        }

        private void btnDirectionAdd_T_Click(object sender, EventArgs e)
        {
            Send_Message("%T+\r\n");
        }

        private void btnDirectionAdd_S_Click(object sender, EventArgs e)
        {
            Send_Message("%S+\r\n");
        }

        private void btnDirectionAdd_R_Click(object sender, EventArgs e)
        {
            Send_Message("%R+\r\n");
        }

        private void btnDirectionAdd_Q_Click(object sender, EventArgs e)
        {
            Send_Message("%Q+\r\n");
        }

        private void btnDirectionAdd_P_Click(object sender, EventArgs e)
        {
            Send_Message("%P+\r\n");
        }

        private void btnDirectionAdd_O_Click(object sender, EventArgs e)
        {
            Send_Message("%O+\r\n");
        }

        private void btnDirectionAdd_N_Click(object sender, EventArgs e)
        {
            Send_Message("%N+\r\n");
        }

        private void btnDirectionAdd_A_Click(object sender, EventArgs e)
        {
            Send_Message("%A+\r\n");
        }

        private void btnDirectionAdd_B_Click(object sender, EventArgs e)
        {
            Send_Message("%B+\r\n");
        }

        private void btnDirectionAdd_C_Click(object sender, EventArgs e)
        {
            Send_Message("%C+\r\n");
        }

        private void btnDirectionAdd_D_Click(object sender, EventArgs e)
        {
            Send_Message("%D+\r\n");
        }

        private void btnDirectionAdd_E_Click(object sender, EventArgs e)
        {
            Send_Message("%E+\r\n");
        }

        private void btnDirectionAdd_F_Click(object sender, EventArgs e)
        {
            Send_Message("%F+\r\n");
        }

        private void btnDirectionAdd_G_Click(object sender, EventArgs e)
        {
            Send_Message("%G+\r\n");
        }

        private void btnDirectionAdd_H_Click(object sender, EventArgs e)
        {
            Send_Message("%H+\r\n");
        }

        private void btnDirectionAdd_I_Click(object sender, EventArgs e)
        {
            Send_Message("%I+\r\n");
        }

        private void btnDirectionAdd_J_Click(object sender, EventArgs e)
        {
            Send_Message("%J+\r\n");
        }

        private void btnDirectionAdd_K_Click(object sender, EventArgs e)
        {
            Send_Message("%K+\r\n");
        }

        private void btnDirectionAdd_L_Click(object sender, EventArgs e)
        {
            Send_Message("%L+\r\n");
        }

        private void btnDirectionAdd_M_Click(object sender, EventArgs e)
        {
            Send_Message("%M+\r\n");
        }

        private void ToolOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog files1 = new OpenFileDialog();
            files1.Filter = "Bin文件;Hex文件|*.bin;*.hex";
            if (files1.ShowDialog() == DialogResult.OK)
            {
                string[] arr1 = files1.FileName.Split('.');
                if (arr1[arr1.Length - 1].ToLowerInvariant() == "bin")
                {
                    FileStream fs = new FileStream(files1.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(fs);
                    byte[] BinData = reader.ReadBytes((int)fs.Length);
                    reader.Close();
                    fs.Close();
                    int i;
                    if (BinData.Length > 0 && BinData.Length < ALLBytes)
                    {
                        for (i = 0; i < BinData.Length; i++)
                        {
                            bufferBytes[i] = BinData[i];
                        }
                        for (i = BinData.Length; i < ALLBytes; i++)
                        {
                            bufferBytes[i] = 0xff;
                        }
                        //bufferBytes[ALLBytes - 3] = (byte)'H';
                        //bufferBytes[ALLBytes - 2] = (byte)'C';
                        //bufferBytes[ALLBytes - 1] = (byte)'X';
                        
                        arr1 = this.Text.Split('-');
                        this.Text = arr1[0]+ "-" + files1.FileName;
                    }
                }
                else
                if (arr1[arr1.Length - 1].ToLowerInvariant() == "hex")
                {
                    int i;
                    for (i = 0; i < ALLBytes; i++)
                    {
                        bufferBytes[i] = 0xff;
                    }
                    Hex2Bin(files1.FileName);
                    arr1 = this.Text.Split('-');
                    this.Text = arr1[0] + "-" + files1.FileName;
                }
                
                
                //StreamReader sr = File.
            }
            //dOpenBin.ShowDialog();

        }

        private void 一键升级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rBtnSerialPort.Checked)
            {
                DialogResult DR = MessageBox.Show("是否保留参数升级", "提示", MessageBoxButtons.YesNoCancel);
                if (DR == DialogResult.Yes)
                {
                    HoldData = true;
                    thrFirmwareUpdata = new Thread(Updata);
                    thrFirmwareUpdata.Start();
                }
                else
                if (DR == DialogResult.No)
                {
                    HoldData = false;
                    thrFirmwareUpdata = new Thread(Updata);
                    thrFirmwareUpdata.Start();
                }
            }
            else
            {
                MessageBox.Show("当前为网络连接，暂不支持升级！");
            }

        }
        private void Updata()
        {
            isUpdata = true;
            iStep = 0;
            int iRepeat = 0;
            
            while (true)
            {
                switch (iStep)
                {
                    case 0:
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            //mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            //Thread.Sleep(10);
                            Send_Message("*DD\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText("\r\n>>正在重启测风仪...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'G')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>收到握手信号！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>重启测风仪失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 1: //收到握手信号
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$X\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>正在等待测风仪确认握手信号...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == '!')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>握手成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>握手失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 2: //设置启动位置
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$LS\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>正在设置启动到下载区...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'S')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>指令发送成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>指令发送失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 3: //检查启动位置
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$C\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>正在检查启动设置...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'C' && recvBytes[2] == 'L')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                if (HoldData)
                                {
                                    iStep++;
                                }
                                else
                                {
                                    iStep = 5;//跳转到清空
                                }

                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>启动设置成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>启动设置失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 4: //读出数据区
                        while (iRepeat < 3)
                        {
                            ReceiveBytes = 0;
                            int itmp = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$R\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>读取原数据区域...\r\n");
                            }));
                            Thread.Sleep(300);
                            int iTimeOut = 0;
                            while ((ReceiveBytes - itmp) > 0  || iTimeOut < 3)
                            {
                                //if (ReceiveBytes < ALLBytes)
                                //{
                                    if ((ReceiveBytes - itmp) == 0)
                                    { iTimeOut++; }
                                    else
                                    {
                                        iTimeOut = 0;
                                    }
                                //}
                                itmp = ReceiveBytes;
                                Invoke(new Action(() =>
                                {
                                    txtMessage.AppendText(">>已获取" + (itmp * 100 / ALLBytes).ToString() + "%\r\n");
                                }));
                                Thread.Sleep(300);
                            }
                            //if (ReceiveBytes == ALLBytes)
                            int iDif = 0;
                            while (iDif < 0x10)
                            {
                                if (recvBytes[iDif] == 0x02)
                                {
                                    break;
                                }
                                else
                                {
                                    iDif++;
                                }
                            }
                            if (recvBytes[iDif] == 0x02)
                            //if (recvBytes[iDif] == 0x02 && recvBytes[16127+iDif] == 0xff && recvBytes[16128 + iDif] < 0xff)
                            {
                                int i;
                                for (i = 16128; i < ALLBytes; i++)
                                {
                                    bufferBytes[i] = recvBytes[i + iDif];
                                }
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>读取原数据区域成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>读取原数据区域失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 5: //清空APROM位置
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            if (HoldData)
                            {
                                FileStream file2 = File.Create(Application.StartupPath + "\\tmp.bin");
                                BinaryWriter bWriter = new BinaryWriter(file2);
                                bWriter.Write(bufferBytes);
                                bWriter.Close();
                                file2.Close();
                                Invoke(new Action(() =>
                                {
                                    txtMessage.AppendText(">>临时保存该设备Bin文件到" + Application.StartupPath + "\\tmp.bin\r\n");
                                }));
                                //MessageBox.Show("bin文件已保存到" + Application.StartupPath + "\\tmp.bin");
                            }
                            Send_Message("$Q\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>正在清空APROM数据...\r\n");
                            }));
                            Thread.Sleep(500);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'Q')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>清空数据成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>清空数据失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 6: //准备发送数据
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$W\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>准备发送数据...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == '*' && recvBytes[2] == '#')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>开始发送数据...\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>准备发送数据失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 7: //开始发送数据
                        while (iRepeat < 3)
                        {
                            ReceiveBytes = 0;
                            iRepeat++;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            //Send_Message(((byte)0x02).ToString());
                            //Send_Message(bufferBytes, 1, ALLBytes-1);
                            //SentBytes = ALLBytes;
                            //BinaryWriter bWriter = new BinaryWriter(mSerialPort.BaseStream);
                            //bufferBytes[0] = 0x02;
                            //bWriter.Write(bufferBytes, 0, 1);
                            //Thread.Sleep(1);
                            //bWriter.Write(bufferBytes,1,ALLBytes-1);

                            //SentBytes = ALLBytes;
                            thrSerialPortSend = new Thread(sentbindata);
                            thrSerialPortSend.Start();
                            Invoke(new Action(() =>
                            {
                                //Send_Message(bufferBytes, 0, bufferBytes.Length);
                                //int itmp;
                                //itmp = SentBytes;
                                Thread.Sleep(300);
                            //int iTimeOut = 0;
                            while (SentBytes < ALLBytes)
                            {
                                //if (mSerialPort.BytesToWrite < ALLBytes)
                                //{ iTimeOut++;
                                //}
                                //else
                                //{ iTimeOut = 0;
                                //}
                                
                                    //itmp = mSerialPort.BytesToWrite;
                                    txtMessage.AppendText(">>已发送" + (SentBytes * 100 / ALLBytes).ToString() + "%\r\n");
                                    
                                    Thread.Sleep(300);
                               }


                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'Z')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>数据发送完成...\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>数据发送失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 8: //再次读出数据区
                        while (iRepeat < 3)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            int itmp = 0;
                            Send_Message("$R\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>读取原数据区域...\r\n");
                            }));
                            Thread.Sleep(300);
                            int iTimeOut = 0;
                            while ((ReceiveBytes - itmp) > 0 || iTimeOut < 3)
                            {
                                //if (ReceiveBytes < ALLBytes)
                                //{
                                    if ((ReceiveBytes - itmp) == 0)
                                    { iTimeOut++; }
                                    else
                                    {
                                        iTimeOut = 0;
                                    }
                               // }
                                itmp = ReceiveBytes;
                                Invoke(new Action(() =>
                                {
                                    txtMessage.AppendText(">>已获取" + (itmp * 100 / ALLBytes).ToString() + "%\r\n");
                                }));
                                Thread.Sleep(300);
                            }
                            int iDif = 0;
                            while (iDif < 0x10)
                            {
                                if(recvBytes[iDif] == 0x02)
                                //if (recvBytes[iDif + ALLBytes -3] == (byte)'H' && recvBytes[iDif + ALLBytes - 2] == (byte)'C' && recvBytes[iDif + ALLBytes - 1] == (byte)'X')
                                {
                                    break;
                                }
                                else
                                {
                                    iDif++;
                                }
                            }
                            if (iDif < 0x10)
                            {
                                int i;
                                for (i = 0; i < ALLBytes; i++)
                                {
                                    if (bufferBytes[i] != recvBytes[i+iDif])
                                    {
                                        break;
                                    }
                                }
                                if (i == ALLBytes)
                                {
                                    if (HoldData)
                                    {
                                        File.Delete(Application.StartupPath + "\\tmp.bin");
                                            //FileStream file2 = File.Create(Application.StartupPath + "\\tmp.bin");
                                            //BinaryWriter bWriter = new BinaryWriter(file2);
                                            //bWriter.Write(bufferBytes);
                                            //bWriter.Close();
                                            //file2.Close();
                                            //MessageBox.Show("bin文件已保存到" + Application.StartupPath + "\\tmp.bin");
                                        
                                    }
                                    recvBytes[0] = 0;
                                    recvBytes[1] = 0;
                                    recvBytes[2] = 0;
                                    recvBytes[3] = 0;
                                    iRepeat = 0;
                                    iStep++;
                                    break;
                                }
                                else
                                {
                                    if (MessageBox.Show("最否清空APROM后，重新下载？","提示",MessageBoxButtons.OKCancel) == DialogResult.OK)
                                    {
                                        recvBytes[0] = 0;
                                        recvBytes[1] = 0;
                                        recvBytes[2] = 0;
                                        recvBytes[3] = 0;
                                        iRepeat = 0;
                                        iStep = 5; //返回清空APROM
                                        break;
                                    }
                                    else
                                    {        
                                        break;
                                    }
                                }

                            }

                        }
                        if (iStep == 9)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>校验通过！\r\n");
                            }));
                        }
                        else
                        if (iStep == 5)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>校验未通过！重新下载...\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>校验失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 9: //设置启动位置
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$AS\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>正在设置启动到工作区...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'S' && recvBytes[2] == 'A')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>指令发送成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>指令发送失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 10: //检查启动位置
                        while (iRepeat < 20)
                        {
                            ReceiveBytes = 0;
                            mSerialPort.DiscardInBuffer();
                            //mSerialPort.ReadExisting();
                            Thread.Sleep(10);
                            Send_Message("$C\r\n");
                            iRepeat++;
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>正在检查启动设置...\r\n");
                            }));
                            Thread.Sleep(300);
                            if (recvBytes[0] == '@' && recvBytes[1] == 'C' && recvBytes[2] == 'A')
                            {
                                recvBytes[0] = 0;
                                recvBytes[1] = 0;
                                recvBytes[2] = 0;
                                recvBytes[3] = 0;
                                iRepeat = 0;
                                iStep++;
                                break;
                            }

                        }
                        if (iRepeat == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>启动设置成功！\r\n");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                txtMessage.AppendText(">>启动设置失败，退出自动升级！\r\n");
                            }));
                            isUpdata = false;
                            return;
                        }
                        break;
                    case 11: //正在重启到工作区

                        ReceiveBytes = 0;
                        Send_Message("*BB\r\n");
                        iRepeat++;
                        Invoke(new Action(() =>
                        {
                            txtMessage.AppendText(">>正在重启设备...\r\n");
                        }));
                        isUpdata = false;
                        return;
                    //break;
                    default:
                        Invoke(new Action(() =>
                        {
                            txtMessage.AppendText(">>下载过程异常，退出自动升级！\r\n");
                        }));
                        isUpdata = false;
                        return;
                }
            }
            

        }
        private void sentbindata()
        {
            //int i;
            for (SentBytes = 0; SentBytes < ALLBytes; SentBytes += 128 )
            {
                Send_Message(bufferBytes, SentBytes, 128);
            }
            
        }

        private void 升级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mSerialPort.IsOpen == true && bufferBytes[0] == 0x02)
               //if (mSerialPort.IsOpen == true && bufferBytes[0] == 0x02 && bufferBytes[ALLBytes - 3] == (byte)'H' && bufferBytes[ALLBytes - 2] == (byte)'C' && bufferBytes[ALLBytes - 1] == (byte)'X')
            {
                ToolupDataFW.Enabled = true;
            }
            else
            {
                ToolupDataFW.Enabled = false;
            }
        }
        private void Hex2Bin( string fs )
        {
            StreamReader HexReader = new StreamReader(fs);

            string szLine = "";

            Int32 length1 = 0;

            Int32 add1, total = 0;

            Int32 length2 = 0;//比较所有行然后最大的长度

            Int32 k;

            //byte[] szBin = new byte[65536];

            while (true)

            {

                szLine = HexReader.ReadLine(); //读取一行数据

                if (szLine == null) //读完所有行

                {

                    break;

                }

                if (szLine.Substring(0, 1) == ":") //判断第1字符是否是:

                {

                    if (szLine.Substring(1, 8) == "00000001")//数据结束

                    {

                        break;

                    }

                    if (szLine.Substring(7, 2) == "00")

                    {

                        // szHex += szLine.Substring(9, szLine.Length - 11); //读取有效字符：后0和1break

                        length1 = Int32.Parse(szLine.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);//计算这一行有多少个数据

                        add1 = Int32.Parse(szLine.Substring(3, 4), System.Globalization.NumberStyles.HexNumber);//计算这一行的起始地址

                        for (k = 0; k < length1; k++) //两字符合并成一个16进制字节

                        {

                            bufferBytes[add1 + k] = (byte)Int32.Parse(szLine.Substring(2 * k + 9, 2), System.Globalization.NumberStyles.HexNumber);

                        }

                        total = length1 + add1;

                        if (total > length2)

                        {

                            length2 = total;

                        }

                    }

                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (mSerialPort.IsOpen)
            {
                mSerialPort.Close();
                mSerialPort.Dispose();
            }
            if (mTcp.Connected)
            {
                mTcp.Close();
            }
            timer2.Stop();
        }
    }
   
    
}
