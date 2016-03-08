using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace VHDLib
{
    public enum VHDOpeMode
    {
        Attach,
        Detach
    }


    internal static class VHDLoader
    {
        public static IntPtr OpenVHD(FileInfo file, VHDOpeMode openMode)
        {
            IntPtr handle =IntPtr.Zero;

            //Storage type initialization
            VIRTUAL_STORAGE_TYPE storageType = new VIRTUAL_STORAGE_TYPE();
            storageType.DeviceId = Win32.VIRTUAL_STORAGE_TYPE_DEVICE_VHD;
            storageType.VendorId = Win32.VIRTUAL_STORAGE_TYPE_VENDOR_MICROSOFT;

            //Open disk parameters
            OPEN_VIRTUAL_DISK_PARAMETERS openVdisk = new OPEN_VIRTUAL_DISK_PARAMETERS();
            openVdisk.Version = OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_1;
            openVdisk.Version1.RWDepth = Win32.OPEN_VIRTUAL_DISK_RW_DEPTH_DEFAULT;

            VIRTUAL_DISK_ACCESS_MASK accessMask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_ALL;

            if (openMode == VHDOpeMode.Attach)
                accessMask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_ATTACH_RW;
            else if (openMode == VHDOpeMode.Detach)
                accessMask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_DETACH;

            //Open the virtual disk for read write using API
            int nRet = Win32.OpenVirtualDisk(ref storageType,
                file.FullName,
                accessMask,
                OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE,
                ref openVdisk,
                ref handle);

            if (nRet != Win32.ERROR_SUCCESS)
            {
                throw new Win32Exception(nRet);
            }



            return handle;
        }
    }
}
