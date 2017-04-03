//-----------------------------------------------------------------------
// <copyright file="ProcessWithLogging.cs" company="InHisCompany">
//     Copyright (c) In His Company USA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SemanticLogging
{
    using System;

    public class ProcessWithLogging
    {
        public void ProcessSomething()
        {
            try
            {
                Logger.Log.ProcessorStart();

                for (int i = 1; i <= 5; i++)
                {
                    if (i < 5)
                    {
                        Logger.Log.ProcessRow(i.ToString());
                    }
                    else
                    {
                        Logger.Log.ProcessRowFail(i.ToString(), "Exception to Show ROW Failure");
                    }
                }
                throw new Exception("Exception to Show PROCESS Failure");
            }
            catch (Exception exception)
            {
                Logger.Log.ProcessorFail(exception.Message);
            }
            finally
            {
                Logger.Log.ProcessorStop();
            }
        }
    }
}
