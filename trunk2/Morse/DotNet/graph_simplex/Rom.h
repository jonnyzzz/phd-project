#pragma once

#include <hash_map>
#include <map>
using namespace std;
using namespace stdext;

class Graph;
struct Node;
struct Edge;
class Function;

class CRom
{
public:
	CRom(Graph* graph);	
	virtual ~CRom(void);

protected:
	double factor;	
	Graph* graph;

private:
	enum Type {
		M0 = -2,
		M1 = -1,
		M2 = 0
	}; 

	struct ContourNode {
		Node* node;	
		ContourNode* next; //tree-like 

		double node_cost;

		double v;

		int type; //M2 default<=> !M0 && !M1

		ContourNode();
	};

	typedef hash_map<Node*, ContourNode*> EGraph;
	typedef EGraph::iterator EGraphIterator;

	ContourNode* nodes;
	ContourNode* nodes_alloc;
	EGraph egraph;

protected:
	virtual double cost(Node* node) = 0;

private:
	ContourNode* getContourNode(Node* node);
	ContourNode* getContourNodeTo(Edge* edge);

	
	double cost(Edge* e);
	double cost(ContourNode* node);
	double contour_cost(ContourNode* node); //in a contour. link by ->next

	bool isSub(ContourNode* root, ContourNode* i1, ContourNode* i2);
	bool preceed(ContourNode* root, ContourNode* i1, ContourNode*i2);

	bool tree(ContourNode*& node);


	void cleanUP();

	ContourNode* minimize(ContourNode* node);

	ContourNode* createNode(Node* node);
	ContourNode* createNodeTo(Edge* edge);
	ContourNode* init();

	void createTreeInit(ContourNode* root);

public:
	void maximize();
	void minimize();

	double getAnswer();
	int getAnswerLength();

private:
	double answerValue;
	ContourNode* extrema;

private:
	void dump();

private:
	class myAllocator;
	typedef map<ContourNode*, myAllocator> map_ids;
	
	map_ids ids;

    int ids_subber;
	void dumpNode(ContourNode* node);

	void dumpGraph();

	void bigDump(ContourNode* node);

	int getID(ContourNode* node);

	void dumpExtremaContour(ostream& o, ContourNode* node);

};

