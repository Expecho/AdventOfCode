<Query Kind="FSharpProgram">
  <Output>DataGrids</Output>
</Query>

let lines = seq { yield! System.IO.File.ReadLines @"C:\Sources\adventofcode\2021\fsharp\day-2-input.txt" }

let move positionInfo = 
    match positionInfo with
    | (direction, count) when direction = "forward" -> count, 0
    | (direction, count) when direction = "up" -> 0, count * -1
    | (direction, count) when direction = "down" -> 0, count
    | _ -> 0, 0

let xy =
  lines 
  |> Seq.map (fun line -> line.Split " ")
  |> Seq.map (fun line -> line.[0], int(line.[1]))  
  |> Seq.map (fun positionInfo -> move positionInfo)
  |> Seq.fold(fun (sumX, sumY) position -> sumX + fst(position), sumY + snd(position)) (0,0)

let result = fst(xy) * snd(xy)

printfn $"{xy}"
printfn $"{result}"