
#include "stdio.h"

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
}

int x,y;
int high;
int low;

void loop() {
  // put your main code here, to run repeatedly:
    x=analogRead(A0);
    y=analogRead(A1);
   // Serial.write("%d,%d",x,y);
    
    //Serial.print("X->");
    //Serial.print(String(x));
    //Serial.print(" Y->");
    //Serial.print(String(y));

    high = x >> 8;
    low = x & 0xff;
    //Serial.print("X->");
    Serial.write((byte)high);
    Serial.write((byte)low);
    Serial.write(0xff);
    high = y >> 8;
    low = y & 0xff;
    Serial.write(high);
    Serial.write(low);
    Serial.write(0xff);
    Serial.write(0x0d);
    Serial.write(0x0a);
    delay(200);
}

