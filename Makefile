
LIBDIR=../cppsharp/build/gmake/lib/Release_x64

all: libnative.so Test.exe

native.o: native.h
	g++ -Wall -g -fPIC -c -o native.o native.cpp

libnative.so: native.o
	g++ -Wall -shared -o libnative.so native.o

libnative.a: native.o
	ar rcs libnative.a native.o

Gen.exe: libnative.so libnative.a Gen.cs
	mcs Gen.cs -lib:${LIBDIR} -r:CppSharp -r:CppSharp.AST -r:CppSharp.Generator -r:CppSharp.Runtime -r:CppSharp.Parser.CSharp

native.cs: Gen.exe
	LD_LIBRARY_PATH=${LIBDIR} MONO_PATH=${LIBDIR} mono Gen.exe ./ ./ ./

Test.exe: Test.cs native.cs
	mcs -unsafe Test.cs native.cs

.PHONY: clean runtest

runtest: native.cs Test.exe
	mono Test.exe

clean:
	rm -f *.so *.a *.o *.exe native.cs

