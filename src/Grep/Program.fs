open System.IO

let currentDir = DirectoryInfo(".").FullName

let skips = [
    "packages"
    "node_modules"
    "tools"
    ".git"
]

let findText (info: FileInfo) text =
    let fullName = info.FullName
    let mutable lineNumber = 1
    let lines = File.ReadLines fullName
    lines |> Seq.iter (fun item ->
        if item.Contains(text: string) then
            printfn " %s [%s] %s"
                (lineNumber.ToString("D4"))
                (fullName.Replace(currentDir, "").TrimStart('/'))
                (item)
            lineNumber <- lineNumber + 1
    )

let rec grep (dir: DirectoryInfo) pattern text =
    if skips |> List.exists ((=) dir.Name) then ()
    else
        dir.GetFiles(pattern)
        |> Seq.iter (fun item ->  findText item text)

        dir.GetDirectories()
        |> Seq.iter (fun item -> grep item pattern text)

[<EntryPoint>]
let main argv =
    let pattern = argv.[0]
    let text = argv.[1]
    grep (DirectoryInfo ".") pattern text
    0
