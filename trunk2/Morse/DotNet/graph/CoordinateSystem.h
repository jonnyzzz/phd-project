// CoordinateSystem.h: interface for the CoordinateSystem class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_COORDINATESYSTEM_H__32E37CB5_FFD7_49B8_B907_ED003DD5D264__INCLUDED_)
#define AFX_COORDINATESYSTEM_H__32E37CB5_FFD7_49B8_B907_ED003DD5D264__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "typedefs.h"

class CoordinateSystem  
{
public:
	CoordinateSystem(int dimention, const JDouble* min, const JDouble* max, const JInt* grid);
	virtual ~CoordinateSystem();

public:

    void toInternal(JDouble* in, JInt* out) const; 
    void toInternal(JDouble* in, JInt* out, int axis_offset, int len) const; 
	JInt toInternal(JDouble value, int axis) const;

	JInt toInternalModulo(JDouble value, int axis) const;

	JDouble toExternal(JInt value, int axis) const;

	const JInt* getGrid() const;
	const JDouble* getMin() const;
	const JDouble* getMax() const;
	const JDouble* getEps() const;

	int getDimention() const;

	JInt reduce(JInt v, JInt i) const;

public:
	bool intersects(const JDouble* min, const JDouble* max, int u_bound) const;
	bool intersects(const JDouble* min, const JDouble* max) const;
	bool intersects(const JInt* cell) const;

	bool equals(CoordinateSystem* cs) const;


protected:
	int dimention;

	JDouble* min;
	JDouble* max;
	JDouble* eps;
	JInt* grid;
};

#endif // !defined(AFX_COORDINATESYSTEM_H__32E37CB5_FFD7_49B8_B907_ED003DD5D264__INCLUDED_)
