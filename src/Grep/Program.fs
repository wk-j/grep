open System.IO

let currentDir = DirectoryInfo(".").FullName

let skips = [
    "packages"
    "node_modules"
    "tools"
    ".git"
]

let findText (info: FileInfo) text =
    let lines = File.ReadLines(info.FullName)
    let mutable line = 1
    for item in lines do
         if item.Contains(text: string) then
            printfn " %s [%s] %s"
                (line.ToString("D4"))
                (info.FullName.Replace(currentDir, "").TrimStart('/'))
                (item)
            line <- line + 1

let rec grep (dir: DirectoryInfo) pattern text =
    if skips |> List.exists ((=) dir.Name) then ()
    else
        let files = dir.GetFiles(pattern)
        for item in files  do
            findText item text
        let dirs = dir.GetDirectories()
        for item in dirs do
            grep item pattern text

[<EntryPoint>]
let main argv =
    let pattern = argv.[0]
    let text = argv.[1]
    grep (DirectoryInfo ".") pattern text
    0
