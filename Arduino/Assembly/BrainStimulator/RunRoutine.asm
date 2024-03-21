; ------------------------
; variables
; ------------------------
.equ _OnOff		=	0					;Digital 8
.equ _Clock1	=	3					;Digital 11
.equ _Clock2	=	4					;Digital 12

; ------------------------------------------------------------------------
; defineDigiPotPins
; ------------------------------------------------------------------------
init_controlPins:
  LDI   R21, 0B11111111	
  OUT   DDRB, R21		  ; set port B as out pins
  LDI   R21, 0B00000000	
  OUT   PORTB, R21		  ; set port B as out in pins with low value
  RET

; ------------------------------------------------------------------------
; Control state of digital ports
; ------------------------------------------------------------------------
set_OnOff_on:     
	SBI   PORTB, _OnOff
	RET

set_OnOff_off:    
	CBI   PORTD, _OnOff
	RET

set_Clk1_on:     
	SBI   PORTD, _Clock1
	RET

set_Clk1_off:    
	CBI   PORTD, _Clock1
	RET

set_Clk2_on:     
	SBI   PORTD, _Clock2
	RET

set_Clk2_off:    
	CBI   PORTD, _Clock2
	RET
