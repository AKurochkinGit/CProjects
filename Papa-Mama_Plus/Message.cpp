#include "Message.h"
#include<thread>
#include<iostream>
#include<mutex>

int Message::n_rep;
std::mutex mtx;

Message::Message(std::string _value, int _repeat, int _delay)
{
    value = _value;
    repeat = _repeat;
    delay = _delay;
}

void Message::ToSay()
{
   
    int i = 0;
    while (i < repeat && n_rep > 0)
    { 
        mtx.lock();
        std::cout << value << '\n';
        n_rep--; 
        mtx.unlock();
        i++;
       
        std::this_thread::sleep_for(std::chrono::milliseconds{ delay });
      
    }
}