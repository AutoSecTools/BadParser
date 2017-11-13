# BadParser

## Overview

BadParser is a vulnerable parser designed to aid in the testing of fuzzers by simulating different kinds of memory corruption issues. Vulnerabilities are simulated by causing write-access violations at specific addresses, which serve as unique identifiers for the different issues.

Currently BadParser supports JSON and XML input files, with other file formats planned.

The program simulates seven different vulnerabilities:

**0xdead0001** - widget.name buffer overflow

**0xdead0002** - widget.position.x integer overflow

**0xdead0003** - widget.position.y integer underflow

**0xdead0004** - widget.buffer buffer overflow

**0xdead0005** - widget.buffer uninitialized pointer

**0xdead0006** - widget array buffer overflow pointer

**0xdead0007** - widget.variant type confusion

Test files for each issue can be found in the application directory e.g. test_0xdead0001.json or test_0xdead0001.xml.

## Running BadParser

BadParser can be run from the command line by passing a test file to it.

```
c:\tools>BadParser.exe test.json
2 widgets loaded
Foo Widget, { 10, 20 }, Buffer Size=4, Variant=100
Bar Widget, { 100, 55 }, Buffer Size=8, Variant=Hello world
```

Using a debugger such as cdb or windbg, the simulated vulnerabilities can be reproduced with the included test files.

```
c:\tools>c:\debuggers\cdb.exe -g BadParser.exe test_0xdead0001.json

Microsoft (R) Windows Debugger Version 6.3.9600.17029 X86
Copyright (c) Microsoft Corporation. All rights reserved.
[...]
2 widgets loaded
(774.168c): Access violation - code c0000005 (first chance)
First chance exceptions are reported before any exception handling.
This exception may be expected and handled.
eax=00000000 ebx=00daebc8 ecx=00000011 edx=00000000 esi=00000000 edi=00dae880
eip=01620f00 esp=00dae84c ebp=00dae868 iopl=0         nv up ei pl zr na pe nc
cs=0023  ss=002b  ds=002b  es=002b  fs=0053  gs=002b             efl=00010246
01620f00 c7050100addead0bd0ba mov dword ptr ds:[0DEAD0001h],0BAD00BADh ds:002b:dead0001=????????
```

