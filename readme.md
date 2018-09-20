# RichTea.Common
[![NuGet](https://img.shields.io/nuget/v/RichTea.Common.svg?style=flat)](https://www.nuget.org/packages/RichTea.Common/)

This project is a repository of useful classes:

## Classes
* [EqualsBuilder](Common/Docs/EqualsBuilder.md)
* [HashBuilder](Common/Docs/HashBuilder.md)
* [ToStringBuilder](Common/Docs/ToStringBuilder.md)
* [RandomExtension](Common/Docs/RandomExtension.md)

## Cake Tasks
This project uses [Cake](https://cakebuild.net)!
* cake -target=Clean
* cake -target=Restore-Nuget-Packages
* cake -target=Build
* cake -target=Test

## CI

|        | Windows | Linux |
| ------ | --------|-------|
| Master | [![Build status](https://ci.appveyor.com/api/projects/status/x9xexmpnqvtebcit/branch/master?svg=true)](https://ci.appveyor.com/project/RichTeaMan/common/branch/master) | [![Build Status](https://travis-ci.org/RichTeaMan/Common.svg?branch=master)](https://travis-ci.org/RichTeaMan/Common) |

[![Coverage Status](https://coveralls.io/repos/github/RichTeaMan/Common/badge.svg?branch=master)](https://coveralls.io/github/RichTeaMan/Common?branch=master)
