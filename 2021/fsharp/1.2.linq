<Query Kind="FSharpProgram">
  <Output>DataGrids</Output>
</Query>

let lines = seq { yield! System.IO.File.ReadLines @"C:\Sources\adventofcode\2021\fsharp\day-1-input.txt" }

let getChange pair =
    match pair with
    | (prev, current) when current < prev -> "decrease"
    | (prev, current) when current > prev -> "increase"
    | _ -> "equal"
    
let groupResult =
  lines 
  |> Seq.map (fun line -> int line)
  |> Seq.windowed 3
  |> Seq.map (fun window -> window.Sum())
  |> Seq.pairwise 
  |> Seq.map (fun pair -> getChange pair)
  |> Seq.countBy (fun change -> change)
  |> Seq.iter (fun change -> printfn $"{change}")
  
  
