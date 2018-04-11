/*
 * Sender.c
 *
 * Created: 11-04-2018 14:03:47
 *  Author: valde
 */ 


#include <avr/io.h>
#include "Sender.h"
#define F_CPU 16000000
#include <util/delay.h>
#include <avr/interrupt.h>


void sendPWM(){
	TCCR1A |= 0b10000011;
	TCCR1B |= 0b00011001;
	OCR1A = 132/2;
	ICR1 = 132 
	DDRB |= 0b00100000;
	_delay_ms(1);
	DDRB = 0;
	TCCR1A = 0;
	TCCR1B = 0;
	OCR1A = 0;
	ICR1 = 0;
}

void sendCommand(char * address, int command){
	
}