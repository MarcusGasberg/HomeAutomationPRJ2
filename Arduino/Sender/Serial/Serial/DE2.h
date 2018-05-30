/*
 * DE2.h
 *
 * Created: 14-05-2018 15:18:25
 *  Author: Valdemar
 */ 


#ifndef DE2_H_
#define DE2_H_



char checkStatus();
void initINT1();
char getStatus();
void setStatus(char);
void disableINT1();
volatile unsigned char status;

#endif /* DE2_H_ */

