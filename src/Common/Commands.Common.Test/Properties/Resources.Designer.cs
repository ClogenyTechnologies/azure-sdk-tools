﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Common.Test.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] Azure {
            get {
                object obj = ResourceManager.GetObject("Azure", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://az413943.vo.msecnd.net/cache/2.5.2.exe.
        /// </summary>
        public static string CacheRuntimeUrl {
            get {
                return ResourceManager.GetString("CacheRuntimeUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] InvalidProfile {
            get {
                object obj = ResourceManager.GetObject("InvalidProfile", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;fake&gt;
        ///  This is a fake xml.
        ///&lt;/fake&gt;.
        /// </summary>
        public static string invalidsubscriptions {
            get {
                return ResourceManager.GetString("invalidsubscriptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;Subscriptions version=&quot;1.0&quot; xmlns=&quot;urn:Microsoft.WindowsAzure.Management:WaPSCmdlets&quot;&gt;
        ///  &lt;Subscription name=&quot;mysub1&quot;&gt;
        ///    &lt;SubscriptionId&gt;279b0675-cf67-467f-98f0-67ae31eb540f&lt;/SubscriptionId&gt;
        ///    &lt;Thumbprint&gt;12D09EC0008EEE10C1B80AB70B3739E6BC509BB3&lt;/Thumbprint&gt;
        ///    &lt;ServiceEndpoint&gt;0853C43B56C81CE8FC44C8ACDC8C54783C6080E2&lt;/ServiceEndpoint&gt;
        ///    &lt;CurrentStorageAccountName&gt;0853C43B56C81CE8FC44C8ACDC8C54783C6080E2&lt;/CurrentStorageAccountName&gt;
        ///  &lt;/Subscription&gt;
        ///  &lt;S [rest of string was truncated]&quot;;.
        /// </summary>
        public static string subscriptions {
            get {
                return ResourceManager.GetString("subscriptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;runtimemanifest&gt;
        ///  &lt;baseuri uri=&quot;http://CDN/&quot; /&gt;
        ///  &lt;runtimes&gt;
        ///    &lt;runtime type=&quot;iisnode&quot; version=&quot;0.1.20&quot; filepath=&quot;/iisnode/bar.exe&quot; /&gt;
        ///    &lt;runtime type=&quot;iisnode&quot; version=&quot;0.1.21&quot; filepath=&quot;/iisnode/default.exe&quot; default=&quot;true&quot; /&gt;
        ///    &lt;runtime type=&quot;node&quot; version=&quot;0.8.2&quot; filepath=&quot;/node/foo.exe&quot; /&gt;
        ///    &lt;runtime type=&quot;node&quot; version=&quot;0.6.20&quot; filepath=&quot;/node/default.exe&quot; default=&quot;true&quot; /&gt;
        ///    &lt;runtime type=&quot;php&quot; version=&quot;5.3&quot; filepath=&quot;/php/5.3.exe&quot; default=&quot;true&quot; /&gt;
        ///    &lt;runt [rest of string was truncated]&quot;;.
        /// </summary>
        public static string testruntimemanifest {
            get {
                return ResourceManager.GetString("testruntimemanifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {{
        ///  &quot;author&quot;: &quot;&quot;,
        ///
        ///  &quot;name&quot;: &quot;{0}&quot;,
        ///  &quot;version&quot;: &quot;0.0.0&quot;,
        ///  &quot;dependencies&quot;:{{}},
        ///  &quot;devDependencies&quot;:{{}},
        ///  &quot;optionalDependencies&quot;: {{}},
        ///  &quot;engines&quot;: {{
        ///    &quot;node&quot;: &quot;{1}&quot;,
        ///    &quot;iisnode&quot;: &quot;*&quot;
        ///  }}
        ///
        ///}}.
        /// </summary>
        public static string ValidPackageJson {
            get {
                return ResourceManager.GetString("ValidPackageJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] ValidProfile {
            get {
                object obj = ResourceManager.GetObject("ValidProfile", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] ValidProfile2 {
            get {
                object obj = ResourceManager.GetObject("ValidProfile2", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] ValidProfile3 {
            get {
                object obj = ResourceManager.GetObject("ValidProfile3", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] ValidProfileChina {
            get {
                object obj = ResourceManager.GetObject("ValidProfileChina", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] ValidProfileChinaOld {
            get {
                object obj = ResourceManager.GetObject("ValidProfileChinaOld", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Scaffold Name=&quot;TestScaffold&quot;&gt;
        ///  &lt;ScaffoldFile PathExpression=&quot;modules\.*&quot;/&gt;
        ///  &lt;ScaffoldFile TargetPath=&quot;/bin/node.exe&quot; Path=&quot;bin/node123dfx65.exe&quot;/&gt;
        ///  &lt;ScaffoldFile Path=&quot;bin/iisnode.dll&quot;/&gt;
        ///  &lt;ScaffoldFile Path=&quot;bin/setup.cmd&quot;/&gt;
        ///  &lt;ScaffoldFile Path=&quot;Web.config&quot;&gt;
        ///    &lt;Scaffold.ReplaceParameterRule /&gt;
        ///  &lt;/ScaffoldFile&gt;
        ///  &lt;ScaffoldFile Path=&quot;WebRole.xml&quot; Copy=&quot;False&quot; &gt;
        ///    &lt;Scaffold.ReplaceParameterRule /&gt;
        ///  &lt;/ScaffoldFile&gt;
        ///&lt;/Scaffold&gt;.
        /// </summary>
        public static string ValidScaffoldXml {
            get {
                return ResourceManager.GetString("ValidScaffoldXml", resourceCulture);
            }
        }
    }
}
