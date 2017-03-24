using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;

namespace 测风仪调试工具
{
    public partial class HCXSerialPortTool : Form
    {
        SerialPort mSerialPort;
        TcpClient mTcp;
        int ReceiveBytes;
        string Recordstr;
        public HCXSerialPortTool()
        {
            InitializeComponent();
            mSerialPort = serialPort1;
            GetSerialPortList();
            rBtnSerialPort.Checked = true;
            rBtnSpeed180.Checked = true;
            
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
                mSerialPort.ReadBufferSize = 1024;
                mSerialPort.WriteBufferSize = 1024;
                mSerialPort.ReadTimeout = 10;
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
                string[] arr = ex.ToString().Split((char)0x0D);
                txtMessage.AppendText("\r\n>>Error:" + arr[0]);
                return false;
            }


        }
        private Boolean Tcp_Connect(string strIP, int iPort)
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
                string[] arr = ex.ToString().Split((char)0x0D);
                txtMessage.AppendText("\r\n>>Error:" + arr[0]);
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
                string[] arr = ex.ToString().Split((char)0x0D);
                txtMessage.AppendText("\r\n>>Error:" + arr[0]);
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
                string[] arr = ex.ToString().Split((char)0x0D);
                txtMessage.AppendText("\r\n>>Error:" + arr[0]);
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int i, j;
            int n = mSerialPort.BytesToRead;
            byte[] reBytes = new byte[n];
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
        private string GetAndRemoveNMEA()
        {
            //int iStart,iEnd;
            if (Recordstr.IndexOf('$') != 0)  //如果$不在第一位，则删前$前面所有的字符
            {
                Recordstr = Recordstr.Remove(0, Recordstr.IndexOf('$'));
            }
            string[] strTmp = Recordstr.Split((char)0x0D); // 以0x0D字符对字符串进行分割，返回字符串数组

            Recordstr = Recordstr.Remove(0, Recordstr.IndexOf((char)0x0D) + 1); //删除第一个0x0D之前所有的数据
            return strTmp[0];
        }
        private void AnalysisNMEA(string Tmp)
        {
            string strTmp, Status;
            float WindDeriction, WindSpeed, Temp1, Temp2;
            int VV, HeatUP, HeatDown;

            Recordstr += Tmp;

            while (Recordstr.IndexOf('$') >= 0 && Recordstr.IndexOf((char)0x0d) >= 0)
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
                    //string[] arr3 = ex.ToString().Split((char)0x0D);
                    //Invoke(new Action(() =>
                    //{
                    //    //txtRecvMssg.Text = string.Format("[{0}]:{1}\r\n", DateTime.Now.ToLongTimeString(), strTmp);

                    //    SetStatus(Status);
                    //}));
                    //MessageBox.Show(ex.ToString());
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
                        cbxSerialPort.Enabled = false;
                        cbxBaudRate.Enabled = false;

                    }
                }
            }
            else
            {
                btnConnect.Text = "连接设备";
                rBtnNet.Enabled = true;
                cbxSerialPort.Enabled = true;
                cbxBaudRate.Enabled = true;
                cbxNetIP.Enabled = true;
                cbxNetPort.Enabled = true;
                if (mSerialPort.IsOpen)
                {
                    mSerialPort.Close();
                }
                else
                if (mTcp != null)
                    if (mTcp.Connected)
                    {
                        mTcp.Close();
                    }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label36.Text = ReceiveBytes.ToString();
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
            Send_Message("*GO\r\n");
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
            switch (cbxAverageTime.Text)
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
    }
   
    
}
