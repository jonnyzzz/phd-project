#pragma once

#include "AbstractProcess.h"

class AbstractGraphCreator : public AbstractProcess
{
public:
    AbstractGraphCreator(Graph* base, int* factor, ProgressBarInfo* info);
	virtual ~AbstractGraphCreator(void);


public:
	virtual void processNextGraph(Graph* graph);
	virtual void start();

protected:
	virtual JDouble getMin(int i) = 0;
	virtual JDouble getMax(int i) = 0;
    virtual int getNewDimension() = 0;

private:
	int dimensionNew;
	int dimensionOld;
	int* b;
	int* factor;
	JInt* point;
	JInt* tpoint;
	

private:
	Graph* createEmptyGraph(Graph* graph);

	void putNodes(Graph* from, Graph* to, Node* node);
};
