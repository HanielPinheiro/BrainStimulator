.equ	A = 0x41 ;primeiro bloco de dados - corrente
.equ	B = 0x42 ;segundo bloco de dados - polaridade
.equ	C = 0x43 ;terceiro bloco de dados - larg pulso
.equ	D = 0x44 ;quarto bloco de dados - intervalo

.equ	S = 0x53 ; segundo
.equ	M = 0x4D ; milissegundo
.equ	U = 0x55 ; microsegundo

.equ	P = 0x50 ;polaridade positiva
.equ	N = 0x4E ;polaridade negativa

ParsingNewData:
	;Lendo dados		
	CPI R22, A
	BREQ printWelcome

	CPI R22, B
	BREQ printWelcome

	CPI R22, C
	BREQ printWelcome

	CPI R22, D
	BREQ printWelcome

	ret


; ------------------------------------------------------------------------
; AssimilateNewData
; ------------------------------------------------------------------------
AssimilateNewData:
	lds r22, countPulses
	LDI r23, maxPulses
	CP r22, r23
	BREQ endRoutine
		
	;Adicionando no vetor e deslocando posicao do vetor
	ldi	XL,LOW(currents)		; initialize X pointer
	ldi	XH,HIGH(currents)		; to currents address	
	ADD XL, R22
	st	X, r16					; store r16 to currents+countPulses
	
	ldi	XL,LOW(polarities)		; initialize X pointer
	ldi	XH,HIGH(polarities)		; to polarities address
	ADD XL, R22
	st	X,r17	
	
	ldi	XL,LOW(pulseLength)		; initialize X pointer
	ldi	XH,HIGH(pulseLength)		; to pulseLength address		
	ADD XL, R22
	st	X,r18	

	ldi	XL,LOW(interpulseLength)		; initialize X pointer
	ldi	XH,HIGH(interpulseLength)		; to interpulseLength address		
	ADD XL, R22
	st	X,r19

	ldi	XL,LOW(interpulseUnity)		; initialize X pointer
	ldi	XH,HIGH(interpulseUnity)		; to currents address
	ADD XL, R22
	st	X,r20	

	ldi	XL,LOW(pulseUnity)		; initialize X pointer
	ldi	XH,HIGH(pulseUnity)		; to pulseUnity address
	ADD XL, R22
	st	X,r21	

	;Atualizando contador
	lds r16, countPulses
	inc R16
	sts countPulses, R16	
	RET

endRoutine:
    RET