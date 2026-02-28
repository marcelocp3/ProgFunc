// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let describe_number n =
    match n with
    | 1 -> "um"
    | 2 -> "dois"
    | 3 -> "três"
    | 4 -> "quatro"
    | 5 -> "cinco"
    | _ -> "outro" // O '_' captura qualquer outro caso [cite: 263]

let compararTupla ponto =
    match ponto with
    | (x, y) when x = y -> "x e y são iguais"
    | (x, y) when x > y -> "x é maior"
    | (x, y) -> "y é maior" // Se não caiu nos acima, y é maior

// 3. Quantidade de elementos (Recursivo com Pattern Matching) [cite: 292, 293, 295]
let rec contarElementos lista =
    match lista with
    | [] -> 0
    | _ :: cauda -> 1 + contarElementos cauda

// 4. Maior elemento
let rec maiorElemento lista =
    match lista with
    | [] -> failwith "Lista vazia"
    | [x] -> x
    | h :: t -> max h (maiorElemento t)

// 5. Segundo maior elemento
let segundoMaior lista =
    match List.sortDescending lista with
    | _ :: segundo :: _ -> segundo
    | _ -> failwith "Lista muito curta"

// 7. Definição do Record atualizado [cite: 339, 370]
type Person = { name: string; age: int; country: string; email: string option }

// 6. Verificar maioridade [cite: 360]
let ehMaiorDeIdade person =
    if person.age >= 18 then "Maior de idade" else "Menor de idade"

// 7. Verificar se e-mail existe
let temEmail person =
    match person.email with
    | Some e -> sprintf "E-mail existe: %s" e
    | None -> "Não possui e-mail"

let rec update_all lista alvo novoValor =
    match lista with
    | [] -> []
    | h :: t -> 
        let novoH = if h = alvo then novoValor else h
        novoH :: update_all t alvo novoValor