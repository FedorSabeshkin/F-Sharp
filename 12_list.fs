// upto n = [1; 2; ...; n]
let rec upto = 


let rec dnto_with_accum = function
  | (1, accummulator) -> 1 :: accummulator
  | (n, accummulator) -> n :: accummulator


// downto n = [n; n-1; n-2; ...; 1]
let rec dnto = function
  | 1 -> dnto_with_accum (1, []) 
  | n -> dnto_with_accum (n, (dnto (n-1)))


let rec evenn =