using Android.App;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("APPOt.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("OpenFramework")]
[assembly: AssemblyProduct("APPOt.Android")]
[assembly: AssemblyCopyright("Copyright ©OpenFramework 2020")]
[assembly: AssemblyTrademark("Constraula")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]
[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]