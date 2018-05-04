## Grep

Find text in `.cs` `.fs` `.xml`

## Installation

```bash
dotnet tool install -g wk.Grep
```

## Usage

```bash
wk-grep <DIR> <TEXT>
```

```bash
> wk-grep . "Name"
src/Grep/Program.fs [0001] let currentDir = DirectoryInfo(".").FullName
src/Grep/Program.fs [0002]     let lines = File.ReadLines(info.FullName)
src/Grep/Program.fs [0003]             printfn "%s [%s] %s"  (info.FullName.Replace(currentDir, "").TrimStart('/')) (line.ToString("D4")) item
src/Grep/Program.fs [0004]     if dir.Name = ".node_modules" then ()
src/Grep/Program.fs [0005]     elif dir.Name = "packages" then ()
src/Grep/obj/DotnetToolSettings.xml [0001]     <Command Name="wk-grep" EntryPoint="Grep.dll" Runner="dotnet" />
```