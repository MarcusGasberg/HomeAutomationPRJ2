/*
 * DE2.c
 *
 * Created: 14-05-2018 15:18:33
 *  Author: Valdemar
 */ 
#include <avr/io.h>
#include "CodeLock.h"

char checkStatus(){
	if((PIND & 1<<1))
	return 'L';
	else
	return 'O';
}
void initINT1(){
	DDRD &= 0b11111101;
	EIMSK |= 0b00000010;
	EICRA |= 0b00000100; // any edge triggered
	setStatus(checkStatus());
}
char getStatus(){
	return status;
}
void setStatus(char s){
	status = s;
}
void disableINT1(){
	EIMSK &= 0b11111101;
	EICRA &= 0b11111011;
}
void setDontSend(int d){
	dontSend = d;
}
int getDontSend(){
	return dontSend;
}
