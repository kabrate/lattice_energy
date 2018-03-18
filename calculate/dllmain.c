/* Replace "dll.h" with the name of your header */
#include "dll.h"
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "sqlite3.h"
double engy;
int tp;
static int callback(void *data, int argc, char **argv, char **azColName){
   int i;
   fprintf(stderr, "%s: ", (const char*)data);
   engy = atof(argv[0]);
   return 0;
}
static int callback_1(void *data, int argc, char **argv, char **azColName){
   int i;
   fprintf(stderr, "%s: ", (const char*)data);
   tp = atoi(argv[0]);
   return 0;
}

DLLIMPORT double energy(int Name1,int temperature)
{/*
	int i,j;
	Latticeenergy energy2[130];
	Latticeenergy eny;
	FILE *fp2;
	fp2 = fopen ("data_new.csv", "r");
	rewind(fp2);
	for(i=0;i<126;i++)//读取物质的晶格能数据 
   {
   fscanf(fp2,"%d,%d,%d,%lf",&energy2[i].Name,&energy2[i].type,&energy2[i].temperature,&energy2[i].eny);
   
   }
    fclose(fp2);
	 
	
	
	for(j=0;j<126;j++)
	{
		if (Name1==energy2[j].Name&&temperature==energy2[j].temperature)
		{
		    eny=energy2[j];
		    break;
		}
		
	}
	return eny.eny;
 */
   sqlite3 *db;
   char *zErrMsg = 0;
   int rc;
   char sql[100];
   char sub[5];
   char temp[4];
   sprintf(sub,"%d",Name1);
   sprintf(temp,"%d",temperature);
   sprintf(sql,"SELECT energy from Energy_ where substance=%d AND temprature=%d",Name1,temperature);
   const char* data = "Callback function called";

   /* Open database */
   rc = sqlite3_open("energy.db", &db);

   /* Create SQL statement */

   /* Execute SQL statement */
   rc = sqlite3_exec(db, sql, callback, (void*)data, &zErrMsg);
   sqlite3_close(db);
   return engy;
}
DLLIMPORT int type(int Name1,int temperature)
{
	/*
	int i,j;
	Latticeenergy energy2[130];
	Latticeenergy eny;
	FILE *fp2;
	fp2 = fopen ("data_new.csv", "r");
	rewind(fp2);
	for(i=0;i<126;i++)//读取物质的晶格能数据 
   {
   fscanf(fp2,"%d,%d,%d,%lf",&energy2[i].Name,&energy2[i].type,&energy2[i].temperature,&energy2[i].eny);
   
   }
    fclose(fp2);
	
	
	
	for(j=0;j<126;j++)
	{
		if (Name1==energy2[j].Name&&temperature==energy2[j].temperature)
		{
		    eny=energy2[j];
		    break;
		}
		
	}
	*/
   sqlite3 *db;
   char *zErrMsg = 0;
   int rc;
   char sql[100];
   char sub[5];
   char temp[4];
   sprintf(sub,"%d",Name1);
   sprintf(temp,"%d",temperature);
   sprintf(sql,"SELECT struct from Energy_ where substance=%d AND temprature=%d",Name1,temperature);
   const char* data = "Callback function called";

   /* Open database */
   rc = sqlite3_open("energy.db", &db);

   /* Create SQL statement */

   /* Execute SQL statement */
   rc = sqlite3_exec(db, sql, callback_1, (void*)data, &zErrMsg);
   sqlite3_close(db);
   return tp;

}

DLLIMPORT double cal(int type1,double energy1,int type2,double energy2 )
{
	double sqrt2=sqrt(2)/2;
	double sqrt3=sqrt(3)/2;
	double s,s1,s2,s3;
	double a=energy1,b=energy2;
	if (type1==1 &&type2==1)
	{
		s1=fabs(a-b)/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-2*b)/6/b;
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}	
	if ((type1==1 &&type2==2)||(type1==2 &&type2==1))
	{
		s1=fabs(sqrt2*a-b)/b/3+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt3*b)/3/sqrt3/b+fabs(0.5*a-b)/3/b;
		s3=fabs(a*0.5-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}
	if ((type1==2 &&type2==3)||(type1==3 &&type2==2))
	{
		s1=fabs(sqrt2*a-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a-sqrt3*b)/3/sqrt3/b+fabs(sqrt2*a-sqrt(2)*b)/3/b/sqrt(2);
		s3=fabs(a*sqrt2-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}
	if ((type1==1 &&type2==3)||(type1==3 &&type2==1))
	{
		s1=fabs(a-b)/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-sqrt(3)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if ((type1==2 &&type2==4)||(type1==4 &&type2==2))
	{
		s1=fabs(a-b)/b/3+fabs(2*0.98559*a-sqrt(2)*b)/3/b/sqrt(2)+ fabs(a-b)/3/b;
		s2=fabs(a-b)/b/3+fabs(2*0.908216-sqrt3*b)/3/b/sqrt(3)+fabs(a-sqrt(2)*b)/3/b/sqrt(2);
		s3=fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(2*a*0.8660254-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(6)*b)/3/b/sqrt(6);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if ((type1==1 &&type2==4)||(type1==4 &&type2==1))
	{
		s1=fabs(a-sqrt2*b)/3/b/sqrt(2)+fabs(2*a*0.965926/sqrt(3)-b)/3/b+fabs(a/sqrt(3)-sqrt2*b)/3/b/sqrt2;
		s2=fabs(a-b)/3/b+fabs(2*a*0.99578894/sqrt(3)-sqrt(6)/2*b)/3/b/sqrt(2)*2+fabs(1/sqrt(3)*a-sqrt2*b)/3/b/sqrt2;
		s3=fabs(a-b)/3/b+fabs(1/sqrt(3)*a-b)/3/b+fabs(a/sqrt(3)-sqrt(3)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	
	
	return s;
}
DLLIMPORT int plane(int type1,double energy1,int type2,double energy2)
{
	double sqrt2=sqrt(2)/2;
	double sqrt3=sqrt(3)/2;
	double s,s1,s2,s3;
	double a=energy1,b=energy2;
	if (type1==1 &&type2==1)
	{
		s1=fabs(a-b)/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-2*b)/6/b;
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}	
	if ((type1==1 &&type2==2)||(type1==2 &&type2==1))
	{
		s1=fabs(sqrt2*a-b)/b/3+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt3*b)/3/sqrt3/b+fabs(0.5*a-b)/3/b;
		s3=fabs(a*0.5-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}
	if ((type1==2 &&type2==3)||(type1==3 &&type2==2))
	{
		s1=fabs(sqrt2*a-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a-sqrt3*b)/3/sqrt3/b+fabs(sqrt2*a-sqrt(2)*b)/3/b/sqrt(2);
		s3=fabs(a*sqrt2-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}
	if ((type1==1 &&type2==3)||(type1==3 &&type2==1))
	{
		s1=fabs(a-b)/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-sqrt(3)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if ((type1==2 &&type2==4)||(type1==4 &&type2==2))
	{
		s1=fabs(a-b)/b/3+fabs(2*0.98559*a-sqrt(2)*b)/3/b/sqrt(2)+ fabs(a-b)/3/b;
		s2=fabs(a-b)/b/3+fabs(2*0.908216-sqrt3*b)/3/b/sqrt(3)+fabs(a-sqrt(2)*b)/3/b/sqrt(2);
		s3=fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(2*a*0.8660254-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(6)*b)/3/b/sqrt(6);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if ((type1==1 &&type2==4)||(type1==4 &&type2==1))
	{
		s1=fabs(a-sqrt2*b)/3/b/sqrt(2)+fabs(2*a*0.965926/sqrt(3)-b)/3/b+fabs(a/sqrt(3)-sqrt2*b)/3/b/sqrt2;
		s2=fabs(a-b)/3/b+fabs(2*a*0.99578894/sqrt(3)-sqrt(6)/2*b)/3/b/sqrt(2)*2+fabs(1/sqrt(3)*a-sqrt2*b)/3/b/sqrt2;
		s3=fabs(a-b)/3/b+fabs(1/sqrt(3)*a-b)/3/b+fabs(a/sqrt(3)-sqrt(3)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if (s1<s2&&s1<s3) return 100;
	else if (s2<s1&&s2<s3) return 110;
	else if (s3<s1&&s3<s2) return 111;
	
}
DLLIMPORT double angle(int type1,double energy1,int type2,double energy2)
{
	double sqrt2=sqrt(2)/2;
	double sqrt3=sqrt(3)/2;
	double s,s1,s2,s3;
	double a=energy1,b=energy2;
	if (type1==1 &&type2==1)
	{
		s1=fabs(a-b)/b;   //0
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b; //9.74
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-2*b)/6/b;  //15
		if (s1<s2&&s1<s3) return 0;
		else if (s2<s1&&s2<s3) return 9.74;
		else if (s3<s1&&s3<s2) return 15;
	}	
	else if ((type1==1 &&type2==2)||(type1==2 &&type2==1))
	{
		s1=fabs(sqrt2*a-b)/b/3+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;   //0
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt3*b)/3/sqrt3/b+fabs(0.5*a-b)/3/b;  //9.74
		s3=fabs(a*0.5-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);   //15
		if (s1<s2&&s1<s3) return  0 ;
		else if (s2<s1&&s2<s3) return 9.74;
		else if (s3<s1&&s3<s2) return 15;
	}
	else if ((type1==2 &&type2==3)||(type1==3 &&type2==2))
	{

		return 0;
	}
	else if ((type1==1 &&type2==3)||(type1==3 &&type2==1))
	{ 
		s1=fabs(a-b)/b;    //0
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;   //9.74
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-sqrt(3)*b)/3/b/sqrt(3);    //15
		if (s1<s2&&s1<s3) return 0;
		else if (s2<s1&&s2<s3) return 9.74;
		else if (s3<s1&&s3<s2) return 15;
	}
	else if ((type1==2 &&type2==4)||(type1==4 &&type2==2))
	{
		s1=fabs(a-b)/b/3+fabs(2*0.98559*a-sqrt(2)*b)/3/b/sqrt(2)+ fabs(a-b)/3/b;      //15
		s2=fabs(a-b)/b/3+fabs(2*0.908216-sqrt3*b)/3/b/sqrt(3)+fabs(a-sqrt(2)*b)/3/b/sqrt(2);//24.74
		s3=fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(2*a*0.8660254-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(6)*b)/3/b/sqrt(6);    //30
		if (s1<s2&&s1<s3) return 15;
		else if (s2<s1&&s2<s3) return 24.74;
		else if (s3<s1&&s3<s2) return 30;
	}
	else if ((type1==1 &&type2==4)||(type1==4 &&type2==1))
	{
		s1=fabs(a-sqrt2*b)/3/b/sqrt(2)+fabs(2*a*0.965926/sqrt(3)-b)/3/b+fabs(a/sqrt(3)-sqrt2*b)/3/b/sqrt2;   //15
		s2=fabs(a-b)/3/b+fabs(2*a*0.99578894/sqrt(3)-sqrt(6)/2*b)/3/b/sqrt(2)*2+fabs(1/sqrt(3)*a-sqrt2*b)/3/b/sqrt2;    //5.26
		s3=fabs(a-b)/3/b+fabs(1/sqrt(3)*a-b)/3/b+fabs(a/sqrt(3)-sqrt(3)*b)/3/b/sqrt(3);     //60
		if (s1<s2&&s1<s3) return 15;
		else if (s2<s1&&s2<s3) return 5.26;
		else if (s3<s1&&s3<s2) return 60;
	}

	
}
DLLIMPORT int plane1(int type )
{
	switch (type)
	{
	  case 1:return 100;break;
	  case 3:return 334;break;
	  case 4:return 100;break;
	}

}

BOOL APIENTRY DllMain (HINSTANCE hInst     /* Library instance handle. */ ,
                       DWORD reason        /* Reason this function is being called. */ ,
                       LPVOID reserved     /* Not used. */ )
{
    switch (reason)
    {
      case DLL_PROCESS_ATTACH:
        break;

      case DLL_PROCESS_DETACH:
        break;

      case DLL_THREAD_ATTACH:
        break;

      case DLL_THREAD_DETACH:
        break;
    }

    /* Returns TRUE on success, FALSE on failure */
    return TRUE;
}
