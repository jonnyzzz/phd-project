#pragma once
#include "rom.h"


class FunctionMS;
class Graph;

class CRomMS :
	public CRom
{
public:
	CRomMS(FunctionMS* function, Graph* graph);
	virtual ~CRomMS(void);

protected:
	virtual JDouble cost(Node* node);

private:
	JDouble* variables;
	FunctionMS* function;	
};
