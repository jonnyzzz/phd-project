#pragma once

class NodeMultiplicator {
public:
	NodeMultiplicator(int dimension, const JDouble* eps, int* factors);
	virtual ~NodeMultiplicator();

public:
	void start(JDouble* node); //suppose node to be constant!
	
	bool next();

	void setCoordinateReturn(JDouble* x);

private:
	int dimension;

	JDouble* x0;
	JDouble* x;
	JDouble* eps;
	int* factors;

	int* b;
};