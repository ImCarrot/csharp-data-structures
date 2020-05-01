# csharp-data-structures
A sample project to demystify the working of the data structures. These are very basic and non optimal implementations of these data structures but are useful to get a jump start on the data structures

> These are just sample implementations and not optimized for production code. In production I'd highly recommend using the DataStructures provided by the development platform since it'll handle a lot of things for you (one example would be calling the `Dispose()` of an object that implements the `IDisposible` interface) when objects are cleared from memory.

#### Questions and Answers

**Question**: Why did we initialize the Array to 0 in the array implementations instead of a fixed size? or why not `null`?

**Answer:** Initializing the array with a fixed size would use up memeory even if there is no data. Did not use `null` for simplicity of code and avoid null checks that would hinder the code readability.

**Question:** Why do we `AddLast()` and `RemoveFirst()` in the Queue implementation using LinkLists? Why not `AddFirst()` and `RemoveLast()`

**Answer:** We do so, because when the calling client uses the `IEnumerable` of the Queue to pull out the data we can directly use the LinkList implementation of the `IEnumerable` instead of writing our own reverse logic.
