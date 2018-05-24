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
void incIndex();
int getIndex();
void setIndex(int);
void setExit(int e);
int getExit();
void setMode(int);
int getMode();
void startTransmission(int *,int*);
void endTransmission();
int sendx10(int*,int*);
void setSend(int);
int getSend();
void setMessage(int);
int getMessage();
void incReadIndex();
int getReadIndex();
void setReadIndex(int);
void setCycle(int);
int getCycle();
void incCycle();
void reset();
void setWait(int);
int getWait();














#endif /* SENDER_H_ */