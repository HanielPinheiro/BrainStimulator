#define __SFR_OFFSET 0x00
#include <avr/io.h>

.global delay_100ms
.global delay_us

delay_100ms:
  rcall aux1;
  rcall aux2;
  rcall loops;

loops:  
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    dec   r16               ; 1 ciclo (62,5 ns)
    breq  dec_r17           ; 1 ciclo (62,5 ns)
    rjmp  loops              ; 2 ciclos | TOTAL 32 ciclos
                            ; 250 x 32 = 8000 ciclos

dec_r17:
    dec   r17               ;
    breq  end_100ms         ;
    rcall aux1
    rjmp  loops              ;
                            ; 200 x 8000 = 1600000
                            ; 1.6E6 x 62.5ns = 100ms
end_100ms: 
    ret                     ;retorna
    
aux1: ldi   r16,50           ; 1 ciclo (62,5 ns)
      ret
      
aux2: ldi   r17,10           ; 1 ciclo (62.5 ns)  
      ret
      
delay_us:
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 12 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 12 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 12 ciclo (62,5 ns)
    ret                     ; 4 ciclos(62,5ns);





    
