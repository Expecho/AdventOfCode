<Query Kind="FSharpProgram">
  <Output>DataGrids</Output>
</Query>

let lines = seq { yield! System.IO.File.ReadLines @"C:\Sources\adventofcode\2021\fsharp\day-1-input.txt" }

let getChanges pair =
    match pair with
    | (prev, current) when current < prev -> "decrease"
    | (prev, current) when current > prev -> "increase"
    | (prev, current) -> "equal"
    
let groupResult =
  lines 
  |> Seq.map (fun z -> int z)
  |> Seq.pairwise 
  |> Seq.map (fun z -> getChanges z)
  |> Seq.countBy (fun c -> c)
  |> Seq.iter (fun c -> printfn $"{c}")
  
  
