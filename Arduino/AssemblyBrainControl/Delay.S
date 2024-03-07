;------------------------
.global delay_s
.global delay_ms
.global delay_us

;------------------------------------------------------------------------
;GENERAL ROUTINES
;------------------------------------------------------------------------
back:RET

;------------------------------------------------------------------------
; DELAY SEC
;------------------------------------------------------------------------
delay_s:
       LDI    R18, 10
LOOP:  RCALL  delay_100ms
       DEC    R18           ;decrement the counter
       BRNE   LOOP          ;repeat until counter = 0  
       RET

delay_100ms:                ;sub-rotina de delay de 100ms
    ldi   r17,200           ; 1 ciclo (62.5 ns)
     
aux1:
    ldi   r16,249           ; 1 ciclo (62,5 ns)

aux2:
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    nop                     ; 1 ciclo (62,5 ns)
    dec   r16               ; 1 ciclo (62,5 ns)
    breq  dec_r17           ; 1 ciclo (62,5 ns)
    rjmp  aux2              ; 2 ciclos | TOTAL 32 ciclos
                            ; 250 x 32 = 8000 ciclos

dec_r17:
    dec   r17               ;
    breq  back              ;
    rjmp  aux1              ;
                            ; 200 x 8000 = 1600000
                            ; 1.6E6 x 62.5ns = 100ms

;------------------------------------------------------------------------
; DELAY MS
;------------------------------------------------------------------------
set_R19:
    LDI   R19,250           ; 1 ciclo (62,5 ns)
    RET
    
set_R20:
    LDI   R20,4             ; 1 ciclo (62,5 ns)    
    RET
    
dec_R19:
    RCALL delay_us          ; 16 ciclos (62,5 ns)
    DEC   R19               ; 1 ciclo (62,5 ns)
    BREQ  dec_R20           ; 1 ciclo (62,5 ns)
    RJMP  dec_R19           ; 2 ciclos | TOTAL 20 ciclos   
     
dec_R20:
    DEC   R20               ; 1 ciclo (62,5 ns)
    BREQ  back              ; 1 ciclo (62,5 ns)    
    RJMP  dec_R19           ; 2 ciclos | TOTAL 4 ciclos
    
delay_ms: 
    RCALL set_R19             ; 1 ciclo
    RCALL set_R20             ; 1 ciclo
    RCALL dec_R19             ; 20 * 250 * 4 + 4 * 4 ciclo
    RET                       ; 1 ciclo | TOTAL 4 ciclos
  
;------------------------------------------------------------------------
; DELAY MICROS
;------------------------------------------------------------------------
delay_us: 
    NOP                      ;1 cycle
    NOP                      ;2 cycle
    NOP                      ;3 cycle
    NOP                      ;4 cycle
    NOP                      ;5 cycle
    NOP                      ;6 cycle
    NOP                      ;7 cycle
    NOP                      ;8 cycle
    NOP                      ;9 cycle
    NOP                      ;10 cycle
    NOP                      ;11 cycle
    NOP                      ;12 cycle
    NOP                      ;13 cycle
    NOP                      ;14 cycle
    NOP                      ;15 cycle
    RET                      ;16 cycle = 16 * 62,5ns = 1 micro
