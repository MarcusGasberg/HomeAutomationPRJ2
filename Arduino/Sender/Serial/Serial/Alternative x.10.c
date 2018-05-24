/*#include <avr/io.h>
#include <avr/interrupt.h>
#include "uart_int.h"
#include "led.h"
#include "Sender.h"
unsigned int readIndex;
unsigned char data[4];
volatile unsigned int send;
unsigned int bitsSent;

int main(void)
{
	InitUART(9600,8,'E',1);
	initINT1();
	sei();
	while(1){
		if(state == 1){
			encodeAddress(data,address,4);
			encodeCommand(data,command,4);
			x10encode(address,command);
			startTransmission();
			while(1){
				if(send == 1){
					sendx10();
					bitsSent++;
					if(bitsSent == 20){
						setMode(1);
						repeat = 1;
					}
				}
			}
		}
	}
}




ISR(INT0_vect){
	send = 1;	
}
ISR (USART0_RX_vect){
	data[readIndex] = UDR0;
	readIndex++;
	if(readIndex >= 4){
		readIndex = 0;
		disableUART();
		state = 1;
	}
}

ISR(TIMER0_OVF_vect)
{
	send = 1;
	timerCounter++;
	if(timerCounter >= 2){
		stopTimer0();
		timerCounter = 0;
	}
}

ISR(TIMER2_OVF_vect){
	DDRB = 0;
	TCCR1A = 0;
	TCCR1B = 0;
	OCR1A = 0;
	ICR1 = 0; // timer 1 PWM slukkes
	TCCR2B = 0;
	TIMSK2 = 0; // timer 2 og timer 2 overflow slukkes
}

ISR(INT1_vect){
	if(PORTD & 0b00000010)
	SendChar('L');
	else
	SendChar('O');
}
*/