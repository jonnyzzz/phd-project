#include "StdAfx.h"
#include ".\foodchain3d.h"
#include <math.h>
#include "../Graph/graph.h"

FoodChain3D::FoodChain3D(void) : FunctionBase(3,1)
{
}

FoodChain3D::FoodChain3D(double* input, double* output) : FunctionBase(3,1,input, output)
{
}


FoodChain3D::~FoodChain3D() {
}

double inline  FoodChain3D::Max(double x, double y) {
	return x>y ? x : y;
}

int FoodChain3D::getFunctionDimension() {
	return 3;
}

double FoodChain3D::g(double t) {
	return (1-exp(-t))/t;
}

void FoodChain3D::evaluate() {

 double* f = output;
 double x = input[0];
 double y = input[1];
 double z = input[2];

 double expy = exp(-y);
 double expz = exp(-z);
 double gxgz = g(z)*g(y);

 bool expyGgxgz = expy > gxgz;

 f[0] = a*x*expy/(1 + x * (expyGgxgz ?  expy : gxgz));
 f[1] = b*x*y*g(y)*exp(-z)*g(d*y*z);
 f[2] = c*y*z;

 if ( ComputeDerivate() ) {
	 {
		double t1 = expy;      
		double t3 = expz;
		double t11 = (t1>(-1.0+t3)*(-1.0+t1)/z/y ? t1 : (-1.0+t3)*(-1.0+t1)/z/y);
		double t14 = pow(1.0+x*t11,2.0);
		f[3] = a*t1/t14;
	 }
	 ///f[4] = F(1)/dy
		if (expyGgxgz) {
			double t2 = expy;	
			double t4 = y*y;
			double t6 = y*x;
			double t7 = expz;
			double t9 = x*t2;
			double t10 = x*t7;
			double t12 = exp(-y-z);
			double t13 = x*t12;
			double t18 = pow(z*y+x-t9-t10+t13,2.0);
			f[4] = -a*x*t2*z*(z*t4+t6-t6*t7-x+t9+t10-t13)/t18;
		} else {
			double t2 = expy;      
			double t4 = y*y;
			double t6 = y*x;
			double t7 = expz;
			double t9 = x*t2;
			double t10 = x*t7;
			double t12 = exp(-y-z);
			double t13 = x*t12;
			double t18 = pow(z*y+x-t9-t10+t13,2.0);
			f[4] = -a*x*t2*z*(z*t4+t6-t6*t7-x+t9+t10-t13)/t18;
		}
	 //f[5] = F(1)dz
	 if (expyGgxgz) {
		 f[5] = 0;
	 } else {
		double t1 = x*x;      
		double t3 = expy;
		double t7 = expz;
		double t14 = exp(-y-z);
		double t17 = pow(z*y+x-x*t3-x*t7+x*t14,2.0);
		f[5] = a*t1*t3*y*(-1.0+t3)*(t7*z-1.0+t7)/t17;
	 }
	 //f[6] - F(2)dx
	 {
		double t1 = expy;      
		double t4 = expz;
        double t8 = exp(-d*y*z);
        f[6] = b*(-1.0+t1)*t4*(-1.0+t8)/d/y/z;
	 }
	 //f[7] - f(2)dy
	 {
		double t2 = expz;      
		double t3 = d*y;
        double t6 = exp(-z*(1.0+t3));
        double t8 = exp(-y-z);
        double t11 = exp(-y-z-t3*z);
        double t13 = t11*y;
        double t15 = d*z;
        double t20 = y*y;
        f[8] = b*x*(-t2+t6+t8-t11+t8*y-t13+t6*y*t15-t13*t15)/t20/d/z;
	 }
	 //f[8] - f(2)dz
	 {
		double t2 = expy;      
		double t5 = expz;
        double t7 = d*y;
        double t10 = exp(-z-t7*z);
        double t14 = exp(-z*(1.0+t7));
        double t22 = z*z;
        f[8] = -b*x*(-1.0+t2)*(-t5*z+t10*z+t14*y*d*z-t5+t10)/y/d/t22;
	 }
	 //f[9] - f(3)dx
	 {
		 f[9] = 0;
	 }
     //f[10] - f(3)dy
	 {
		 f[10] = c*z;
	 }
	 //f[11] - f(3)dz
	 {
		 f[11] = c*y;
	 }
 }
}

double FoodChain3D::a = 0;
double FoodChain3D::b = 0;
double FoodChain3D::c = 0;
double FoodChain3D::d = 0;

const int FoodChain3DFactory::Dim = 3;

Graph* FoodChain3DFactory::CreateGraph() {
	double _min[] = {0.01, 0.001, 0.001};
	double _max[] = {20, 20, 20};
	int _grid[] = {5,5,5};

	Graph* g = new Graph(3, _min, _max, _grid, false, 1, 1);
    g->maximize();
	return g;
}

void FoodChain3DFactory::Dump() {
	cout<<"FoodChain with a="<<FoodChain3D::a <<" b="<<FoodChain3D::b<<" c="<<FoodChain3D::c<<" d="<<FoodChain3D::d<<endl;
}