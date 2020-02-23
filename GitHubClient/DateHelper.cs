using System;

namespace MHanafy.GithubClient
{
    static class DateHelper
    {
        /// <summary>
        /// Number of seconds to use as a safety margin, i.e. tokens will be assumed expired 5 seconds earlier than actual expiry
        /// </summary>
        public const int SafetyMargin = 5;

        public static int ToUnixTime(this DateTime time)
        {
            return (int) time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
