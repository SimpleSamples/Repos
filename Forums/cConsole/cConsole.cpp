#include <stdio.h>

int main()
{
	FILE* fp;
	errno_t err;
	err = fopen_s(&fp, "C:/Users/Sam/Desktop/fileopening.txt", "w");
	fputc('H', fp);
	fclose(fp);
	return 0;
}
