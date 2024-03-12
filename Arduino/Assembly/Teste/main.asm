	.include "m328pdef.inc"

	.equ	maxPulses	= 10	; business rule - max number of pulses that stimulator can reproduce in a period
	.equ	numBytes 	= 2		; number of bytes integers < 255
	.equ	arrBytes	= 20	; numBytes * maxPulses
	.equ	F_CPU = 16000000	
	.dseg
	.org	SRAM_START

	strSerialRead:		.byte 100          ; Allocate 100 bytes for string (adjust size as needed)	

	currents:			.byte maxPulses ;0=50uA,1=100uA,2=150uA,3=200uA,4=250uA,5=300uA,6=350uA,7=400uA,8=450uA,9=500uA,10=550uA,11=600uA,12=650uA
	polarities:			.byte maxPulses ;0 = neg, 1 = pos
	pulseLength:		.byte arrBytes 
	interpulseLength:	.byte arrBytes 
	interpulseUnity:	.byte maxPulses ;0 us,1 ms ,2 sec
	pulseUnity:			.byte maxPulses ;0 us,1 ms ,2 sec

	countPulses:        .byte 1
	
	.cseg	
	.org	0x00		

	LDI		r16,LOW(RAMEND)				; set stack to RAMEND - check point
	OUT		SPL,r16						; RAMEND is the actual point of stack memory
	LDI		r16,HIGH(RAMEND)			; higher bit	
	OUT		SPH,r16		

	LDI		r16,0						; set counter pulses to 0 [idx of arrays]
	STS     countPulses, r16

	RCALL	setup			
	
setup:	
	RCALL	init_serial			
	RCALL	init_controlPins		
	RCALL	init_digiPotPins	
	RCALL	set_current_650
	RCALL	loop			
	

loop:	
	RCALL	monitor_serial
	STS     UDR0,R22		    
	RCALL	ParsingNewData		
	RJMP	loop						; call loop again

.include "RunRoutine.asm"				; include RunRoutine subroutines	
.include "DigitalPotentiometer.asm"		; include DigitalPotentiometer subroutines	
.include "Delay.asm"					; include serialConfig subroutines
.include "SerialConfig.asm"				; include serialConfig subroutines
.include "ReadRoutine.asm"				; include RunRoutine subroutines	
