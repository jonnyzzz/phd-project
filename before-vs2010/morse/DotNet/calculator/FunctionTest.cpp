#include "StdAfx.h"
#include ".\functiontest.h"
#include <iostream>
#include "FunctionFactory.h"
#include "FunctionNative.h"
#include "FunctionNodeConstant.h"
#include "FunctionFactoryParseException.h"
#include "FunctionNode.h"
#include "FunctionDictionary.h"
#include "FunctionContext.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



FunctionTest::FunctionTest(void)
{
}

FunctionTest::~FunctionTest(void)
{
}


void FunctionTest::test() {
   bool b = true;
  // b&=testFunctionSubstitution();
   justATest();
   b&=testFunctionComplexSubstitution();

   if (b) {
      cout<<"Completed\n";
   } else {
      cout<<"Failed!\n";
   }
}

void FunctionTest::testPlus() {
   cout<<"Test Plus interpret\n";
}


class AssertException{};


double FunctionTest::abs(double a) {
   return (a>0)?a:-a;
}

void FunctionTest::assertEQ(double a, double b) {
   assert(abs(a-b)<1e-8);
}

void FunctionTest::assert(bool b) {
   if (!b) throw AssertException();
}


bool FunctionTest::justATest() {
   FunctionFactory factory("a(b,c,d,e,f,r,g,t,h,y) = 0; t=a(1,2,3,4,5,6,7,8,9,a(0,9,8,7,6,5,4,3,2,1));");
   factory.print(cout);

   return false;
}

bool FunctionTest::testFunctionSubstitution() {
   cout<<"teset Function&Constant substitution. 1\n";
   
   const char leftPart[] = "a(t)=t*t;f=a(x);x=";
   const char rightPart[] = ";";

   for (double d=-10; d<10; d+=0.33) {
      bool r = false;

     // try
      { 
         char buff[255];
         char* tmp = buff;

         strcpy(buff, leftPart);
         
         while (*tmp++ != 0); tmp--;
         tmp += sprintf(tmp, "%f", d);
         //*tmp=0;
         
         strcpy(tmp, rightPart);

         // cout<<"buffer:"<<buff<<"\n";

         FunctionFactory factory(buff);
         FunctionNode* node = factory.getEquation(factory.getFunctionDictionary()->lookUp("f"));
         
         /*
         factory.print(cout);

         node->print(cout, factory.getFunctionDictionary());
         cout<<"\n";
         //*/

         double value =  node->evaluate(&FunctionContext());

         // cout<<value<<"\t"<<(d*d)<<"\n";

         assertEQ(value, d*d);

         delete node;
         r = true;
      }     
/*
      catch (FunctionFactoryParseException*) {
         cerr<<"ParseError\n";
      } catch (AssertException) {
         cerr<<"Assert failed\n";
      } catch (...) {
         cerr<<"Unknown error!\n";
      }
      //*/
      if (!r) return false;
      cout<<"OK\n";
   }
   return true;
}



bool FunctionTest::testFunctionComplexSubstitution() {
   cout<<"teset Function&Constant complex substitution. 2\n";
   
   const char leftPart[] = "ct(z)=a(z,z); a(t,p)=t*p; f=ct(x);x=";
   const char rightPart[] = ";";

   for (double d=-10; d<10; d+=0.33) {
      bool r = false;

      try
      { 
         char buff[255];
         char* tmp = buff;

         strcpy(buff, leftPart);
         
         while (*tmp++ != 0); tmp--;
         tmp += sprintf(tmp, "%f", d);
         //*tmp=0;
         
         strcpy(tmp, rightPart);

            //cout<<"buffer:"<<buff<<"\n";

         FunctionFactory factory(buff);
         FunctionNode* node = factory.getEquation(factory.getFunctionDictionary()->lookUp("f"));
         
         /*
         factory.print(cout);

         node->print(cout, factory.getFunctionDictionary());
         cout<<"\n";
         //*/

         double value =  node->evaluate(&FunctionContext());

         //cout<<value<<"\t"<<(d*d)<<"\n";

         assertEQ(value, d*d);

         delete node;
         r = true;
      }     
//*
      catch (FunctionFactoryParseException*) {
         cerr<<"ParseError\n";
      } catch (AssertException) {
         cerr<<"Assert failed\n";
      } catch (...) {
         cerr<<"Unknown error!\n";
      }
      //*/
      if (!r) return false;
      cout<<"OK\n";
   }
   return true;
}

