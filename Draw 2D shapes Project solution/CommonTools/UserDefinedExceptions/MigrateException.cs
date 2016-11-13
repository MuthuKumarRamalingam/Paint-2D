using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTools
{
    public class MigrateException : Exception
    {
        const string message = "Can't Migrate from Higher to Lower version";

        public MigrateException()
            : base(message)
        {
        }

        public MigrateException(int LatestVersion, int savedVersion)
            : base("LatestVersion" + LatestVersion + "\n SavedVersion" + savedVersion + "\n" + message)
        {

        }
    }
}
