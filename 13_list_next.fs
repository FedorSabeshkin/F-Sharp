
let rec get_odd_with_accum = function
  | (head :: tail, currentRound, maxRound, accumulator) when currentRound < maxRound -> 
    if(currentRound % 2 = 1)  
    then get_odd_with_accum(tail, currentRound+1, maxRound, head :: accumulator)
    else get_odd_with_accum(tail, currentRound+1, maxRound, accumulator)
  | ([head], currentRound, maxRound, accumulator) -> 
    if(currentRound % 2 = 1)  
    then head :: accumulator
    else accumulator
  | ([ ], currentRound, maxRound, accumulator) -> 
    accumulator
    
// Оставить только значения на нечетных позициях
let rec rmodd = function
  | [] -> []
  | list -> 
    let odd_item_list = get_odd_with_accum (list, 0, (List.length list), [])
	List.rev odd_item_list

let rec del_even_with_accum = function
  | (head :: tail, accumulator) -> 
    if(head % 2 = 1)  
    then del_even_with_accum(tail, head :: accumulator)
    else del_even_with_accum(tail, accumulator)
  | ([head], accumulator) -> 
    if(head % 2 = 1)  
    then head :: accumulator
    else accumulator
  | ([ ], accumulator) -> 
    accumulator
    
// Вернуть только нечетные значения 
let rec del_even =  function
  | [] -> []
  | list -> 
    let odd_item_list = del_even_with_accum (list, [])
    List.rev odd_item_list

let rec multiplicity_with_accum = function
  | (search_value, head :: tail, amount) -> 
    if(head = search_value)  
    then multiplicity_with_accum(search_value, tail, amount+1)
    else multiplicity_with_accum(search_value, tail, amount)
  | (search_value, [head], amount) -> 
    if(head = search_value)  
    then amount + 1
    else amount
  | (search_value, [ ], amount) -> 
    amount
    
// Вычисляет число повторений элемента "x" в списке "xs"
let rec multiplicity x xs = match xs with
  | [] -> 0
  | _  -> 
    multiplicity_with_accum (x, xs, 0)


let rec split = function
  | [] -> ([], [])
  | [x] -> ([x], [])
  | first :: (second :: tail) ->
        let (a, b) = split tail
        (first :: a, second :: b)


let rec zip = function
  | ([], []) -> []
  | (h1 :: t1, h2 :: t2) -> (h1, h2) :: zip(t1, t2)
  | _ -> failwith "different lengths"
