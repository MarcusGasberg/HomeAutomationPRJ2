/*
 * Sender.h
 *
 * Created: 11-04-2018 14:04:09
 *  Author: valde
 */ 


#ifndef SENDER_H_
#define SENDER_H_
#include <string.h>
//Addresse kode : 4 bit
//Kommando kode : 4 bit
void setup();
void incIndex();
int getIndex();
void setIndex(int);
void setExit(int e);
int getExit();
void setMode(int);
int getMode();
void startTransmission(int *,int*);
void endTransmission();
void sendx10(int*,int*);
void setSend(int);
int getSend();
void setCycle(int);
int getCycle();
void incCycle();
void reset();
void setWait(int);
int getWait();














#endif /* SENDER_H_ */