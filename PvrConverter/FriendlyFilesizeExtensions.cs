using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvrConverter
{
    static class FriendlyFilesizeExtensions
    {
        private static string GbSuffix = " GB";
        private static string MbSuffix = " MB";
        private static string KbSuffix = " KB";
        private static string BytesSuffix = " Bytes";

        public static string ToFileSize(this int source)
        {
            return ToFileSize(Convert.ToInt64(source));
        }

        public static string ToFileSize(this long source)
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);

            if (bytes >= Math.Pow(byteConversion, 3)) // GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 3), 2), GbSuffix);
            }
            else if (bytes >= Math.Pow(byteConversion, 2)) // MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 2), 2), MbSuffix);
            }
            else if (bytes >= byteConversion) // KB Range
            {
                return string.Concat(Math.Round(bytes / byteConversion, 2), KbSuffix);
            }
            else // Bytes
            {
                return string.Concat(bytes, BytesSuffix);
            }
        }
    }
}
