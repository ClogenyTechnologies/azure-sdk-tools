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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.ILB
{

    using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetAzurePublicIPCmdletInfo : CmdletsInfo
    {

        public GetAzurePublicIPCmdletInfo(string publicIPName, IPersistentVM vm)
        {
            this.cmdletName = Utilities.GetAzurePublicIPCmdletName;
            this.parameters.Add(new CmdletParam("PublicIPName",publicIPName));
            this.parameters.Add(new CmdletParam("VM", vm));
        }
    }
}
