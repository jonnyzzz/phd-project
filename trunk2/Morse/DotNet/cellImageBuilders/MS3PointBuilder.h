#pragma once
#include "sipointbuilder.h"

class MS3PointBuilder :
	public SIPointBuilder
{
public:
	MS3PointBuilder(Graph* graph, int* factor, int* ks, Function* function);
	virtual ~MS3PointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, JInt* answer);


private:
	struct angle {
		JDouble phi;
		JDouble psi;
	};

	angle getAngle(const JDouble* v);
};
