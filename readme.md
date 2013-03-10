IP.i4o - Index for objects
=======================

IP.i4o (index for objects) enhances the i4o library (<https://github.com/ericksoa/i4o>) from which it was forked. This library was renamed as well in order to prevent confusion if, for example, both this and the original were to appear on NuGet.

## Project
[ipashchuk.github.com/IP.i4o](http://ipashchuk.github.com/IP.i4o)

## Key Features

* Allows indexes to be added to collections to optimize LINQ queries since, by default, LINQ queries collection items sequentially. Specifically, this is achieved by adding either a comparison or an equality index, which have O(log n) or O(1) operation, respectively.
<pre>Standard (unoptimized) LINQ queries: **O(n)**
LINQ queries with comparison index: **O(log n)**
LINQ queries with equality index: **O(1)**</pre>

### Enhancements/changes to i4o

* Optimized inefficient index queries whereby the binary search was performed twice: first to check if the key existed and again to look up the key/value
* Removed c5 collections dependency/source code (it was used by i40 primarily for its red-black tree implementation and helper methods for selecting ranges) in favor of the .NET built-in generic `SortedList<TKey,TValue>` (the range selection functionality was implemented via `SortedList<TKey,TValue>` extension methods).
* Removed Silverlight projects -- this is mainly because I'm not developing anything for Silverlight at the moment and do not want to spend time maintaining it.

## Documentation

* [github.com/ipashchuk/IP.i4o/wiki](https://github.com/ipashchuk/IP.i4o/wiki)

## Milestones/issues

* [github.com/ipashchuk/IP.i4o/issues>](https://github.com/ipashchuk/IP.i4o/issues)

## How to get it

* A beta should soon be available on NuGet.
* Download/fork the source and build.

## License

GNU Lesser General Public License (LGPL), Version 3.0, 29 June 2007