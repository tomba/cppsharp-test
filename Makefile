
LIBDIR=../cppsharp/build/gmake/lib/Release_x64

all: libnative.so Test.exe

libnative.so: native.cpp native.h
	g++ -shared -o libnative.so native.cpp

Gen.exe: libnative.so Gen.cs
	mcs Gen.cs -lib:${LIBDIR} -r:CppSharp -r:CppSharp.AST -r:CppSharp.Generator -r:CppSharp.Runtime -r:CppSharp.Parser.CSharp

native.cs: Gen.exe
	LD_LIBRARY_PATH=${LIBDIR} MONO_PATH=${LIBDIR} mono Gen.exe ./ ./ ./

Test.exe: Test.cs native.cs
	mcs -unsafe Test.cs native.cs

.PHONY: clean runtest

runtest: native.cs Test.exe
	mono Test.exe

clean:
	rm -f libnative.so Gen.exe Test.exe native.cs

