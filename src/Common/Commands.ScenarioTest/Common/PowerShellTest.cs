﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.Common.Test.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Resources;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    using Commands.Test.Utilities.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PowerShellTest
    {
        public static string ErrorIsNotEmptyException = "Test failed due to a non-empty error stream, check the error stream in the test log for more details";

        protected PowerShell powershell;
        protected List<string> modules;

        public TestContext TestContext { get; set; }

        public PowerShellTest(AzureModule commandMode, params string[] modules)
        {
            this.modules = new List<string>();
            if (commandMode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(FileUtilities.GetContentFilePath(@"ServiceManagement\Azure\Azure.psd1"));
            }
            else if (commandMode == AzureModule.AzureResourceManager)
            {
                this.modules.Add(FileUtilities.GetContentFilePath(@"ResourceManager\AzureResourceManager\AzureResourceManager.psd1"));
            }
            else
            {
                throw new ArgumentException("Unknown command type for testing");
            }
            this.modules.Add("Assert.ps1");
            this.modules.Add("Common.ps1");
            this.modules.AddRange(modules);
            TestingTracingInterceptor.AddToContext();
        }

        protected void AddScenarioScript(string script)
        {
            powershell.AddScript(Testing.GetTestResourceContents(script));
        }

        public virtual Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            Collection<PSObject> output = null;
            for (int i = 0; i < scripts.Length; ++i)
            {
                Console.WriteLine(scripts[i]);
                powershell.AddScript(scripts[i]);
            }
            try
            {
                output = powershell.Invoke();
                
                if (powershell.Streams.Error.Count > 0)
                {
                    throw new RuntimeException(ErrorIsNotEmptyException);
                }

                return output;
            }
            catch (Exception psException)
            {
                powershell.LogPowerShellException(psException, this.TestContext);
                throw;
            }
            finally
            {
                powershell.LogPowerShellResults(output, this.TestContext);
            }
        }

        [TestInitialize]
        public virtual void TestSetup()
        {
            powershell = PowerShell.Create();

            foreach (string moduleName in modules)
            {
                powershell.AddScript(string.Format("Import-Module \"{0}\"", Testing.GetAssemblyTestResourcePath<ResourceLocator>(moduleName)));
            }

            powershell.AddScript("$VerbosePreference='Continue'");
            powershell.AddScript("$DebugPreference='Continue'");
            powershell.AddScript("$ErrorActionPreference='Stop'");
            powershell.AddScript("Write-Debug \"AZURE_TEST_MODE = $env:AZURE_TEST_MODE\"");
            powershell.AddScript("Write-Debug \"TEST_HTTPMOCK_OUTPUT = $env:TEST_HTTPMOCK_OUTPUT\"");
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            powershell.Dispose();
        }
    }
}
