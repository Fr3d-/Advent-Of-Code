open System

let readLines filePath = System.IO.File.ReadLines(filePath)
let lines = readLines "input.txt" |> Seq.toList
// lines |> Seq.iter(fun x -> printfn "%s\n\n" x)

let up = "52149"
let right = "149CD"
let down = "5ADC9"
let left = "DA521"

let doMove move pos =
    match move with
    | 'U' when pos - 3 > 0 -> pos - 3
    | 'R' when not (pos % 3 = 0) -> pos + 1
    | 'D' when pos + 3 < 10 -> pos + 3
    | 'L' when not (pos % 3 = 1) -> pos - 1
    | _ -> pos

let rec moveOnKeypad charList pos =
    match charList with
    | move::rest -> moveOnKeypad rest (doMove move pos)
    | _ -> pos

let rec getCode strings accum =
    match strings with
    | string::rest ->
        let chars = string |> Seq.toList
        getCode rest (accum @ [moveOnKeypad chars 5])
    | _ -> accum |> List.map (fun x -> string x) |> String.concat ""

printfn "Password: %s" (getCode lines [])