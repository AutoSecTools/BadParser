@echo off
pushd .

set dbg="c:\Program Files (x86)\Windows Kits\10\Debuggers\x64\cdb.exe"
set log=out.log
cd c:\source\BadParser\bin

if exist %log% do del %log%
::%dbg% -g -c "q" BadParser.exe test_0xdead0001.json 

::for %%e in (json xml) do for /f %%i in ('dir test_*.%%e /b') do (
for %%b in (32 64) do for /f %%i in ('dir test_0x* /oe /on /b') do (
    echo ========================================================
    echo Testing %%i with %%b-bit executable
    echo ========================================================
    %dbg% -g -c "q" BadParser%%b.exe %%i >> %log%
)
::? ['','`']-^<@(t) 0..8-^>@(n)format('{0}dead{1:X4}', t, n.int())
popd
@echo on