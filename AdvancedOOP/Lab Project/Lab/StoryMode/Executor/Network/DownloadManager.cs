﻿namespace Executor.Network
{
    using System.Net;
    using System.Threading.Tasks;

    using Executor.Exceptions;
    using Executor.Interfaces;
    using Executor.IO;

    public class DownloadManager : IDownloadManager
    {
        private WebClient webClient;

        public DownloadManager()
        {
            this.webClient = new WebClient();
        }

        public void Download(string fileURL)
        {
            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading: ");

                string nameOfFile = this.ExtractNameOfFile(fileURL);
                string pathToDownload = SessionData.currentPath + "/" + nameOfFile;

                this.webClient.DownloadFile(fileURL, pathToDownload);

                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException)
            {
                throw new InvalidPathException();
            }

        }

        public void DownloadAsync(string fileURL)
        {
            Task currentTask = Task.Run(() => this.Download(fileURL));
            SessionData.taskPool.Add(currentTask);
        }

        private string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.LastIndexOf("/");

            if (indexOfLastBackSlash != -1)
            {
                return fileURL.Substring(indexOfLastBackSlash + 1);
            }
            else
            {
                throw new InvalidPathException();
            }
        }
    }
}
