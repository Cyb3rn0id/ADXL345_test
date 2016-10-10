# ADXL345 test
Firmware and software for testing an ADXL345 accelerometer with Arduino and Visual Basic.NET.
Source code for PC software provided (AxeView), requires VB.NET 2008 and inclusion of ZedGraph DLL in the IDE.
Note that in VB source code, RTS and DTR lines of Serial Port are set to True, since Arduino requires them for proper communication. If you experience problems or want to use a board different than Arduino, try to disable DTR and RTS lines in the source.

**Warnings !**
* ADXL345 works @ 3.3V!
* For using ADXL345 in I2C mode, CS line must be pulled to high level
* Remember to add 2 4K7 pull-up resistors on SDA and SCL lines
* If you want to edit the code, remember to include ZedGraph DLL in your ide

![application screenshot](https://github.com/Cyb3rn0id/ADXL345_test/blob/master/screenshot.png)

**Links**
* [ADXL345 breakout board](https://www.sparkfun.com/products/9836)
* [Hookup guide](https://learn.sparkfun.com/tutorials/adxl345-hookup-guide?_ga=1.9343222.255659784.1474484618)
* [Video of an older version of AxeView](https://www.youtube.com/watch?v=DYrT9s_6ovc)
* [ZedGraph on SourceForge](https://sourceforge.net/projects/zedgraph/)
