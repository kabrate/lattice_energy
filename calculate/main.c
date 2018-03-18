#include <stdio.h>
#include <stdlib.h>
#include <Windows.h>
/* run this program using the console pauser or add your own getch, system("pause") or input loop */
typedef struct le
{
	int Name;
	int type;
	int temperature;
	double eny;
} Latticeenergy;
int main(int argc, char *argv[]) {
	typedef Latticeenergy (*FUNT)(int,int);
	HINSTANCE Hint = LoadLibrary("findit.dll");
	FUNT ADD = (FUNT)GetProcAddress(Hint,"faxian");
	int a=1,b=1500;
	printf("sum is %lf \n",ADD(a,b).eny);
	return 0;
}
