// glupost.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <string>
using namespace std;
class LivingThing {
protected:
	void breathe() {
		std::cout << "I'm breathing as a living thing." << std::endl;
	}
};

class Animal : protected LivingThing {
protected:
	void breathe() {
		std::cout << "I'm breathing as an animal." << std::endl;
	}
};

class Reptile : protected LivingThing {
public:
	void breathe() {
		std::cout << "I'm breathing as a reptile." << std::endl;
	}

	void crawl() {
		std::cout << "I'm crawling as a reptile." << std::endl;
	}
};

class Snake : public Animal, public Reptile {

};
int main()
{
	Snake snake;

	snake.breathe();
	snake.crawl();
	return 0;
}
