#pragma once

#include "AbstractProcess.h"

class Function;
class Graph;

class MSUniversalPointBuilder : 
	public AbstractProcess
{
public:
	MSUniversalPointBuilder(Graph* graph, Function* function, JInt* factor, JInt* ks);
	virtual ~MSUniversalPointBuilder(void);

public:
	virtual void start();
	virtual void processNextGraph(Graph* graph);
	virtual Graph* result();


private:
	AbstractProcess* process;
	Function* function;

	JInt* ks;
	JInt* factor;

private:
	bool needSameProcess(Graph* graph);

	AbstractProcess* createProcess(Graph* graph);

};


class MSUniversalPointBuilderNoImplementationException {
};

class MSUniversalPointBuilderGraphNoMatchERxception {
};

