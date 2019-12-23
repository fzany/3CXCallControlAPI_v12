using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TCX.Configuration;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;

namespace ActiveCalls_QueueCalls
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        static extern int GetKeyValueA(string strSection, string strKeyName, string strNull, StringBuilder RetVal, int nSize, string strFileName);

        public delegate void UpdateConnectDlg(int newConn);

        Dictionary<int, ActiveConnection> _activeConnDict;
        Dictionary<int, ActiveConnection> _queueConnDict;
        bool _stopUpdates;

        public Form1()
        {
            InitializeComponent();
            _activeConnDict = new Dictionary<int, ActiveConnection>();
            _queueConnDict = new Dictionary<int, ActiveConnection>();
            _stopUpdates = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                #region phone system initialization(init db server)
                PhoneSystem.ApplicationName = "CallViewer";//any name
                RegistryKey regKeyAppRoot;
                if (IntPtr.Size == 4)
                {
                    regKeyAppRoot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\3CX\\PhoneSystem");
                }
                else
                {
                    regKeyAppRoot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\3CX\\PhoneSystem");
                }
                String _appPath = (string)regKeyAppRoot.GetValue("AppPath");
                String filePath = Path.Combine(_appPath, @"Bin\3CXPhoneSystem.ini");
                String value = GetKeyValue("ConfService", "ConfPort", filePath);
                Int32 port = 0;
                if (!String.IsNullOrEmpty(value))
                {
                    Int32.TryParse(value.Trim(), out port);
                    PhoneSystem.CfgServerPort = port;
                }
                value = GetKeyValue("ConfService", "confUser", filePath);
                if (!String.IsNullOrEmpty(value))
                    PhoneSystem.CfgServerUser = value;
                value = GetKeyValue("ConfService", "confPass", filePath);
                if (!String.IsNullOrEmpty(value))
                    PhoneSystem.CfgServerPassword = value;
                #endregion
                Tenant[] tenantArr = PhoneSystem.Root.GetTenants();
                if (tenantArr.Length == 0)
                {
                    MessageBox.Show("Corrupted database");
                    return;
                }

                PhoneSystem.Root.Inserted += new NotificationEventHandler(Root_Updated);
                PhoneSystem.Root.Updated += new NotificationEventHandler(Root_Updated);
                PhoneSystem.Root.Deleted += new NotificationEventHandler(Root_Deleted);
                //dn can be extension, Queue, RingGroup, External Line, etc
                //currently we use only the first tenant
                DN[] dnArr = tenantArr[0].GetDN();
                #region active calls
                //_activeConn represents the conn in both ways 
                //ex: if extension 100 calls 101 we will have 2 connections
                //one from 100 to 101 and the other from 101 to 100
                //the dict will contain all the connection in one way
                ActiveConnection[] connArr;
                foreach (DN dn in dnArr)
                {
                    connArr = dn.GetActiveConnections();
                    foreach (ActiveConnection con in connArr)
                    {
                        if (con.Status != ConnectionStatus.Connected)
                            continue;//count only the connected connections
                        if (!_activeConnDict.ContainsKey(con.CallID))
                        {
                            _activeConnDict[con.CallID] = con;
                        }
                    }
                }
                actveCallsLabel.Text = _activeConnDict.Count.ToString();
                #endregion

                #region calls on queues
                Queue[] queueArr = tenantArr[0].GetQueues();
                foreach (Queue queue in queueArr)
                {
                    connArr = queue.GetActiveConnections();
                    foreach (ActiveConnection con in connArr)
                    {
                        if (con.Status != ConnectionStatus.Connected)
                            continue;//count only the connected connections
                        if (!_queueConnDict.ContainsKey(con.CallID))
                        {
                            _queueConnDict[con.CallID] = con;
                        }
                    }
                }
                queueCallsLabel.Text = _queueConnDict.Count.ToString();
                #endregion
                _stopUpdates = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// called every time an object is deleted(a connection is dropped)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Root_Deleted(object sender, NotificationEventArgs e)
        {
            if (_stopUpdates)
                return;
            if (e.ConfObject is ActiveConnection)
            {//filter active Connections
                ActiveConnection con = e.ConfObject as ActiveConnection;
                if (con.Status != ConnectionStatus.Connected)
                    return;//count only the connected connections
                //increment the active connection by one
                if (con.DN is Queue)
                {
                    if (_queueConnDict.ContainsKey(con.CallID))
                    {
                        _queueConnDict.Remove(con.CallID);
                        this.BeginInvoke(new UpdateConnectDlg(UpdateCallsInQueue), new object[] { _queueConnDict.Count });
                    }
                }
                else if (_activeConnDict.ContainsKey(con.CallID))
                {
                    _activeConnDict.Remove(con.CallID);
                    this.BeginInvoke(new UpdateConnectDlg(UpdateActiveConns), new object[] { _activeConnDict.Count });
                }
            }
        }

        /// <summary>
        /// called every time new data is inserted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Root_Updated(object sender, NotificationEventArgs e)
        {
            if (_stopUpdates)
                return;
            if (e.ConfObject is ActiveConnection)
            {//filter active Connections
                ActiveConnection con = e.ConfObject as ActiveConnection;
                if (con.Status != ConnectionStatus.Connected)
                    return;//count only the connected connections
                if (con.DN is Queue)
                {
                    if (!_queueConnDict.ContainsKey(con.CallID))
                    {
                        _queueConnDict[con.CallID] = con;
                        this.BeginInvoke(new UpdateConnectDlg(UpdateCallsInQueue), new object[] { _queueConnDict.Count });
                    }
                }
                else if (!_activeConnDict.ContainsKey(con.CallID))
                {
                    _activeConnDict[con.CallID] = con;
                    this.BeginInvoke(new UpdateConnectDlg(UpdateActiveConns), new object[] { _activeConnDict.Count });
                }
            }
        }

        void UpdateActiveConns(int newVal)
        {
            actveCallsLabel.Text = newVal.ToString();
        }

        void UpdateCallsInQueue(int newVal)
        {
            queueCallsLabel.Text = newVal.ToString();
        }

        static public string GetKeyValue(string Section, string KeyName, string FileName)
        {
            //Reading The KeyValue Method
            try
            {
                StringBuilder JStr = new StringBuilder(255);
                int i = GetKeyValueA(Section, KeyName, String.Empty, JStr, 255, FileName);
                return JStr.ToString();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}