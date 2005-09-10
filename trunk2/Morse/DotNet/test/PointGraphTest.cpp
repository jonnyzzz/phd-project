#include "StdAfx.h"
#include ".\pointgraphtest.h"
#include "..\AdaptiveCellImageBuilder\PointGraph.h"
#include "..\SystemFunction\ISystemFunction.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


class MyFunction : ISystemFunction 
{
private:
    double in;
    double out;

public:
    MyFunction () : ISystemFunction(1, 1) {}
    virtual ~MyFunction(void) {}

public:    
    virtual double* getInput()  { return &in; }
    virtual double* getOutput() { return &out;} 

    virtual void evaluate()  { out = in; }

public:
    virtual bool isNative() { return false; }
    virtual bool hasFunction() { return true; }
    virtual bool hasDerivative() {return false; }	

};



PointGraphTest::PointGraphTest(const char* testName, ostream& o) : TestBase(testName, o)
{
}

PointGraphTest::~PointGraphTest(void)
{
}



void PointGraphTest::Test() {

  
    MyFunction function;

    PointGraph graph((ISystemFunction*)&function, 1);

    
    graph.Dump(cout);

    graph.Reset();

    double v;

    v=1;
    ASSERTTRUE(graph.AddNode(&v)->points[0] == v);
    
    graph.Reset();
    ASSERTTRUE(graph.Points().size() == 0);
    
    v=1;
    graph.AddNodeWithAllEdges(&v);
    v=2;
    graph.AddNodeWithAllEdges(&v);
    //v=3;
    //graph.AddNodeWithAllEdges(&v);

    graph.Dump(cout);

    double prec[] =  {0.4, 0.4, 0.4};

    graph.Iterate(prec);

    graph.Dump(cout); 
/*
    graph.Reset();
    v=1;
    graph.AddNodeWithAllEdges(&v);
    v=2;
    graph.AddNodeWithAllEdges(&v);

    graph.Iterate(0.4);

    graph.Dump(cout); 
    
    //*/

}