/*
 * UART_test.c
 *
 * Created: 09-05-2018 17:09:29
 *  Author: Valdemar
 */ /*
#include "uart_int.h"
#include "led.h"
#include <avr/interrupt.h>
#define F_CPU 16000000
#include <util/delay.h>
volatile unsigned int readIndex;
volatile unsigned int sendIndex;
volatile unsigned int trigger = 0;
volatile unsigned char data[5];
unsigned char target[5] = {'1','2','A','3'};

int main(){
	UCSR0B =0;
	UDR0 = 0;
	sei();
	initLEDport();
	InitUART(9600,8,'N',1);
	while(trigger != 1){}
	SendString(data);
	for(int i = 0; i< 4; i++){
		if(data[i] == target[i])
			writeAllLEDs(1<<i);
	}
	while(1){}	
}

ISR (USART0_RX_vect){
	data[readIndex] = UDR0;
	readIndex++;
	if(readIndex >= 5){
		readIndex = 0;
		trigger = 1;
	}
}

/*ISR (USART0_UDRE_vect){
	UDR0 = data[sendIndex];
	sendIndex++;
	if(sendIndex >= 4){
		sendIndex = 0;
		UCSR0B &= 0b11011111; // disable transmit
	}		
}*/
