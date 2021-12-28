<Query Kind="FSharpProgram">
  <Output>DataGrids</Output>
</Query>

let lines = seq { yield! System.IO.File.ReadLines @"C:\Sources\adventofcode\2021\fsharp\day-2-input.txt" }
  
let experiment (posX, posY, aim) directionInfo =
    let x = match directionInfo with
        | (direction, count) when direction = "forward" -> posX + count, posY + aim * count, aim
        | (direction, count) when direction = "up" -> posX, posY, aim - count
        | (direction, count) when direction = "down" -> posX, posY, aim + count
        | _ -> 0, 0, 0
    printfn $"{directionInfo} {x}"
    x

let xy =
  lines 
  |> Seq.map (fun line -> line.Split " ")
  |> Seq.map (fun line -> line.[0], int(line.[1]))  
  |> Seq.fold(fun (posX, posY, aim) directionInfo -> experiment (posX, posY, aim) directionInfo) (0,0,0)

let print input =
   match input with
    | (x, y, aim) -> printfn $"({x},{y}) {(x*y)}"

print xy