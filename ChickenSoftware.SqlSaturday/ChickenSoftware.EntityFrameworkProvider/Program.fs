open System
open System.Data.SqlClient
open Microsoft.FSharp.Data.TypeProviders

type private schema = SqlEntityConnection<"Data Source=DIXON13J\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;">

let ShowCustomers() =
    let context = schema.GetDataContext()
    context.Customers |> Seq.iter(fun c ->  Console.WriteLine(String.Format("{0} {1}",c.ContactTitle, c.ContactName)))
    0

let RunAddAndRemoveACustomer () =
    let context = schema.GetDataContext()
    Console.WriteLine(String.Format("{0} orignial customers in database",context.Customers |> Seq.length))
    let customer = new schema.ServiceTypes.Customers(CustomerID="XXXXX",CompanyName="NewCo",ContactTitle="Boss",ContactName="John Smith",Address="123 Main Street")
    context.Customers.AddObject(customer)
    context.DataContext.SaveChanges() |> ignore
    Console.WriteLine(String.Format("{0} customers in database after add",context.Customers |> Seq.length))
    context.Customers.DeleteObject(customer)
    context.DataContext.SaveChanges() |> ignore
    Console.WriteLine(String.Format("{0} customers in database after delete",context.Customers |> Seq.length))
    0

let RunCustomerTransaction () =
    let context = schema.GetDataContext()
    Console.WriteLine(String.Format("{0} orignial customers in database",context.Customers |> Seq.length))
    context.DataContext.Connection.Open() |> ignore
    let transaction = context.DataContext.Connection.BeginTransaction() 
    let customer = new schema.ServiceTypes.Customers(CustomerID="XXXXX",CompanyName="NewCo",ContactTitle="Boss",ContactName="John Smith",Address="123 Main Street")
    context.Customers.AddObject(customer)
    context.DataContext.SaveChanges() |> ignore
    Console.WriteLine(String.Format("{0} customers in database after add",context.Customers |> Seq.length))
    transaction.Rollback() |> ignore
    Console.WriteLine(String.Format("{0} customers in database after rollback",context.Customers |> Seq.length))

let RunCustomerStoredProcedure () =
    let context = schema.GetDataContext()
    let query = context.DataContext.ExecuteStoreQuery("CustOrderHist",new SqlParameter("CustomerID","AFKLI"))
    query |> Seq.iter(fun (pn,t) -> Console.WriteLine(String.Format("{0} {1}",pn,t)))
    0
       
[<EntryPoint>]
let main argv = 
//    ShowCustomers() |> ignore
//    RunAddAndRemoveACustomer() |> ignore
//    RunCustomerTransaction() |> ignore
//    RunCustomerStoredProcedure() |> ignore
    Console.ReadKey() |> ignore
    0
    

