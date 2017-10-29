# Name Sorter

## Structure:

1. Main program (console app) in "/name-sorter/name-sorter" is responsible for interfacing with text file (importing contents from text file and exporting contents to text file).
2. Source code library in Person.Name is responsible for handling person names and defining the rule for sorting them, as well as defining the exception class for invalid person names.
3. Test code libray in Person.Name.Test is responsible for unit tests for PersonName class.

## Running Test

In /name-sorter (the main directory), execute: `dotnet test`

## Running Main Program (Console App)

In /name-sorter/name-sorter, execute: `dotnet run ./unsorted-names-list.txt`

## Generating EXE (Assuming Usage for Windows 7 - 64 Bits)

In /name-sorter/name-sorter, execute: `dotnet publish -c release -r win7-x64`

The exe (and the accompanying dependency files) will be generated in `/name-sorter/name-sorter/bin/release/netcoreapp2.0/win7-x64`

The name-sorter.exe can then be used for executing: `name-sorter ./unsorted-names-list.txt`

## Travis:

[Link](https://travis-ci.org/peter-aryanto/name-sorter)
