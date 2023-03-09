# CasparCG-CountDown

CasparCG Countdown is an application to show time or countdown in Miranda Kaleido multiviewers.

This application was developed around 2015 and received minor updates afterwards. Feel free to improve it and don't hesitate to send me a message.

## Features

- Shows the status of playtime/countdown time
- The timer is sent using telnet to the Kaleido Dynamic Address
- Supports OSC messages from CasparCG server of all versions up to 2.3

## How use?
- Step 1: You must create a dynamic address field in the Kedit and apply in to Kaleido

![N|Solid](https://github.com/maxmuzy/CasparCG-CountDown/blob/master/Kaleido%20example/kedit.png)

- Step 2: Setup the predefined client on CasparCG Server with IP and Port

![N|Solid](https://github.com/maxmuzy/CasparCG-CountDown/blob/master/Kaleido%20example/server.png)


- Step 3: Setup the application with IP address and Dynamic Address of Kaleido

![N|Solid](https://github.com/maxmuzy/CasparCG-CountDown/blob/master/Kaleido%20example/countdown.png)


- Step 4: Test

You can test using a telnet client like Putty and after connect send:

```sh
<setKDynamicText>set address="1" text="Test </setKDynamicText>
```
*the last quote should not be placed, it is probably a Kaleido bug

## Kaleido Alto Example

![N|Solid](https://github.com/maxmuzy/CasparCG-CountDown/blob/master/Kaleido%20example/Kaleido.jpeg)



## License

**CasparCG-CountDown** is distributed under the GNU General Public License GPLv3 or higher, see LICENSE for details.

***CasparCG-CountDown uses the following third party libraries:***

**Bespoke OSC** (https://www.bespokesoftware.org/wordpress/open-sound-control/) under the Microsoft Public License (MS-PL)

**.Net Telnet** (https://dotnettelnet.sourceforge.net/index.html) under the GPL

(c) Matthias L. Jugel, Marcus Meißner 1996-2002. All Rights Reserved.
(c) Seva Petrov 2002-2003. All Rights Reserved.

**CasparCG Server** (https://github.com/CasparCG/server) is distributed under the GNU General Public License GPLv3 or higher
