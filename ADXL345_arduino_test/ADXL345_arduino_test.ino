/*
 * Arduino + ADL345 test
 * by Bernardo Giovanni
 * http://www.settorezero.com
 * 
 * Data from accelerometer sent on Serial port @115200
 *  
 */
 
#include <Wire.h>
#define I2C_add    0x53   // ADXL345 I2C address
byte buff[6];             // 6 bytes buffer for data from accelerometer

void setup()
  {
  Wire.begin();           // init I2C
  Serial.begin(115200);     // Init UART
  // Turn ON ADXL345
  writeTo(I2C_add, 0x2D, 0);      
  writeTo(I2C_add, 0x2D, 16);
  writeTo(I2C_add, 0x2D, 8);
  }

void loop()
  {
  int regAddress = 0x32;    //first axis register
  int x, y, z;
  readFrom(I2C_add, regAddress, 6, buff); //read ADXL345
    
  x = (int)buff[1] << 8 | buff[0];   
  y = (int)buff[3] << 8 | buff[2];
  z = (int)buff[5] << 8 | buff[4];

  // send data on serial port
  Serial.print(x,DEC);
  Serial.print(',');
  Serial.print(y,DEC);
  Serial.print(',');
  Serial.println (z,DEC);
 
  delay(100);
  }

//Writes val to address register on device
void writeTo(byte device, byte address, byte val)
  {
   Wire.beginTransmission(device);
   Wire.write(address); 
   Wire.write(val);  
   Wire.endTransmission(); 
  }

//reads num bytes starting from address register on device in to buff array
void readFrom(byte device, byte address, byte num, byte buff[])
  {
  Wire.beginTransmission(device);
  Wire.write(address); 
  Wire.requestFrom(device, num); 
  
  byte i = 0;
  while(Wire.available())
   { 
    buff[i] = Wire.read(); 
    i++;
   }
  Wire.endTransmission(); 
 }
