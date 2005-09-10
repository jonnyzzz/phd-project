#pragma once

#include "../graph/typedefs.h"

class BoxEdge
{
public:
    BoxEdge(JDouble* point);
    ~BoxEdge(void);

public:
    JDouble* point;
    JDouble* valueCache;    
};
