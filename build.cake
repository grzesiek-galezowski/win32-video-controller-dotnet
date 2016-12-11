var target = Argument("target", "Default");
var targetSolution = "./Win32VideoControllerInfo/Win32VideoControllerInfo.sln";
var mainProject = "./Win32VideoControllerInfo/Win32VideoControllerInfo/Win32VideoControllerInfo.csproj";
var configuration = "Release";

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
		Id                      = "Win32VideoController",
		Version                 = "0.0.0.1",
		Title                   = "Win32 Video Controller",
		Authors                 = new[] {"Grzegorz Gałęzowski"},
		Owners                  = new[] {"Grzegorz Gałęzowski"},
		Description             = "Win32 Video Controller WMI Wrapper",
		Summary                 = "Win32 Video Controller WMI Wrapper",
		ProjectUrl              = new Uri("https://github.com/grzesiek-galezowski/win32-video-controller-dotnet"),
		LicenseUrl              = new Uri("http://opensource.org/licenses/MIT"),
		Copyright               = "Grzegorz Gałęzowski 2016",
		ReleaseNotes            = new [] {"Bug fixes", "Issue fixes", "Typos"},
		Tags                    = new [] {"Win32", "VideoController"},
		RequireLicenseAcceptance= false,
		Symbols                 = false,
		NoPackageAnalysis       = true,
		OutputDirectory         = "./nuget",
		ArgumentCustomization = args => args.Append("-Prop Configuration=" + configuration)
	};
	  
	NuGetPack(
       mainProject,
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