namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using Commands.Test.Utilities.Common;
    using ServiceManagement.IaaS.Extensions;
    using Microsoft.WindowsAzure.Commands.Utilities;
    using System.Management.Automation;
    
    [TestClass]
    public class RemoveAzureVMChefExtensionCommandTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;
        private MockIPersistentVMForChefExtension mockIPersistentVM;
        [TestInitialize]
        public void SetupTest()
        {
            mockCommandRuntime = new MockCommandRuntime();
            mockIPersistentVM = new MockIPersistentVMForChefExtension();
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }
        public class RemoveAzureVMChefExtensionCommandStub : RemoveAzureVMChefExtensionCommand
        {
            public RemoveAzureVMChefExtensionCommandStub() { }
        }

        [TestMethod]
        [TestCategory(Category.Functional)]
        public void RemoveAzureVMChefExtensionExecuteChefCommand()
        {

            var getChefExtension = new RemoveAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM,
            };

            getChefExtension.ExecuteCommand();
            Assert.AreEqual(1, mockCommandRuntime.OutputPipeline.Count, "One item should be in the output pipeline");
        }
    }
}
