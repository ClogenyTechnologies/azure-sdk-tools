﻿// ----------------------------------------------------------------------------------
//
// Copyright 2011 Microsoft Corporation
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

namespace Microsoft.WindowsAzure.Management.Websites.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Properties;
    using Services;
    using WebEntities;
    using WebSites.Cmdlets.Common;

    /// <summary>
    /// Stops an azure website.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "AzureWebsite")]
    public class StopAzureWebsiteCommand : WebsiteContextCmdletBase
    {
        /// <summary>
        /// Initializes a new instance of the StopAzureWebsiteCommand class.
        /// </summary>
        public StopAzureWebsiteCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StopAzureWebsiteCommand class.
        /// </summary>
        /// <param name="channel">
        /// Channel used for communication with Azure's service management APIs.
        /// </param>
        public StopAzureWebsiteCommand(IWebsitesServiceManagement channel)
        {
            Channel = channel;
        }

        internal override void ExecuteCommand()
        {
            Site website = null;

            InvokeInOperationContext(() =>
            {
                website = RetryCall(s => Channel.GetWebsite(s, Name));
            });

            if (website == null)
            {
                throw new Exception(string.Format(Resources.InvalidWebsite, Name));
            }

            InvokeInOperationContext(() =>
            {
                Site websiteUpdate = new Site
                                        {
                                            Name = Name,
                                            HostNames = new [] { Name + ".azurewebsites.net" },
                                            State = "Stopped"
                                        };

                RetryCall(s => Channel.UpdateWebsite(s, website.WebSpace, Name, websiteUpdate));
            });
        }
    }
}
