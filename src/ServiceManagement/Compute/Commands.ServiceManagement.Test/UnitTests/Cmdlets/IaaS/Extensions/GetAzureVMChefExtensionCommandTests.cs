
namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands.Test.Utilities.Common;
    using ServiceManagement.IaaS.Extensions;
    using VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Utilities;
    using System.Management.Automation;
    using Model;

    public class MockIPersistentVMForChefExtension : IPersistentVM
    {
        public PersistentVM GetInstance()
        {
            Model.PersistentVMModel.ResourceExtensionReference extensionRef = null;
            extensionRef = new Model.PersistentVMModel.ResourceExtensionReference()
            {
                Name = "ChefClient",
                Publisher = "Chef.Bootstrap.WindowsAzure,",
                Version = "11.0"
            };

            var resourceList = new Model.PersistentVMModel.ResourceExtensionReferenceList();
            resourceList.Add(extensionRef);

            return new PersistentVM()
            {
                ResourceExtensionReferences = resourceList,
                OSVirtualHardDisk = new Model.PersistentVMModel.OSVirtualHardDisk() { OS = "Windows" }
            };
        }
    }

    [TestClass]
    public class GetAzureVMChefExtensionCommandTests : TestBase
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
        public class GetAzureVMChefExtensionCommandStub : GetAzureVMChefExtensionCommand
        {
            public GetAzureVMChefExtensionCommandStub() { }
        }

        [TestMethod]
        public void GetAzureVMChefExtensionExecuteChefCommand()
        {
            var getChefExtension = new GetAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM
            };

            getChefExtension.ExecuteCommand();

            Assert.AreEqual(1, mockCommandRuntime.OutputPipeline.Count, "One item should be in the output pipeline");
        }
    }
}