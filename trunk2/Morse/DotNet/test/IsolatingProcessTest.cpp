#include "StdAfx.h"
#include ".\isolatingprocesstest.h"
#include "../homotop/isolatingset.h"

IsolatingProcessTest::IsolatingProcessTest(ostream& o) : TestBase("Isolating Test", o)
{
}

IsolatingProcessTest::~IsolatingProcessTest(void)
{
}


void IsolatingProcessTest::Test() {
	reset();

	to(1, 2);
	to(2, 3);
	to(3, 1);

	testLen(3, getGraph());

	
	reset();

	to(1, 2);
	to(2, 3);
	to(3, 4);
	to(4, 5);
	to(5, 1);
	to(5, 2);
	to(1, 5);

	SimpleGraphApi st;
	st.to(1, 5);
	st.to(5, 1);

	testLen(2, st.getGraph());

	to(2, 1);
	
	testLen(3, st.getGraph());

	to(5, 6);
	to(6, 5);

	testLen(4, st.getGraph());

	to(3, 2);

	//fails
	testLen(6, st.getGraph());

	to(6, 7);
	to(7, 6);

	//fails
	testLen(7, st.getGraph());

	to(7, 8);
	to(8, 7);

	testLen(8, st.getGraph());

	to(8, 4);

	testLen(8, st.getGraph());
	
}

void IsolatingProcessTest::testLen(int len, Graph* start) {

	cout<<"\n\n--------------------------------------\n\n";

	IsolatingSetProcess ps (getGraph(), start, &ProgressBarInfo());
	ps.start();
	ps.processNextGraph( getGraph() );

	Graph* g = ps.result();

	AssertTrue(g->getNumberOfNodes() == len, "Incorrect result graph", __LINE__);
	
	delete g;
}