﻿
using Microsoft.Win32.SafeHandles;

using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;
using System.IO;
using System.Linq;

using System.Runtime.InteropServices;

using System.Text;

using System.Threading;

using System.Windows.Forms;

using ZedGraph;



namespace HID_PnP_Demo

{

    public partial class MainForm : Form

    {

        private System.ComponentModel.BackgroundWorker ReadWriteThread;

        System.Windows.Forms.Timer timer1 = null;

        private object lockobject = new object();

        public int CurrentProgressValue

        {
            get
            {
                return tsProgress.Value;
            }

            set
            {
                mainStatusStrip.Invoke(new MethodInvoker(delegate
                {

                    tsProgress.Value = value;
                    if (tsProgress.Value <= 0 || tsProgress.Value >= 100)

                    {
                        tsProgress.Visible = false;
                    }
                    else
                    {
                        tsProgress.Visible = true;
                    }
                    mainStatusStrip.Refresh();
                }));
            }
        }

        public MainForm()

        {

            InitializeComponent();

            timer1 = new System.Windows.Forms.Timer(this.components);

            timer1.Interval = 10;

            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;

            timer1.Start();



            tsProgress.Minimum = 0;

            tsProgress.Maximum = 100;

            tsProgress.Step = 1;

            ReadWriteThread = new BackgroundWorker();

            this.ReadWriteThread.WorkerReportsProgress = true;

            this.ReadWriteThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadWriteThread_DoWork);



            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

            //Additional constructor code



            //Initialize tool tips, to provide pop up help when the mouse cursor is moved over objects on the form.

            //ANxVoltageToolTip.SetToolTip(this.ANxVoltage_lbl, "If using a board/PIM without a potentiometer, apply an adjustable voltage to the I/O pin.");

            //ANxVoltageToolTip.SetToolTip(this.progressBar1, "If using a board/PIM without a potentiometer, apply an adjustable voltage to the I/O pin.");

            //PushbuttonStateTooltip.SetToolTip(this.PushbuttonState_lbl, "Try pressing pushbuttons on the USB demo board/PIM.");



            //Register for WM_DEVICECHANGE notifications.  This code uses these messages to detect plug and play connection/disconnection events for USB devices

            DEV_BROADCAST_DEVICEINTERFACE DeviceBroadcastHeader = new DEV_BROADCAST_DEVICEINTERFACE();

            DeviceBroadcastHeader.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;

            DeviceBroadcastHeader.dbcc_size = (uint)Marshal.SizeOf(DeviceBroadcastHeader);

            DeviceBroadcastHeader.dbcc_reserved = 0;	//Reserved says not to use...

            DeviceBroadcastHeader.dbcc_classguid = InterfaceClassGuid;



            //Need to get the address of the DeviceBroadcastHeader to call RegisterDeviceNotification(), but

            //can't use "&DeviceBroadcastHeader".  Instead, using a roundabout means to get the address by 

            //making a duplicate copy using Marshal.StructureToPtr().

            IntPtr pDeviceBroadcastHeader = IntPtr.Zero;  //Make a pointer.

            pDeviceBroadcastHeader = Marshal.AllocHGlobal(Marshal.SizeOf(DeviceBroadcastHeader)); //allocate memory for a new DEV_BROADCAST_DEVICEINTERFACE structure, and return the address 

            Marshal.StructureToPtr(DeviceBroadcastHeader, pDeviceBroadcastHeader, false);  //Copies the DeviceBroadcastHeader structure into the memory already allocated at DeviceBroadcastHeaderWithPointer

            RegisterDeviceNotification(this.Handle, pDeviceBroadcastHeader, DEVICE_NOTIFY_WINDOW_HANDLE);





            //Now make an initial attempt to find the USB device, if it was already connected to the PC and enumerated prior to launching the application.

            //If it is connected and present, we should open read and write handles to the device so we can communicate with it later.

            //If it was not connected, we will have to wait until the user plugs the device in, and the WM_DEVICECHANGE callback function can process

            //the message and again search for the device.

            if (CheckIfPresentAndGetUSBDevicePath())    //Check and make sure at least one device with matching VID/PID is attached

            {

                uint ErrorStatusWrite;

                uint ErrorStatusRead;





                //We now have the proper device path, and we can finally open read and write handles to the device.

                WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();

                ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                ErrorStatusRead = (uint)Marshal.GetLastWin32Error();



                if ((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))

                {

                    AttachedState = true;       //Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it

                    AttachedButBroken = false;

                    tsUSB.Text = "已连接";

                }

                else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...

                {

                    AttachedState = false;      //Let the rest of this application known not to read/write to the device.

                    AttachedButBroken = true;   //Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes

                    if (ErrorStatusWrite == ERROR_SUCCESS)

                        WriteHandleToUSBDevice.Close();

                    if (ErrorStatusRead == ERROR_SUCCESS)

                        ReadHandleToUSBDevice.Close();

                }

            }

            else    //Device must not be connected (or not programmed with correct firmware)

            {

                AttachedState = false;

                AttachedButBroken = false;

            }



            if (AttachedState == true)

            {

                tsUSB.Text = "已连接";

                ReadWriteThread.RunWorkerAsync();

            }

            else

            {

                tsUSB.Text = "未连接";

                //MessageHelper.ShowError("设备未连接！");

            }





            //ReadWriteThread.RunWorkerAsync();   //Recommend performing USB read/write operations in a separate thread.  Otherwise,

            //the Read/Write operations are effectively blocking functions and can lock up the

            //user interface if the I/O operations take a long time to complete.



            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        }



        private void Timer1_Tick(object sender, EventArgs e)

        {

            //Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            //Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            //uint BytesWritten = 0;

            //uint BytesRead = 0;



            //// System.DateTime currentTime = new System.DateTime();

            //time1 = DateTime.Now;





            //if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            //{

            //    OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

            //    OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

            //    OUTBuffer[2] = 0xff;

            //    OUTBuffer[3] = 0x00;    //LED on/off控制位        



            //    for (uint i = 4; i < 65; i++)

            //        OUTBuffer[i] = 0;



            //    //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

            //    if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

            //    {

            //        //  button2_Click(null,null);

            //    }

            //}

            //time2 = DateTime.Now;

            //time_temp = time2 - time1;

            ////label1.Text = string.Format("{0}秒{1}毫秒", time_temp.Seconds, time_temp.Milliseconds);

        }



        private void btGenerateCurve_Click(object sender, EventArgs e)
        {
            Reading = true;
            Byte[] arr2 = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1
            int sum,getbuf;
            bool result = false;


            float fa ;
            float deep;
            float qinjiao;
            int num ;
            float position ;
            float zdepth;
            CurrentProgressValue = 0;

            //totallength = -1;
            mainStatusStrip.Invoke(new MethodInvoker(delegate
            {
                tsState.Text = "Reading......";
                mainStatusStrip.Refresh();
            }));
            btGenerateCurve.Invoke(new MethodInvoker(delegate
            {
                btGenerateCurve.Enabled = false;
            }));
            dgvDataList.Rows.Clear();
            zgcChart.GraphPane.CurveList.Clear();
            zgcChart.Invoke(new MethodInvoker(delegate
            {
                zgcChart.Refresh();
            }));
            CurrentProgressValue = 10;
            //ReadDataLength();


            //while (totallength<=0)
            //{
            //    //this.Refresh();
            //    Thread.Sleep(1005);
            //}
            ReadData();

            getbuf = 0;
            ThreadPool.QueueUserWorkItem(o => {
                Thread.Sleep(1000);
                for (int i = 0; i < 5; i++)
                {
                    if (Reading)
                    {
                        Thread.Sleep(1005);
                    }
                    else
                    {
                        result = true;
                    }
                }
                /*
                if (result == true)
                {
                    getbuf = 0;
                    for (int i = 0; i < TotalCount; i++)
                    {
                        if (revval[i, 24] == 0x10)
                        {
                            getbuf++;
                        }
                    }

                    while (TotalCount > getbuf)
                    {
                        CheckData();
                        getbuf = 0;
                        for (int i = 0; i < TotalCount; i++)
                        {
                            if (revval[i, 24] == 0x10)
                            {
                                getbuf++;
                            }
                        }
                    }
                }
                */

                result = true;
                CurrentProgressValue =70;
                if (!result)
                {
                    revval[1, 1] = 1;
                    btGenerateCurve.Invoke(new MethodInvoker(delegate
                    {
                        btGenerateCurve.Enabled = true;
                    }));
                    mainStatusStrip.Invoke(new MethodInvoker(delegate
                    {
                        tsState.Text = "OK";
                        mainStatusStrip.Refresh();
                    }));
                    CurrentProgressValue = 100;
                    MessageHelper.ShowError("数据帧不正确请重读！");
                    return;
                }
                else
                {

                    /*

                    fa = 0;
                    for (i = 0; i < 120; i++)
                    {
                        fa += 2.7;
                        savedatabuf[i].deep = i + fa;
                        savedatabuf[i].qinjiao = fa;
                        savedatabuf[i].num = i;
                        savedatabuf[i].position = fa + i + fa;
                        savedatabuf[i].zdepth = fa + i + 3.23;
                        savedatabuf[i].shujustatus = 0;
                    }
                    //   savedatahead[0].length = 3;
                    savedatahead[0].num = 65;
                    */
                    TotalCount = 65;
                    fa = 2.7f;
                    for (int i = 0; i < TotalCount; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            arr2[j] = revval[i, j];
                        }


                        fa += 2.7f;
                        deep = i + fa;
                        qinjiao = fa;
                        num = i;
                        position = fa + i + fa;
                        zdepth = fa + i + 3.23f;

                        if (i == 2)
                        {
                            qinjiao = 10000;
                            position = 10000;
                            zdepth = 10000;
                        }

                        if (i == 4)
                        {
                            deep = 10000;
                        }


                        var item = new DataItem
                        {
                            GH = num,
                            Deep = deep,
                            Position = position,
                            ZDeep = zdepth,
                            QingJiao = qinjiao,
                            SJZT = BitConverter.ToUInt16(arr2, 23),
                            //TestString = System.Text.Encoding.Default.GetString(sINBuffer)
                        };

                        dgvDataList.Invoke(new MethodInvoker(delegate
                        {
                            int index = dgvDataList.Rows.Add();
                            dgvDataList.Rows[index].Cells["CNUM"].Value = item.GH;
                            dgvDataList.Rows[index].Cells["CDeep"].Value = item.Deep.ToString("0.00");
                            dgvDataList.Rows[index].Cells["CPosition"].Value = item.Position.ToString("0.00");
                            dgvDataList.Rows[index].Cells["CZDeep"].Value = item.ZDeep.ToString("0.00");
                            dgvDataList.Rows[index].Cells["CQinJiao"].Value = item.QingJiao.ToString("0.00");
                            dgvDataList.Rows[index].Cells["CSJZT"].Value = item.SJZT;
                            ReadResult.Add(item);
                        }));

                    }
                    dgvDataList.Invoke(new MethodInvoker(delegate
                    {
                        dgvDataList.Refresh();
                    }));

                    CurrentProgressValue = 80;

                    InitChart();
                }
                CurrentProgressValue = 99;
                btGenerateCurve.Invoke(new MethodInvoker(delegate
                {
                    btGenerateCurve.Enabled = true;
                }));
                mainStatusStrip.Invoke(new MethodInvoker(delegate
                {
                    tsState.Text = "OK";
                    mainStatusStrip.Refresh();
                }));
                CurrentProgressValue = 100;
            });

            
            

            //Clear Old data
            //lock (lockobject)
            //{
            //    button1_Click(sender, e);
            //    lchartPoint = 0;
            //    dgvDataList.Rows.Clear();
            //    ReadResult.Clear();


            //    Byte[] OUTBuffer = new byte[65];    //Allocate a memory buffer equal to the OUT endpoint size + 1
            //    Byte[] INBuffer = new byte[65];     //Allocate a memory buffer equal to the IN endpoint size + 1
            //    uint BytesWritten = 0;
            //    uint BytesRead = 0;

            //    if (AttachedState == true)  //Do not try to use the read/write handles unless the USB device is attached and ready
            //    {
            //        OUTBuffer[0] = 0;   //The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
            //        OUTBuffer[1] = 0x00;    //READ_POT command (see the firmware source code), gets 10-bit ADC Value
            //        OUTBuffer[2] = 0xfc;
            //        OUTBuffer[3] = 21;    //LED on/off控制位        

            //        OUTBuffer[4] = 21;    //LED on/off控制位        

            //        //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.
            //        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))    //Blocking function, unless an "overlapped" structure is used
            //        {
            //            //  button2_Click(null,null);
            //        }
            //    }
            //    else
            //    {
            //        MessageHelper.ShowError("设备未连接，请检查！");
            //    }
            //}

        }



        private void btClearParam_Click(object sender, EventArgs e)

        {

            textBox1.Text = string.Empty;

            textBox2.Text = string.Empty;

            textBox3.Text = string.Empty;

            textBox4.Text = string.Empty;

            textBox5.Text = string.Empty;

            textBox6.Text = string.Empty;
            //textBox7.Text = string.Empty;
            //textBox8.Text = string.Empty;
        }



        private void btRead_Click(object sender, EventArgs e)

        {

            //btRead.Invoke(new MethodInvoker(delegate

            //{

            //    btRead.Enabled = false;

            //}));

            //dgvDataList.Rows.Clear();

            //zgcChart.GraphPane.CurveList.Clear();

            //ReadData();



            //ThreadPool.QueueUserWorkItem(o => {

            //    Thread.Sleep(1000);

            //    while (Reading)

            //    {

            //        //this.Refresh();

            //        Thread.Sleep(1005);

            //    }

            //    btRead.Invoke(new MethodInvoker(delegate

            //    {

            //        btRead.Enabled = true;

            //    }));

            //    MessageHelper.ShowInfo("数据已加载");

            //});



        }



        bool Reading = false;

        //int totallength = -1;

        Dictionary<uint, byte[]> DicFrames = new Dictionary<uint, byte[]>();

        List<DataItem> ReadResult = new List<DataItem>();

        byte[,] revval = new byte[500,40];//发送计数
        int read_buf_num = 0;


        private void MainForm_Load(object sender, EventArgs e)

        {

            //加载的时候就把所有数据读取过来

            //ReadData();

        }

        private void ReadData()

        {

            DicFrames = new Dictionary<uint, byte[]>();

            ReadResult = new List<DataItem>();

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;



            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xfc;

                OUTBuffer[3] = 21;    //LED on/off控制位        



                OUTBuffer[4] = 21;    //LED on/off控制位        



                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    Reading = true;

                }

            }





        }



        private void ReadDataLength()

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;



            // System.DateTime currentTime = new System.DateTime();

            time1 = DateTime.Now;





            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xfc;

                OUTBuffer[3] = 20;    //LED on/off控制位        



                OUTBuffer[4] = 20;    //LED on/off控制位        



                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    //  button2_Click(null,null);

                }

            }

        }



        private void ReadOneFrame(int frameNO)

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;

            int j;



            int num = 5;

            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xfc;

                OUTBuffer[3] = 22;    //LED on/off控制位        



                OUTBuffer[4] = 22;    //LED on/off控制位        

                j = frameNO;

                OUTBuffer[num] = Convert.ToByte((j >> 8) & 0x000000ff);

                num++;

                OUTBuffer[num] = Convert.ToByte(j & 0x000000ff);

                num++;

                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    //  button2_Click(null,null);

                }

            }

        }



         private bool CheckData()
        {
            int retry = 4;

            for (int i = 0; i < TotalCount; i++)
            {
                if (revval[i, 24] != 0x10)
                {
                    //缺帧
                    Reading = true;
                    ReadOneFrame(i);
                }
            }


            while (retry-- > 0)
            {
                if (!Reading)
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            return false;
        }



        private Byte[] IntData()

        {

            List<byte> list = new List<byte>();

            if (DicFrames.Keys.Count <= 0)

            {

                return null;

            }

            else

            {

                for (UInt16 i = 0; i < DicFrames.Keys.Count; i++)

                {

                    if (DicFrames.ContainsKey(i))

                    {

                        for (int j = 0; j < DicFrames[i].Length; j++)

                        {

                            list.Add(DicFrames[i][j]);

                        }

                    }

                    else

                    {

                        throw new Exception("缺帧");

                    }

                }

            }

            return list.ToArray();

        }



        private void InitChart()

        {
            ClearHighligth();
            //加载创建曲线数据

            //标题相关设置

            // Deep Position  ZDeep QingJiao SJZT 

            if (ReadResult.Count < 0)

            {

                MessageHelper.ShowError("无数据！");

                return;

            }


            zgcChart.GraphPane.CurveList.Clear();

            zgcChart.GraphPane.Title.Text = "曲线图";

            //设置X轴说明文字

            zgcChart.GraphPane.XAxis.Title.Text = "杆号";

            //设置Y轴说明文字

            zgcChart.GraphPane.YAxis.Title.Text = "数值";

            zgcChart.IsShowPointValues = true;



            PointPairList listDeep = new PointPairList();

            PointPairList listPosition = new PointPairList();

            PointPairList listZDeep = new PointPairList();

            PointPairList listQingJiao = new PointPairList();

            PointPairList listSJZT = new PointPairList();



            foreach (var item in ReadResult.OrderBy(p => p.GH))

            {
                if(item.Deep<=1000)
                {
                    listDeep.Add(new PointPair(item.GH, item.Deep));
                }
                
                if (item.Position <= 1000)
                {
                    listPosition.Add(new PointPair(item.GH, item.Position));
                }
                
                if (item.ZDeep <= 1000)
                {
                    listZDeep.Add(new PointPair(item.GH, item.ZDeep));
                }
                
                if (item.QingJiao <= 1000)
                {
                    listQingJiao.Add(new PointPair(item.GH, item.QingJiao));
                }
                
                if (item.SJZT <= 1000)
                {
                    listSJZT.Add(new PointPair(item.GH, item.SJZT));
                }
                

            }



            ZedGraph.LineItem[] line = new LineItem[5];

            line[0] = zgcChart.GraphPane.AddCurve("深度", listDeep, Color.Red);

            line[1] = zgcChart.GraphPane.AddCurve("水平距离", listPosition, Color.Green);

            line[2] = zgcChart.GraphPane.AddCurve("垂直距离", listZDeep, Color.DarkBlue);

            line[3] = zgcChart.GraphPane.AddCurve("倾角", listQingJiao, Color.Blue);

            line[4] = zgcChart.GraphPane.AddCurve("数据状态", listSJZT, Color.DarkGray);



            line[0].Symbol.Type = SymbolType.Circle;

            line[0].Symbol.Size = 2;

            line[1].Symbol.Type = SymbolType.Circle;

            line[1].Symbol.Size = 2;

            line[2].Symbol.Type = SymbolType.Circle;

            line[2].Symbol.Size = 2;

            line[3].Symbol.Type = SymbolType.Circle;

            line[3].Symbol.Size = 2;

            line[4].Symbol.Type = SymbolType.Circle;

            line[4].Symbol.Size = 2;



            zgcChart.PointValueEvent += ZgcChart_PointValueEvent;

            zgcChart.Invoke(new MethodInvoker(delegate

            {

                zgcChart.GraphPane.AxisChange();

                zgcChart.Refresh();

            }));

        }


        private void SetHighLigt(int iindex)
        {
            zgcChart.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    zgcChart.GraphPane.GraphObjList.Clear();
                    var clor = Color.FromArgb(0x00, 0xA0, 0x00);
                    //foreach (var myCurve in zgcChart.GraphPane.CurveList)
                    //{
                    //    
                    //    EllipseObj myobje = new EllipseObj((float)myCurve.Points[iindex].X - 1, (float)myCurve.Points[iindex].Y +0.5,1, 1, clor, clor);

                    //    myobje.ZOrder = ZOrder.B_BehindLegend;

                    //    zgcChart.GraphPane.GraphObjList.Add(myobje);
                    //    zgcChart.AxisChange();
                    //}

                    LineObj myobje = new LineObj(clor, (float)zgcChart.GraphPane.CurveList[0].Points[iindex].X, zgcChart.GraphPane.YAxis.Scale.Min, (float)zgcChart.GraphPane.CurveList[0].Points[iindex].X, zgcChart.GraphPane.YAxis.Scale.Max);
                    myobje.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                    myobje.ZOrder = ZOrder.B_BehindLegend;
                    zgcChart.GraphPane.GraphObjList.Add(myobje);
                    zgcChart.AxisChange();
                    zgcChart.Refresh();
                }
                catch (Exception ex)
                {
                }
                
            }));
        }

        private void ClearHighligth()
        {
            zgcChart.Invoke(new MethodInvoker(delegate
            {
                zgcChart.GraphPane.GraphObjList.Clear();
                zgcChart.Refresh();
            }));
        }
        private string ZgcChart_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)

        {

            PointPair pari = curve[iPt];



            return string.Format(" 杆号:{1} {0}:{2}", curve.Label.Text, pari.X, pari.Y.ToString("0.00").Replace(".00", "").Replace(".0", ""));

        }









        #region USB Methods

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------



        byte RHEAD3H = 0XCa;

        byte RHEAD3L = 0XC5;

        byte SHEAD3H = 0X9a;

        byte SHEAD3L = 0X95;

        byte CMD_READ_PSWD = 1;

        byte CMD_SET_PSWD = 2;

        byte CMD_READ_CALIB = 3;

        byte CMD_SET_CALIB = 4;

        byte CMD_CLOSE_UART3 = 5;

        byte CMD_TURN_ON_TEST = 7;

        byte CMD_WRITE_MOD = 8;

        byte CMD_READ_MOD = 9;

        byte CMD_TURN_ON_CHEK = 10;

        byte CMD_TURN_OFF_CHEK = 11;

        byte PASSWD_LEN = 9;

        byte CMD_READ_PSWD2 = 20;













        //Constant definitions from setupapi.h, which we aren't allowed to include directly since this is C#

        internal const uint DIGCF_PRESENT = 0x02;

        internal const uint DIGCF_DEVICEINTERFACE = 0x10;

        //Constants for CreateFile() and other file I/O functions

        internal const short FILE_ATTRIBUTE_NORMAL = 0x80;

        internal const short INVALID_HANDLE_VALUE = -1;

        internal const uint GENERIC_READ = 0x80000000;

        internal const uint GENERIC_WRITE = 0x40000000;

        internal const uint CREATE_NEW = 1;

        internal const uint CREATE_ALWAYS = 2;

        internal const uint OPEN_EXISTING = 3;

        internal const uint FILE_SHARE_READ = 0x00000001;

        internal const uint FILE_SHARE_WRITE = 0x00000002;

        //Constant definitions for certain WM_DEVICECHANGE messages

        internal const uint WM_DEVICECHANGE = 0x0219;

        internal const uint DBT_DEVICEARRIVAL = 0x8000;

        internal const uint DBT_DEVICEREMOVEPENDING = 0x8003;

        internal const uint DBT_DEVICEREMOVECOMPLETE = 0x8004;

        internal const uint DBT_CONFIGCHANGED = 0x0018;

        //Other constant definitions

        internal const uint DBT_DEVTYP_DEVICEINTERFACE = 0x05;

        internal const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0x00;

        internal const uint ERROR_SUCCESS = 0x00;

        internal const uint ERROR_NO_MORE_ITEMS = 0x00000103;

        internal const uint SPDRP_HARDWAREID = 0x00000001;

        int[] display = new int[65];

        DateTime time1, time2;

        TimeSpan time_temp;

        //long lchartPoint, lcharPointSet;



        //Various structure definitions for structures that this code will be using

        internal struct SP_DEVICE_INTERFACE_DATA

        {

            internal uint cbSize;               //DWORD

            internal Guid InterfaceClassGuid;   //GUID

            internal uint Flags;                //DWORD

            internal uint Reserved;             //ULONG_PTR MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  

        }



        internal struct SP_DEVICE_INTERFACE_DETAIL_DATA

        {

            internal uint cbSize;               //DWORD

            internal char[] DevicePath;         //TCHAR array of any size

        }



        internal struct SP_DEVINFO_DATA

        {

            internal uint cbSize;       //DWORD

            internal Guid ClassGuid;    //GUID

            internal uint DevInst;      //DWORD

            internal uint Reserved;     //ULONG_PTR  MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  

        }



        internal struct DEV_BROADCAST_DEVICEINTERFACE

        {

            internal uint dbcc_size;            //DWORD

            internal uint dbcc_devicetype;      //DWORD

            internal uint dbcc_reserved;        //DWORD

            internal Guid dbcc_classguid;       //GUID

            internal char[] dbcc_name;          //TCHAR array

        }



        //DLL Imports.  Need these to access various C style unmanaged functions contained in their respective DLL files.

        //--------------------------------------------------------------------------------------------------------------

        //Returns a HDEVINFO type for a device information set.  We will need the 

        //HDEVINFO as in input parameter for calling many of the other SetupDixxx() functions.

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern IntPtr SetupDiGetClassDevs(

            ref Guid ClassGuid,     //LPGUID    Input: Need to supply the class GUID. 

            IntPtr Enumerator,      //PCTSTR    Input: Use NULL here, not important for our purposes

            IntPtr hwndParent,      //HWND      Input: Use NULL here, not important for our purposes

            uint Flags);            //DWORD     Input: Flags describing what kind of filtering to use.



        //Gives us "PSP_DEVICE_INTERFACE_DATA" which contains the Interface specific GUID (different

        //from class GUID).  We need the interface GUID to get the device path.

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern bool SetupDiEnumDeviceInterfaces(

            IntPtr DeviceInfoSet,           //Input: Give it the HDEVINFO we got from SetupDiGetClassDevs()

            IntPtr DeviceInfoData,          //Input (optional)

            ref Guid InterfaceClassGuid,    //Input 

            uint MemberIndex,               //Input: "Index" of the device you are interested in getting the path for.

            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);    //Output: This function fills in an "SP_DEVICE_INTERFACE_DATA" structure.



        //SetupDiDestroyDeviceInfoList() frees up memory by destroying a DeviceInfoList

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern bool SetupDiDestroyDeviceInfoList(

            IntPtr DeviceInfoSet);          //Input: Give it a handle to a device info list to deallocate from RAM.



        //SetupDiEnumDeviceInfo() fills in an "SP_DEVINFO_DATA" structure, which we need for SetupDiGetDeviceRegistryProperty()

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern bool SetupDiEnumDeviceInfo(

            IntPtr DeviceInfoSet,

            uint MemberIndex,

            ref SP_DEVINFO_DATA DeviceInterfaceData);



        //SetupDiGetDeviceRegistryProperty() gives us the hardware ID, which we use to check to see if it has matching VID/PID

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern bool SetupDiGetDeviceRegistryProperty(

            IntPtr DeviceInfoSet,

            ref SP_DEVINFO_DATA DeviceInfoData,

            uint Property,

            ref uint PropertyRegDataType,

            IntPtr PropertyBuffer,

            uint PropertyBufferSize,

            ref uint RequiredSize);



        //SetupDiGetDeviceInterfaceDetail() gives us a device path, which is needed before CreateFile() can be used.

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern bool SetupDiGetDeviceInterfaceDetail(

            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()

            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,                    //Input: Pointer to an structure which defines the device interface.  

            IntPtr DeviceInterfaceDetailData,      //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will receive the device path.

            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.

            ref uint RequiredSize,                  //Output (optional): The number of bytes needed to hold the entire struct 

            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure



        //Overload for SetupDiGetDeviceInterfaceDetail().  Need this one since we can't pass NULL pointers directly in C#.

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern bool SetupDiGetDeviceInterfaceDetail(

            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()

            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,               //Input: Pointer to an structure which defines the device interface.  

            IntPtr DeviceInterfaceDetailData,       //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will contain the device path.

            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.

            IntPtr RequiredSize,                    //Output (optional): Pointer to a DWORD to tell you the number of bytes needed to hold the entire struct 

            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure



        //Need this function for receiving all of the WM_DEVICECHANGE messages.  See MSDN documentation for

        //description of what this function does/how to use it. Note: name is remapped "RegisterDeviceNotificationUM" to

        //avoid possible build error conflicts.

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        internal static extern IntPtr RegisterDeviceNotification(

            IntPtr hRecipient,

            IntPtr NotificationFilter,

            uint Flags);



        //Takes in a device path and opens a handle to the device.

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        static extern SafeFileHandle CreateFile(

            string lpFileName,

            uint dwDesiredAccess,

            uint dwShareMode,

            IntPtr lpSecurityAttributes,

            uint dwCreationDisposition,

            uint dwFlagsAndAttributes,

            IntPtr hTemplateFile);



        //Uses a handle (created with CreateFile()), and lets us write USB data to the device.

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        static extern bool WriteFile(

            SafeFileHandle hFile,

            byte[] lpBuffer,

            uint nNumberOfBytesToWrite,

            ref uint lpNumberOfBytesWritten,

            IntPtr lpOverlapped);



        //Uses a handle (created with CreateFile()), and lets us read USB data from the device.

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        static extern bool ReadFile(

            SafeFileHandle hFile,

            IntPtr lpBuffer,

            uint nNumberOfBytesToRead,

            ref uint lpNumberOfBytesRead,

            IntPtr lpOverlapped);







        //--------------- Global Varibles Section ------------------

        //USB related variables that need to have wide scope.

        bool AttachedState = false;                     //Need to keep track of the USB device attachment status for proper plug and play operation.

        bool AttachedButBroken = false;

        SafeFileHandle WriteHandleToUSBDevice = null;

        SafeFileHandle ReadHandleToUSBDevice = null;

        String DevicePath = null;   //Need the find the proper device path before you can open file handles.





        //Variables used by the application/form updates.

        bool PushbuttonPressed = false;     //Updated by ReadWriteThread, read by FormUpdateTimer tick handler (needs to be atomic)

        bool ToggleLEDsPending = false;     //Updated by ToggleLED(s) button click event handler, used by ReadWriteThread (needs to be atomic)

        uint ADCValue = 0;			//Updated by ReadWriteThread, read by FormUpdateTimer tick handler (needs to be atomic)

        int Button_State = 0;

        //Globally Unique Identifier (GUID) for HID class devices.  Windows uses GUIDs to identify things.

        Guid InterfaceClassGuid = new Guid(0x4d1e55b2, 0xf16f, 0x11cf, 0x88, 0xcb, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30);



        TextBox[] myText = new TextBox[8];

        //--------------- End of Global Varibles ------------------



        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------





        //Need to check "Allow unsafe code" checkbox in build properties to use unsafe keyword.  Unsafe is needed to

        //properly interact with the unmanged C++ style APIs used to find and connect with the USB device.

        //public unsafe Form1()

        //{

        //    InitializeComponent();



        //    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //    //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //    //Additional constructor code



        //    //Initialize tool tips, to provide pop up help when the mouse cursor is moved over objects on the form.

        //    ANxVoltageToolTip.SetToolTip(this.ANxVoltage_lbl, "If using a board/PIM without a potentiometer, apply an adjustable voltage to the I/O pin.");

        //    ANxVoltageToolTip.SetToolTip(this.progressBar1, "If using a board/PIM without a potentiometer, apply an adjustable voltage to the I/O pin.");

        //    PushbuttonStateTooltip.SetToolTip(this.PushbuttonState_lbl, "Try pressing pushbuttons on the USB demo board/PIM.");



        //    //Register for WM_DEVICECHANGE notifications.  This code uses these messages to detect plug and play connection/disconnection events for USB devices

        //    DEV_BROADCAST_DEVICEINTERFACE DeviceBroadcastHeader = new DEV_BROADCAST_DEVICEINTERFACE();

        //    DeviceBroadcastHeader.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;

        //    DeviceBroadcastHeader.dbcc_size = (uint)Marshal.SizeOf(DeviceBroadcastHeader);

        //    DeviceBroadcastHeader.dbcc_reserved = 0;	//Reserved says not to use...

        //    DeviceBroadcastHeader.dbcc_classguid = InterfaceClassGuid;



        //    //Need to get the address of the DeviceBroadcastHeader to call RegisterDeviceNotification(), but

        //    //can't use "&DeviceBroadcastHeader".  Instead, using a roundabout means to get the address by 

        //    //making a duplicate copy using Marshal.StructureToPtr().

        //    IntPtr pDeviceBroadcastHeader = IntPtr.Zero;  //Make a pointer.

        //    pDeviceBroadcastHeader = Marshal.AllocHGlobal(Marshal.SizeOf(DeviceBroadcastHeader)); //allocate memory for a new DEV_BROADCAST_DEVICEINTERFACE structure, and return the address 

        //    Marshal.StructureToPtr(DeviceBroadcastHeader, pDeviceBroadcastHeader, false);  //Copies the DeviceBroadcastHeader structure into the memory already allocated at DeviceBroadcastHeaderWithPointer

        //    RegisterDeviceNotification(this.Handle, pDeviceBroadcastHeader, DEVICE_NOTIFY_WINDOW_HANDLE);





        //    //Now make an initial attempt to find the USB device, if it was already connected to the PC and enumerated prior to launching the application.

        //    //If it is connected and present, we should open read and write handles to the device so we can communicate with it later.

        //    //If it was not connected, we will have to wait until the user plugs the device in, and the WM_DEVICECHANGE callback function can process

        //    //the message and again search for the device.

        //    if (CheckIfPresentAndGetUSBDevicePath())    //Check and make sure at least one device with matching VID/PID is attached

        //    {

        //        uint ErrorStatusWrite;

        //        uint ErrorStatusRead;





        //        //We now have the proper device path, and we can finally open read and write handles to the device.

        //        WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

        //        ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();

        //        ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

        //        ErrorStatusRead = (uint)Marshal.GetLastWin32Error();



        //        if ((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))

        //        {

        //            AttachedState = true;       //Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it

        //            AttachedButBroken = false;

        //            StatusBox_txtbx.Text = "Device Found, AttachedState = TRUE";

        //        }

        //        else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...

        //        {

        //            AttachedState = false;      //Let the rest of this application known not to read/write to the device.

        //            AttachedButBroken = true;   //Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes

        //            if (ErrorStatusWrite == ERROR_SUCCESS)

        //                WriteHandleToUSBDevice.Close();

        //            if (ErrorStatusRead == ERROR_SUCCESS)

        //                ReadHandleToUSBDevice.Close();

        //        }

        //    }

        //    else    //Device must not be connected (or not programmed with correct firmware)

        //    {

        //        AttachedState = false;

        //        AttachedButBroken = false;

        //    }



        //    if (AttachedState == true)

        //    {

        //        StatusBox_txtbx.Text = "Device Found, AttachedState = TRUE";

        //    }

        //    else

        //    {

        //        StatusBox_txtbx.Text = "Device not found, verify connect/correct firmware";

        //    }



        //    ReadWriteThread.RunWorkerAsync();   //Recommend performing USB read/write operations in a separate thread.  Otherwise,

        //                                        //the Read/Write operations are effectively blocking functions and can lock up the

        //                                        //user interface if the I/O operations take a long time to complete.



        //    //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

        //    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //}





        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------



        //FUNCTION:	CheckIfPresentAndGetUSBDevicePath()

        //PURPOSE:	Check if a USB device is currently plugged in with a matching VID and PID

        //INPUT:	Uses globally declared String DevicePath, globally declared GUID, and the MY_DEVICE_ID constant.

        //OUTPUT:	Returns BOOL.  TRUE when device with matching VID/PID found.  FALSE if device with VID/PID could not be found.

        //			When returns TRUE, the globally accessable "DetailedInterfaceDataStructure" will contain the device path

        //			to the USB device with the matching VID/PID.



        bool CheckIfPresentAndGetUSBDevicePath()

        {

            /* 

		    Before we can "connect" our application to our USB embedded device, we must first find the device.

		    A USB bus can have many devices simultaneously connected, so somehow we have to find our device only.

		    This is done with the Vendor ID (VID) and Product ID (PID).  Each USB product line should have

		    a unique combination of VID and PID.  



		    Microsoft has created a number of functions which are useful for finding plug and play devices.  Documentation

		    for each function used can be found in the MSDN library.  We will be using the following functions (unmanaged C functions):



		    SetupDiGetClassDevs()					//provided by setupapi.dll, which comes with Windows

		    SetupDiEnumDeviceInterfaces()			//provided by setupapi.dll, which comes with Windows

		    GetLastError()							//provided by kernel32.dll, which comes with Windows

		    SetupDiDestroyDeviceInfoList()			//provided by setupapi.dll, which comes with Windows

		    SetupDiGetDeviceInterfaceDetail()		//provided by setupapi.dll, which comes with Windows

		    SetupDiGetDeviceRegistryProperty()		//provided by setupapi.dll, which comes with Windows

		    CreateFile()							//provided by kernel32.dll, which comes with Windows



            In order to call these unmanaged functions, the Marshal class is very useful.

             

		    We will also be using the following unusual data types and structures.  Documentation can also be found in

		    the MSDN library:



		    PSP_DEVICE_INTERFACE_DATA

		    PSP_DEVICE_INTERFACE_DETAIL_DATA

		    SP_DEVINFO_DATA

		    HDEVINFO

		    HANDLE

		    GUID



		    The ultimate objective of the following code is to get the device path, which will be used elsewhere for getting

		    read and write handles to the USB device.  Once the read/write handles are opened, only then can this

		    PC application begin reading/writing to the USB device using the WriteFile() and ReadFile() functions.



		    Getting the device path is a multi-step round about process, which requires calling several of the

		    SetupDixxx() functions provided by setupapi.dll.

		    */



            try

            {

                IntPtr DeviceInfoTable = IntPtr.Zero;

                SP_DEVICE_INTERFACE_DATA InterfaceDataStructure = new SP_DEVICE_INTERFACE_DATA();

                SP_DEVICE_INTERFACE_DETAIL_DATA DetailedInterfaceDataStructure = new SP_DEVICE_INTERFACE_DETAIL_DATA();

                SP_DEVINFO_DATA DevInfoData = new SP_DEVINFO_DATA();



                uint InterfaceIndex = 0;

                uint dwRegType = 0;

                uint dwRegSize = 0;

                uint dwRegSize2 = 0;

                uint StructureSize = 0;

                IntPtr PropertyValueBuffer = IntPtr.Zero;

                bool MatchFound = false;

                uint ErrorStatus;

                uint LoopCounter = 0;



                //Use the formatting: "Vid_xxxx&Pid_xxxx" where xxxx is a 16-bit hexadecimal number.

                //Make sure the value appearing in the parathesis matches the USB device descriptor

                //of the device that this aplication is intending to find.

                String DeviceIDToFind = "Vid_0483&Pid_5750";



                //First populate a list of plugged in devices (by specifying "DIGCF_PRESENT"), which are of the specified class GUID. 

                DeviceInfoTable = SetupDiGetClassDevs(ref InterfaceClassGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);



                if (DeviceInfoTable != IntPtr.Zero)

                {

                    //Now look through the list we just populated.  We are trying to see if any of them match our device. 

                    while (true)

                    {

                        InterfaceDataStructure.cbSize = (uint)Marshal.SizeOf(InterfaceDataStructure);

                        if (SetupDiEnumDeviceInterfaces(DeviceInfoTable, IntPtr.Zero, ref InterfaceClassGuid, InterfaceIndex, ref InterfaceDataStructure))

                        {

                            ErrorStatus = (uint)Marshal.GetLastWin32Error();

                            if (ErrorStatus == ERROR_NO_MORE_ITEMS) //Did we reach the end of the list of matching devices in the DeviceInfoTable?

                            {   //Cound not find the device.  Must not have been attached.

                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);  //Clean up the old structure we no longer need.

                                return false;

                            }

                        }

                        else    //Else some other kind of unknown error ocurred...

                        {

                            ErrorStatus = (uint)Marshal.GetLastWin32Error();
                            SetupDiDestroyDeviceInfoList(DeviceInfoTable);  //Clean up the old structure we no longer need.
                            return false;
                        }

                        //Now retrieve the hardware ID from the registry.  The hardware ID contains the VID and PID, which we will then 
                        //check to see if it is the correct device or not.

                        //Initialize an appropriate SP_DEVINFO_DATA structure.  We need this structure for SetupDiGetDeviceRegistryProperty().
                        DevInfoData.cbSize = (uint)Marshal.SizeOf(DevInfoData);
                        SetupDiEnumDeviceInfo(DeviceInfoTable, InterfaceIndex, ref DevInfoData);

                        //First query for the size of the hardware ID, so we can know how big a buffer to allocate for the data.
                        SetupDiGetDeviceRegistryProperty(DeviceInfoTable, ref DevInfoData, SPDRP_HARDWAREID, ref dwRegType, IntPtr.Zero, 0, ref dwRegSize);

                        //Allocate a buffer for the hardware ID.
                        //Should normally work, but could throw exception "OutOfMemoryException" if not enough resources available.
                        PropertyValueBuffer = Marshal.AllocHGlobal((int)dwRegSize);

                        //Retrieve the hardware IDs for the current device we are looking at.  PropertyValueBuffer gets filled with a 
                        //REG_MULTI_SZ (array of null terminated strings).  To find a device, we only care about the very first string in the
                        //buffer, which will be the "device ID".  The device ID is a string which contains the VID and PID, in the example 
                        //format "Vid_04d8&Pid_003f".
                        SetupDiGetDeviceRegistryProperty(DeviceInfoTable, ref DevInfoData, SPDRP_HARDWAREID, ref dwRegType, PropertyValueBuffer, dwRegSize, ref dwRegSize2);

                        //Now check if the first string in the hardware ID matches the device ID of the USB device we are trying to find.
                        String DeviceIDFromRegistry = Marshal.PtrToStringUni(PropertyValueBuffer); //Make a new string, fill it with the contents from the PropertyValueBuffer

                        Marshal.FreeHGlobal(PropertyValueBuffer);       //No longer need the PropertyValueBuffer, free the memory to prevent potential memory leaks

                        //Convert both strings to lower case.  This makes the code more robust/portable accross OS Versions
                        DeviceIDFromRegistry = DeviceIDFromRegistry.ToLowerInvariant();
                        DeviceIDToFind = DeviceIDToFind.ToLowerInvariant();
                        //Now check if the hardware ID we are looking at contains the correct VID/PID
                        MatchFound = DeviceIDFromRegistry.Contains(DeviceIDToFind);
                        if (MatchFound == true)
                        {
                            //Device must have been found.  In order to open I/O file handle(s), we will need the actual device path first.
                            //We can get the path by calling SetupDiGetDeviceInterfaceDetail(), however, we have to call this function twice:  The first
                            //time to get the size of the required structure/buffer to hold the detailed interface data, then a second time to actually 
                            //get the structure (after we have allocated enough memory for the structure.)
                            DetailedInterfaceDataStructure.cbSize = (uint)Marshal.SizeOf(DetailedInterfaceDataStructure);
                            //First call populates "StructureSize" with the correct value
                            SetupDiGetDeviceInterfaceDetail(DeviceInfoTable, ref InterfaceDataStructure, IntPtr.Zero, 0, ref StructureSize, IntPtr.Zero);
                            //Need to call SetupDiGetDeviceInterfaceDetail() again, this time specifying a pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA buffer with the correct size of RAM allocated.
                            //First need to allocate the unmanaged buffer and get a pointer to it.
                            IntPtr pUnmanagedDetailedInterfaceDataStructure = IntPtr.Zero;  //Declare a pointer.
                            pUnmanagedDetailedInterfaceDataStructure = Marshal.AllocHGlobal((int)StructureSize);    //Reserve some unmanaged memory for the structure.
                            DetailedInterfaceDataStructure.cbSize = 6; //Initialize the cbSize parameter (4 bytes for DWORD + 2 bytes for unicode null terminator)
                            Marshal.StructureToPtr(DetailedInterfaceDataStructure, pUnmanagedDetailedInterfaceDataStructure, false); //Copy managed structure contents into the unmanaged memory buffer.

                            //Now call SetupDiGetDeviceInterfaceDetail() a second time to receive the device path in the structure at pUnmanagedDetailedInterfaceDataStructure.
                            if (SetupDiGetDeviceInterfaceDetail(DeviceInfoTable, ref InterfaceDataStructure, pUnmanagedDetailedInterfaceDataStructure, StructureSize, IntPtr.Zero, IntPtr.Zero))
                            {
                                //Need to extract the path information from the unmanaged "structure".  The path starts at (pUnmanagedDetailedInterfaceDataStructure + sizeof(DWORD)).
                                IntPtr pToDevicePath = new IntPtr((uint)pUnmanagedDetailedInterfaceDataStructure.ToInt32() + 4);  //Add 4 to the pointer (to get the pointer to point to the path, instead of the DWORD cbSize parameter)
                                DevicePath = Marshal.PtrToStringUni(pToDevicePath); //Now copy the path information into the globally defined DevicePath String.

                                //We now have the proper device path, and we can finally use the path to open I/O handle(s) to the device.
                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
                                Marshal.FreeHGlobal(pUnmanagedDetailedInterfaceDataStructure);  //No longer need this unmanaged SP_DEVICE_INTERFACE_DETAIL_DATA buffer.  We already extracted the path information.
                                return true;    //Returning the device path in the global DevicePath String
                            }
                            else //Some unknown failure occurred
                            {
                                uint ErrorCode = (uint)Marshal.GetLastWin32Error();
                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure.
                                Marshal.FreeHGlobal(pUnmanagedDetailedInterfaceDataStructure);  //No longer need this unmanaged SP_DEVICE_INTERFACE_DETAIL_DATA buffer.  We already extracted the path information.
                                return false;
                            }
                        }

                        InterfaceIndex++;
                        //Keep looping until we either find a device with matching VID and PID, or until we run out of devices to check.
                        //However, just in case some unexpected error occurs, keep track of the number of loops executed.
                        //If the number of loops exceeds a very large number, exit anyway, to prevent inadvertent infinite looping.
                        LoopCounter++;
                        if (LoopCounter == 10000000)    //Surely there aren't more than 10 million devices attached to any forseeable PC...
                        {
                            return false;
                        }
                    }//end of while(true)
                }
                return false;
            }//end of try
            catch
            {
                //Something went wrong if PC gets here.  Maybe a Marshal.AllocHGlobal() failed due to insufficient resources or something.
                return false;
            }
        }
        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------





        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //This is a callback function that gets called when a Windows message is received by the form.

        //We will receive various different types of messages, but the ones we really want to use are the WM_DEVICECHANGE messages.

        protected override void WndProc(ref Message m)

        {

            if (m.Msg == WM_DEVICECHANGE)

            {

                if (((int)m.WParam == DBT_DEVICEARRIVAL) || ((int)m.WParam == DBT_DEVICEREMOVEPENDING) || ((int)m.WParam == DBT_DEVICEREMOVECOMPLETE) || ((int)m.WParam == DBT_CONFIGCHANGED))

                {

                    //WM_DEVICECHANGE messages by themselves are quite generic, and can be caused by a number of different

                    //sources, not just your USB hardware device.  Therefore, must check to find out if any changes relavant

                    //to your device (with known VID/PID) took place before doing any kind of opening or closing of handles/endpoints.

                    //(the message could have been totally unrelated to your application/USB device)



                    if (CheckIfPresentAndGetUSBDevicePath())	//Check and make sure at least one device with matching VID/PID is attached

                    {

                        //If executes to here, this means the device is currently attached and was found.

                        //This code needs to decide however what to do, based on whether or not the device was previously known to be

                        //attached or not.

                        if ((AttachedState == false) || (AttachedButBroken == true))	//Check the previous attachment state

                        {

                            uint ErrorStatusWrite;

                            uint ErrorStatusRead;



                            //We obtained the proper device path (from CheckIfPresentAndGetUSBDevicePath() function call), and it

                            //is now possible to open read and write handles to the device.

                            WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                            ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();

                            ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                            ErrorStatusRead = (uint)Marshal.GetLastWin32Error();



                            if ((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))

                            {

                                AttachedState = true;		//Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it

                                AttachedButBroken = false;

                                tsUSB.Text = "已连接";

                            }

                            else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...

                            {

                                tsUSB.Text = "未连接";

                                AttachedState = false;		//Let the rest of this application known not to read/write to the device.

                                AttachedButBroken = true;	//Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes

                                if (ErrorStatusWrite == ERROR_SUCCESS)

                                    WriteHandleToUSBDevice.Close();

                                if (ErrorStatusRead == ERROR_SUCCESS)

                                    ReadHandleToUSBDevice.Close();

                            }

                        }

                        //else we did find the device, but AttachedState was already true.  In this case, don't do anything to the read/write handles,

                        //since the WM_DEVICECHANGE message presumably wasn't caused by our USB device.  

                    }

                    else	//Device must not be connected (or not programmed with correct firmware)

                    {

                        if (AttachedState == true)		//If it is currently set to true, that means the device was just now disconnected

                        {

                            AttachedState = false;

                            WriteHandleToUSBDevice.Close();

                            ReadHandleToUSBDevice.Close();

                        }

                        AttachedState = false;

                        AttachedButBroken = false;

                    }

                }

            } //end of: if(m.Msg == WM_DEVICECHANGE)



            base.WndProc(ref m);

        } //end of: WndProc() function

        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------









        private void ToggleLEDs_btn_Click(object sender, EventArgs e)

        {



        }



        bool ReadCount = false;
        int TotalCount = 0;
        private void ReadWriteThread_DoWork(object sender, DoWorkEventArgs e)

        {

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------



            /*This thread does the actual USB read/write operations (but only when AttachedState == true) to the USB device.

            It is generally preferrable to write applications so that read and write operations are handled in a separate

            thread from the main form.  This makes it so that the main form can remain responsive, even if the I/O operations

            take a very long time to complete.



            Since this is a separate thread, this code below executes independently from the rest of the

            code in this application.  All this thread does is read and write to the USB device.  It does not update

            the form directly with the new information it obtains (such as the ANxx/POT Voltage or pushbutton state).

            The information that this thread obtains is stored in atomic global variables.

            Form updates are handled by the FormUpdateTimer Tick event handler function.



            This application sends packets to the endpoint buffer on the USB device by using the "WriteFile()" function.

            This application receives packets from the endpoint buffer on the USB device by using the "ReadFile()" function.

            Both of these functions are documented in the MSDN library.  Calling ReadFile() is a not perfectly straight

            foward in C# environment, since one of the input parameters is a pointer to a buffer that gets filled by ReadFile().

            The ReadFile() function is therefore called through a wrapper function ReadFileManagedBuffer().



            All ReadFile() and WriteFile() operations in this example project are synchronous.  They are blocking function

            calls and only return when they are complete, or if they fail because of some event, such as the user unplugging

            the device.  It is possible to call these functions with "overlapped" structures, and use them as non-blocking

            asynchronous I/O function calls.  



            Note:  This code may perform differently on some machines when the USB device is plugged into the host through a

            USB 2.0 hub, as opposed to a direct connection to a root port on the PC.  In some cases the data rate may be slower

            when the device is connected through a USB 2.0 hub.  This performance difference is believed to be caused by

            the issue described in Microsoft knowledge base article 940021:

            http://support.microsoft.com/kb/940021/en-us 



            Higher effective bandwidth (up to the maximum offered by interrupt endpoints), both when connected

            directly and through a USB 2.0 hub, can generally be achieved by queuing up multiple pending read and/or

            write requests simultaneously.  This can be done when using	asynchronous I/O operations (calling ReadFile() and

            WriteFile()	with overlapped structures).  The Microchip	HID USB Bootloader application uses asynchronous I/O

            for some USB operations and the source code can be used	as an example.*/





            Byte[] OUTBuffer = new byte[65];    //Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];     //Allocate a memory buffer equal to the IN endpoint size + 1

            Byte[] sINBuffer = new byte[65];        //Allocate a memory buffer equal to the IN endpoint size + 1

            Byte[] getbuf = new byte[300];		//Allocate a memory buffer equal to the IN endpoint size + 1

            Byte[] floatbuf = new byte[4];		//Allocate a memory buffer equal to the IN endpoint size + 1

            string str;



            uint BytesWritten = 0;

            uint BytesRead = 0;

            int i, j, sum, sumget;

            IntPtr a = new IntPtr(100);

            AutoResetEvent myevent = new AutoResetEvent(false);

            //ReadResult = new List<DataItem>();

            //this.Text = string.Empty;

            while (true)

            {

                try

                {

                    if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

                    {

                        //myevent.WaitOne(300);

                        if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))     //Blocking function, unless an "overlapped" structure is used	

                        {

                            //lchartPoint++;



                            if (INBuffer[2] == 20)     //读取帧头

                            {

                                int num = 0;

                                num = INBuffer[5] * 256 + INBuffer[4];
                                //    num = num * 24 / 55;
                                TotalCount = num;
                                str = num.ToString();

                                lock (lockobject)
                                {
                                    //            tb_num.Enabled = true;
                                    //             tb_num.Text = str;
                                    tbCount.Text = str;
                                }
                                ReadCount = false;
                                //               btGetCount.Enabled = true;

                                return;

                            }

                            else

                            {

                                Reading = true;

                                if (INBuffer[2] == 22)     //读取单帧

                                {

                                    sum = 0;

                                    for (i = 0; i < 60; i++)

                                    {

                                        sum = sum + INBuffer[i + 1];

                                    }



                                    sumget = Convert.ToInt32((INBuffer[61]) + (INBuffer[62] * 0x100) + (INBuffer[63] * 0x10000) + (INBuffer[64] * 0x1000000));

                                    if (sumget == sum)  //通讯OK

                                    {

                                        for (j = 0; j < 64; j++)

                                            sINBuffer[j] = INBuffer[j + 1];

                                        lock (lockobject)

                                        {

                                            byte length = sINBuffer[2];

                                            UInt16 index = BitConverter.ToUInt16(new byte[] { sINBuffer[3], sINBuffer[4] }, 0);



                                            if (index < 300)
                                            {
                                                for (j = 0; j < 24; j++)
                                                {
                                                    revval[index, j] = sINBuffer[5 + j];
                                                }
                                                revval[index, j] = 0x10;
                                                for (j = 0; j < 24; j++)
                                                {
                                                    revval[index + 1, j] = sINBuffer[5 + j + 24];
                                                }
                                                revval[index + 1, j] = 0x10;
                                            }










                                            if (DicFrames.ContainsKey(index))

                                            {

                                                DicFrames[index] = sINBuffer.Skip(5).Take(length - 5 - 4).ToArray();

                                            }

                                            else

                                            {

                                                DicFrames.Add(index, sINBuffer.Skip(5).Take(length - 5 - 4).ToArray());

                                            }

                                        }

                                    }

                                }

                                else
                                {


                                    sum = 0;
                                    for (i = 0; i < 60; i++)
                                    {
                                        sum = sum + INBuffer[i + 1];
                                    }

                                    sumget = Convert.ToInt32((INBuffer[61]) + (INBuffer[62] * 0x100) + (INBuffer[63] * 0x10000) + (INBuffer[64] * 0x1000000));
                                    if (sumget == sum)  //通讯OK
                                    {

                                        for (j = 0; j < 64; j++)
                                            sINBuffer[j] = INBuffer[j + 1];

                                        lock (lockobject)

                                        {

                                            byte length = sINBuffer[2];

                                            UInt16 index = BitConverter.ToUInt16(new byte[] { sINBuffer[3], sINBuffer[4] }, 0);

                                            if (index < 300)
                                            {
                                                for (j = 0; j < 24; j++)
                                                {
                                                    revval[index, j] = sINBuffer[5 + j];
                                                }
                                                revval[index, j] = 0x10;
                                                for (j = 0; j < 24; j++)
                                                {
                                                    revval[index + 1, j] = sINBuffer[5 + j + 24];
                                                }
                                                revval[index + 1, j] = 0x10;
                                            }
                                            if (DicFrames.ContainsKey(index))

                                            {

                                                DicFrames[index] = sINBuffer.Skip(5).Take(length - 5 - 4).ToArray();

                                            }

                                            else

                                            {

                                                DicFrames.Add(index, sINBuffer.Skip(5).Take(length - 5 - 4).ToArray());

                                            }



                                        }

                                    }

                                    CurrentProgressValue += 70 / TotalCount;
                                    Thread.Sleep(5);

                                    Reading = false;

                                }

                            }



                        } //end of: if(AttachedState == true)

                        else

                        {

                            Thread.Sleep(5);

                        }

                    }
                }

                catch

                {

                    //Exceptions can occur during the read or write operations.  For example,

                    //exceptions may occur if for instance the USB device is physically unplugged

                    //from the host while the above read/write functions are executing.



                    //Don't need to do anything special in this case.  The application will automatically

                    //re-establish communications based on the global AttachedState boolean variable used

                    //in conjunction with the WM_DEVICECHANGE messages to dyanmically respond to Plug and Play

                    //USB connection events.

                }



            } //end of while(true) loop

            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        }







        //private void FormUpdateTimer_Tick(object sender, EventArgs e)

        //{

        //    int i;

        //    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //    //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //    //This timer tick event handler function is used to update the user interface on the form, based on data

        //    //obtained asynchronously by the ReadWriteThread and the WM_DEVICECHANGE event handler functions.



        //    //Check if user interface on the form should be enabled or not, based on the attachment state of the USB device.

        //    if (AttachedState == true)

        //    {

        //        //Device is connected and ready to communicate, enable user interface on the form 

        //        StatusBox_txtbx.Text = "Device Found: AttachedState = TRUE";

        //        PushbuttonState_lbl.Enabled = true;	//Make the label no longer greyed out

        //        ANxVoltage_lbl.Enabled = true;

        //        // textBox2.Text = "";

        //        // for(i=0;i<65;i++)

        //        //   textBox2.Text=textBox2.Text + display[i];

        //    }

        //    if ((AttachedState == false) || (AttachedButBroken == true))

        //    {

        //        //Device not available to communicate. Disable user interface on the form.

        //        StatusBox_txtbx.Text = "Device Not Detected: Verify Connection/Correct Firmware";

        //        PushbuttonState_lbl.Enabled = false;	//Make the label no longer greyed out

        //        ANxVoltage_lbl.Enabled = false;



        //        PushbuttonState_lbl.Text = "Pushbutton State: Unknown";

        //        ADCValue = 0;

        //        progressBar1.Value = 0;

        //    }



        //    //Update the various status indicators on the form with the latest info obtained from the ReadWriteThread()

        //    if (AttachedState == true)

        //    {

        //        //Update the pushbutton state label.

        //        if (PushbuttonPressed == false)

        //            PushbuttonState_lbl.Text = "Pushbutton State: Not Pressed";		//Update the pushbutton state text label on the form, so the user can see the result 

        //        else

        //            PushbuttonState_lbl.Text = "Pushbutton State: Pressed";         //Update the pushbutton state text label on the form, so the user can see the result 



        //        //Update the ANxx/POT Voltage indicator value (progressbar)

        //        // progressBar1.Value = (int)ADCValue;

        //    }

        //    //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

        //    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //}





        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------------------

        //FUNCTION:	ReadFileManagedBuffer()

        //PURPOSE:	Wrapper function to call ReadFile()

        //

        //INPUT:	Uses managed versions of the same input parameters as ReadFile() uses.

        //

        //OUTPUT:	Returns boolean indicating if the function call was successful or not.

        //          Also returns data in the byte[] INBuffer, and the number of bytes read. 

        //

        //Notes:    Wrapper function used to call the ReadFile() function.  ReadFile() takes a pointer to an unmanaged buffer and deposits

        //          the bytes read into the buffer.  However, can't pass a pointer to a managed buffer directly to ReadFile().

        //          This ReadFileManagedBuffer() is a wrapper function to make it so application code can call ReadFile() easier

        //          by specifying a managed buffer.

        //--------------------------------------------------------------------------------------------------------------------------

        public unsafe bool ReadFileManagedBuffer(SafeFileHandle hFile, byte[] INBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped)

        {

            IntPtr pINBuffer = IntPtr.Zero;



            try

            {

                pINBuffer = Marshal.AllocHGlobal((int)nNumberOfBytesToRead);    //Allocate some unmanged RAM for the receive data buffer.



                if (ReadFile(hFile, pINBuffer, nNumberOfBytesToRead, ref lpNumberOfBytesRead, lpOverlapped))

                {

                    Marshal.Copy(pINBuffer, INBuffer, 0, (int)lpNumberOfBytesRead);    //Copy over the data from unmanged memory into the managed byte[] INBuffer

                    Marshal.FreeHGlobal(pINBuffer);

                    return true;

                }

                else

                {

                    Marshal.FreeHGlobal(pINBuffer);

                    return false;

                }



            }

            catch

            {

                if (pINBuffer != IntPtr.Zero)

                {

                    Marshal.FreeHGlobal(pINBuffer);

                }

                return false;

            }

        }



        //private void Form1_Load(object sender, EventArgs e)

        //{

        //    lcharPointSet = 100;

        //    chart1.Series["Series1"].IsVisibleInLegend = false;

        //    chart1.ChartAreas[0].AxisY.Minimum = 0;//Y显示范围

        //    chart1.ChartAreas[0].AxisY.Maximum = 4095;

        //    chart1.ChartAreas[0].AxisX.Minimum = 0;

        //    chart1.ChartAreas[0].AxisX.Maximum = lcharPointSet;



        //}



        private void button1_Click(object sender, EventArgs e)

        {



        }



        private void button3_Click(object sender, EventArgs e)

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;





            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                //Get ANxx/POT Voltage value from the microcontroller firmware.  Note: some demo boards may not have a pot

                //on them.  In this case, the firmware may be configured to read an ANxx I/O pin voltage with the ADC

                //instead.  If this is the case, apply a proper voltage to the pin.  See the firmware for exact implementation.

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xff;

                OUTBuffer[3] = 0x01;    //LED on/off控制位          



                for (uint i = 4; i < 65; i++)

                    OUTBuffer[i] = 0;



                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    // button2_Click(null, null);

                }

            }

        }



        private void ANxVoltageToolTip_Popup(object sender, PopupEventArgs e)

        {



        }



        private void button4_Click(object sender, EventArgs e)

        {



        }





        private void chart1_Click(object sender, EventArgs e)

        {



        }



        private void timer1_Tick(object sender, EventArgs e)

        {

            button1_Click(null, null);

        }



        //private void button2_Click_1(object sender, EventArgs e)

        //{

        //    int x;

        //    try

        //    {

        //        x = Convert.ToInt32(comboBox2.Text);

        //        if (x <= 1000)

        //        {

        //            timer1.Interval = 1000 / x;

        //            timer1.Enabled = true;

        //        }



        //    }

        //    catch (System.Exception ex)

        //    {



        //    }



        //}



        //private void button4_Click_1(object sender, EventArgs e)

        //{

        //    timer1.Enabled = false;

        //}



        //private void button5_Click_1(object sender, EventArgs e)

        //{

        //    chart1.Series["Series1"].Points.Clear();

        //    chart1.ChartAreas[0].AxisX.Minimum = 0;

        //    chart1.ChartAreas[0].AxisX.Maximum = lcharPointSet;

        //    lchartPoint = 0;

        //}



        //private void button6_Click_1(object sender, EventArgs e)

        //{

        //    Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

        //    Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

        //    uint BytesWritten = 0;

        //    uint BytesRead = 0;



        //    // System.DateTime currentTime = new System.DateTime();

        //    time1 = DateTime.Now;





        //    if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

        //    {

        //        OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

        //        OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

        //        OUTBuffer[2] = 0x00;

        //        OUTBuffer[3] = 0x00;



        //        for (uint i = 4; i < 65; i++)

        //            OUTBuffer[i] = 0;



        //        //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

        //        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

        //        {

        //            //  button2_Click(null,null);

        //        }

        //    }

        //    time2 = DateTime.Now;

        //    time_temp = time2 - time1;

        //    label1.Text = string.Format("{0}秒{1}毫秒", time_temp.Seconds, time_temp.Milliseconds);

        //}





        //private void button12_Click(object sender, EventArgs e)

        //{

        //    int i;

        //    i = Convert.ToInt32(tb_key_val.Text);

        //    i++;

        //    tb_key_val.Text = i.ToString();

        //}



        private void button9_Click(object sender, EventArgs e)

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;



            // System.DateTime currentTime = new System.DateTime();

            time1 = DateTime.Now;





            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xfd;

                OUTBuffer[3] = 0xfd;    //LED on/off控制位        





                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    //  button2_Click(null,null);

                }

            }

        }



        private void button13_Click(object sender, EventArgs e)

        {



        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)

        {

            button3_Click(sender, e);

            timer1.Enabled = false;

            timer1.Stop();

        }



        private void zgcChart_Load(object sender, EventArgs e)

        {



        }







        //private void button10_Click(object sender, EventArgs e)

        //{

        //    Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

        //    Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

        //    uint BytesWritten = 0;

        //    uint BytesRead = 0;

        //    int j;



        //    // System.DateTime currentTime = new System.DateTime();

        //    time1 = DateTime.Now;





        //    if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

        //    {

        //        OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

        //        OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

        //        OUTBuffer[2] = 0xfc;

        //        OUTBuffer[3] = 0xfc;    //LED on/off控制位        

        //        int num = 4;



        //        j = Convert.ToInt32(tb_key_val.Text);

        //        if (j > 33000000)

        //        {

        //            MessageBox.Show("密钥数据过大");

        //            return;

        //        }

        //        OUTBuffer[num] = Convert.ToByte((j >> 8) & 0x000000ff);

        //        num++;

        //        OUTBuffer[num] = Convert.ToByte(j & 0x000000ff);

        //        num++;

        //        OUTBuffer[num] = Convert.ToByte((j >> 8) & 0x000000ff);

        //        num++;

        //        OUTBuffer[num] = Convert.ToByte(j & 0x000000ff);

        //        num++;

        //        tb_smecid_read.Text = "";

        //        //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

        //        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

        //        {

        //            //  button2_Click(null,null);

        //        }

        //    }





        //}



        //private void button2_Click(object sender, EventArgs e)

        //{

        //    int i;

        //    i = Convert.ToInt32(tb_key_val.Text);

        //    i--;

        //    tb_key_val.Text = i.ToString();

        //}



        private void button4_Click_2(object sender, EventArgs e)

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;



            // System.DateTime currentTime = new System.DateTime();

            time1 = DateTime.Now;





            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xfc;

                OUTBuffer[3] = 20;    //LED on/off控制位        



                OUTBuffer[4] = 20;    //LED on/off控制位        



                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    //  button2_Click(null,null);

                }

            }

        }



        //bool ReadCount = false;

        //int TotalCount = 0;

        private void btGetCount_Click(object sender, EventArgs e)

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1
            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1
            uint BytesWritten = 0;
            uint BytesRead = 0;

            // System.DateTime currentTime = new System.DateTime();
            time1 = DateTime.Now;


            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready
            {
                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value
                OUTBuffer[2] = 0xfc;
                OUTBuffer[3] = 20;    //LED on/off控制位        

                OUTBuffer[4] = 20;    //LED on/off控制位        

                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.
                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                {
                    //  button2_Click(null,null);
                }
            }

            tbCount.Text = "1111";

        }



        private void dgvDataList_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex < 0)

            {

                return;

            }

            

            DataGridViewRow row = dgvDataList.Rows[e.RowIndex];
            int index = row.Cells["CNUM"].Value == null ? 0 : Convert.ToInt32(row.Cells["CNUM"].Value);
            SetHighLigt(index);

            textBox1.Text = row.Cells["CNUM"].Value == null ? string.Empty : row.Cells["CNUM"].Value.ToString();

            textBox2.Text = row.Cells["CDeep"].Value == null ? string.Empty : row.Cells["CDeep"].Value.ToString();

            textBox3.Text = row.Cells["CPosition"].Value == null ? string.Empty : row.Cells["CPosition"].Value.ToString();

            textBox4.Text = row.Cells["CZDeep"].Value == null ? string.Empty : row.Cells["CZDeep"].Value.ToString();

            textBox5.Text = row.Cells["CQinJiao"].Value == null ? string.Empty : row.Cells["CQinJiao"].Value.ToString();

            textBox6.Text = row.Cells["CSJZT"].Value == null ? string.Empty : row.Cells["CSJZT"].Value.ToString();

        }



        private void btEdit_Click(object sender, EventArgs e)

        {



            var items = ReadResult.Where(p => textBox1.Text.Equals(p.GH.ToString()));

            if (items == null || items.Count() <= 0)

            {

                MessageHelper.ShowError("找不到数据！");

            }

            else



            {

                var item = items.FirstOrDefault();

                float deep = 0;

                float position = 0;

                float zdeep = 0;

                float qinjiao = 0;

                uint sjzt = 0;

                try

                {

                    deep = Convert.ToSingle(textBox2.Text);

                }

                catch

                {

                    MessageHelper.ShowError("深度必须为整数");

                    return;

                }

                try

                {

                    position = Convert.ToSingle(textBox3.Text);

                }

                catch

                {

                    MessageHelper.ShowError("位置必须为浮点小数");

                    return;

                }



                try

                {

                    zdeep = Convert.ToSingle(textBox4.Text);

                }

                catch

                {

                    MessageHelper.ShowError("深度必须为浮点小数");

                    return;

                }

                try

                {

                    qinjiao = Convert.ToSingle(textBox5.Text);

                }

                catch

                {

                    MessageHelper.ShowError("倾角必须为浮点小数");

                    return;

                }

                try

                {

                    sjzt = Convert.ToUInt16(textBox6.Text);

                }

                catch

                {

                    MessageHelper.ShowError("数据状态必须为无符号整数");

                    return;

                }



                item.Deep = deep;

                item.Position = position;

                item.ZDeep = zdeep;

                item.QingJiao = qinjiao;

                item.SJZT = sjzt;



                foreach (DataGridViewRow row in dgvDataList.Rows)

                {

                    if (row.Cells["CNUM"].Value != null && textBox1.Text.Equals(row.Cells["CNUM"].Value.ToString()))

                    {

                        dgvDataList.Invoke(new MethodInvoker(delegate

                        {

                            row.Cells["CDeep"].Value = item.Deep.ToString("0.00");

                            row.Cells["CPosition"].Value = item.Position.ToString("0.00");

                            row.Cells["CZDeep"].Value = item.ZDeep.ToString("0.00");

                            row.Cells["CQinJiao"].Value = item.QingJiao.ToString("0.00");

                            row.Cells["CSJZT"].Value = item.SJZT;

                        }));

                    }



                }

                InitChart(); //Refresh();

            }



        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try {
                dataGridViewToCSV(this.dgvDataList);
            }
            catch(Exception ex)
            {
                MessageHelper.ShowError("導出錯誤：" + ex.Message);
            }
           
        }
        private bool dataGridViewToCSV(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.FileName = null;
            saveFileDialog.Title = "保存";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(stream, System.Text.Encoding.GetEncoding(-0));
                string strLine = "";
                try
                {
                    //表头
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        if (i > 0)
                            strLine += ",";
                        strLine += dataGridView.Columns[i].HeaderText;
                    }
                    strLine.Remove(strLine.Length - 1);
                    sw.WriteLine(strLine);
                    strLine = "";
                    //表的内容
                    for (int j = 0; j < dataGridView.Rows.Count; j++)
                    {
                        strLine = "";
                        int colCount = dataGridView.Columns.Count;
                        for (int k = 0; k < colCount; k++)
                        {
                            if (k > 0 && k < colCount)
                                strLine += ",";
                            if (dataGridView.Rows[j].Cells[k].Value == null)
                                strLine += "";
                            else
                            {
                                string cell = dataGridView.Rows[j].Cells[k].Value.ToString().Trim();
                                //防止里面含有特殊符号
                                cell = cell.Replace("\"", "\"\"");
                                cell = "\"" + cell + "\"";
                                strLine += cell;
                            }
                        }
                        sw.WriteLine(strLine);
                    }
                    sw.Close();
                    stream.Close();
                    MessageBox.Show("数据被导出到：" + saveFileDialog.FileName.ToString(), "导出完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void button7_Click(object sender, EventArgs e)

        {

            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

            Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

            uint BytesWritten = 0;

            uint BytesRead = 0;



            if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

            {

                OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

                OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

                OUTBuffer[2] = 0xfc;

                OUTBuffer[3] = 21;    //LED on/off控制位        



                OUTBuffer[4] = 21;    //LED on/off控制位        



                //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

                if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

                {

                    //  button2_Click(null,null);

                }

            }



        }



        //private void button8_Click(object sender, EventArgs e)

        //{



        //    Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1

        //    Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1

        //    uint BytesWritten = 0;

        //    uint BytesRead = 0;

        //    int j;



        //    int num = 5;

        //    if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready

        //    {

        //        OUTBuffer[0] = 0;	//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.

        //        OUTBuffer[1] = 0x00;	//READ_POT command (see the firmware source code), gets 10-bit ADC Value

        //        OUTBuffer[2] = 0xfc;

        //        OUTBuffer[3] = 22;    //LED on/off控制位        



        //        OUTBuffer[4] = 22;    //LED on/off控制位        

        //        j = Convert.ToInt32(tb_read_num.Text);

        //        OUTBuffer[num] = Convert.ToByte((j >> 8) & 0x000000ff);

        //        num++;

        //        OUTBuffer[num] = Convert.ToByte(j & 0x000000ff);

        //        num++;

        //        //To get the ADCValue, first, we send a packet with our "READ_POT" command in it.

        //        if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used

        //        {

        //            //  button2_Click(null,null);

        //        }

        //    }

        //}



        //private void comboBox1_SelectedValueChanged(object sender, EventArgs e)

        //{

        //    try

        //    {

        //        lcharPointSet = Convert.ToInt32(comboBox1.Text);

        //    }

        //    catch (System.Exception ex)

        //    {



        //    }



        //}



        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        //{

        //    timer1.Enabled = false;

        //}

        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------



        #endregion

    }

}