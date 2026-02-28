// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
// Função que define a chave conforme a regra FizzBuzz (Slide 21)
let fizzBuzzKey n =
    match (n % 3 = 0, n % 5 = 0) with
    | (true, true)  -> "FizzBuzz"
    | (true, false) -> "Fizz"
    | (false, true) -> "Buzz"
    | _             -> "Comum"

// Implementação manual do groupBy (Slide 21)
let myGroupBy projection list =
    let folder acc item =
        let key = projection item
        match Map.tryFind key acc with
        | Some existingList -> Map.add key (existingList @ [item]) acc
        | None              -> Map.add key [item] acc
    
    List.fold folder Map.empty list

// Teste
let numeros = [1..20]
let resultadoFB = myGroupBy fizzBuzzKey numeros

