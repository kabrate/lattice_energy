#include <iostream>
#include <stdio.h>
#include <windows.h>
/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int main(int argc, char *argv[]) 
{
typedef double (*FUNT)(int,int);// ����ָ������ 
HINSTANCE Hint = LoadLibrary("dll_test.dll");// ���� dll
FUNT cal = (FUNT)GetProcAddress(Hint,"main");
printf("%lf",cal(10,1500));
	return 0;
}
