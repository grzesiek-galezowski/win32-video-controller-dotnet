var target = Argument("target", "Default");
var targetSolution = "./Win32VideoControllerInfo/Win32VideoControllerInfo.sln";
var mainProject = "./Win32VideoControllerInfo/Win32VideoControllerInfo/Win32VideoControllerInfo.csproj";
var configuration = "Release";
var nuspec = "Win32VideoControllerInfo.nuspec";

Task("RestoreNugetPackages")
  .Does(() =>
  {
	NuGetRestore(targetSolution);	  
  });

Task("Default")
  .IsDependentOn("PrepareNugetPackage");
  
Task("PrepareNugetPackage")
  .IsDependentOn("Build")
  .Does(() =>
  {
	var settings   = new NuGetPackSettings {
		Id                      = "Win32VideoControllerInfo",
		//Version                 = "0.0.0.1",
		Title                   = "Win32VideoControllerInfo",
		Copyright               = "Grzegorz Gałęzowski 2016",
		ReleaseNotes            = new [] {"Initial Version"},
		Tags                    = new [] {"Win32", "VideoController", "WMI"},
		RequireLicenseAcceptance= false,
		Symbols                 = false,
		NoPackageAnalysis       = true,
		OutputDirectory         = "./nuget",
		ArgumentCustomization = args => args.Append("-Prop Configuration=" + configuration)
	};
	NuGetPack(
       nuspec,
       settings
	);	  
  });
  
Task("Build")
  .IsDependentOn("RestoreNugetPackages")
  .Does(() =>
{
  Information("Started!");
  MSBuild(targetSolution, new MSBuildSettings {
    Verbosity = Verbosity.Minimal,
    ToolVersion = MSBuildToolVersion.VS2015,
    Configuration = configuration,
    PlatformTarget = PlatformTarget.MSIL
    });
});

Task("Clean")
  .Does(() =>
  {
	  
  });



RunTarget(target);