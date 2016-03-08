using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace VHDLib
{

    #region PInvoke Enums
    public enum ATTACH_VIRTUAL_DISK_FLAG : int
    {
        ATTACH_VIRTUAL_DISK_FLAG_NONE = 0x00000000,
        ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY = 0x00000001,
        ATTACH_VIRTUAL_DISK_FLAG_NO_DRIVE_LETTER = 0x00000002,
        ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME = 0x00000004,
        ATTACH_VIRTUAL_DISK_FLAG_NO_LOCAL_HOST = 0x00000008
    }

    public enum ATTACH_VIRTUAL_DISK_VERSION : int
    {
        ATTACH_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
        ATTACH_VIRTUAL_DISK_VERSION_1 = 1
    }

    public enum OPEN_VIRTUAL_DISK_FLAG : int
    {
        OPEN_VIRTUAL_DISK_FLAG_NONE = 0x00000000,
        OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS = 0x00000001,
        OPEN_VIRTUAL_DISK_FLAG_BLANK_FILE = 0x00000002,
        OPEN_VIRTUAL_DISK_FLAG_BOOT_DRIVE = 0x00000004
    }

    public enum OPEN_VIRTUAL_DISK_VERSION : int
    {
        OPEN_VIRTUAL_DISK_VERSION_1 = 1
    }
    #endregion

    #region PinvokeStructures



    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ATTACH_VIRTUAL_DISK_PARAMETERS
    {
        public ATTACH_VIRTUAL_DISK_VERSION Version;
        public ATTACH_VIRTUAL_DISK_PARAMETERS_Version1 Version1;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ATTACH_VIRTUAL_DISK_PARAMETERS_Version1
    {
        public Int32 Reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OPEN_VIRTUAL_DISK_PARAMETERS
    {
        public OPEN_VIRTUAL_DISK_VERSION Version;
        public OPEN_VIRTUAL_DISK_PARAMETERS_Version1 Version1;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OPEN_VIRTUAL_DISK_PARAMETERS_Version1
    {
        public Int32 RWDepth;
    }

    public enum VIRTUAL_DISK_ACCESS_MASK : int
    {
        VIRTUAL_DISK_ACCESS_ATTACH_RO = 0x00010000,
        VIRTUAL_DISK_ACCESS_ATTACH_RW = 0x00020000,
        VIRTUAL_DISK_ACCESS_DETACH = 0x00040000,
        VIRTUAL_DISK_ACCESS_GET_INFO = 0x00080000,
        VIRTUAL_DISK_ACCESS_CREATE = 0x00100000,
        VIRTUAL_DISK_ACCESS_METAOPS = 0x00200000,
        VIRTUAL_DISK_ACCESS_READ = 0x000d0000,
        VIRTUAL_DISK_ACCESS_ALL = 0x003f0000,
        VIRTUAL_DISK_ACCESS_WRITABLE = 0x00320000
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct VIRTUAL_STORAGE_TYPE
    {
        public Int32 DeviceId;
        public Guid VendorId;
    }
    #endregion

    internal class Win32
    {
        internal const Int32 ERROR_SUCCESS = 0;

        internal const int OPEN_VIRTUAL_DISK_RW_DEPTH_DEFAULT = 1;

        internal const int VIRTUAL_STORAGE_TYPE_DEVICE_VHD = 2;

        internal static readonly Guid VIRTUAL_STORAGE_TYPE_VENDOR_MICROSOFT = new Guid("EC984AEC-A0F9-47e9-901F-71415A66345B");


        [DllImport("virtdisk.dll", CharSet = CharSet.Unicode)]
        internal static extern Int32 AttachVirtualDisk(IntPtr VirtualDiskHandle, IntPtr SecurityDescriptor, ATTACH_VIRTUAL_DISK_FLAG Flags, Int32 ProviderSpecificFlags, ref ATTACH_VIRTUAL_DISK_PARAMETERS Parameters, IntPtr Overlapped);

        [DllImportAttribute("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        internal static extern Boolean CloseHandle(IntPtr hObject);

        [DllImport("virtdisk.dll", CharSet = CharSet.Unicode)]
        internal static extern Int32 OpenVirtualDisk(ref VIRTUAL_STORAGE_TYPE VirtualStorageType, String Path, VIRTUAL_DISK_ACCESS_MASK VirtualDiskAccessMask, OPEN_VIRTUAL_DISK_FLAG Flags, ref OPEN_VIRTUAL_DISK_PARAMETERS Parameters, ref IntPtr Handle);

        [DllImport("virtdisk.dll", CharSet = CharSet.Unicode)]
        internal static extern Int32 DetachVirtualDisk(IntPtr VirtualDiskHandle, ATTACH_VIRTUAL_DISK_FLAG Flags, Int32 ProviderSpecificFlags);
    }
}
