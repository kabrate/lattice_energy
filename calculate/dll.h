#ifndef _DLL_H_
#define _DLL_H_

#if BUILDING_DLL
# define DLLIMPORT __declspec (dllexport)
#else /* Not BUILDING_DLL */
# define DLLIMPORT __declspec (dllimport)
#endif /* Not BUILDING_DLL */


DLLIMPORT double energy(int Name1,int temperature);
DLLIMPORT int type(int Name1,int temperature);
DLLIMPORT double cal(int type1,double energy1,int type2,double energy2 );
DLLIMPORT int plane(int type1,double energy1,int type2,double energy2);
DLLIMPORT int plane1(int type );
DLLIMPORT double angle(int type1,double energy1,int type2,double energy2);
#endif /* _DLL_H_ */
