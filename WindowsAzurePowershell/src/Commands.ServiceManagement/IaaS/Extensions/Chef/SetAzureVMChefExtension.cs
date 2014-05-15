// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    using System.Management.Automation;
    using System;
    using System.IO;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachineChefExtensionNoun,
        DefaultParameterSetName = SetChefExtensionParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMChefExtensionCommand : VirtualMachineChefExtensionCmdletBase
    {
        protected const string SetChefExtensionParamSetName = "SetChefExtension";

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version. Default is 11.12.")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Validation Key File Path.")]
        [ValidateNotNullOrEmpty]
        public string ValidationPem { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Client Config (ClientRb)File Path.")]
        [ValidateNotNullOrEmpty]
        public string ClientRb { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Node Runlist.")]
        [ValidateNotNullOrEmpty]
        public string RunList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef Server Url.")]
        [ValidateNotNullOrEmpty]
        public string ChefServerUrl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Chef ValidationClientName, used to determine whether a chef-client may register with a Chef server.")]
        [ValidateNotNullOrEmpty]
        public string ValidationClientName { get; set; }

        internal void ExecuteCommand()
        {
            ValidateParameters();
            SetDefault();
            SetPrivateConfig();
            SetPublicConfig();
            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
        }

        internal void SetDefault()
        {
            this.Version = this.Version ?? ExtensionDefaultVersion;
        }

        internal void SetPrivateConfig()
        {
            this.PrivateConfiguration = string.Format(PrivateConfigurationTemplate, File.ReadAllText(this.ValidationPem).TrimEnd('\r', '\n'));
        }

        internal void SetPublicConfig()
        {
            string ClientConfig = string.Empty;

            if (!string.IsNullOrEmpty(this.ClientRb))
            {
                ClientConfig = File.ReadAllText(this.ClientRb).TrimEnd('\r', '\n');

                if (!string.IsNullOrEmpty(this.ChefServerUrl) && !string.IsNullOrEmpty(this.ValidationClientName))
                {
                    string UserConfig = @"
chef_server_url  \""{0}\""
validation_client_name 	\""{1}\""
";
                    ClientConfig += string.Format(UserConfig, this.ChefServerUrl, this.ValidationClientName);
                }
                else if (!string.IsNullOrEmpty(this.ChefServerUrl))
                {
                    string UserConfig = @"
chef_server_url  \""{0}\""
";
                    ClientConfig += string.Format(UserConfig, this.ChefServerUrl);
                }
                else if (!string.IsNullOrEmpty(this.ValidationClientName))
                {
                    string UserConfig = @"
validation_client_name 	\""{0}\""
";
                    ClientConfig += string.Format(UserConfig, this.ValidationClientName);
                }
            }
            else if (!string.IsNullOrEmpty(this.ChefServerUrl) && !string.IsNullOrEmpty(this.ValidationClientName))
            {
                ClientConfig = @"
chef_server_url  \""{0}\""
validation_client_name 	\""{1}\""
";
            }
            this.PublicConfiguration = string.Format(PublicConfigurationTemplate, ClientConfig, this.RunList);
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            if (string.IsNullOrEmpty(this.ClientRb) && (string.IsNullOrEmpty(this.ChefServerUrl) && string.IsNullOrEmpty(this.ValidationClientName)))
            {
                throw new ArgumentException("Required -ClientRb or -ChefServerUrl and -ValidationClientName options.");
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}