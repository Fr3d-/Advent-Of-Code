open System
open System.Text.RegularExpressions

let readLines filePath = System.IO.File.ReadLines(filePath)
let lines = readLines "input.txt" |> List.ofSeq

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

let rec traverseLines lines accum =
    match lines with
    | x::xs ->
        match x with
        | Regex @"(\d+)\s+(\d+)\s+(\d+)" [a; b; c] when int a + int b > int c && int a + int c > int b && int c + int b > int a ->
            traverseLines xs (accum + 1)
        | _ -> traverseLines xs accum
    | _ -> accum
        
traverseLines lines 0