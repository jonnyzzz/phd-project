#pragma once
#include "AdaptiveProcessBase.h"
#include "../graph/memoryManager.h"
#include <list>
using namespace std;

class AdaptiveBoxMethod :
    public AdaptiveProcessBase
{
private:

    struct BoxEdge {
        JDouble* point;
        JDouble* valueCache;
        BoxEdge(JDouble* point): point(point), valueCache(NULL) {}
    };

    typedef pair<BoxEdge, BoxEdge> Cell;
    typedef list<Cell> CellsList;
    typedef list<BoxEdge> BoxList;


public:
    AdaptiveBoxMethod(ISystemFunction* function, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info);
    virtual ~AdaptiveBoxMethod(void);

protected:
    virtual void processResultNode(Node* node);

    void processCells(CellsList& cells, BoxList& boxes);

    bool check(Cell& cell);

private:
    void evaluateBox(BoxEdge& box);


private:
    double* arraycopy(const double* node);
    void arraycopy(double* to, const double* from);
    double* createArray();
    double Abs(double x);

private:
    MemoryManager manager;
    JDouble* input;
    JDouble* output;

};
