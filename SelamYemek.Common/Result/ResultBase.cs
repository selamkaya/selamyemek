using System;
using System.Collections.Generic;
using System.Text;

namespace SelamYemek.Common
{
    public abstract class ResultBase
    {
        #region Property
        public bool Failed { get; set; }

        public int Code { get; set; } = 200;

        public string Message { get; set; }

        public string StackTrace { get; set; }
        #endregion
    }
}
