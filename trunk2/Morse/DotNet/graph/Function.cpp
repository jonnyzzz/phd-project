#include "StdAfx.h"
#include ".\function.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


const char Function::FunctionName[] = "y%d";
const char Function::VariableName[] = "x%d";

Function::Function(FunctionFactory* factory, int dimension, int iterations) : factory(factory), dimension(dimension), iterations(iterations)
{
	cout<<"Dimension Function: "<<dimension<<"\n";

   nativeF = new FunctionNative*[dimension];
   nativeDF = new FunctionNative**[dimension];

   char buff[255];

   FunctionNativeVariableSequence seq;
   FunctionDictionary* dic = factory->getFunctionDictionary();

   for (int i=0; i<dimension; i++) {
      sprintf(buff, VariableName, i+1);
      seq.push_back(dic->lookUp(buff));
   }

   variables = new double[dimension * 3]; //double === JDouble!!! ^%)// *3 = whole for MS mode. Not used in FunctionNative
   x0 = new double[dimension];
   d0 = new double*[dimension];
   f0 = new double[dimension];
   ansD = new double*[dimension];
   ansDD = new double*[dimension];
   ansT = new double*[dimension];

   for (int i=0; i<dimension; i++) {
      d0[i] = new double[dimension];
	  ansD[i] = new double[dimension];
	  ansDD[i] = new double[dimension];
	  ansT[i] = new double[dimension];

      sprintf(buff,FunctionName, i+1);
      FunctionNode* node = factory->getEquation(buff);
      nativeF[i] = new FunctionNative(node->clone(), seq, variables);

      nativeDF[i] = new FunctionNative*[dimension];

      for (int j=0; j<dimension;j++) {
         sprintf(buff, VariableName, j+1);
         FunctionNode* dnode = node->diff(dic->lookUp(buff));
         nativeDF[i][j] = new FunctionNative(dnode, seq, variables);
      }
      delete node;
   }

   ans = new JDouble[dimension];
   gx = new JDouble[dimension];
// test();
}

Function::~Function(void)
{
   //delete factory;
   for (int i=0; i<dimension; i++) {
      delete nativeF[i];
      for (int j=0; j<dimension; j++) {
         delete nativeDF[i][j];
      }
      delete[] nativeDF[i];
      delete[] d0[i];
	  delete[] ansD[i];
	  delete[] ansDD[i];
	  delete[] ansT[i];
   }
   delete[] ansT;
   delete[] ansDD;
   delete[] ansD;
   delete[] d0;
   delete[] x0;
   delete[] f0;
   delete[] nativeDF;
   delete[] nativeF;
   delete[] variables;
   delete[] ans;
   delete[] gx;
}


JDouble* Function::getVariables() {
   return variables;
}

JDouble Function::iF(int f) {
	return nativeF[f]->evaluate();
}


JDouble Function::F(int f) {
	VERIFY( f >=0 && f < dimension);
	VERIFY( iterations > 0 );		
	
	if (iterations == 1) {
	   return iF(f);
	} else {
		for (int i=0; i<dimension; i++) {
			gx[i] = variables[i];
		}
		for (int it = 0; it<iterations; it++) {
			iF(ans);
			for (i=0; i<dimension; i++) {
				variables[i] = ans[i];
			}
		}
		for (int i=0; i<dimension; i++) {
			variables[i] = gx[i];		
		}

		return ans[i];
	}	
}

void Function::iF(JDouble* value) {
	//todo: implement it in one asm call
	for (int i=0; i<dimension; i++) {
		value[i] = iF(i);
	}
}

void Function::idF(JDouble** value) {
	for (int i=0; i<dimension; i++) {
		for (int j=0; j<dimension; j++) {
			value[i][j] = idF(i, j);
		}
	}
}

JDouble Function::idF(int f, int x) {
	return nativeDF[f][x]->evaluate();
}

JDouble Function::dF(int f, int x) {
	VERIFY( f >=0 && f < dimension);
	VERIFY( x >=0 && x < dimension);
	if (iterations == 1) { 
		return idF(f, x);
	} else {
		for (int i=0; i<dimension; i++) {
			gx[i] = variables[i];
		}
		idF(ansD);
		iF(ans);
		for (int it=1; it<iterations; it++) {
            idF(ansDD);

			for (int i=0; i<dimension; i++) {
				for (int j=0; j<dimension; j++) {
					ansT[i][j] = 0;
					for (int k=0; k<dimension; k++) {
						ansT[i][j] += ansD[i][k]*ansDD[k][j];
					}
				}
			}

			JDouble** tmp = ansT;
			ansT = ansD;
			ansD = ansT;
		}
		return ansD[f][x];
	}
}

void Function::t() {
   for (int i=0; i<dimension; i++) {
      f0[i] = nativeF[i]->evaluate();
      x0[i] = variables[i];

      for (int j=0; j<dimension; j++) {
         d0[i][j] = nativeDF[i][j]->evaluate();
      }
   }
}
         
JDouble Function::tF(int f) {
   VERIFY( f >=0 && f < dimension);	
   JDouble ret = f0[f];
   for (int i=0; i<dimension;i++) {
      ret += d0[f][i]*(variables[i]-x0[i]);
   }
   return ret;
}

JDouble Function::tdF(int f, int x) {	
   return d0[f][x];
}

void Function::print() {
   this->factory->print(cout);
   /*
   nativeF[0]->print(cout, factory->getFunctionDictionary());
   nativeDF[0][1]->print(cout, factory->getFunctionDictionary());
   */
}

int Function::getDimension() {
   return dimension;
}

void Function::test() {
   double* x = getVariables();
   for (int i=0; i<dimension; i++) x[i] = 0;
   cout<<"Dimension = "<< dimension <<"\n";
   cout<<"x[] = 0\nf0(x) = "<<F(0)<<"\n";
   t();
   cout<<"tF(0) = "<<tF(0)<<"\n";
}
