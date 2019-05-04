#addin "nuget:https://api.nuget.org/v3/index.json?package=Cake.Coveralls&version=0.10.0"
#tool "nuget:https://api.nuget.org/v3/index.json?package=coveralls.io&version=1.4.2"
#tool "nuget:https://api.nuget.org/v3/index.json?package=OpenCover&version=4.7.922"
#tool "nuget:https://api.nuget.org/v3/index.json?package=ReportGenerator&version=4.1.4"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var coverallsToken = Argument("coverallsToken", string.Empty);

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectories("./**/bin/**");
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreRestore("./Common.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreBuild("./Common.sln", new DotNetCoreBuildSettings {
    Verbosity = DotNetCoreVerbosity.Minimal,
    Configuration = configuration
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
     var settings = new DotNetCoreTestSettings
     {
         Configuration = configuration,
        ArgumentCustomization = args=>args.Append("/p:CollectCoverage=true /p:CoverletOutputFormat=opencover")
     };
    DotNetCoreTest("Common.Tests/Common.Tests.csproj", settings);
});

Task("Appveyor")
    .IsDependentOn("Test")
    .Does(() =>
{
    CoverallsIo("Common.Tests/coverage.opencover.xml", new CoverallsIoSettings()
    {
        RepoToken = coverallsToken
    });

});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Test");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
