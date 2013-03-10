IP.i4o - Index for objects
=======================

IP.i4o (index for objects) enhances the i4o library ([https://github.com/ericksoa/i4o](https://github.com/ericksoa/i4o) from which it was forked. This library was renamed as well in order to prevent confusion if, for example, both this and the original were to appear on NuGet.

## Key Features

* Allows indexes to be added to collections to optimize LINQ queries since, by default, LINQ queries collection items sequentially.

## Enhancements/changes to i4o

* Optimized inefficient index queries whereby the binary search was performed twice: first to check if the key existed and again to look up the key/value
* Removed c5 collections dependency/source code (mainly the red-black tree implementation was used) in favor of the .NET built-in generic SortedList 
* Removed Silverlight projects -- this is mainly because I'm not developing anything for Silverlight at the moment and do not want to spend time maintaining it

## How to Build

To be completed

## License

GNU Lesser General Public License (LGPL)
Version 3.0, 29 June 2007