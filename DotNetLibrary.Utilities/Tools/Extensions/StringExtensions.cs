namespace DotNetLibrary.Utilities.Tools.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetString"></param>
        /// <returns></returns>
        public static bool  IsNullOrWhiteSpace(this string targetString)    
        {
            bool result = string.IsNullOrWhiteSpace(targetString);
            return result;
        }
    }
}
