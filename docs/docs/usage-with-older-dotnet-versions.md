---
title: Usage with older .NET Versions
---

If you use this library with .NET versions older than 6.0 you will receive warnings informing you that some dependencies of this packet don't necessarily support your chosen .NET version. The .NET Standard version of this package is tested against .NET Framework 4.8 and older versions (including .NET Core) should work fine as well. You can suppress these warnings by adding the following option to your csproj file:

```xml
<PropertyGroup>
   ...
   <SuppressTfmSupportBuildWarnings>true</SuppressTfmSupportBuildWarnings>
   ...
</PropertyGroup>
```
