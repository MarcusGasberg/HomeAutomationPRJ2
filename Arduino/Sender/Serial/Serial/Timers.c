/*
 * Timer0.c
 *
 * Created: 14-05-2018 15:02:11
 *  Author: Valdemar
 */ 
#include "Timers.h"
#include "X.10 transmitter.h"
#include <avr/io.h>

//Timer 0 functions
void initTimer0(){
	TCCR0B |= 0b00000100; // 256 clock prescaler
	TIMSK0 |= 0b00000001; // overflow interrupt enabled
	TCNT0 = 48; //3.3 ms to overflow
}
void stopTimer0(){
	TCCR0A = 0;
	TCCR0B = 0;
	TIMSK0 = 0;
}

//PWM generator functions
void sendPWM(){
	TCCR1A |= 0b10000010; //mode 14 fast PWM, top = ICR1
	TCCR1B |= 0b00011001; // no prescaling
	OCR1A = 134/2; 
	ICR1 = 134;
	initTimer2();
}
void stopTimer1(){
	TCCR1A = 0;
	TCCR1B = 0;
}
void initTimer2(){
	TIMSK2 |= 1; // overflow interrupt enable
	TCCR2B |= 0b00000110; //256 clock prescaler
	TCNT2 = 193;
}
void stopTimer2(){
	TCCR2B = 0;
	TIMSK2 = 0;
}
