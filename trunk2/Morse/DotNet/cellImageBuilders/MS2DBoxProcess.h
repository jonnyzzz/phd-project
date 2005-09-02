#pragma once
#include "abstractprocessext.h"
#include "../systemFunction/MS2DAngleFunction.h" 
#include <list>
using namespace std;
struct Node;


class MS2DBoxProcess :
    public AbstractProcessExt
{
public:

    //factor is int[3] here. But factor[0] == factor[1] == 1 is asserted
    MS2DBoxProcess(MS2DAngleFunction* function, Graph* original, Graph* si, int* factor, ProgressBarInfo* info);
    virtual ~MS2DBoxProcess(void);

private:
    class Segment {
    public:
        double left;
        double right;
        Node* node;
        Segment(Node* node, double left, double right) : node(node), left(left), right(right) {};
    };

    typedef list<Segment> SegmentList;
    
public:
    virtual void processNextGraph(Graph* graph);
    virtual void start();

protected:
    void multiplyNode(Node* node, Graph* graph);
    void processNode(Node* resultNode, SegmentList& list);

private:
    Graph* siGraph;
    MS2DAngleFunction* function;
    int* factor;
    int dimension;

    JDouble* x;
    JInt* xi;
    JDouble* input;
    JDouble* output;

    JDouble* amin;
    JDouble* amax;
};
