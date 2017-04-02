//-----------------------------------------------------------------------
// <copyright file="LoggerUnitTest.cs" company="InHisCompany">
//     Copyright (c) In His Company USA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace SemanticLogging.UnitTest
{
    using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for Logger
    /// </summary>
    [TestClass]
    public class LoggerUnitTest
    {
        /// <summary>
        /// Confirm the quality of the Event Source
        /// </summary>
        [TestMethod]
        public void ValidateEventSource()
        {
            //// see https://msdn.microsoft.com/en-us/library/dn774985(v=pandp.20).aspx
            //// for details about the EventSourceAnalyzer, its coverage and validation checks
            EventSourceAnalyzer.InspectAll(Logger.Log);
        }
    }
}
