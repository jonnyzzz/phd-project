#ifndef WIN32
#ifndef GCC_LIB
#define GCC_LIB

  #define FALSE false

  #define GCC_DIE(x) {cout<<"ATL ASSERTION FAILED"<<endl<<#x<<" at "<<__FILE__<<":"<<__LINE__<<endl; throw -1;}

  #define ASSERT(x) {if (!(x)){ GCC_DIE(x);} };
  #define VERIFY(x) {if (!(x)){ GCC_DIE(x);} };

  #define ATLASSERT(x) { if (!(x)) {GCC_DIE(x);} }


#endif
#endif
