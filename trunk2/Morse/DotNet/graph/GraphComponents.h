// GraphComponents.h: interface for the GraphComponents class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_GRAPHCOMPONENTS_H__3E4A2CB8_5391_4BD3_9C7A_67824F635963__INCLUDED_)
#define AFX_GRAPHCOMPONENTS_H__3E4A2CB8_5391_4BD3_9C7A_67824F635963__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class Graph;

class GraphComponents  
{
public:
	GraphComponents();
	virtual ~GraphComponents();

public:
	void addGraphAsComponent(Graph* graph);
	Graph* getAt(int index);
	int length();

public:
	int getDimension();

private:
	struct dataS {
		Graph* graph;
		int index;
		dataS* next;
	};

	dataS* root;
	int count;

};

#endif // !defined(AFX_GRAPHCOMPONENTS_H__3E4A2CB8_5391_4BD3_9C7A_67824F635963__INCLUDED_)
