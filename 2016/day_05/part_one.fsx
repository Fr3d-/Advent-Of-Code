open System

let input = "abbhdwsy"
let md5 = System.Security.Cryptography.MD5.Create()

let hash (input:string) = 
    input 
    |> System.Text.Encoding.ASCII.GetBytes
    |> md5.ComputeHash
    |> Seq.map (fun c -> c.ToString("x2"))
    |> Seq.toList

let isValidHash l =
    let rec isValidHashAccum l accum =
        match l with
        | _ when accum > 4 ->
            true
        | x::xs when x = "00" ->
            isValidHashAccum xs (accum + 1)
        | _ -> 
            false 

    isValidHashAccum l 0

let rec search (hashList: string list) counter =
    match hashList with
    | x when isValidHash x ->
        (hashList.[5], counter)
    | _ -> 
        let newInput = input + counter.ToString()
        printfn "%A" counter
        search (hash newInput) (counter + 1)

let findHash () =
    let numCharacters = 8

    let rec getPassword password counter num =
        match num with
        | x when x < numCharacters ->
            let (char, c) = search (hash input) counter
            getPassword (char :: password) c (num + 1)
        | _ ->
            password

    getPassword [] 0 0

findHash ()