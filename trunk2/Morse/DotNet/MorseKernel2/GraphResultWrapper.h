#pragma once

#include "graphResult.h"
#include "writableGraphResult.h"

class Graph;
class AbstractProcess;

class GraphResultGraphIterator {
public:
	GraphResultGraphIterator(IGraphResult* result);
	~GraphResultGraphIterator();

public:
	bool hasNext();
	Graph* Current();
	void Next();

public:
	Graph* operator->();
	operator Graph*();

private:
	int index;
	IGraphResult* result;
};



class GraphResultGraphList {
public:
	GraphResultGraphList(IWritableGraphResult* result);
	~GraphResultGraphList();

public:
	void AddGraph(Graph* graph, bool isComponent);


private:
	IWritableGraphResult* result;

};

class GraphResultUtil {
public:
	void PerformProcess(AbstractProcess* process, IGraphResult* input, IWritableGraphResult* output, bool isStrongComponent);

};