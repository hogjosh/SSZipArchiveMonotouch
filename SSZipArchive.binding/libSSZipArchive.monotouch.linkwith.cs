using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libSSZipArchive.monotouch.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, LinkerFlags = "-lz")]
