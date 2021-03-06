module Tests

open System
open Xunit
open System.Diagnostics

[<Fact>]
let ``Year 2020 day 1 part 1`` () =
    let input = "1721,979,366,299,675,1456"
    let expected = 514579L
    let actual = Year2020.Day1.part1 input
    Assert.Equal(expected, actual)

[<Fact>]
let ``Year 2020 day 1 part 2`` () =
    let input = "1721,979,366,299,675,1456"
    let expected = 241861950L
    let actual = Year2020.Day1.part2 input
    Assert.Equal(expected, actual)

[<Fact>]
let ``Year 2020 day 1 solutions`` () =
    Debug.Print(Year2020.Day1.input |> Year2020.Day1.part1 |> fun x -> x.ToString())
    Debug.Print(Year2020.Day1.input |> Year2020.Day1.part2 |> fun x -> x.ToString())

[<Fact>]
let ``Year 2020 day 2 part 1`` () =
    let input = "1-3 a: abcde,1-3 b: cdefg,2-9 c: ccccccccc"
    let expected = 2L
    let actual = Year2020.Day2.part1 input
    Assert.Equal(expected, actual)

[<Fact>]
let ``Year 2020 day 2 part 2`` () =
    let input = "1-3 a: abcde,1-3 b: cdefg,2-9 c: ccccccccc"
    let expected = 1
    let actual = Year2020.Day2.part2 input
    Assert.Equal(expected, actual)

[<Fact>]
let ``Year 2020 day 2 solutions`` () =
    Debug.Print(Year2020.Day2.input |> Year2020.Day2.part1 |> fun x -> x.ToString())
    Debug.Print(Year2020.Day2.input |> Year2020.Day2.part2 |> fun x -> x.ToString())
