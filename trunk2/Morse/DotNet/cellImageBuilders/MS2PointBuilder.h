#pragma once
#include "sipointbuilder.h"

class MS2PointBuilder :
	public SIPointBuilder
{
public:
	MS2PointBuilder(Graph* graph, int* factor, int* ks, Function* function);
	virtual ~MS2PointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, JInt* answer);	

private:
	JDouble tR();
};
