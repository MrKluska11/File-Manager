using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
    public class Drive : IDrivesInformations
    {
        public List<string> DrivesNames
        {
            get
            {
                List<string> names = new List<string>();
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach(DriveInfo d in drives)
                {
                    if(d.DriveType == DriveType.Fixed) //rejection other drives for example cd-roms
                    {
                        names.Add(d.Name);
                    }                  
                }

                return names;
            }
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public int FileNumber
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal TotalSpace
        {
            get
            {
                DriveInfo drive = DriveInfo.GetDrives().Where(a => a.Name == this.Path).First();
                int gigabytes = 1024 * 1024 * 1024;
                return drive.TotalSize / gigabytes;
            }
        }

        public decimal FreeSpace
        {
            get
            {
                DriveInfo drive = DriveInfo.GetDrives().Where(a => a.Name == this.Path).First();
                int gigabytes = 1024 * 1024 * 1024;
                return drive.TotalFreeSpace / gigabytes;
            }
        }

        public string FileSystem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Drive(string path)
        {
            this.Path = path;
            this.Name = path.Substring(0, 2);
        }

        public Drive()
        {

        }
    }
}
