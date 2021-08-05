// I'm having some garbage output error messages and I don't understand what they mean
// https://docs.microsoft.com/en-us/answers/questions/300036/i39m-having-some-garbage-output-error-messages-and.html#comment-301840

#include "pch.h"
#include <iostream>
#include <vector>

class Board
{
public:
	int something;
};

int random(std::vector<std::vector<Board>>);

int main()
{
	std::cout << "Begin play.\n";
	std::vector<std::vector<Board>> playboard(6, std::vector<Board>(7));
	std::vector<std::vector<Board>>::iterator row;
	std::vector<Board>::iterator col;
	int i = 0;
	for (row = playboard.begin(); row != playboard.end(); row++) {
		for (col = row->begin(); col != row->end(); col++) {
			col->something = ++i;
		}
	}
	random(playboard);
}

int random(std::vector<std::vector<Board>> playboard)
{
	std::vector<std::vector<Board>>::iterator row;
	std::vector<Board>::iterator col;
	std::cout << "This is random.\n";
	for (row = playboard.begin(); row != playboard.end(); row++) {
		for (col = row->begin(); col != row->end(); col++) {
			std::cout << col->something << ' ';
		}
		std::cout << std::endl;
	}
	return 0;
}
