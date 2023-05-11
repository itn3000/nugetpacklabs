var Configuration = Argument("Configuration", "Debug");
var Target = Argument("Target", "Default");

Task("Default")
    .IsDependentOn("Pack.Lib1")
    .IsDependentOn("Build.App1")
    ;

Task("Pack.Lib1")
    .Does(() =>
    {
        var setting = new DotNetPackSettings()
        {
            Configuration = Configuration,
            OutputDirectory = "artifacts/packages"
        };
        DotNetPack("lib1/lib1.csproj", setting);
    });
Task("Build.App1")
    .Does(() =>
    {
        var setting = new DotNetBuildSettings()
        {
            Configuration = Configuration
        };
        DotNetBuild("app1/app1.csproj", setting);
    });

RunTarget(Target);