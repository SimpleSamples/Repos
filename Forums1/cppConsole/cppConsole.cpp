#include "pch.h"
using namespace std;

class Board
{
public:
	int something;
};

int random(Board);

int random(Board board[6][7]); //the Board object is an array of other objects

int main()
{
	Board playboard[6][7];
	random(playboard); //playboard is a Board object
	return 0;
}
int random(Board board[6][7]) { //the Board object is an array of other objects
	std::cout << "This is random.\n";
	return 0;
}
