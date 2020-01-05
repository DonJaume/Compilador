ORG 00

MOVLW 2F		;CARACTER ANTERIOR A 0 EN ASCII

*INICIO
ADDLW 01		;SUMAMOS 1
MOVWF PORTA	;LO ENVIAMOS AL PUERTO A
MOVWF UART		;LO ENVIAMOS A LA UART

SUBLW 35		;LE RESTAMOS 35 (5 EN ASCII)
JPZ BORRADO		;SI ES 0 SALTAMOS A BORRADO PARA REINICIAR LA CUENTA
ADDLW 35		;SI NO ES 0 LE VOLVEMOS A SUMAR 35
GOTO INICIO		;SEGUIMOS SUMANDO


*BORRADO
NOP
NOP
MOVLW 30		;CARGAMOS 0(ASCII)
MOVWF PORTA	;LO ENVIAMOS AL PUERTO A
MOVWF UART		;LO ENVIAMOS A LA UART
MOVLW 0A		;CARGAMOS /N (ASCII)
MOVWF PORTA	;LO ENVIAMOS AL PUERTO A
MOVWF UART		;LO ENVIAMOS A LA UART
MOVLW 30		;CARGAMOS 0(ASCII)
GOTO INICIO		;VOLVEMOS AL INICIO

END