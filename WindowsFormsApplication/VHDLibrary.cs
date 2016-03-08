using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace VHDLib
{
    public class VHDLibrary
    {

        public VHDLibrary()
        {
        }

        /// <summary>
        /// Attaches the virtual harddisk
        /// </summary>
        /// <returns></returns>
        public void Attach(FileInfo path)
        {
           
            //Open VHD file for atatch
            IntPtr handle = VHDLoader.OpenVHD(path, VHDOpeMode.Attach);

            try
            {

                //Opening the VHD was successful. Now attach the disk.

                ATTACH_VIRTUAL_DISK_PARAMETERS attachParam = new ATTACH_VIRTUAL_DISK_PARAMETERS();
                attachParam.Version = ATTACH_VIRTUAL_DISK_VERSION.ATTACH_VIRTUAL_DISK_VERSION_1;

                //Attach the virtual hardisk
                int nRet = Win32.AttachVirtualDisk(handle,
                    IntPtr.Zero,
                    ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME,
                    0, ref attachParam, IntPtr.Zero);

                if (nRet != Win32.ERROR_SUCCESS)
                {
                    throw new Win32Exception(nRet);
                }

            }
            finally
            {
                if (handle != IntPtr.Zero)
                    Win32.CloseHandle(handle);// close handle to disk
            }

        }

        /// <summary>
        /// Detaches the virtual harddisk
        /// </summary>
        /// <returns></returns>
        public void Detach(FileInfo path)
        {

            //Open VHD file for detach
            IntPtr handle = VHDLoader.OpenVHD(path, VHDOpeMode.Detach);
            try
            {
                int nRet = Win32.DetachVirtualDisk(handle, ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NONE, 0);

                if (nRet != Win32.ERROR_SUCCESS)
                    throw new Win32Exception(nRet);
            }
            finally
            {
                if (handle != IntPtr.Zero)
                    Win32.CloseHandle(handle);// close handle to disk
            }

        }
    }
}
