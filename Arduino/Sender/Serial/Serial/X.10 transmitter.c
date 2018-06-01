/*
* Sender.c
*
* Created: 11-04-2018 14:03:47
*  Author: valde
*/

#define F_CPU 160000000
#include <avr/io.h>
#include "X.10 transmitter.h"
#include "Encoder.h"
#include "Timers.h"
#include "UART app.h"
#include "ZCD.h"
volatile int index;
volatile int mode;
volatile int cycle;
volatile int send;
volatile int exit1;
volatile int wait;
void reset(){
	setMode(0);
	setCycle(0);
	setExit(0);
	setMessage(0);
	setSend(0);
	initINT1();
	setDontSend(0);
}
void setup(){
	sei();
	initINT1();
}
void setWait(int w){
	wait= w;
}
int getWait(){
	return wait;
}
void setMode(int m){
	mode = m;
	setIndex(0);
}
int getMode(){
	return mode;
}
void setSend(int s){
	send = s;
}
int getSend(){
	return send;
}
void setExit(int e){
	exit1 = e;
}
int getExit(){
	return exit1;
}
void setCycle(int c){
	cycle = c;
}
int getCycle(){
	return cycle;
}
void incCycle(){
	cycle++;
}
int getIndex(){
	return index;
}
void setIndex(int i){
	index = i;
}
void incIndex(){
	index++;
}
void startTransmission(int* x10add,int * x10com){
		setWait(1); // venter 1 zerocrossing før der sendes
		initINT0(); // initierer zerocrossing
		// initiering af x.10 sender sekvens
		DDRB |= 0b00100000; // PB5 sættes som udgang
		setMode(1);
		while(getExit() == 0){
			if(getCycle() < 3){
				if(getSend() == 1){
				sendx10(x10add,x10com);
				setSend(0);
			}
		}
		else if(getCycle() >= 3){ // stopper hvis der er sendt 3 gange.
			endTransmission();
			setExit(1);
		}
	}
}

void endTransmission(){
	disableINT0();
}	

void sendx10(int * x10address, int* x10command){
	if(getMode() == 1) // sender startkode
	{
		switch(getIndex()){
			case 0:
			sendPWM(); // der sendes et 1 tal
			incIndex();
			break;
			case 1:
			sendPWM();
			incIndex();
			break;
			case 2:
			sendPWM();
			incIndex();
			break;
			case 3:
			setMode(2);
			break;
		}
	}
	else if(getMode() == 2 || getMode() == 3){
			disableINT0();
			initTimer0();
		if(getMode() == 2) // sender addresse kode
		{
			if(x10address[getIndex()] == 1){
				sendPWM();
				incIndex();
			}
			else {
				incIndex();
			}
			if(getIndex() == (ADDRESS_LENGTH*2){
				setMode(3);
			}

		}
		else if(getMode() == 3){
			if(x10command[getIndex()] == 1){
				sendPWM();
				incIndex();
			}
			else{
				incIndex();
			}
			if(getIndex() == (COMMAND_LENGTH*2)){
				setMode(0);
			}
		}
		
		}
	if(getMode() == 0){
		setSend(0);
		stopTimer0();
		incCycle();
		setWait(1);
		setMode(1);
		initINT0();
	}
}


