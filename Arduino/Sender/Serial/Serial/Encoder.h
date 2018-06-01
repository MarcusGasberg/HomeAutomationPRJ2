
/*
* SerialLib.h
*
* Created: 30-04-2018 12:56:07
*  Author: Valdemar
*/


#define ADDRESS_LENGTH 4
#define COMMAND_LENGTH 4

void encodeCommand(const char *, int*, int);
void encodeBIN(const char *, int*, int);
void encodeAddress(const char *, int*, int);
void x10encode(int*, int*, int*, int*);
void toEncode(const char *,int*,int*);