﻿using FieldMgt.API.Infrastructure.Factories.PathProvider;
using System;
using System.IO;

namespace FieldMgt.API.Infrastructure.Factories.LogFiles
{
    public class CreateLogFiles
    {
        /// <summary>
        /// Create the log file if not exist
        /// </summary>
        /// <paramname="pathProvider"></param>
        public static void CreateFileIfNotExist(IPathProvider pathProvider)
        {
            string FolderPath = pathProvider.MapPath("Logs");
            if (!string.IsNullOrEmpty(FolderPath))
            {
                string FileName = string.Concat(DateTime.Now.ToString("MMMM_dd_yyyy"), ".txt");
                string FilePath = Path.Combine(FolderPath, FileName);
                if (!File.Exists(FilePath))
                    File.Create(FilePath);
            }
        }
        /// <summary>
        /// use to log the error 
        /// </summary>
        /// <paramname="pathProvider"></param>
        public static void Log(IPathProvider pathProvider, string message,string errordetails)
        {
            string FolderPath = pathProvider.MapPath("Logs");
            string FileName = string.Concat(DateTime.Now.ToString("MMMM_dd_yyyy"), ".txt");
            string FilePath = Path.Combine(FolderPath, FileName);

            using (StreamWriter writer = File.AppendText(FilePath))
            {
                writer.WriteLine("");
                writer.WriteLine($"#########################   {DateTime.Now.ToString("dddd dd MMMM hh:mm:ss")}    ##################################");
                writer.WriteLine(message);
                writer.WriteLine(errordetails);
                writer.Dispose();

            }
        }
    }
}
