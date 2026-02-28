# ProgFunc
Exercícios da disciplina eletiva de Programação Funcional

Para criar um projeto em F# é necessário rodar no terminal o comando

```bash
dotnet new console --language F# -o MeuProjeto
cd MeuProjeto
```

Para testar se de fato o projeto foi, rodar no terminal dentro da pasta do projeto

```bash
dotnet run
```

No terminal deve aparecer 

```bash
Hello from F#
```

Quando criar um arquivo novo dentro do projeto, é importante adicionar esse arquivo no compilador da mesma forma que Program.fs está adicionado. Caso o arquivo novo utilizar algo que está no Program.fs, é necessário que o Program.fs seja compilado primeiro, ou seja, esteja acima na lista.

Quando testar no terminal um arquivo program.fs, declarar no topo deste algo como: 

```fsharp
module Program
```

No terminal: 

```bash
dotnet fsi
> load "Program.fs";;
> open Program;;
> calcularHash 5 10;;
```

---

## Resumo das Principais Sintaxes do F#

### 1. Comentários

```fsharp
// Comentário de linha única

(* Comentário
   de múltiplas linhas *)
```

---

### 2. Declaração de Valores (`let`)

Em F#, valores são imutáveis por padrão.

```fsharp
let nome = "F#"
let idade = 25
let pi = 3.14159
```

---

### 3. Tipos Básicos

| Tipo      | Exemplo                  |
|-----------|--------------------------|
| `int`     | `let x = 42`             |
| `float`   | `let f = 3.14`           |
| `string`  | `let s = "olá"`          |
| `bool`    | `let b = true`           |
| `char`    | `let c = 'A'`            |
| `unit`    | `let u = ()`             |

---

### 4. Funções

Funções são definidas com `let`. F# usa **currying** por padrão (cada argumento é aplicado um a um).

```fsharp
// Função simples
let somar a b = a + b
let resultado = somar 3 5  // resultado = 8

// Função com tipo explícito
let multiplicar (x: int) (y: int) : int = x * y

// Função anônima (lambda)
let dobrar = fun x -> x * 2

// Função recursiva
let rec fatorial n =
    if n <= 1 then 1
    else n * fatorial (n - 1)
```

---

### 5. Expressões Condicionais

`if/elif/else` é uma expressão e sempre retorna um valor.

```fsharp
let classificar nota =
    if nota >= 7.0 then "Aprovado"
    elif nota >= 5.0 then "Recuperação"
    else "Reprovado"
```

---

### 6. Pattern Matching

Equivalente ao `switch`, mas muito mais poderoso.

```fsharp
let descrever n =
    match n with
    | 0 -> "zero"
    | 1 -> "um"
    | x when x < 0 -> "negativo"
    | _ -> "outro número"

// Pattern matching em tuplas
let coordenada ponto =
    match ponto with
    | (0, 0) -> "origem"
    | (x, 0) -> sprintf "eixo X em %d" x
    | (0, y) -> sprintf "eixo Y em %d" y
    | (x, y) -> sprintf "ponto (%d, %d)" x y
```

---

### 7. Tuplas

```fsharp
let par = (1, "um")
let (numero, texto) = par  // Desestruturação

let tripla = (1, 2, 3)
let (a, b, c) = tripla
```

---

### 8. Listas

Listas em F# são imutáveis e encadeadas (linked lists).

```fsharp
let numeros = [1; 2; 3; 4; 5]
let vazia = []
let comCabeca = 0 :: numeros  // [0; 1; 2; 3; 4; 5]
let concatenada = [1; 2] @ [3; 4]  // [1; 2; 3; 4]

// Head e Tail
let primeiro = List.head numeros  // 1
let resto = List.tail numeros     // [2; 3; 4; 5]

// Funções de lista
let dobrados = List.map (fun x -> x * 2) numeros      // [2; 4; 6; 8; 10]
let pares = List.filter (fun x -> x % 2 = 0) numeros  // [2; 4]
let soma = List.fold (+) 0 numeros                     // 15
```

---

### 9. Arrays

Arrays são mutáveis e de acesso aleatório rápido.

```fsharp
let arr = [| 1; 2; 3; 4; 5 |]
let terceiro = arr.[2]  // 3
arr.[0] <- 10           // Mutação permitida em arrays
```

---

### 10. Sequências (`seq`)

Sequências são avaliadas de forma preguiçosa (lazy).

```fsharp
let seq1 = seq { 1 .. 10 }
let pares = seq { for i in 1..20 do if i % 2 = 0 then yield i }
```

---

### 11. Records

Records são tipos de dados imutáveis com campos nomeados.

```fsharp
type Pessoa = {
    Nome: string
    Idade: int
}

let p1 = { Nome = "Ana"; Idade = 30 }

// Cópia com atualização
let p2 = { p1 with Idade = 31 }

printfn "%s tem %d anos" p1.Nome p1.Idade
```

---

### 12. Unions Discriminadas (Discriminated Unions)

Permitem representar um valor que pode ser de diferentes formas.

```fsharp
type Forma =
    | Circulo of float
    | Retangulo of float * float
    | Triangulo of float * float * float

let area forma =
    match forma with
    | Circulo r -> System.Math.PI * r * r
    | Retangulo (l, a) -> l * a
    | Triangulo (b, h, _) -> b * h / 2.0
```

---

### 13. Option

`Option` é usado para representar valores que podem ou não existir (evita `null`).

```fsharp
let dividir a b =
    if b = 0 then None
    else Some (a / b)

match dividir 10 2 with
| Some resultado -> printfn "Resultado: %d" resultado
| None -> printfn "Divisão por zero!"
```

---

### 14. Pipe Operator (`|>`)

O operador `|>` passa o resultado de uma expressão como último argumento da próxima função.

```fsharp
let resultado =
    [1; 2; 3; 4; 5]
    |> List.filter (fun x -> x % 2 <> 0)  // [1; 3; 5]
    |> List.map (fun x -> x * x)           // [1; 9; 25]
    |> List.sum                             // 35
```

---

### 15. Composição de Funções (`>>` e `<<`)

```fsharp
let dobrar x = x * 2
let incrementar x = x + 1

let dobrarEIncrementar = dobrar >> incrementar
let resultado = dobrarEIncrementar 5  // (5 * 2) + 1 = 11
```

---

### 16. Mutabilidade

Por padrão, tudo é imutável. Use `mutable` para permitir mudança.

```fsharp
let mutable contador = 0
contador <- contador + 1
printfn "Contador: %d" contador  // Contador: 1
```

---

### 17. Loops

```fsharp
// for com range
for i in 1..5 do
    printfn "%d" i

// for em lista
for item in ["a"; "b"; "c"] do
    printfn "%s" item

// while
let mutable i = 0
while i < 5 do
    printfn "%d" i
    i <- i + 1
```

---

### 18. Classes e Interfaces

F# também suporta programação orientada a objetos.

```fsharp
type Animal(nome: string, som: string) =
    member this.Nome = nome
    member this.FazerSom() = printfn "%s faz %s" nome som

let cachorro = Animal("Rex", "au au")
cachorro.FazerSom()  // Rex faz au au

// Interface
type IVoador =
    abstract member Voar: unit -> string

type Passaro(nome: string) =
    interface IVoador with
        member _.Voar() = sprintf "%s está voando!" nome
```

---

### 19. Módulos

Módulos organizam funções e tipos relacionados.

```fsharp
module Matematica =
    let quadrado x = x * x
    let cubo x = x * x * x

let q = Matematica.quadrado 4  // 16
let c = Matematica.cubo 3      // 27
```

---

### 20. Impressão e Formatação

```fsharp
printfn "Olá, %s! Você tem %d anos." "Maria" 25
printf "Sem nova linha"
printfn ""

// sprintf retorna uma string
let mensagem = sprintf "Pi é aproximadamente %.2f" 3.14159
printfn "%s" mensagem  // Pi é aproximadamente 3.14
```

---

### Referências

- [Documentação oficial do F#](https://learn.microsoft.com/pt-br/dotnet/fsharp/)
- [Tour do F#](https://learn.microsoft.com/pt-br/dotnet/fsharp/tour)
- [F# for Fun and Profit](https://fsharpforfunandprofit.com/)
