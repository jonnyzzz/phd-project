#pragma once
#include "rom.h"
#include <map>


class CRomDebug :
	public CRom
{

public:
	typedef map<Node*, double> Values;

public:
	CRomDebug(Graph* graph, const Values& values);
	virtual ~CRomDebug(void);

protected:
	virtual double cost(Node* node);

private:
	Values values;

public:
	struct ExGraph {
		Graph* graph;
		Values values;
	};

	static ExGraph createFromFile(const char* file);

};
