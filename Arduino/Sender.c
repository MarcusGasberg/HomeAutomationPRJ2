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
#define ADDRESS_LENGTH 8
#define COMMAND_LENGTH 8
#define STOP 0
#define START 1
#define ADDRESS 2 
#define COMMAND 3 
#define END 4

//Addresse kode : 4 bit
//Kommando kode : 4 bit 


int index = 0;
int mode = 0;
unsigned int address[ADDRESS_LENGTH];
unsigned int command[COMMAND_LENGTH];
unsigned int timerCounter = 0;
 
// der skal være globale variable som interrupts skal kunne anvende og ændre på. 

void sendPWM(){
	TCCR1A |= 0b10000011; // initiering af PWM ved timer 1 
	TCCR1B |= 0b00011001;
	OCR1A = 132/2;
	ICR1 = 132 
	DDRB |= 0b00100000; // PB5 sættes som udgang
	_delay_ms(1); // delay på 1 ms hvor pulsen sendes.
	DDRB = 0;
	TCCR1A = 0;
	TCCR1B = 0;
	OCR1A = 0;
	ICR1 = 0; // alt slukkes
}

void sendCommand(int * adr, int * com){
	for(int i = 1; i < ADDRESS_LENGTH+1; i++){
		if(adr[i-1] == 1){
			address[(i*2)-2] = 1;
			address[(i*2)-1] = 0;
		}
		else{
			address[(i*2)-2] = 0;
			address[(i*2)-1] = 1;
		}
	}
	for(int i = 1; i < COMMAND_LENGTH+1; i++){
		if(com[i-1] == 1){							// Konvertering af kommandoer til komplimentære bits
			command[(i*2)-2] = 1;
			command[(i*2)-1] = 0;
		}
		else{
			command[(i*2)-2] = 0;
			command[(i*2)-1] = 1;
		}
	}
	sendStartCode();
	
}

void sendStartCode(){ // funktion der sender "1110" som er startkoden
	sei();
	EIMSK |= 0b00000001; // enable INT0
	EICRA |= 0b00000011; // rising edge triggered
	mode = 1;
}

ISR(INT0_vect){
	if(mode == START) // sender startkode
	{ 
		switch(index){
			case 0: 
				sendPWM(); // der sendes et 1 tal
				index++;
				break;
			case 1:
				sendPWM();
				index++;
				break;
			case 2: 
				sendPWM();
				index++;
				break;
			case 3:
				index = 0;
				mode = 2;
				break;
		}
	}
	else if(mode != 0){
		TCCR0B |= 0b00000100; // 256 clock prescaler
		TIMSK0 |= 0b00000001; /
		TCNT0 = 81;
		if(mode == ADDRESS) // sender addresse kode
		{
			if(address[index] == 1){
				sendPWM();
				index++;
			}
			else
				index++;
			if(index == ADDRESS_LENGTH){
				index = 0;
				mode = 3;
			}

		}
		else if(mode == COMMAND){
			if(command[index] == 1){
				sendPWM();
				index++;
			}
			else
			index++;
			if(index == COMMAND_LENGTH){
				index = 0;
				mode = 0;
			}
		}
		else if(mode == STOP){
			cli();
		}
	
}

ISR(TIMER0_OVF_vect)
{
	timerCounter++;
	if(mode == ADDRESS){
		if(address[index]== 1){
			sendPWM();
			index++;
		}
		else 
			index++;
		if(index == ADDRESS_LENGTH){
		index = 0;
		mode = 3;
		}
		
	}
	else if(mode == COMMAND){
		if(command[index] == 1){
			sendPWM();
			index++;
		}
		else
		index++;
		if(index == COMMAND_LENGTH){
			index = 0;
			mode = 0;
		}
	}
	else if(mode == STOP)
		cli();
	if(timerCounter >= 2){
		TIMSK0 = 0;
		timerCounter = 0;
	}
}

