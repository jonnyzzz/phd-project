#pragma once
#include "AbstractBoxProcess.h"


class ProjectiveSystemFunctionDerivate;

class MSSegmentBoxProcess :
    public AbstractBoxProcess
{
public:
    MSSegmentBoxProcess(ProjectiveSystemFunctionDerivate* function, Graph* original, int* factor, ProgressBarInfo* info);
    virtual ~MSSegmentBoxProcess(void);


public:
    virtual void processNodeAndImage(JDouble* value_min, JDouble* value_max, Node* node, Graph* graph_result);


private:
    double* input;
    double* output;
    int dimention; //of function

    double* inputV;
    double* outputV;
};
