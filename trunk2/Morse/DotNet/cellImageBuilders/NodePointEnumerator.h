#pragma once

class NodePointEnumerator
{
public:
	NodePointEnumerator(int dimension, int* factors);
	virtual ~NodePointEnumerator();

public:

	void start(const JInt* node); //x = node*factor + [0..factor], 
	JInt* getCurrent();
	bool next();

private:
	int dimension;
	int* factor;

	int* b;
	JInt* x;
	JInt* x0;
};
