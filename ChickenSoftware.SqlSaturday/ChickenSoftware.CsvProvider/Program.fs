open System
open FSharp.Data

type schema = CsvProvider<"http://ichart.finance.yahoo.com/table.csv?s=MSFT">

[<EntryPoint>]
let main argv = 
    let context = schema.Load("http://ichart.finance.yahoo.com/table.csv?s=MSFT")
    context.Rows 
        |> Seq.take(20)
        |> Seq.iter(fun r -> Console.WriteLine(String.Format("{0} {1}",r.Date, r.``Adj Close``)))
    Console.ReadKey() |> ignore
    0
