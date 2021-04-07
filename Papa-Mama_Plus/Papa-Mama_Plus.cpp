

#include<iostream>
#include<thread>
#include<vector>
#include<string>
#include<thread>
#include "Message.h"


int main()
{
    Message::n_rep = 7;
    Message mama("mama", 3, 2000);
    Message papa("papa", 2, 3000);
    Message dog("gav-gaf", 2, 1000);
    std::thread d(&Message::ToSay, dog);
    std::thread tp(&Message::ToSay, papa);
    std::thread tm(&Message::ToSay, mama);
    d.join();
    tp.join();
    tm.join();
}