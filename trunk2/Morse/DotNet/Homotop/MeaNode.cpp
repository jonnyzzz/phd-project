#include "StdAfx.h"
#include ".\meanode.h"
#include "meagraphimpl.h"

static int ourNumbers = 0;

MeaNode::MeaNode(MeaGraphImpl* meaGraph, Node* hisNode, Graph* hisGraph)
{
	myMeaGraph = meaGraph;
	myNumber = ourNumbers++;
	myNode = hisNode;
	myColor = WHITE;
	myDistance = 0;
	myGraph = hisGraph;
	cout<<"constructing node No."<<myNumber<<"\n";
	//cout<<"color:"<<myColor;
}

MeaNode::MeaNode(const MeaNode& copy) : myAdjacents(copy.myAdjacents) {
	myNode = copy.myNode;
	myDistance = copy.myDistance;
	myColor = copy.myColor;
	myGraph = copy.myGraph;
}
MeaNode::~MeaNode(void)
{
	cout<<"destructing node No."<<myNumber<<"\n";
}

Color MeaNode::getColor() const {
	return myColor;
}

void MeaNode::setColor(Color color) {
	myColor = color;
}
int MeaNode::getDistance()const{
	return myDistance;
}
void MeaNode::setDistance(int dist)
{
	myDistance = dist;
}
Graph& MeaNode::getGraph(){
	return *myGraph;	
}
MeaNodeSet MeaNode::getAdjacentNodes (){
	//return myAdjacents;/*
	MeaNodeSet result;
	Graph& g = getGraph();
	EdgeEnumerator* ee = g.getEdgeRoot(myNode);
	Edge* tempEdge;
	Node* tempNode;
	while (tempEdge = g.getEdge(ee)){
			tempNode = g.getEdgeTo(tempEdge);
			MeaNode* tempMeaNode = myMeaGraph->findNode(tempNode);
			assert(tempMeaNode!=NULL);
			result.insert(tempMeaNode);
	}	
	return result;
}

void MeaNode::createEdge(const MeaNode& destination){
	Graph& g = getGraph();
	Edge* edge = g.browseTo(myNode, destination.myNode);	
}

bool MeaNode::equals (const MeaNode& node) const{
	return myNode==node.myNode;
}

bool MeaNode::operator==(const MeaNode& node) const {
	cout<<"== has been called!\n";
	//return 0;
	return equals(node);	
}

bool MeaNode::operator<(const MeaNode& node) const {
	return myNode<node.myNode;
}
Node* MeaNode::getHisNode(void)
{
	return myNode;
}
