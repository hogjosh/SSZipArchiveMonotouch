XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
MONOBUILD=/Library/Frameworks/Mono.Framework/Commands/xbuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
ROOT=.
XCODE_PROJECT_ROOT=$(ROOT)/SSZipArchive.monotouch
XCODE_PROJECT=$(XCODE_PROJECT_ROOT)/SSZipArchive.monotouch.xcodeproj
XCODE_TARGET=SSZipArchive.monotouch
MONO_PROJECT_ROOT=$(ROOT)/SSZipArchive.binding
MONO_PROJECT=$(MONO_PROJECT_ROOT)/SSZipArchive.binding.csproj

all: clean SSZipArchiveMonotouch.dll

libSSZipArchive.monotouch-i386.a:
	$(XBUILD) -project $(XCODE_PROJECT) -target $(XCODE_TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(XCODE_PROJECT_ROOT)/build/Release-iphonesimulator/lib$(XCODE_TARGET).a $@

libSSZipArchive.monotouch-ios.a:
	$(XBUILD) -project $(XCODE_PROJECT) -target $(XCODE_TARGET) -sdk iphoneos -configuration Release clean build
	-mv $(XCODE_PROJECT_ROOT)/build/Release-iphoneos/lib$(XCODE_TARGET).a $@

libSSZipArchive.monotouch.a: libSSZipArchive.monotouch-i386.a libSSZipArchive.monotouch-ios.a
	lipo -create -output $@ $^

SSZipArchiveMonotouch.dll: libSSZipArchive.monotouch.a
	$(MONOBUILD) /p:Configuration=Release $(MONO_PROJECT)
	-mv $(MONO_PROJECT_ROOT)/bin/Release/SSZipArchiveMonotouch.dll $(ROOT)

clean:
	-rm -rf build *.a *.dll *.mdb
