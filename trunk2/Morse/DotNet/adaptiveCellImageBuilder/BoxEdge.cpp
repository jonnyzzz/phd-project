#include "StdAfx.h"
#include ".\boxedge.h"

BoxEdge::BoxEdge(JDouble* point) : point(point), valueCache(NULL)
{
}

BoxEdge::~BoxEdge(void)
{
}


JDouble* BoxEdge::GetCachedValue() {
    return valueCache;
}

JDouble* BoxEdge::GetPoint() {
    return point;
}

void BoxEdge::SetCachedValue(JDouble* cache) {
    this->valueCache = cache;
}
