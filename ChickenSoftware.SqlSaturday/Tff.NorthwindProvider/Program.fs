open System
open Microsoft.FSharp.Data.TypeProviders

type schema = SqlDataConnection<"Data Source=DIXON13J\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;">

[<EntryPoint>]
let main argv = 
    let context = schema.GetDataContext()
    context.Customers |> Seq.iter(fun c ->  Console.WriteLine(String.Format("{0} {1}",c.ContactTitle, c.ContactName)))
    Console.ReadKey() |> ignore
    0
