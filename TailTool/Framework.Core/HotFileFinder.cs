using System;
using System.Collections.Generic;
using System.IO;
using Kraken.Framework.Core.Extensions;
using NLog;

namespace Kraken.Framework.Core
{
    /// <summary>
    /// Use for finding logs to tail
    /// </summary>
    public class HotFileFinder
    {

        #region Fields

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        public string SearchFolder { get; set; }

        public List<string> FilenamePattern { get; set; }

        public List<string> AntiFilenamePattern { get; set; }

        #endregion
        
        #region Ctor

        public HotFileFinder()
        {
            AntiFilenamePattern = new List<string>();
            FilenamePattern = new List<string>();
        }

        #endregion
        
        #region Instances

        public List<FileInfo> FindMatches()
        {
            if (!Directory.Exists(SearchFolder))
            {
                Log.Warn("{0} does not exist", SearchFolder);
                return new List<FileInfo>();
            }

            // Get all matching files
            var files = new List<string>();
            foreach(string filePattern in FilenamePattern)
            {
                files.AddRange(Directory.GetFiles(SearchFolder, filePattern, SearchOption.AllDirectories));
            }

            // Calculate hotlist of files
            List<FileInfo> hotList = new List<FileInfo>();
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                var matchDate = fileInfo.LastWriteTime > DateTime.Now.Date;
                var matchAntiPattern = AntiFilenamePattern.ContainedAsFragment(fileInfo.Name);
                
                if (matchDate && !matchAntiPattern)
                {
                    hotList.Add(fileInfo);
                }
            }
            return hotList;
        }

        #endregion

    }
}
