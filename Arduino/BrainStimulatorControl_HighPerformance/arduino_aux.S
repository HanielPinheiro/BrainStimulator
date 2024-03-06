#define __SFR_OFFSET 0x00
#include <avr/io.h>

.global Delay_1ms
.global Delay_1us
.global SetTime_250us

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Set Time -- -
; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =

SetTime_250us:
ldi   r16, 150                ; 1 ciclo (62.5 ns)
ret                           ; 1 ciclo (62.5 ns) 

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Rotinas Delay 1ms -- -
; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
Delay_1ms:
call delay_250us		 			    ; 4000 ciclos (16 ciclos * 250(ate zerar r16) )
call delay_250us		 			    ; 4000 ciclos
call delay_250us		 			    ; 4000 ciclos
call delay_250us		 			    ; 4000 ciclos
ret       	             			; 1 ciclo (62.5 ns)

delay_250us:                 	; sub - rotina de delay de 1ms
nop                      			; 1 ciclo (62, 5 ns)
nop                      			; 2 ciclo (62, 5 ns)
nop                      			; 3 ciclo (62, 5 ns)
nop                      			; 4 ciclo (62, 5 ns)
nop                      			; 5 ciclo (62, 5 ns)
nop                      			; 6 ciclo (62, 5 ns)
nop                      			; 7 ciclo (62, 5 ns)
nop                      			; 8 ciclo (62, 5 ns)
nop                      			; 9 ciclo (62, 5 ns)
nop                      			; 10 ciclo (62, 5 ns)
nop                      			; 11 ciclo (62, 5 ns)
nop                      			; 12 ciclo (62, 5 ns)
nop                      			; 13 ciclo (62, 5 ns)
dec  r16       	    	 			  ; 14 ciclo (62.5 ns)
breq SetTime_250us       			; + 2 ciclos = 16 ciclo (62.5 ns) se r16 = 0 vem aqui
rjmp delay_250us	     	      ; + 2 ciclos = 16 ciclos (62.5 ns) se nao, vem aqui
                              ; 16 ciclos * 62.5ns = 1 us

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Rotinas Delay 1us -- -
Delay_1us:
;nop                     			; 1 ciclo (62, 5 ns)
;nop                     			; 2 ciclo (62, 5 ns)
;nop                     			; 3 ciclo (62, 5 ns)
;nop                     			; 4 ciclo (62, 5 ns)
;nop                     			; 5 ciclo (62, 5 ns)
;nop                     			; 6 ciclo (62, 5 ns)
;nop                     			; 7 ciclo (62, 5 ns)
;nop                     			; 8 ciclo (62, 5 ns)
;nop                     			; 9 ciclo (62, 5 ns)
;nop                     			; 10 ciclo (62, 5 ns)
;nop                     			; 11 ciclo (62, 5 ns)
;nop                     			; 12 ciclo (62, 5 ns)
;nop                     			; 13 ciclo (62, 5 ns)
;nop                     			; 14 ciclo (62, 5 ns)
;nop                     			; 15 ciclo (62, 5 ns)
ret	            					    ; 16 ciclo (62, 5 ns)
                              ; ciclos barrados pra compensar delay da funcao for
