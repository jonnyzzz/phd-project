#pragma once
#include "rom.h"
#include "../cellimagebuilders/abstractprocess.h"

class Graph;
class IMorseFunction;

class CRomFunction2N :
    public CRom
{
public:
    CRomFunction2N(IMorseFunction* function, Graph* graph);
    virtual ~CRomFunction2N(void);

public:
    virtual double cost(Node* node);


private:
    Graph* graph;
    IMorseFunction* function;

    int dimenstion;
    double* input;
    double* output;
};
