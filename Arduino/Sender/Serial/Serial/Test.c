/*
* Test.c
*
* Created: 03-05-2018 08:51:52
*  Author: Valdemar
*/

#include <avr/io.h>
#include <avr/interrupt.h>
#include "uart_int.h"
#include "Controller.h"
#include "Encoder.h"
#include "Timers.h"
#include "DE2.h"

#define F_CPU 16000000
#include <util/delay.h>
volatile unsigned char data[(ADDRESS_LENGTH/4)+(COMMAND_LENGTH/4)];
volatile int address[ADDRESS_LENGTH/2];
volatile int command[COMMAND_LENGTH/2];
volatile int x10address[ADDRESS_LENGTH];
volatile int x10command[COMMAND_LENGTH];


int main(){
	stopTimer0();
	sei();
	initINT1();
	InitUART(9600,8,'N',1);
	status = checkStatus();
while(1){
	reset();
	setMessage(0);
	InitUART(9600,8,'N',1);
	//setWait(1);
	while(getMessage()== 0){}
	while(status == 'L'){
		data[0] = 0;
		data[1] = 0;
		data[2] = 0;
		data[3] = 0;
	}
	toEncode(data,address,4,command,4,x10address,x10command);
	initINT0();
	startTransmission(x10address,x10command);
	//stopTimer0();
	}
}

ISR(INT0_vect){
	initTimer3(1);
}
ISR (USART0_RX_vect){
	data[getReadIndex()] = UDR0;
	incReadIndex();
	if(getReadIndex() >= 4){
		setReadIndex(0);
		disableUART();
		setMessage(1);
	}
}

ISR(TIMER0_OVF_vect)
{
	setSend(1);
}

ISR(TIMER2_OVF_vect){
	TCCR1A = 0;
	TCCR1B = 0;
	//OCR1A = 0;
	//ICR1 = 0; // timer 1 PWM slukkes
	//PORTB &= 0b11011111;
	TCCR2A = 0;
	TCCR2B = 0;
	TIMSK2 = 0; // timer 2 og timer 2 overflow slukkes
}

ISR(INT1_vect){
	status = checkStatus();
}
ISR(TIMER3_OVF_vect){
	if(getWait() == 1){
		setSend(0);
		setWait(0);
		stopTimer3();
	}
	else{
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
}