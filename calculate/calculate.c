#include <stdio.h>
#include <stdlib.h>
#include <math.h>
 
typedef struct le
{
	int Name;
	int type;
	int temperature;
	double eny;
} Latticeenergy;
double cal(Latticeenergy leny1,Latticeenergy leny2 )
{
	double sqrt2=sqrt(2)/2;
	double sqrt3=sqrt(3)/2;
	double s,s1,s2,s3;
	double a=leny1.eny,b=leny2.eny;
	int name1=leny1.Name,name2=leny2.Name;
	if (leny1.type==1 &&leny2.type==1)
	{
		s1=fabs(a-b)/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-2*b)/6/b;
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}	
	if ((leny1.type==1 &&leny2.type==2)||(leny1.type==2 &&leny2.type==1))
	{
		s1=fabs(sqrt2*a-b)/b/3+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt3*b)/3/sqrt3/b+fabs(0.5*a-b)/3/b;
		s3=fabs(a*0.5-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}
	if ((leny1.type==2 &&leny2.type==3)||(leny1.type==3 &&leny2.type==2))
	{
		s1=fabs(sqrt2*a-b)/3/b+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-b)/3/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a-sqrt3*b)/3/sqrt3/b+fabs(sqrt2*a-sqrt(2)*b)/3/b/sqrt(2);
		s3=fabs(a*sqrt2-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(sqrt2*a-sqrt(6)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s2;
		s=s<s3?s:s3;
	}
	if ((leny1.type==1 &&leny2.type==3)||(leny1.type==3 &&leny2.type==1))
	{
		s1=fabs(a-b)/b;
		s2=fabs(a*sqrt2-b)/b/3+fabs(a*0.98559-sqrt(6)*b/2)/3/sqrt(6)/b*2+fabs(a-b)/3/b;
		s3=fabs(a*sqrt2-b)/3/b+fabs(a*0.96593-b)/3/b+fabs(sqrt2*a-sqrt(3)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if ((leny1.type==2 &&leny2.type==4)||(leny1.type==4 &&leny2.type==2))
	{
		s1=fabs(a-b)/b/3+fabs(2*0.98559*a-sqrt(2)*b)/3/b/sqrt(2)+ fabs(a-b)/3/b;
		s2=fabs(a-b)/b/3+fabs(2*0.908216-sqrt3*b)/3/b/sqrt(3)+fabs(a-sqrt(2)*b)/3/b/sqrt(2);
		s3=fabs(a-sqrt(2)*b)/3/b/sqrt(2)+fabs(2*a*0.8660254-sqrt(2)*b)/3/b/sqrt(2)+fabs(a-sqrt(6)*b)/3/b/sqrt(6);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	if ((leny1.type==1 &&leny2.type==4)||(leny1.type==4 &&leny2.type==1))
	{
		s1=fabs(a-sqrt2*b)/3/b/sqrt(2)+fabs(2*a*0.965926/sqrt(3)-b)/3/b+fabs(a/sqrt(3)-sqrt2*b)/3/b/sqrt2;
		s2=fabs(a-b)/3/b+fabs(2*a*0.99578894/sqrt(3)-sqrt(6)/2*b)/3/b/sqrt(2)*2+fabs(1/sqrt(3)*a-sqrt2*b)/3/b/sqrt2;
		s3=fabs(a-b)/3/b+fabs(1/sqrt(3)*a-b)/3/b+fabs(a/sqrt(3)-sqrt(3)*b)/3/b/sqrt(3);
		s=s1<s2?s1:s1;
		s=s<s3?s:s3;
	}
	
	
	return s;
}
Latticeenergy faxian(int Name1,int temperature)
{
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
	return eny;
}
void load()
{
}
int main()
{
	int i,j;
	int name1,name2,temp;
	Latticeenergy leny1,leny2;
    Latticeenergy energy[130];
    double s;
    scanf("%d %d %d",&name1,&name2,&temp);
    leny1=faxian(name1,temp);
    leny2=faxian(name2,temp);
    s=cal(leny1,leny2);
    printf("所求的错配度为： %lf",s);
	return 0;
}
