using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.Shared
{
    public static class Share
    {
        public enum ReturnStatus
        {
            success,
            error,
            warning
        }

        public enum ImageType
        {
            original,
            filtered
        }
    }
}
