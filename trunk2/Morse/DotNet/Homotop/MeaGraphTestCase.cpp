#include "StdAfx.h"
#include ".\meagraphtestcase.h"
#include "meagraphimpl.h"
#include "meanode.h"
#include "meagraphalgorithm.h"
MeaGraphTestCase::MeaGraphTestCase(void)
{
}

MeaGraphTestCase::~MeaGraphTestCase(void)
{
}
void MeaGraphTestCase::testFreshEdgeMakesDestinationAdjacent(void){
	MeaGraphImpl g;
	MeaNode& firstNode = g.addNode();
	MeaNode& secondNode = g.addNode();
	firstNode.createEdge(secondNode);
	MeaNodeSet adjacentNodes = firstNode.getAdjacentNodes();
	assert(adjacentNodes.find(&secondNode)!=adjacentNodes.end());
	cout<<"MeaGraphTestCase::testFreshEdgeMakesDestinationAdjacent passed\n";

}
void MeaGraphTestCase::testSingleContourOnlyGraph(void){
	MeaGraphImpl g;
	MeaNode& firstNode = g.addNode();
	MeaNode& secondNode = g.addNode();
	MeaNode& thirdNode = g.addNode();
	firstNode.createEdge(secondNode);
	secondNode.createEdge(thirdNode);
	thirdNode.createEdge(firstNode);
	MeaGraphAlgorithm algorithm;
	MeaNodeSet result = algorithm.searchContour(firstNode);
	assert(result.size()==3);
	cout << "MeaGraphTestCase::testSingleContourOnlyGraph passed\n";
}
