/*
* Test.c
*
* Created: 03-05-2018 08:51:52
*  Author: Valdemar
*/

#include <avr/io.h>
#include <avr/interrupt.h>
#include "UART app.h"
#include "X.10 transmitter.h"
#include "Encoder.h"
#include "Timers.h"
#include "CodeLock.h"
#include "ZCD.h"

#define F_CPU 16000000
#include <util/delay.h>
volatile unsigned char data[(ADDRESS_LENGTH/2)+(COMMAND_LENGTH/2)];
volatile int x10address[ADDRESS_LENGTH*2];
volatile int x10command[COMMAND_LENGTH*2];


int main(){
	setup();
while(1){
	InitUART(9600,8,'N',1);
	while(getMessage()== 0){}
	disableINT1();
	if(getStatus() == 'L'){
		deleteData(data,(ADDRESS_LENGTH/2)+(COMMAND_LENGTH/2));
		setDontSend(1);
	}
	if(getDontSend() == 0){
	toEncode(data,x10address,x10command);
	startTransmission(x10address,x10command);
	}	
	reset();
	}
}

ISR(INT0_vect){
	if(getWait() == 1){
		setWait(0);
	}
	else {
		initTimer3(1);
	}
}
ISR (USART0_RX_vect){
	fillArray(data);
}

ISR(TIMER0_OVF_vect)
{
	setSend(1);
}

ISR(TIMER2_OVF_vect){
	stopTimer1();
	stopTimer2();
}

ISR(INT1_vect){
	setStatus(checkStatus());
}

ISR(TIMER3_OVF_vect){
	setSend(1);
	if(getCounterTimer() == 0){
		setCounterTimer(1);
		initTimer3(10);
	}
	else if(getCounterTimer() == 1){
		setCounterTimer(0);
		stopTimer3();
	}
}