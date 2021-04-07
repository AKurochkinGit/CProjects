#pragma once
#include<string>
#include"windows.h"
#include<iostream>
#include<thread>
#include<mutex>

class Message
{
private:
	std::string value;
	int repeat;
	int delay;
	
public:
	static int n_rep;
    Message(std::string _value, int _repeat, int _delay);
	void ToSay();
	
};

