/********************************************************************
    	Title:			NetTool
    	Copyright:		(C) 2009 VICO Software, Ltd
    	Author:			FB
    	Create Date:	2009-11-9
    	Description:    
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;


namespace RegisterLib
{
    public class NetInfo 
    {

        public string m_strIPAddress;
        public string m_strCaption;
        public string m_strMacAddress;
        public NetInfo()
        {
            Reset();
        }
        public void Reset()
        {
            m_strIPAddress = string.Empty;
            m_strCaption = string.Empty;
            m_strMacAddress = string.Empty;
         }
    }
    public class NetTool
    {
        private const string MSG_NETINTO_NOTEXIST = "网络适配器信息不存在。";

        public static string LastError
        {
            get{return m_strLastError;}
        }

        private static string m_strLastError;

        public static List<NetInfo> GetNetInfo()
        {
            try
            {
                m_strLastError = string.Empty;
                List<NetInfo> lstInfo = new List<NetInfo>();
                ManagementObjectSearcher oSearcher =new ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration");
                ManagementObjectCollection lstObj = oSearcher.Get();
                foreach (ManagementObject oObj in lstObj)
                {
                    if ((bool)oObj.Properties["IPEnabled"].Value)
                    {
                        NetInfo oInfo = new NetInfo();
                        oInfo.m_strCaption = (string)oObj["caption"]; 
                        oInfo.m_strIPAddress = ((string[])oObj["IPAddress"])[0];
                        oInfo.m_strMacAddress = (string)oObj["MACAddress"];
                        lstInfo.Add(oInfo);
                    } 
                }

                if (0 == lstInfo.Count)
                {
                    m_strLastError=MSG_NETINTO_NOTEXIST;
                    return null;
                }
                return lstInfo;
            }
            catch (Exception ex)
            {
                m_strLastError = ex.ToString();
                return null;
            }
        }
    }
}
