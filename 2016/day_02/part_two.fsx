open System

let readLines filePath = System.IO.File.ReadLines(filePath)
let lines = readLines "input.txt" |> Seq.toList
// lines |> Seq.iter(fun x -> printfn "%s\n\n" x)

// This is very stupid.
let up = "52149" |> Seq.toList
let right = "149CD" |> Seq.toList
let down = "5ADC9" |> Seq.toList
let left = "DA521"  |> Seq.toList
let uppest = "A" |> Seq.toList
let upper = "234" |> Seq.toList
let middle = "56789"  |> Seq.toList
let lower = "ABC" |> Seq.toList
let lowest = "D" |> Seq.toList

let changeRep pos =
    let s = sprintf "%x" pos
    s.ToUpper()

let rec canMove direction pos =
    match direction with
    | x::xs when (string x = changeRep pos) -> false
    | x::xs -> canMove xs pos
    | _ -> true
        
let isIn place pos = not (canMove place pos)

let doMove move pos =
    match move with
    | 'U' when (canMove up pos) && ((isIn upper pos) || (isIn lowest pos)) -> pos - 2
    | 'U' when (canMove up pos) -> pos - 4
    | 'R' when (canMove right pos) -> pos + 1
    | 'D' when (canMove down pos) && ((isIn lower pos) || (isIn uppest pos)) -> pos + 2
    | 'D' when (canMove down pos) -> pos + 4
    | 'L' when (canMove left pos) -> pos - 1
    | _ -> pos

let rec moveOnKeypad charList pos =
    match charList with
    | move::rest -> 
        printfn "%c old:%i new:%i" move pos (doMove move pos)
        moveOnKeypad rest (doMove move pos)
    | _ -> pos

let rec getCode strings accum =
    match strings with
    | string::rest ->
        let chars = string |> Seq.toList
        getCode rest (accum @ [moveOnKeypad chars 5])
    | _ -> accum |> List.map (fun x -> changeRep x) |> String.concat ""


match lines with
| string::rest ->
    let chars = string |> Seq.toList
    moveOnKeypad chars 5

//printfn "Password: %A" (getCode lines [])
printfn "%A" (canMove left 12)