/*
 * ZCD.h
 *
 * Created: 14-05-2018 15:11:19
 *  Author: Valdemar
 */ 


#ifndef ZCD_H_
#define ZCD_H_

#include <avr/interrupt.h>


void initINT0();
void disableINT0();
void initTimer3(int);
void stopTimer3();
void setCounterTimer(int);
int getCounterTimer();

volatile int counterTimer;
#endif /* ZCD_H_ */
