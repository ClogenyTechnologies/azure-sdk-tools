﻿Configuration VisualStudio
{
    Import-DscResource -Module xPSDesiredStateConfiguration
    Node localhost {
        xPackage VS
        {
            Ensure="Present"
            Name = "Microsoft Visual Studio Ultimate 2013"
            Path = "\\products\public\PRODUCTS\Developers\Visual Studio 2013\ultimate\vs_ultimate.exe"
            Arguments = "/quiet /noweb /Log c:\temp\vc.log"
            ProductId = ""
        }
    }
}

. VisualStudio