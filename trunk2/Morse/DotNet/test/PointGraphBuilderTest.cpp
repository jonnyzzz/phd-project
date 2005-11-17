#include "stdafx.h"
#include "PointGraphBuilderTest.h"
#include "../AdaptiveCellImageBuilder/PointGraph.h"
#include "../AdaptiveCellImageBuilder/PointGraphBuilder.h"
#include <fstream>

PointGraphBuilderTest::PointGraphBuilderTest(void) : TestBase("PointGraphBuilder", cout)
{
}

PointGraphBuilderTest::~PointGraphBuilderTest(void)
{
}

namespace {
    template<int dim>
    class MyFunction : public ISystemFunction 
    {
    private:
        double in[dim];
        double out[dim];

    public:
        MyFunction () : ISystemFunction(dim, 1) {}
        virtual ~MyFunction(void) {}

    public:    
        virtual double* getInput()  { return in; }
        virtual double* getOutput() { return out;} 

        virtual void evaluate()  { for(int i=0;i<dim;i++) out[i]=in[i]; }

    public:
        virtual bool isNative() { return false; }
        virtual bool hasFunction() { return true; }
        virtual bool hasDerivative() {return false; }	

    };
};



void PointGraphBuilderTest::Test() {
    
    JDouble eps[] = {1,1,1};
    smartPointer<ISystemFunction> func = new MyFunction<3>();
    PointGraph pg(func, func->getFunctionDimension());
    PointGraphBuilder pgb(func->getFunctionDimension(), eps, pg);

    JDouble x[] = {0,0,0};

    pgb.BuildInitialGraph(x);


    ofstream o;
    o.open("o:\\3D");
    pg.Dump(o);
    o.flush(); 

    JDouble p[] = {0.07,0.07,0.07};
    pg.Iterate(p);

    pg.Dump(o);
    o.flush();
    pg.Dump(cout);

    o.close();
}