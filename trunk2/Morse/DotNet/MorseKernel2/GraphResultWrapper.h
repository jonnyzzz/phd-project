#pragma once

#include "resultSet.h"
#include "resultSetIterator.h"
#include "graphResult.h"
#include "writableGraphResult.h"
#include "writableResultSet.h"

class Graph;
class GraphSet;
class AbstractProcess;

class GraphResultGraphIterator {
public:
	GraphResultGraphIterator(IResultSet* result);
	~GraphResultGraphIterator();

public:
	bool HasNext();
	Graph* Current();
	void Next();

public:
	Graph* operator->();
	operator Graph*();

private:
	ResultSetIterator<IGraphResult> resultSetIterator;
};



class GraphResultGraphList {
public:
	GraphResultGraphList();
	~GraphResultGraphList();

public:
	void AddGraph(Graph* graph, bool isComponent);
	void AddGraphs(GraphSet& graphSet, bool isComponent);

public:
	IResultSet* GetResultSet();


private:
	IWritableResultSet* resultSet;

};
