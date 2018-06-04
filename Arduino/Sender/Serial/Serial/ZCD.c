/*
 * ZCD.c
 *
 * Created: 14-05-2018 15:11:00
 *  Author: Valdemar
 */ 
#include "ZCD.h"
volatile int counterTimer;
void initINT0(){
	DDRD &= 0b11111110; // PD0 som udgang
	EIMSK |= 0b00000001; // enable INT0
	EICRA |= 0b00000010; // falling edge triggered
}
void disableINT0(){
	EIMSK &= 0b11111110;
	EICRA &= 0b11111100;
}
void initTimer3(int ms){
	if(ms == 1){
		TCCR3A = 0;
		TIMSK3 = 1;
		TCNT3 = 59489;
		TCCR3B = 1;
	}	
	else if(ms == 10){
		TCCR3B = 2;
		TCNT3 = 65537 - 20000;
	}
}
void stopTimer3(){
	TCCR3A = 0;
	TCCR3B = 0;
	TIMSK3 = 0;
}
void setCounterTimer(int c){
	counterTimer = c;
}
int getCounterTimer(){
	return counterTimer;
}
