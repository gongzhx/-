using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace 测风仪调试工具
{
    //public delegate Boolean ConnectCallBackDelegate();
    //public delegate Boolean WriteCallBackDelegate
    class CanHigher
    {
        /* LINE CONTROL */
        /* DATA BITS DEFINE */
        const int CS5 = 0x00;
        const int CS6 = 0x01;
        const int CS7 = 0x02;
        const int CS8 = 0x03;

        /* STOP BITS DEFINE	*/
        const int STOP1 = 0x00;
        const int STOP15 = 0x04;        //	only when byte length is 5
        const int STOP2 = 0x04;

        /* PARITY DEFINE */
        const int PAR_NONE = 0x00;
        const int PAR_ODD = 0x08;
        const int PAR_EVEN = 0x18;
        const int PAR_MARK = 0x28;
        const int PAR_SPACE = 0x38;

        /* BREAK DEFINE */
        const int SET_BREAK = 0x40;
        const int CLEAR_BREAK = 0x00;

        /*	MODEM CONTROL */
        const int C_DTR = 0x01;
        const int C_RTS = 0x02;

        /*	MODEM STATUS */
        const int M_CTS = 0x01;
        const int M_DSR = 0x02;
        const int M_RI = 0x04;
        const int M_CD = 0x08;

        /* ERROR STATUS */
        const int ERR_PARITY = 0x01;
        const int ERR_FRAME = 0x02;
        const int ERR_OVERRUN = 0x04;
        const int ERR_BRK = 0x08;

        /*	FLOW CONTROL	*/
        const int FLOW_NONE = 0x00;
        const int OUT_CTS = 0x01;
        const int OUT_DSR = 0x02;
        const int OUT_X = 0x04;
        const int OUT_XANY = 0x08;
        const int IN_RTS = 0x10;
        const int IN_DTR = 0x20;
        const int IN_X = 0x40;

        /* CTRL COMMAND */
        const int SET_SERIAL = 0x01;
        const int SET_REPORT = 0x02;
        const int REPORT_SERIAL = 0x03;
        const int CLOSE = 0x04;
        const int TIME_BREAK = 0x05;

        /* MASK DEFINE */
        const int MASK_BAUD = 0x01;
        const int MASK_MODE = 0x02;
        const int MASK_FLOW = 0x04;
        const int MASK_CTRL = 0x08;
        const int MASK_BRK = 0x10;

        /* REPORT SET */
        const int REPORT_ONCE = 0x00;
        const int REPORT_IF_CHANGED = 0x01;
        const int REPORT_TIMER = 0x02;      // timer is 1 second

        /*	KEEPALIVE */
        const int NOP = 0xf1;


        private IPEndPoint mPoint;
        private TcpClient mTcp;
        private Boolean isConnected = false;
        NetworkStream ntwStream ;


        public void SetIPEndP(IPEndPoint tmpPoint)
        {
            mPoint = tmpPoint;
        }
        public IPEndPoint GetIPEndP()
        {
            return mPoint;
        }
        private void InfoMessage(string str)
        {
            ;
        }
        public void Connect()
        {
            //if (mPoint != null)
            //{
                //mTcp.Connect(mPoint);
                mTcp.BeginConnect(mPoint.Address, mPoint.Port, new AsyncCallback(ConnectCallBack), mTcp);
                //if (mTcp.Connected)
                //{
                //    isConnected = true;
                //    return true;
                //}
                //else
                //{
                //    return false;
            //    //}
            //}
            //return false;
        }
        private void ConnectCallBack(IAsyncResult ar)
        {
            //TcpClient t = (TcpClient)ar.AsyncState;
            //t.EndConnect(ar);
            
            try
            {
                mTcp.EndConnect(ar);
                //mTcp = (TcpClient)ar.AsyncState;
                if (mTcp.Connected)
                {
                    isConnected = true;
                    InfoMessage("连接成功");
                    ntwStream = mTcp.GetStream();
                }
                else
                {
                    InfoMessage("连接失败");
                }
            }
            catch(Exception ex)
            {
                InfoMessage(ex.Message);
                InfoMessage("连接失败");
            }

        }
        public Boolean GetConnected()
        {
            if (isConnected)
            {
                try
                {
                    //NetworkStream ntwStream = mTcp.GetStream();
                    byte[] tmpBytes = new byte[2] { 0xff, 0xf1 };
                    //ntwStream.Write(tmpBytes, 0, 2);
                    //ntwStream.Close();
                    return WriteCMD(tmpBytes, 0, 2);
                }
                catch (Exception ex)
                {
                    InfoMessage(ex.Message);
                    mTcp.Close();
                    mTcp = null;
                    isConnected = false;
                    return false;
                }
            }
            else
            { return false; }
                
        }
        private void WriteCallback(IAsyncResult ar)
        {
            try
            {
                ntwStream.EndWrite(ar);
                
            }
            catch(Exception ex)
            {
                InfoMessage(ex.Message);
                mTcp.Close();
                mTcp = null;
                isConnected = false;
            }
            
            //if ((int)ar <= 0)
            //{

            //}

        }
        public void WriteData(Byte[] tmpBuf)
        {
            int tmpi = tmpBuf.Length;

            if (isConnected)
            {
                //try
                //{
                //NetworkStream ntwStream = mTcp.GetStream();
                for (int i = 0; i < tmpi; i++)
                {
                    if (tmpBuf[i] == 0xff)
                    {
                        byte[] tmpBytes = new byte[2] { 0xff, 0xff };
                        //ntwStream.Write(tmpBytes, 0, 2);
                        ntwStream.BeginWrite(tmpBytes, 0, 2, new AsyncCallback(WriteCallback), null);

                    }
                    else
                    {
                        ntwStream.BeginWrite(tmpBuf, i, 1, new AsyncCallback(WriteCallback), null);
                    }
                }
            }
            
        }
        public Boolean WriteCMD(byte[] buffer, int offset, int size)
        {
            if (isConnected)
            {
                try
                {
                    NetworkStream ntwStream = mTcp.GetStream();
                    ntwStream.Write(buffer, offset, size);
                    ntwStream.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    InfoMessage(ex.Message);
                    mTcp.Close();
                    mTcp = null;
                    isConnected = false;
                    return false;
                }
            }
            else
            { return false; }
        }
        public Boolean Set_time_break(int brktm)
        {
            byte[] buf = new byte[6];
            // = 1000; // 1 秒
            buf[0] = 0xff;
            buf[1] = TIME_BREAK;
            buf[2] = (byte)(brktm / 0xffffff);
            buf[3] = (byte)(brktm / 0xffff % 0xff);
            buf[4] = (byte)(brktm / 0xff % 0xff);
            buf[5] = (byte)(brktm  % 0xff);
            
            return WriteCMD(buf, 0, 6);
                    
            
        }
        public Boolean Set_param(byte mask,byte mode,byte flow, byte ctrl,int baud)
        {
            byte[] buf = new byte[32];

            //mode = CS8 | STOP1 | PAR_NONE;      // 8 bits data, 1 bit stop, no parity
            //flow = FLOW_NONE;                   // no flowctrl
            //ctrl = C_DTR | C_RTS;               // DTR on, RTS on
            //baud = 9600;                        // baud is 9600bps

            //mask = MASK_MODE | MASK_FLOW | MASK_CTRL | MASK_BAUD;

            buf[0] = 0xff;
            buf[1] = SET_SERIAL;
            buf[2] = mask;
            buf[3] = mode;
            buf[4] = flow;
            buf[5] = ctrl;
            buf[6] = (byte)(baud >> 24);
            buf[7] = (byte)(baud >> 16);
            buf[8] = (byte)(baud >> 8);
            buf[9] = (byte)baud;

            return WriteCMD(buf, 0, 10);
        }
        public Boolean Set_Report(Byte type)
        {
            ;
            byte[] buf = new byte[3];
            //type = REPORT_IF_CHANGED;
            buf[0] = 0xff;
            buf[1] = SET_REPORT;
            buf[2] = type;
            return WriteCMD(buf, 0, 3);
        }
    }
}
