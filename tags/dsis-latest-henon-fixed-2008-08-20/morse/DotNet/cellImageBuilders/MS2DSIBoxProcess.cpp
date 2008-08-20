#include "stdafx.h"
#include "MS2DSIBoxProcess.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MS2DSIBoxProcess::MS2DSIBoxProcess(MS2DAngleFunction* function, Graph* graph, int* factor, ProgressBarInfo* info)
: AbstractBoxProcess(graph, function->GetInternalFunction(), factor, info), centerOutput(AbstractBoxProcess::getCurrentCenterValue())  ,
  function(function)
{
}

MS2DSIBoxProcess::~MS2DSIBoxProcess(void)
{
}


void MS2DSIBoxProcess::processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* resultNode, Graph* graph_result) {
	//NOTE!!!
	//TODO:
	//TODO: Here we use assumption that in SystemFunctionDerivate object of MS2DAngleFunction is value of center point of that cell
	double left;
    double center;
    double right;
       
    input[2] = graph_result->toExternal(graph_result->getCells(resultNode)[2],2);
    left = function->evaluateAngle();

    input[2]+= graph_result->getEps()[2]/2;
    center = function->evaluateAngle();

    input[2]+= graph_result->getEps()[2]/2;
    right = function->evaluateAngle();

    if (right < left) {
        double t = left;
        left = right;
        right = t;
    }
    
    if (left <= center && center <= right) {
		value_min[2] = left;
		value_max[2] = right;
		graph_result->addEdges(resultNode, value_min, value_max);
        //list.push_back(Segment(resultNode, left, right));        
    } else {
		value_min[2] = -M_PI_2;
		value_max[2] = left;
		graph_result->addEdges(resultNode, value_min, value_max);

		value_min[2] = right;
		value_max[2] = M_PI_2;
		graph_result->addEdges(resultNode, value_min, value_max);

        //list.push_back(Segment(resultNode, -M_PI_2, left));
        //list.push_back(Segment(resultNode, right, M_PI_2));
    }
}

