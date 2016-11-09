# BadParser

BadParser is intended to aid in the testing of fuzzers by simulating different kinds of memory corruption vulnerabilities found in parsers. Vulnerabilities are simulated by causing write-access violations at specific addresses, which serve as unique identifiers.

Currently BadParser only supports JSON input files, but other file formats are planned.

**0xdead0001** - widget.name buffer overflow

**0xdead0002** - widget.position.x integer overflow

**0xdead0003** - widget.position.y integer underflow

**0xdead0004** - widget.buffer buffer underflow

**0xdead0005** - widget.buffer uninitialized pointer

**0xdead0006** - widget array buffer pointer

**0xdead0007** - widget.variant type confusion