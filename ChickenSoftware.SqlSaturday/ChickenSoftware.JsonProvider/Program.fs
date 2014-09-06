open System
open FSharp.Data
open Microsoft.FSharp.Data.TypeProviders

type schema = JsonProvider<"http://api.worldbank.org/country/cz/indicator/GC.DOD.TOTL.GD.ZS?format=json">

let runJsonProvider () =
    let context = schema.Load("http://api.worldbank.org/country/cz/indicator/GC.DOD.TOTL.GD.ZS?format=json");
    context.Array |> Seq.iter(fun r ->  Console.WriteLine(String.Format("{0} {1}",r.Date, r.Value)))
    0

let runWorldBankProvider () =
    let context = WorldBankData.GetDataContext()
    let indicators = context.Countries.Mexico.Indicators.``Electricity production from natural gas sources (kWh)``
    let years = indicators.Years
    let values = indicators.Values
    let data' = Seq.zip years values
    data' |> Seq.iter(fun (v,d) -> Console.WriteLine(String.Format("{0} {1}",v, d)))
    0

[<EntryPoint>]
let main argv = 
    runJsonProvider() |> ignore
    //runWorldBankProvider() |> ignore
    Console.ReadKey() |> ignore
    0

