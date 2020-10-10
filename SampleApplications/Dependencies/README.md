The files in the Dependencies folder are used by the SampleApplications.

To use .dll files, just create a new reference in your Visual Studio project 
and browse to where the file is located.

Using Nuget packages is slightly more involved. You first have to decide where 
you want to store the packages, then run a command to get them into place, and 
then bring them into your project. So follow these steps:

* Decide where to store the packages: the simplest place is simply to create a 
folder, for example C:\Projects\Packages, in your projects folder structure.

* To get the packages into place, start a Powershell session and run a command 
like this for each one:

>
nuget add C:\Projects\tradewright-twsapi\SampleApplications\Dependencies\TradeWright.IBAPI.973.7.1.nupkg -source C:\Projects1\Packages

* To use the packages in a project, open the NuGet Package Manager from the 
Project menu in Visual Studio, then click the Settings icon beside the Package 
Source dropdown. Click the 'add' icon above the 'Available package sources' list,
give it a name (eg Local Packages) and set the path, for example C:\Projects\Packages. 
Now click ok. Then select your new package source from the 'Package source' dropdown,
and all the NuGet packages in that source will be listed. For each one you need, 
select it from the list and click 'Install'. 

The NuGet packages required by the sample applications are as follows:

VB-API-sample needs TradeWright.IBAPI, TradeWright.UI and TradeWright.Utilities.Logging

ApiLoadTestTW needs TradeWright.IBAPI




**tradewright.ibapi.973.7.1.nupkg**

This Nuget package file is generated from the tradewright-twsapi project. It contains 
the API binaries.
	
**tradewright.ui.1.0.0.nupkg**

This Nuget package contains the binaries for a prototype user interface docking 
component, and a simple UI theming engine. The source code has not yet been published 
to GitHub, but this will be done soon.
	
**tradewright.utilities.logging.1.0.1.nupkg**

This Nuget package contains the binaries for the TradeWright Common Logging component, 
which is generated by the [TradeWright Common .Net](https://github.com/tradewright/tradewright-common.net) 
project.

**CSharpApi.dll**
**CSharpApi.pdb**
	
These files are the outputs from building IB's CSharp Api. You can obtain the source 
code from the Interactive Brokers website and build it yourself to use the latest version. 