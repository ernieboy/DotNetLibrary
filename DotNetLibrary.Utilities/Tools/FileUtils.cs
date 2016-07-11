using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

namespace DotNetLibrary.Utilities.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public  static class FileUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="absoluteFilePath"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadAllLinesFromFile(string absoluteFilePath)
        {
            Contract.Requires<ArgumentNullException>(absoluteFilePath != null, "Preconditions, absoluteFilePath may not be null");
            using (TextReader reader = File.OpenText(absoluteFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
