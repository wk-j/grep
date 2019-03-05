## Grep

[![NuGet](https://img.shields.io/nuget/v/wk.Grep.svg)](https://www.nuget.org/packages/wk.Grep)

Search text in files

## Installation

```bash
dotnet tool install -g wk.Grep
```

## Usage

```bash
wk-grep <FILE-PATTERN> <TEXT>
```

```bash
❯❯❯ wk-grep "*.fs" Name
 0001 [src/Grep/Program.fs] let currentDir = DirectoryInfo(".").FullName
 0002 [src/Grep/Program.fs]     let lines = File.ReadLines(info.FullName)
 0003 [src/Grep/Program.fs]                 (info.FullName.Replace(currentDir, "").TrimStart('/'))
 0004 [src/Grep/Program.fs]     if dir.Name = ".node_modules" then ()
 0005 [src/Grep/Program.fs]     elif dir.Name = "packages" then ()
```