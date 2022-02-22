using System;
using System.Collections.Generic;
using System.Text;

namespace SelamYemek.Common
{
    public static class ExceptionHandler
    {
        #region Methods
        public static void Handle(Action tryAction, Action<Exception> catchAction = null)
        {
            try
            {
                tryAction();
            }
            catch (Exception exception)
            {
                if (catchAction != null)
                    catchAction(exception);
            }
        }
        #endregion
    }
}
