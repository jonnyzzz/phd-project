// CoordinateSystem.cpp: implementation of the CoordinateSystem class.
//
//////////////////////////////////////////////////////////////////////
#include "stdafx.h"
#include "CoordinateSystem.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CoordinateSystem::CoordinateSystem(int dimention, const JDouble* min, const JDouble* max, const JInt* grid)
{
   this->dimention = dimention;
   this->min = new JDouble[dimention];
   this->max = new JDouble[dimention];
   this->eps = new JDouble[dimention];
   this->grid = new JInt[dimention];

   for (int i=0; i<dimention; i++) {
      this->min[i] = min[i];
      this->max[i] = max[i];
      this->grid[i] = grid[i];
      this->eps[i] = (max[i] - min[i])/grid[i];
   }
      

}

CoordinateSystem::~CoordinateSystem()
{
   delete[] min;
   delete[] max;
   delete[] eps;
   delete[] grid;

}


///////////////////////////////////////////////////////////////////

JDouble CoordinateSystem::toExternal(JInt value, int axis) const {
   return min[axis] + eps[axis]*(JDouble)value;
}

JInt CoordinateSystem::toInternal(JDouble value, int axis) const{
   JInt ret = (JInt)((value - min[axis])/eps[axis]);

   return ret;
}

JInt CoordinateSystem::toInternalExt(JDouble value, int axis, JDouble* minValue) const {
   JInt ret = (JInt)( *minValue = ((value - min[axis])/eps[axis]));
   return ret;
}

void CoordinateSystem::toInternal(JDouble* in, JInt* out) const {
    for (int i=0; i<dimention; i++) {
        *out++ = toInternal(*in++, i);
    }
}

void CoordinateSystem::toInternal(JDouble* in, JInt* out, int axis_offset, int len) const{
    for (int i=0; i<len; i++) {
        *out++ = toInternal(*in++, i + axis_offset);
    }
}


JInt CoordinateSystem::toInternalModulo(JDouble value, int axis) const {
	return toInternal(value, axis);
}

JInt CoordinateSystem::reduce(JInt v, int i) const {
	if (v > 0) {
		return v % grid[i];
	} else {
		return (v % grid[i]) + grid[i];
	}
}

const JInt* CoordinateSystem::getGrid()const {
   return grid;
}

const JDouble* CoordinateSystem::getEps() const{
   return eps;
}

const JDouble* CoordinateSystem::getMax() const{
   return max;
} 

const JDouble* CoordinateSystem::getMin() const{
   return min;
}

int CoordinateSystem::getDimention() const {
   return dimention;
}
/////////////////////////////////////////////////////


bool CoordinateSystem::intersects(const JDouble* Min, const JDouble* Max, int u_bound) const{
   for (int i=0;i<u_bound;i++){
      if (!
         ( ( (Min[i] <= min[i]) && (min[i] <= Max[i]) ) ||
         (   (Min[i] <= max[i]) && (max[i] <= Max[i]) ) ||
         (   (min[i] <= Min[i]) && (Max[i] <= max[i]) ))
         ) return false;

   }
   
   return true;
}

bool CoordinateSystem::intersects(const JDouble* Min, const JDouble* Max) const {
	return intersects(Min, Max, dimention);
}

bool CoordinateSystem::intersects(const JInt* cell) const{
   for (int i=0; i<dimention; i++) {
      if ((cell[i] < 0) || (cell[i] >=  grid[i])) return false;
   }
   return true;
}


/////////////////////////////////////////////////////////////////////////////////

bool CoordinateSystem::equals(CoordinateSystem* cs) const {
   if (cs->dimention != this->dimention) return false;

   for (int i=0; i<dimention; i++) {
      if (this->min[i] != cs->min[i]) return false;
      if (this->max[i] != cs->max[i]) return false;
      if (this->grid[i] != cs->grid[i]) return false;
   }

   return true;
}