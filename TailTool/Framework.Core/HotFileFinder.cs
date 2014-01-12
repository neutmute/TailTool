﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using Kraken.Framework.Core.Extensions;
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

        public string FilenamePattern { get; set; }

        public List<string> AntiFilenamePattern { get; set; }

        #endregion
        
        #region Ctor

        public HotFileFinder()
        {
            AntiFilenamePattern = new List<string>();
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

            string[] files = Directory.GetFiles(SearchFolder, FilenamePattern, SearchOption.AllDirectories);
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
