#pragma once
#include "meanode.h"

struct AlgItem;
class MeaGraphAlgorithm
{
public:
	MeaGraphAlgorithm(void);
	~MeaGraphAlgorithm(void);
	MeaNodeSet searchContour(MeaNode& sourceNode);

private: void contour(AlgItem* item, MeaNodeSet& nodeSet);
};
