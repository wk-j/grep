open System.IO

let acceptFiles = ["*.fs"; "*.fsx"; "*.cs"; "*.csx"; "*.xml"]
let currentDir = DirectoryInfo(".").FullName

let findText (info: FileInfo) text =
    let lines = File.ReadLines(info.FullName)
    let mutable line = 1
    for item in lines do
         if item.Contains(text: string) then
            printfn "%s [%s] %s"  (info.FullName.Replace(currentDir, "").TrimStart('/')) (line.ToString("D4")) item
            line <- line + 1

let rec grep (dir: DirectoryInfo) text =
    if dir.Name = ".node_modules" then ()
    elif dir.Name = "packages" then ()
    else
        let files = acceptFiles |> Seq.map (fun pattern -> dir.GetFiles(pattern)) |> Seq.collect (id)
        for item in files  do
            findText item text
        let dirs = dir.GetDirectories()
        for item in dirs do
            grep item text

[<EntryPoint>]
let main argv =
    let dir = argv.[0]
    let text = argv.[1]
    grep (DirectoryInfo dir) text
    0
