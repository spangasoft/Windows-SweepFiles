using System;
using System.Collections.Generic;
using System.Threading;


namespace sweep
{
    class MoveFiles
    {
        private string _source;
        private string _target;
        private bool _create;
        private bool _verbose;
        private List<FileInfo> files;
        public MoveFiles(string source, string target, bool create, bool verbose)
        {
            _source = source;
            _target = target;
            _create = create;
            _verbose = verbose;

            if (!System.IO.Directory.Exists(_source)) throw new Exception("Source directory does not exist.");
            if (_create)
                if (!System.IO.Directory.Exists(_target))
                    System.IO.Directory.CreateDirectory(_target);
                else
                    throw new Exception("Target directory does not exist.");
            files = FileInfo.getFileList( System.IO.Directory.GetFiles(_source));
            while (files.Count > 0)
            {
                foreach (FileInfo file in files)
                    if (!file.fileHasBeenMoved && file.isFileReady())
                    {
                        string filename = System.IO.Path.GetFileName(file.pathname);
                        Console.WriteLine("Moving: " + file.pathname + " -> " + _target);
                        System.IO.File.Move(file.pathname, System.IO.Path.Combine(_target, filename));
                        file.fileHasBeenMoved = true;
                    }
                List<FileInfo> newFiles = new List<FileInfo>();
                foreach (FileInfo file in files)
                    if (!file.fileHasBeenMoved)
                        newFiles.Add(file);
                files = newFiles;
                Thread.Sleep(1000);
            }
        }
    }
}
