/*
* SerialLib.c
*
* Created: 30-04-2018 12:56:25
*  Author: Valdemar
*/
#include "Encoder.h"

void toEncode(const char* source, int * address_dest, int address_length, int* command_dest, int command_length, int * x10add, int * x10com) {
	encodeAddress(source, address_dest, address_length);
	encodeCommand(source, command_dest, command_length);
	x10encode(address_dest, command_dest,x10add,x10com);
}


void encodeAddress(const char * source, int * destination, int length) {
	if (source[0] == '0' && source[1] == '0') {
		encodeBIN("0000", destination, length);
	}
	else if (source[0] == '0' && source[1] == '1') {
		encodeBIN("0001", destination, length);
	}
	else if (source[0] == '0' && source[1] == '2') {
		encodeBIN("0010", destination, length);
	}
	else if (source[0] == '0' && source[1] == '3') {
		encodeBIN("0011", destination, length);
	}
	else if (source[0] == '0' && source[1] == '4') {
		encodeBIN("0100", destination, length);
	}
	else if (source[0] == '0' && source[1] == '5') {
		encodeBIN("0101", destination, length);
	}
	else if (source[0] == '0' && source[1] == '6') {
		encodeBIN("0110", destination, length);
	}
	else if (source[0] == '0' && source[1] == '7') {
		encodeBIN("0111", destination, length);
	}
	else if (source[0] == '0' && source[1] == '8') {
		encodeBIN("1000", destination, length);
	}
	else if (source[0] == '0' && source[1] == '9') {
		encodeBIN("1001", destination, length);
	}
	else if (source[0] == '1' && source[1] == '0') {
		encodeBIN("1010", destination, length);
	}
	else if (source[0] == '1' && source[1] == '1') {
		encodeBIN("1011", destination, length);
	}
	else if (source[0] == '1' && source[1] == '2') {
		encodeBIN("1100", destination, length);
	}
	else if (source[0] == '1' && source[1] == '3') {
		encodeBIN("1101", destination, length);
	}
	else if (source[0] == '1' && source[1] == '4') {
		encodeBIN("1110", destination, length);
	}
	else if (source[0] == '1' && source[1] == '5') {
		encodeBIN("1111", destination, length);
	}
}

void encodeCommand(const char * source, int * destination, int length) {
	if (source[2] == '0' && source[3] == '0') {
		encodeBIN("0000", destination, length);
	}
	else if (source[2] == '0' && source[3] == '1') {
		encodeBIN("0001", destination, length);
	}
	else if (source[2] == '0' && source[3] == '2') {
		encodeBIN("0010", destination, length);
	}
	else if (source[2] == '0' && source[3] == '3') {
		encodeBIN("0011", destination, length);
	}
	else if (source[2] == '0' && source[3] == '4') {
		encodeBIN("0100", destination, length);
	}
	else if (source[2] == '0' && source[3] == '5') {
		encodeBIN("0101", destination, length);
	}
	else if (source[2] == '0' && source[3] == '6') {
		encodeBIN("0110", destination, length);
	}
	else if (source[2] == '0' && source[3] == '7') {
		encodeBIN("0111", destination, length);
	}
	else if (source[2] == '0' && source[3] == '8') {
		encodeBIN("1000", destination, length);
	}
	else if (source[2] == '0' && source[3] == '9') {
		encodeBIN("1001", destination, length);
	}
	else if (source[2] == '1' && source[3] == '0') {
		encodeBIN("1010", destination, length);
	}
	else if (source[2] == '1' && source[3] == '1') {
		encodeBIN("1011", destination, length);
	}
	else if (source[2] == '1' && source[3] == '2') {
		encodeBIN("1100", destination, length);
	}
	else if (source[2] == '1' && source[3] == '3') {
		encodeBIN("1101", destination, length);
	}
	else if (source[2] == '1' && source[3] == '4') {
		encodeBIN("1110", destination, length);
	}
	else if (source[2] == '1' && source[3] == '5') {
		encodeBIN("1111", destination, length);
	}
}

void encodeBIN(const char * convert, int * dest, int length) {
	for (int i = 0; i< length; i++) {
		if (convert[i] == '1')
		dest[i] = 1;
		else
		dest[i] = 0;
	}
}
void x10encode(int * adr, int * com,int * x10add,int * x10com) {	
	for (int i = 1; i < (ADDRESS_LENGTH)+1; i++) {
		if (adr[i-1] == 1) {
			x10add[(i * 2) - 2] = 1;
			x10add[(i * 2) - 1] = 0;
		}
		else {
			x10add[(i * 2) - 2] = 0;
			x10add[(i * 2) - 1] = 1;
			}
		}		
	for (int i = 1; i < (COMMAND_LENGTH)+1; i++) {
		if (com[((i)-1)] == 1) {							// Konvertering af kommandoer til komplimentære bits
		x10com[(i * 2) - 2] = 1;
		x10com[(i * 2) - 1] = 0;
	}
	else {
		x10com[(i * 2) - 2] = 0;
		x10com[(i * 2) - 1] = 1;
	}
}
}