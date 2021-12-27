<Query Kind="FSharpProgram">
  <Output>DataGrids</Output>
</Query>

let lines = seq { yield! System.IO.File.ReadLines @"C:\Sources\adventofcode\2021\fsharp\day-1-input.txt" }

let count = 
  lines 
  |> Seq.length

printfn "%i lines" count

let countPairs =
  lines 
  |> Seq.pairwise
  |> Seq.length
  
printfn "%i pairs" countPairs

let countIncrements (x, y) =
    if x = y then 0
    elif x < y then 1
    else 0
    
let getChanges (x, y) =
    if x = y then $"equal"
    elif x < y then $"increase"
    else $"decrease"

let countResult =
  lines 
  |> Seq.pairwise 
  |> Seq.map (fun z -> countIncrements z)
  |> Seq.sum 

printfn $"{countResult} increments"
    
let groupResult =
  lines 
  |> Seq.pairwise 
  |> Seq.map (fun z -> getChanges z)
  |> Seq.countBy (fun c -> c)
  |> Seq.iter (fun c -> printfn $"{c}")
  
  
