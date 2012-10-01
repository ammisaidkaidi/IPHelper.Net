﻿using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace IPHelper
{
    public static class Win32Funcs
    {
        #region Public Fields

        public const string DllName = "iphlpapi.dll";
        public const int AfInet = 2;

        #endregion

        #region Public Methods

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa365801%28v=vs.85%29.aspx"/>
        /// </summary>
        [DllImport(DllName, SetLastError = true)]
        public static extern uint AddIPAddress(uint address, uint ipMask, int ifIndex, out IntPtr nteContext, out IntPtr nteInstance);


        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa365928.aspx"/>
        /// </summary>
        [DllImport(DllName, SetLastError = true)]
        public static extern uint GetExtendedTcpTable(IntPtr tcpTable, ref int tcpTableLength, bool sort, int ipVersion,
                                                      TcpTableType tcpTableType, int reserved);


        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa365930%28v=vs.85%29"/>
        /// </summary>
        [DllImport(DllName, SetLastError = true)]
        public static extern uint GetExtendedUdpTable(IntPtr udpTable, ref int udpTableLength, bool sort, int ipVersion,
                                                      UdpTableType udpTableType, int reserved);

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa365956%28v=vs.85%29.aspx"/>
        /// </summary>
        [DllImport(DllName, SetLastError = true)]
        public static extern uint GetIpNetTable(IntPtr ipNetTable, ref int ipNetTableLength, bool sort);
       

        #endregion

        #region Public Enums

        #region ArpEntryType enum

        public enum ArpEntryType
        {
            UNKNOWN,
            Other,
            Invalid,
            Dynamic,
            Static
        }

        #endregion

        #region TcpTableType enum

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa366386.aspx"/>
        /// </summary>
        public enum TcpTableType
        {
            BasicListener,
            BasicConnections,
            BasicAll,
            OwnerPidListener,
            OwnerPidConnections,
            OwnerPidAll,
            OwnerModuleListener,
            OwnerModuleConnections,
            OwnerModuleAll,
        }

        #endregion

        #region UdpTableType enum

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa366388%28v=vs.85%29"/>
        /// </summary>
        public enum UdpTableType
        {
            Basic,
            OwnerPid,
            OwnerModule
        }

        #endregion

        #endregion

        #region Public Structs

        #region Nested type: IpNetRow

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa366869%28v=vs.85%29.aspx"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct IpNetRow
        {
            public int adaptorIndex;
            public int adaptorPhysicalMacAddressLen;
            public byte adaptorPhysicalMacAddress0;
            public byte adaptorPhysicalMacAddress1;
            public byte adaptorPhysicalMacAddress2;
            public byte adaptorPhysicalMacAddress3;
            public byte adaptorPhysicalMacAddress4;
            public byte adaptorPhysicalMacAddress5;
            public byte adaptorPhysicalMacAddress6;
            public byte adaptorPhysicalMacAddress7;
            public int adaptorAddr;

            public int typeOfARPEntry;
                       // 1 : other. 2:An invalid ARP type. This can indicate an unreachable or incomplete ARP entry. 3:A dynamic ARP type. 4:A static ARP type.
        }

        #endregion

        #region Nested type: IpNetTable

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa366870%28v=vs.85%29.aspx"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct IpNetTable
        {
            public uint Length;
            public IpNetRow row;
        }

        #endregion

        #region Nested type: TcpRow

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa366913.aspx"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TcpRow
        {
            public TcpState state;
            public uint localAddr;
            public byte localPort1;
            public byte localPort2;
            public byte localPort3;
            public byte localPort4;
            public uint remoteAddr;
            public byte remotePort1;
            public byte remotePort2;
            public byte remotePort3;
            public byte remotePort4;
            public int owningPid;
        }

        #endregion

        #region Nested type: TcpTable

        /// <summary>
        /// <see cref="http://msdn2.microsoft.com/en-us/library/aa366921.aspx"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TcpTable
        {
            public uint Length;
            public TcpRow row;
        }

        #endregion

        #region Nested type: UdpRow

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa366928%28v=vs.85%29"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct UdpRow
        {
            public uint localAddr;
            public byte localPort1;
            public byte localPort2;
            public byte localPort3;
            public byte localPort4;
            public int owningPid;
        }

        #endregion

        #region Nested type: UdpTable

        /// <summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa366932%28v=vs.85%29"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct UdpTable
        {
            public uint Length;
            public UdpRow row;
        }

        #endregion

        #endregion
    }
}