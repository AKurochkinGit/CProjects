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
    mtx.lock();
    int i = 0;
    while (i < repeat && n_rep > 0)
    {
        std::cout << value << '\n';
        n_rep--;
        i++;
        mtx.unlock();
        std::this_thread::sleep_for(std::chrono::milliseconds{ delay });
        mtx.lock();
     
    }
    mtx.unlock();
}