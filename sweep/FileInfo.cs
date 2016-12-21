using System.Collections.Generic;
using System.Diagnostics;


namespace sweep
{
    class FileInfo
    {
        long _fileSize;
        public string pathname { set; get; }
        public bool fileHasBeenMoved { set; get; }
        Stopwatch timer;
        FileInfo (string pathname)
        {
            _fileSize = new System.IO.FileInfo(pathname).Length;
            this.pathname = pathname;
            fileHasBeenMoved = false;
            timer = new Stopwatch();
            timer.Start();
        }

        public bool isFileReady()
        {
            bool result = false;
            if (timer.ElapsedMilliseconds >= 5000)
            {
                timer.Restart();
                result = _fileSize == new System.IO.FileInfo(pathname).Length;
                _fileSize = new System.IO.FileInfo(pathname).Length;
            }     
            return result;
        }

        static public List<FileInfo> getFileList(string[] files)
        {
            List<FileInfo> result = new List<FileInfo>();
            foreach (string file in files)
                result.Add(new FileInfo(file));
            return result;
        }
    }
}
