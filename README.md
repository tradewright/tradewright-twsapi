# TradeWright TWSAPI

## Introduction

This project is an alternative to the TWSAPI published by Interactive Brokers 
(IBKR).

It is .Net-based, and can be used from any language that runs on .Net.

It is currently broadly equivalent in functionality to the 9.73 version of 
the IBKR implementation as of June 2017, and will be updated to be fully 
equivalent to the latest version in due course.

At present it is targetted at .Net 4.6. The intention is to retarget it for 
.Net Standard 2.0, which will enable it to be used with .Net implementations
on other platforms (eg Windows universal apps, Linux and macOS).

## Overview

This implementation makes heavy use of asynchronous Tasks, allowing it to be 
run on the main thread of a Windows Forms or Windows Presentation Foundation 
application. Not only does this not involve any additional thread creation, but
it also means that all API callbacks or events happen on the program's main 
thread, so that synchronisation issues are non-existent (unless the program 
needs to use other threads for its own purposes).

API callbacks can be delivered in several ways:

* through the .Net event mechanism. This is the simplest way, and is exactly
  equivalent to consuming events from .Net user interface controls

* by registering a class that inherits from the 'EventSource' class and 
  overrides the various `OnXXX` methods

* by registering a class that inherits from the abstract `CallbackHandler`
  class and overrides the callback methods 

* by registering classes that implement various interfaces relating to 
  different aspecst of API operation, such as `IConnectionStatusConsumer`
  and `IMarketDataConsumer`
  
## Sample Applications

Several sample applications are provided, which illustrate various aspects 
of using the API:

* SimpleTWSAPIDemo: shows the basics of using the API by means of the 
  `EventSource`. This sample displays market data, market depth data, and 
  allows simple orders to be submitted and managed.

* ApiLoadTestTW: starts market data streams for many contracts, and collects
  performance data which is displayed to the user
  
* ApiLoadTestIB: this does the same as ApiLoadTestTW, but uses IBKR's own 
  CSharp API implementation. Running the two side by sides demonstrates the 
  considerably better performance of the TradeWright API compared with 
  IBKR's
  
* ApiLoadTestTW-VB6: this version uses the TWSAPI implementation from the 
  original [TradeBuild Platform](https://github.com/rlktradewright/tradebuild-platform),
  which is written in Visual Basic 6, and again provides a useful comparison
  with this .Net implementation

* Ib_VB_API_Sample: this is IBKR's own Visual Basic sample application, 
  modified to use the TradeWright API.

## Releases

At present, no releases have been made. The intention is to provide 
Microsoft Installer files (.msi) that will install the API library in a 
convenient location for use by developers, together with the compiled sample 
applications. 

It is also intended to provide a Nuget package, to simplify inclusion into 
Visual Studio projects.

In general releases will be named to follow IBKR's versions, for example
9.73.nn, where the patch number nn will be specific to this implementation 
and will be incremented as required.





