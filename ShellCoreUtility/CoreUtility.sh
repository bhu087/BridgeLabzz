#!/bin/sh

LeapYear(){
echo "This is your Leap Year Utility"
echo "Enter your year";
read Year;
if [ $(( Year % 4 )) -eq 0 ]
then
	if [ $(( Year % 100 )) -eq 0 ]
	then
		if [ $(( Year % 400 )) -eq 0 ]
		then
			return 1;
		fi
	return 0;
	fi
return 1;
else
return 0;
fi
}






echo "This is your Start of Program"
echo "Enter your Option"
echo "1 for leap year"

read option

case "$option" in 1)
LeapYear;
if [ $? -eq 1 ]
then
	echo "This is leap year";
else
	echo "This is not leap year";
fi;;
2)
echo "hi";;
esac

