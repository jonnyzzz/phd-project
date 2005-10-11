#ifndef _GRAPHSET_H
#define _GRAPHSET_H

class GraphComponents;
class Graph;

#include <list>
using namespace std;

class GraphSetIterator;

class GraphSet
{
public:
	GraphSet(GraphComponents* cms);
	GraphSet(Graph* graph);
	GraphSet(const GraphSet& graphSet);
	GraphSet();
	~GraphSet(void);

public:
	GraphSet& operator = (const GraphSet& graphSet);
	
public:
	int Length();
	Graph* operator[] (int index);

public:
	void AddGraph(Graph* graph);
	void AddGraph(GraphComponents* cms);
	void AddGraph(const GraphSet& graphSet);

public:
	GraphSetIterator iterator();

private:
	typedef list<Graph*> GraphList;
	GraphList graphList;

private:
	void copyFrom(const GraphSet& graphSet);
	void copyFrom(GraphComponents* cms);

public: 
	void DeleteGraphs();
};


class GraphSetIterator {
private:
	GraphSet graphSet;
	int index;

public:
	GraphSetIterator(const GraphSet& graphSet);

public:
	bool HasNext();
	void Next();
	Graph* Current();

	Graph* operator -> ();
	operator Graph*();

};

#endif
