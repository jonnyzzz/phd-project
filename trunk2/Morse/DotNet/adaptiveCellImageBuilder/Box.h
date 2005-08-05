#pragma once

#include "..\systemFunction\ISystemFunction.h"
#include "..\graph\MemoryManager.h"
#include "..\graph\typedefs.h"

class Point 
{
public:
    Point(JDouble* coordinate);
public:
    JDouble* points() const;
private:
    JDouble* coordinate;
};

Point Middle(const Point& pp1, const Point& pp2, int dimension, MemoryManager& man);


class Box
{
public:
    Box();
    virtual ~Box(void);
};
