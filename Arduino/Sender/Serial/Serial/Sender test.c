/*
 * Sender_test.c
 *
 * Created: 24-04-2018 15:11:16
 *  Author: Valdemar
 */ 


#include <avr/io.h>
#include <avr/interrupt.h>
#include "Sender.h"
#include "uart_int.h"
#define F_CPU 16000000
#include <util/delay.h>



int main(void)
{
	stopTimer0();
	cli();
	InitUART(9600,8,'O',0);
	int addToEncode[4] = {0,0,0,0};
	int comToEncode[4] = {1,0,0,1};
	encode(addToEncode,comToEncode);
	startTransmission();
	
    while(1)
    {
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
			if(address[index] == 1){
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
			if(command[index] == 1){
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
		if(address[index]== 1){
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
		if(command[index] == 1){
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
