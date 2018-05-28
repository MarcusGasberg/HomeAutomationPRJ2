/*
 * Timer0.c
 *
 * Created: 14-05-2018 15:02:11
 *  Author: Valdemar
 */ 
#include "Timers.h"
#include "Controller.h"
#include <avr/io.h>

//Timer 0 functions
void initTimer0(){
	TCCR0B |= 0b00000100; // 256 clock prescaler
	TIMSK0 |= 0b00000001;
	TCNT0 = 48; //3.3 ms to overflow
}
void stopTimer0(){
	TCCR0A = 0;
	TCCR0B = 0;
	TIMSK0 = 0;
}

//Timer 1 functions
void sendPWM(){
	TCCR1A |= 0b10000010; // initiering af PWM ved timer 1
	TCCR1B |= 0b00011001;
	OCR1A = 132/2;
	ICR1 = 132;
	//PORTB |= 0b00100000;
	initTimer2();
}

void initTimer2(){
	TIMSK2 |= 1;
	TCCR2B |= 0b00000110;
	TCNT2 = 193;
}
void stopTimer1(){
	TCCR1A = 0;
	TCCR1B = 0;
}
void stopTimer2(){
	TCCR2A = 0;
	TCCR2B = 0;
	TIMSK2 = 0;
}