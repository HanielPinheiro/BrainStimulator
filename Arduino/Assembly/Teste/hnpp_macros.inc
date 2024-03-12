/*
 * hnpp_macros.inc
 *
 *  Created: 08/03/2024 11:35:58
 *   Author: Hani	
 *
 *	This macros was created to help my life, feel free to use
 */ 

/*=============================================================
* delayms
*
* creates a delay until 99 milliseconds, higher than this, use delayHundredMili
*
* @0 - number of milliseconds to delay for
=============================================================*/

	.macro	delayMili
	push	r16				; Save r16 in stack
	push	r17				; Save r17 in stack	

	LDI		R16,0		;set 0 to r16
	ldi		r17,@0		;set @0 to r17
	rcall	delay_ms

	pop	r17					; Get r17 in stack
	pop	r16					; Get r16 in stack
	.endmacro


/*=============================================================
* delayms
*
* creates a delay until 99 micros, higher than this, use delayHundredMicros
*
* @0 - number of microseconds to delay for
=============================================================*/
.macro	delayMicro
.if @0 > 1
		push	r16				; Save r16 in stack  - 2 cycles
		push	r17				; Save r17 in stack	 - 2 cycles

		LDI		R16,0			;set 0 to r16		 - 1 cycle
		LDI		r17,@0			;set @0 to r17		 - 1 cycle
		rcall	stack

.else
		 NOP NOP NOP NOP NOP NOP NOP NOP	; 8 cycles NOP
		 NOP NOP NOP NOP NOP NOP NOP RET	; 7 cycles NOP
.endif
.endmacro

