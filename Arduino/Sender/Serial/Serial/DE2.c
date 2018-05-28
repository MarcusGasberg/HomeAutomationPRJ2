/*
 * DE2.c
 *
 * Created: 14-05-2018 15:18:33
 *  Author: Valdemar
 */ 
#include <avr/io.h>
#include "DE2.h"
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
}
char getStatus(){
	return status;
}
void setStatus(char s){
	status = s;
}