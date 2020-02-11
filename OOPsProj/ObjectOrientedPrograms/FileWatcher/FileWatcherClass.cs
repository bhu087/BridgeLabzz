////-----------------------------------------------------------------
////<copyright file="FileWatcherClass.cs" company="BridgeLabz">
//// author="Bhushan"
//// </copyright>
////-----------------------------------------------------------------
namespace ObjectOrientedPrograms.FileWatcher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// File watcher main class
    /// </summary>
    public class FileWatcherClass
    {
        /// <summary>
        /// Files the watcher method.
        /// </summary>
        public static void FileWatcherMethod()
        {
            ////file system watcher object created here
            FileSystemWatcher watcher = new FileSystemWatcher();
            ////Watcher path
            watcher.Path = @"D:\repoTemp";
            ////Includes subdirectories in folder
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.DirectoryName
                | NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Security | NotifyFilters.LastWrite;
            ////this includes all type of files
            watcher.Filter = "*.*";
            ////starts the watcher
            watcher.EnableRaisingEvents = true;
            ////if the watcher finds any changes/deletion/creation/renames has to be done on given folder it will
            ////handels by file system evne handler and rename Event Handler and refers to methods
            watcher.Changed += new FileSystemEventHandler(Onchanged);
            watcher.Deleted += new FileSystemEventHandler(Onchanged);
            watcher.Created += new FileSystemEventHandler(Onchanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            ////it will keep tracking untill press enter key
            Console.WriteLine("Your Directory is in undre the file wather tracking....\nEnter to stop...");
            Console.Read();
        }

        /// <summary>
        /// calls when changes in directory.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        public static void Onchanged(object obj, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} is path {1} is changed type {2} ", e.Name, e.FullPath, e.ChangeType);
        }

        /// <summary>
        /// Called when [renamed].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="RenamedEventArgs"/> instance containing the event data.</param>
        public static void OnRenamed(object obj, RenamedEventArgs e)
        {
            Console.WriteLine("{0} is path {1} is Change type {2} ", e.Name, e.FullPath, e.ChangeType);
        }
    }
}
