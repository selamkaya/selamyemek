using System;
using System.Collections.Generic;
using System.Text;

namespace SelamYemek.Common
{
    public class DataResult<TData> : ResultBase
    {
        #region Property
        public TData Data { get; set; }
        #endregion
    }
}
