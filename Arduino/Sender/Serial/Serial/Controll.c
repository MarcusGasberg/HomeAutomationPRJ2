/*
 * Serial.c
 *
 * Created: 29-04-2018 21:36:59
 *  Author: Valdemar
 */ 


/*#include <avr/io.h>
#include <avr/interrupt.h>
#include "uart_int.h"
#include "led.h"
#include "Sender.h"
unsigned int readIndex;
unsigned char data[4];

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
		}
	}
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
ISR(INT0_vect){
	if(mode == 1) // sender startkode
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
			setMode(2);
			break;
		}
	}
	else if(mode != 0){
		if(mode == 2) // sender addresse kode
		{
			startTimer0();
			if(x10address[index] == 1){
				sendPWM(); // Disse bits sendes ikke altid... Det kan fikses ved at ændre på længden af PWM signalet. Men hvorfor?
				index++;
			}
			else
			index++;
			if(index == 8){
				setMode(3);
			}

		}
		else if(mode == 3){
			startTimer0();
			if(x10command[index] == 1){
				sendPWM();
				index++;
			}
			else
			index++;
			if(index == 8){
				setMode(0);
			}
		}
	}
	if(mode == 0){
		endTransmission();
	}
}

ISR(TIMER0_OVF_vect)
{
	timerCounter++;
	if(mode == 2){
		if(x10address[index]== 1){
			sendPWM();
			index++;
		}
		else
		index++;
		if(index == 8){
			setMode(3);
		}
		
	}
	else if(mode == 3){
		if(x10command[index] == 1){
			sendPWM();
			index++;
		}
		else
		index++;
		if(index == 8){
			setMode(0);
		}
	}
	if(mode == 0)
	endTransmission();
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
