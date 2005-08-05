#include "StdAfx.h"
#include ".\box.h"


Point::Point(JDouble* coordinate) : coordinate(coordinate) {}
    
JDouble* Point::points() const {
    return coordinate;
}


Point Middle(const Point& pp1, const Point& pp2, int dimension, MemoryManager& man) {
    JDouble* data = man.AllocateArray<JDouble>(dimension);
    JDouble* p1 = pp1.points();
    JDouble* p2 = pp2.points();
    for (int i=0; i<dimension;i++) {
        data[i] = (p1[i] + p2[i])/2;
    }
    return Point(data);
}

/////////////////////////////////////////////////////



void CheckArcs(const Point& pt1, const Point& pt2, ISystemFunction* function, int dimension) {
    JInt* b = new JInt[dimension+1];
    ZeroMemory(b, sizeof(JInt)*(dimension+1));


}