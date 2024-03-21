/* inspired from http://www.rjhcoding.com/avr-asm-delay-subroutine.php */ 

.equ	msInLoop			= 39999	; inner loop value - pode ser 39998 tbm

start:	
	rcall	delay10ms		; call delay subroutine
	ret

delay10ms:
	ldi	r24,LOW(msInLoop)	; intialize inner loop count in inner - 1 cycle
	ldi	r25,HIGH(msInLoop)	; loop high and low registers		  - 1 cycle

iLoop:	
	sbiw	r24, 1			; decrement inner loop registers	- 2 cycles
	brne	iLoop			; innter loop						- 2 true / 1 false - 159991 total
	dec		r18				; decrement outer loop register		- 1 cycle
	brne	delay10ms		; outer loop						- 2 true / 1 false
	nop						; no operation						- 1 cycle
	ret						; return from subroutine			- 4 cycles

delay_us_2:						;R18 must be informed before
	CPI R18, 0					;1
	BREQ end_delay					;1 and 6 (2 breq + 4 ret)  - final case
	NOP NOP NOP NOP NOP	NOP
	dec  R18					;1	
	RJMP delay_us_2				;2

delay_:
	 RET	; 4 cycles RCALL + 4 cycles RET

delay_us:
	NOP NOP NOP NOP NOP NOP NOP NOP	; 8 cycles NOP
	NOP RET	; 4 cycles RCALL + 4 cycles RET

end_delay: RET