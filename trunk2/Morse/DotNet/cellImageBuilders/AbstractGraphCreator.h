#ifndef _CEEIMAGEBUILDERS_ABSTRACTGRAPHCREATOR_H
#define _CEEIMAGEBUILDERS_ABSTRACTGRAPHCREATOR_H

#include "AbstractProcessExt.h"

class AbstractGraphCreator : public AbstractProcessExt
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


private:
	void putNodes(Graph* from, Graph* to, Node* node);
};

#endif //_CEEIMAGEBUILDERS_ABSTRACTGRAPHCREATOR_H

