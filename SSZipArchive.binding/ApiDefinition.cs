using System;
using MonoTouch.Foundation;

namespace SSZipArchive.monotouch 
{
	[BaseType (typeof (NSObject))]
	public partial interface SSZipArchive 
	{
		[Static, Export ("unzipFileAtPath:toDestination:")]
		bool UnzipFile (string atPath, string toDestination);

		[Static, Export ("unzipFileAtPath:toDestination:overwrite:password:error:")]
		bool UnzipFile (string atPath, string toDestination, bool overwrite, [NullAllowed] string password, [NullAllowed] out NSError error);

		[Static, Export ("unzipFileAtPath:toDestination:delegate:")]
		bool UnzipFile (string atPath, string toDestination, [NullAllowed] ISSZipArchiveDelegate Delegate = null);

		[Static, Export ("unzipFileAtPath:toDestination:overwrite:password:error:delegate:")]
		bool UnzipFile (string atPath, string toDestination, bool overwrite, string password, [NullAllowed] out NSError error, [NullAllowed] ISSZipArchiveDelegate Delegate = null);

		[Static, Export ("createZipFileAtPath:withFilesAtPaths:")]
		bool CreateZipWithFiles (string atPath, string[] filePaths);

		[Static, Export ("createZipFileAtPath:withContentsOfDirectory:")]
		bool CreateZipWithDirectory (string atPath, string directory);

		[Export ("initWithPath:")]
		IntPtr Constructor (string atPath);

		[Export ("open")]
		bool Open();

		[Export ("writeFile:")]
		bool WriteFile (string filePath);

		[Export ("writeData:filename:")]
		bool WriteData (NSData data, string filename);

		[Export ("close")]
		bool Close();
	}

	public interface ISSZipArchiveDelegate { }

	[BaseType (typeof (NSObject))]
	[Model, Protocol]
	public partial interface SSZipArchiveDelegate 
	{
		[Export ("zipArchiveWillUnzipArchiveAtPath:zipInfo:")]
		void ZipArchiveWillUnzipArchive(string atPath, ZipInfo zipInfo);

		[Export ("zipArchiveDidUnzipArchiveAtPath:zipInfo:unzippedPath:")]
		void ZipArchiveDidUnzipArchive(string atPath, ZipInfo zipInfo, string unzippedPath);

		[Export ("zipArchiveWillUnzipFileAtIndex:totalFiles:archivePath:fileInfo:")]
		void ZipArchiveWillUnzipFile(int fileIndex, int totalFiles, string archivePath, ZipInfo fileInfo);

		[Export ("zipArchiveDidUnzipFileAtIndex:totalFiles:archivePath:fileInfo:")]
		void ZipArchiveDidUnzipFile(int fileIndex, int totalFiles, string archivePath, ZipInfo fileInfo);

		[Export ("zipArchiveProgressEvent:total:")]
		void ZipArchiveProgress (int loaded, int total);
	}
}
