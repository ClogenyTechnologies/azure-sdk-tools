namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Commands.Test.Utilities.Common;
    using ServiceManagement.IaaS.Extensions;
    using VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Utilities;
    using System.Management.Automation;
    
    [TestClass]
    public class SetAzureVMChefExtensionCommandTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;
        private MockIPersistentVMForChefExtension mockIPersistentVM;
        private string tmpfile = Path.GetTempFileName();

        [TestInitialize]
        public void SetupTest()
        {
            mockCommandRuntime = new MockCommandRuntime();
            mockIPersistentVM = new MockIPersistentVMForChefExtension();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            File.Delete(tmpfile);
        }

        public class SetAzureVMChefExtensionCommandStub : SetAzureVMChefExtensionCommand
        {
            public SetAzureVMChefExtensionCommandStub() { }
        }

        [TestMethod]
        [TestCategory(Category.Functional)]
        public void SetAzureVMChefExtensionExecuteChefCommand()
        {
            var setChefExtension = new SetAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM,
                Version = "11.10",
                ValidationPem =  tmpfile,
                ClientRb = tmpfile
            };

            setChefExtension.ExecuteCommand();
            Assert.AreEqual(1, mockCommandRuntime.OutputPipeline.Count, "One item should be in the output pipeline");
        }

        [TestMethod]
        [TestCategory(Category.Functional)]
        [ExpectedException(typeof(ArgumentException), 
            "Required -ClientRb or -ChefServerUrl and -ValidationClientName options.")]
        public void SetAzureVMChefExtensionValidateMissingClientRBAndChefServerUrlOrValidationClientName()
        {
            var setChefExtension = new SetAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM,
                Version = "11.10",
                ValidationPem = tmpfile
            };

            setChefExtension.ExecuteCommand();
        }

        [TestMethod]
        [TestCategory(Category.Functional)]
        [ExpectedException(typeof(ArgumentException), 
            "Required -ClientRb or -ChefServerUrl and -ValidationClientName options.")]
        public void SetAzureVMChefExtensionValidateGivenValidationClientNameAndMissingChefServerUrl()
        {
            var setChefExtension = new SetAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM,
                Version = "11.10",
                ValidationPem = tmpfile,
                ValidationClientName = "testClient"

            };
            
            setChefExtension.ExecuteCommand();
        }

        [TestMethod]
        [TestCategory(Category.Functional)]
        [ExpectedException(typeof(ArgumentException), 
            "Required -ClientRb or -ChefServerUrl and -ValidationClientName options.")]
        public void SetAzureVMChefExtensionValidateGivenChefServerUrlAndMissingChefValidationClientName()
        {
            var setChefExtension = new SetAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM,
                Version = "11.10",
                ValidationPem = tmpfile,
                ChefServerUrl = "https://testchefserverurl/testorg/"

            };

            setChefExtension.ExecuteCommand();
        }
    }
}
