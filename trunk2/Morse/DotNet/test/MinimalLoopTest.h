#pragma once
#include "testbase.h"

struct Node;
class Graph;

class MinimalLoopTest :
	public TestBase
{
public:
	MinimalLoopTest(ostream& o);
	virtual ~MinimalLoopTest(void);


public:

	virtual void Test();

private:
	Node* to(int id);
	void to(int from, int t);

	void testOneAnswer(int id, Graph* result);
	
private:
	Graph* graph;
};
