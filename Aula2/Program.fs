module Exercicios

// 1. Hash simples: h(x) = (x^2 mod n)
let calcularHash x n = (x * x) % n

// 2. Maior de três números (usando a função interna max)
let maiorDeTres a b c = max a (max b c)

// 3. Soma dos dígitos (Recursiva)
let rec somaDigitos n =
    let nAbs = abs n
    if nAbs < 10 then nAbs
    else (nAbs % 10) + somaDigitos (nAbs / 10)

// 4. Tribonacci: T(n) = T(n-1) + T(n-2) + T(n-3)
// Casos base: T(0)=0, T(1)=0, T(2)=1
let rec tribonacci n =
    if n = 0 then 0
    elif n = 1 then 0
    elif n = 2 then 1
    else tribonacci (n - 1) + tribonacci (n - 2) + tribonacci (n - 3)

// 5. Verificar se é primo (Auxiliar para o próximo exercício)
let ehPrimo n =
    let nAbs = abs n
    if nAbs < 2 then false
    else
        let rec verificar divisor =
            if divisor * divisor > nAbs then true
            elif nAbs % divisor = 0 then false
            else verificar (divisor + 1)
        verificar 2

// 6. Retorna o próximo primo
let rec proximoPrimo n =
    if ehPrimo (n + 1) then n + 1
    else proximoPrimo (n + 1)

// 7. Função que recebe prefixo e retorna uma função (Lambda/Closure)
// Conforme slide 23: let inc f = fun x -> (f x) + 1
let criarPrefixador prefixo = 
    fun (texto: string) -> prefixo + texto
