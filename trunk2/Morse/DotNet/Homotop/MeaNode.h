#pragma once

#include <set>
using namespace std;

class MeaNode;
typedef set<MeaNode*> MeaNodeSet;
class MeaGraphImpl;
struct MeaNodeComparator;


enum Color {
	WHITE, GREY, BLACK
};


class MeaNode
{
	friend class MeaGraphImpl;
private:
	Color myColor;
	Node* myNode;
	int myDistance;
	Graph* myGraph;
	MeaNodeSet myAdjacents;
	int myNumber;
	MeaGraphImpl* myMeaGraph;
	//const int myColor2 = 0;
	//int myColor3 = myColor;
protected:
	MeaNode(MeaGraphImpl* meaGraph, Node* hisNode, Graph* hisGraph);
public:
	~MeaNode(void);
	MeaNode(const MeaNode& copy);
public:
	virtual Color getColor() const;
	virtual void setColor(Color color);
	int getDistance()const;
	void setDistance(int dist);
	MeaNodeSet getAdjacentNodes ();
	void createEdge(const MeaNode& destination);
	bool equals (const MeaNode& node) const;
	bool operator==(const MeaNode& node) const;
	bool operator<(const MeaNode& node) const;
private:
	Graph& getGraph();

	
public:
	Node* getHisNode(void);
};
/*
struct MeaNodeComparator : public std::binary_function<MeaNode*, MeaNode*, bool> {
	bool operator()(MeaNode& left, MeaNode& right) const {
		cout<<"Comparator!!!";
		return left.myNode<right.myNode;
	}
};
*/