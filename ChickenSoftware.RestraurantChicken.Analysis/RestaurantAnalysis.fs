namespace ChickenSoftware.RestraurantChicken.Analysis

open System.Linq
open System.Configuration
open Microsoft.FSharp.Linq
open Microsoft.FSharp.Data.TypeProviders

type internal SqlConnection = SqlEntityConnection<ConnectionStringName="azureData">

type public RestaurantAnalysis () =
    
    let connectionString = ConfigurationManager.ConnectionStrings.["azureData"].ConnectionString;
    
    member public x.GetAverageScoreByMonth () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.InspectionDate.Value.Month, x.InspectionScore.Value)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort

    member public x.AverageScoreByDay () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.InspectionDate.Value.Day, x.InspectionScore.Value)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort

    member public x.AverageScoreByDayOfWeek () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.InspectionDate.Value.DayOfWeek, x.InspectionScore.Value)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort

    member public x.AverageScoreByHour () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.InspectionDate.Value.Hour, x.InspectionScore.Value)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort

    member public x.AverageScoreByMorningAfternoon () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.InspectionDate.Value.Hour, x.InspectionScore.Value)
            |> Seq.map(fun x -> match fst x with
                                    | h when h < 12 -> "AM", snd x
                                    | _ -> "PM", snd x)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort

    
    member public x.AverageScoreByInspector () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            //|> Seq.filter(fun x -> x.EstablishmentName <> "Test Facility")
            |> Seq.map(fun x -> x.InspectorID, x.InspectionScore.Value)
            //|> Seq.filter(fun x -> fst x <> null)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort


    member public x.AverageScoreByEstablishmentType () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.EstablishmentTypeDesc, x.InspectionScore.Value)
            |> Seq.groupBy(fun x -> fst x)
            |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
            |> Seq.map(fun (x,y) -> x, System.Math.Round(y,2))
            |> Seq.toArray
            |> Array.sort

    member public x.AverageScoreForChineseRestaurants () =
        SqlConnection.GetDataContext(connectionString).Restaurants
            |> Seq.map(fun x -> x.EstablishmentName, x.InspectionScore.Value)
            |> Seq.filter(fun r -> x.IsEstablishmentAChineseRestraurant(fst r))
            |> Seq.averageBy(fun r -> snd(r))


    member public x.AverageScoresOfChineseAndNonChineseByInspector () =
        let dataSet = SqlConnection.GetDataContext(connectionString).Restaurants
                        |> Seq.map(fun x -> x.EstablishmentName, x.InspectorID,x.InspectionScore.Value)
        let chineseRestraurants = dataSet
                                    |> Seq.filter(fun (a,b,c) -> x.IsEstablishmentAChineseRestraurant(a))
                                    |> Seq.map(fun (a,b,c) -> b,c)
                                    |> Seq.groupBy(fun x -> fst x)
                                    |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
                                    |> Seq.toArray
                                    |> Array.sort
        let nonChineseRestraurants = dataSet
                                    |> Seq.filter(fun (a,b,c) -> not(x.IsEstablishmentAChineseRestraurant(a)))
                                    |> Seq.map(fun (a,b,c) -> b,c)
                                    |> Seq.groupBy(fun x -> fst x)
                                    |> Seq.map(fun (x,y) -> (x,y |> Seq.averageBy snd))
                                    |> Seq.toArray
                                    |> Array.sort
        Seq.zip chineseRestraurants nonChineseRestraurants
               |> Seq.map(fun ((a,b),(c,d)) -> a,System.Math.Round(b,2),System.Math.Round(d,2))
               |> Seq.toList
    
    member public x.IsEstablishmentAChineseRestraurant (establishmentName:string) =
        let upperCaseEstablishmentName = establishmentName.ToUpper()
        let numberOfMatchedWords = upperCaseEstablishmentName.Split(' ')
                                    |> Seq.map(fun x -> match x with
                                                            | "ASIA" -> 1
                                                            | "ASIAN" -> 1
                                                            | "CHINA" -> 1
                                                            | "CHINESE" -> 1
                                                            | "GARDEN" -> 1
                                                            | "PANDA" -> 1
                                                            | "WOK" -> 1
                                                            | _ -> 0)
                                    |> Seq.sum
        match numberOfMatchedWords with
            | 0 -> false
            | _ -> true


    member public x.Variance (source: System.Collections.Generic.List<double>) =
        let mean = Seq.average source
        let deltas = Seq.map(fun x -> pown(x-mean) 2) source
        Seq.average deltas
        