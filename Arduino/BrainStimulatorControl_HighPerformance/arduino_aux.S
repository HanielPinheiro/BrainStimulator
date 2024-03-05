#define __SFR_OFFSET 0x00
#include <avr/io.h>

.global InitializeDelayCounterAndSetClockPins

.global Set_Pin8_High
.global Set_Pin8_Low

.global Set_Pin11_High
.global Set_Pin11_Low

.global Set_Pin12_High
.global Set_Pin12_Low

.global Delay_1s
.global Delay_1ms
.global Delay_1us

InitializeDelayCounterAndSetClockPins:
call  setPins						      ; executa SetPins
ret                     			; retorna da sub - rotina

setPins:
call setPins_StimulatorControl_Out
call setTime
ret

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Set Pins Stimulator -- -

setPins_StimulatorControl_Out:
ldi   r18, 0x19      				  ; carrega binario no registrador auxiliar 18
out   DDRB, r18          			; configura PD8 = OnOff / PD11 = Clock1 / PD12 = Clock2
call  Set_Pin8_Low
call  Set_Pin11_Low
call  Set_Pin12_Low
ret

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Set Pins OnOff Stimulator  -- -
Set_Pin8_High:
sbi   PORTB, 0           			; seta o PD8 alto
ret                     			; retorna

Set_Pin8_Low:
cbi   PORTB, 0           			; limpa o PD8 - seta em low
ret                     			; retorna

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Set Pins Clock1 Stimulator  -- -
Set_Pin11_High:
sbi   PORTB, 3           			; seta o PD11 alto
ret                     			; retorna

Set_Pin11_Low:
cbi   PORTB, 3           			; limpa o PD11 - seta em low
ret 								          ; retorna

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
  ; -- - Set Pins Clock2 Stimulator  -- -
Set_Pin12_High:
sbi   PORTB, 4           			; seta o PD12 alto
ret                     			; retorna

Set_Pin12_Low:
cbi   PORTB, 4           			; limpa o PD12 - seta em low
ret 								          ; retorna

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Rotinas do Delay -- -
setTime:
call setTime_1s               ; 2 ciclos (62.5 ns)
call setTime_250us	     			; 2 ciclos (62.5 ns)
ret						 			          ; 1 ciclo (62.5 ns)

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Rotinas Delay 1s -- -
Delay_1s:
call delay_250ms		 			    ; 4001000 ciclos
call delay_250ms		 			    ; 4001000 ciclos
call delay_250ms		 			    ; 4001000 ciclos
call delay_250ms		 			    ; 4001000 ciclos
ret       	             			; 16.004.001 ciclos * (62.5 ns) = 1, 00025 s

setTime_1s:
ldi   r17, 250            		; 1 ciclo (62.5 ns)
ret       	             			; 1 ciclo (62.5 ns)

delay_250ms:                 	; sub - rotina de delay de 1ms
call Delay_1ms		 				    ; 16001 ciclos
dec  r17       	    	 			  ; + 1 ciclo (62.5 ns)
breq setTime_1s       				; + 2 ciclos = 16004 ciclos
rjmp delay_250ms	     			  ; + 2 ciclos = 16004 ciclos
                              ; 16004 ciclos * 62.5ns = 1 ms

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Rotinas Delay 1ms -- -
Delay_1ms:
call delay_250us		 			    ; 4000 ciclos (16 ciclos * 250(ate zerar r16) )
call delay_250us		 			    ; 4000 ciclos
call delay_250us		 			    ; 4000 ciclos
call delay_250us		 			    ; 4000 ciclos
ret       	             			; 1 ciclo (62.5 ns)

setTime_250us:
ldi   r16, 234            		; 1 ciclo (62.5 ns)
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
breq setTime_250us       			; + 2 ciclos = 16 ciclo (62.5 ns) se r16 = 0 vem aqui
rjmp delay_250us	     	      ; + 2 ciclos = 16 ciclos (62.5 ns) se nao, vem aqui
                              ; 16 ciclos * 62.5ns = 1 us

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Rotinas Delay 1us -- -
Delay_1us:
nop                     			; 1 ciclo (62, 5 ns)
nop                     			; 2 ciclo (62, 5 ns)
nop                     			; 3 ciclo (62, 5 ns)
nop                     			; 4 ciclo (62, 5 ns)
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

; == == == == == == == == == == == == == == == == == == == == == == == == == == == == =
; -- - Not used-- -

; -- - Set Pins Digital Potentiometer -- -

SetPins_Digipot_Out:
ldi   r18, 0x1C      			    ; carrega binario no registrador auxiliar 18
out   DDRD, r18          	    ; configura PD2 = INC / PD3 = UD / PD4 = CS como saida
call  Set_Pin2_Low
call  Set_Pin3_Low
call  Set_Pin4_Low
ret

;asmloop:
;call  read_key               ; chama sub - rotina para leitura e ação do teclado
;rjmp  asmloop                ; mantém em loop infinito

;read_key:
;sbis  PIND, 5                ; bit5 PIND está em low ?
;rjmp  led1_on                ; sim, desvia para led1_on
;cbi   PORTD, 7               ; limpa o PD7
;sbis  PIND, 4                ; bit4 PIND está em low ?
;rjmp  led2_on                ; sim, desvia para led2_on
;cbi   PORTD, 6               ; limpa o PD6
;ret


; -- - Set Pins INC Digipot  -- -
Set_Pin2_High:
sbi   PORTD, 2                ; seta o PD2 alto
ret                           ; retorna

Set_Pin2_Low:
cbi   PORTD, 2                ; limpa o PD2 - seta em low
ret                           ; retorna

; -- - Set Pins UD Digipot  -- -
Set_Pin3_High:
sbi   PORTD, 3                ; seta o PD3 alto
ret                           ; retorna

Set_Pin3_Low:
cbi   PORTD, 3                ; limpa o PD3 - seta em low
ret 					                ; retorna

; -- - Set Pins CS Digipot  -- -
Set_Pin4_High:
sbi   PORTD, 4                ; seta o PD4 alto
ret                           ; retorna

Set_Pin4_Low:
cbi   PORTD, 4                ; limpa o PD4 - seta em low
ret 					                ; retorna
