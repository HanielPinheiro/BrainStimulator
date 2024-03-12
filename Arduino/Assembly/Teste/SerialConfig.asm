; ------------------------
; variables
; ------------------------
.equ	baud	=	115200							; baudrate
.equ	bps		=	(F_CPU/16/baud) 				; baud prescale

welcome:	.db	"Stimulator is ready", 0x0D, 0x0A, 0x00			; save char array in pmem with final char null(0x00)

;------------------------------------------------------------------------
; init_serial:
;------------------------------------------------------------------------
init_serial:
  LDI	r16,LOW(bps)						; load baud prescale
  LDI	r17,HIGH(bps)						; into r17:r16
  
  STS	UBRR0L,r16							; load baud prescale
  STS	UBRR0H,r17							; to UBRR0
  
  LDI	R16,(1<<RXEN0)|(1<<TXEN0)			; enable transmitter
  STS	UCSR0B,R16							; and receiver  

  ldi r16, (1<<USBS0)|(3<<UCSZ00) 
  STS UCSR0C,r16
  rcall	printWelcome						; transmit string  
  RET

;------------------------------------------------------------------------
; print routines
;------------------------------------------------------------------------
printWelcome: 
	ldi		ZL,LOW(2*welcome)			; load Z pointer with data
	ldi		ZH,HIGH(2*welcome)			; it's multiplying by 2 because the words are stored in 8bits so need to be translated to 16bits
	RCALL	print_serial_const
	RET

;------------------------------------------------------------------------
; print constants in z(pmem):
;------------------------------------------------------------------------
print_serial_const:	
	lds		r17,UCSR0A					; load UCSR0A into r17
	sbrs	r17,UDRE0					; wait for empty transmit buffer
	rjmp	print_serial_const			; repeat loop
	
	lpm		r16,Z+						; load character from pmem
	cpi		r16,0x00					; check if null
	breq	end_serial					; branch if null

	sts		UDR0,r16					; transmit character	

	rjmp	print_serial_const			; repeat loop

 end_serial: RET

;------------------------------------------------------------------------
; print uart data:
;------------------------------------------------------------------------
monitor_serial:   
			LDS     R21,UCSR0A
            SBRS    R21,RXC0    ; USART Receive Complete
            RJMP    monitor_serial
			LDS     R22,UDR0    ; Store character r22  						
			ret
	