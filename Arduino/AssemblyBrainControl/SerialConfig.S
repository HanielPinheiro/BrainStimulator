#define __SFR_OFFSET 0x00
#include "avr/io.h"

; ------------------------
.global init_serial
.global print_msg
;------------------------------------------------------------------------
; init_serial:
;------------------------------------------------------------------------
init_serial:
  CLR   R24
  STS   UCSR0A, R24                         ; clear UCSR0A register
  STS   UBRR0H, R24                         ; clear UBRR0H register
  LDI   R24, 8                              ;& store in UBRR0L 8 value
  STS   UBRR0L, R24                         ; to set baud rate 115200
  LDI   R24, 1 << RXEN0 | 1 << TXEN0        ; enable RXB & TXB
  STS   UCSR0B, R24
  LDI   R24, 1 << UCSZ00 | 1 << UCSZ01      ; asynch, no parity, 1 stop, 8 bits
  STS   UCSR0C, R24
  RET

;------------------------------------------------------------------------
; print_msg:
;------------------------------------------------------------------------
print_msg:
  LDI   R30, lo8(message1)
  LDI   R31, hi8(message1)                   ; Z points to string message
  sub_rout0: LPM   R18, Z +                 ; load char of string onto R18
  CPI   R18, 0                              ; check if R18 = 0 (end of string)
        BREQ  ext                           ; if yes, exit
  ; --------------------------------------------------------------------
  sub_rout1: LDS   R17, UCSR0A
  SBRS  R17, UDRE0                          ; test data buffer if data can be sent
  RJMP  sub_rout1
  STS   UDR0, R18                           ; send char in R18 to serial monitor
  
  ; --------------------------------------------------------------------
  RJMP  sub_rout0                           ; loop back & get next character
  
  ; --------------------------------------------------------------------
  ext: RCALL delay_s
  RET
  
;------------------------------------------------------------------------
; message1:
;------------------------------------------------------------------------
message1:
  .ascii "Programming Serial Interface!" ; even number of characters!!!
  .byte 10, 13, 0
