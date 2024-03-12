; ------------------------
; variables
; ------------------------
.equ _MIN	=	 0				        ; Min digipot value
.equ _MAX	=	255
.equ _INC	=	2					;Digital 2
.equ _UD	=	3					;Digital 3
.equ _CS	=	4					;Digital 4

; ------------------------------------------------------------------------
; defineDigiPotPins
; ------------------------------------------------------------------------
init_digiPotPins:
  LDI   R21, 0B11111111	
  OUT   DDRD, R21		  ; set port D as out in pins
  LDI   R21, 0B00000000	
  OUT   PORTD, R21		  ; set port D as out in pins with low value

  LDI   R21, _MIN         ; SET MIN to R21 = DIGI POT VALUE
  LDI   R22, _MIN         ; SET MIN to R22 = loop register
  LDI   R23, _MIN         ; SET MIN to R23 = comparison register
  LDI   R24, _MAX          ; SET MAX to R24 = amount register

  RCALL set_ud_off        ; Seta o digipot para decrescer
  RCALL change            ; Zera o digipot (diminui 255 vezes o counter) agora digipot = R21 = 0
  RET

; ------------------------------------------------------------------------
; Control state of digital ports
; ------------------------------------------------------------------------
set_inc_on:     
	SBI   PORTD, _INC
	RET

set_inc_off:    
	CBI   PORTD, _INC
	RET

set_ud_on:     
	SBI   PORTD, _UD
	RET

set_ud_off:    
	CBI   PORTD, _UD
	RET

set_cs_on:     
	SBI   PORTD, _CS
	RET

set_cs_off:    
	CBI   PORTD, _CS
	RET

; ------------------------------------------------------------------------
; Set currents
; ------------------------------------------------------------------------

set_current_650:    
  LDI R23, 58
  RCALL set_amount
  RCALL change                     
  LDI R21, 58  
  RET
  
set_current_600: 
  LDI R23, 54  
  RCALL set_amount
  RCALL change
  LDI R21, 54  
  RET
  
set_current_550: 
  LDI R23, 51  
  RCALL set_amount
  RCALL change
  LDI R21, 51  
  RET
  
set_current_500: 
  LDI R23, 47  
  RCALL set_amount
  RCALL change
  LDI R21, 47  
  RET
  
set_current_450: 
  LDI R23, 43  
  RCALL set_amount
  RCALL change
  LDI R21, 43  
  RET
  
set_current_400: 
  LDI R23, 38  
  RCALL set_amount
  RCALL change
  LDI R21, 38  
  RET
  
set_current_350: 
  LDI R23, 34
  RCALL set_amount
  RCALL change
  LDI R21, 34  
  RET
  
set_current_300: 
  LDI R23, 30  
  RCALL set_amount
  RCALL change
  LDI R21, 30  
  RET
  
set_current_250: 
  LDI R23, 26  
  RCALL set_amount
  RCALL change
  LDI R21, 26  
  RET
  
set_current_200: 
  LDI R23, 22 
  RCALL set_amount
  RCALL change
  LDI R21, 22  
  RET
  
set_current_150: 
  LDI R23, 19  
  RCALL set_amount
  RCALL change
  LDI R21, 19  
  RET
  
set_current_100: 
  LDI R23, 15  
  RCALL set_amount
  RCALL change
  LDI R21, 15  
  RET
  
set_current_50:  
  LDI R23, 11  
  RCALL set_amount
  RCALL change
  LDI R21, 11  
  RET
  
; ------------------------------------------------------------------------
; Compute differences and set amount
; ------------------------------------------------------------------------  
set_amount:
  MOV   R24, R21				; R24 = R21
  CP    R24,R23
  BREQ  end_2					; branch if r24 == R23
  BRSH  compute_dif				; R24 > R23, R24 - R23 (Valor atual > valor solicitado)
  RCALL comput_inv_dif			; R23 > R24, R23 - R24 (Valor solicitado > valor atual)
  RET

compute_dif:                    ; Valor atual (R21/R24) > Valor solicitado (R23)
  SUB    R24,R23                ;R24 e a diferença entre R23 e o valor atual
  RCALL  set_ud_off
  RET

comput_inv_dif:                 ; Valor solicitado (R23) > Valor atual (R21) 
  MOV    R24,R23                ; se R23 > R24 -> R24 = R23 e R23 = R21 (R24)
  MOV    R23,R21                ; R23 = R21(R24)
  SUB    R24,R23                ; R24 e a diferenca entre R23 e o valor atual
  RCALL  set_ud_on
  RET

  end_2: RET
; ------------------------------------------------------------------------
; Change
; ------------------------------------------------------------------------
change:
	; Ja chega aqui com a flag digitalWrite(DIGIPOT_UD_PIN, direction) definida
	RCALL set_inc_on            ;  digitalWrite(DIGIPOT_INC_PIN, HIGH)
	RCALL set_cs_off            ;  digitalWrite(DIGIPOT_CS_PIN, LOW)  
	CLR R22
Loop1: 
	CP R22,R24
	BREQ next
		   
	RCALL set_inc_off            ;  digitalWrite(DIGIPOT_INC_PIN, LOW)  
	LDI	  R18, 2
	RCALL delay_us_2
	RCALL set_inc_on             ;  digitalWrite(DIGIPOT_INC_PIN, HIGH)  
	RCALL delay_us
	RCALL delay_us
	   
	INC R22
	   
	RJMP Loop1

next:
  RCALL set_cs_on             ; digitalWrite(DIGIPOT_CS_PIN, HIGH) fim do for loop   
  RET