// Graph.h: interface for the Graph class.
//
//////////////////////////////////////////////////////////////////////
#pragma once

#include "CoordinateSystem.h"

struct Node;
struct Edge;
struct NodeEnumerator;
struct EdgeEnumerator;
class GraphMemoryAllocator;
class FileInputStream;
class FileOutputStream;

class GraphComponents;

class Graph : public CoordinateSystem
{
public:
	Graph(int dimention, const JDouble* min, const JDouble* max, const JInt* grid);
	virtual ~Graph();

	Graph* copyCoordinates();

//memory routine
//private:
//	GraphMemoryAllocator* memoryAllocator;


private:
	Node** nodes;

// Hash Routins
private:
	int nodeHashMax;
	int edgeHashMax;

private:
	int _hash(const JInt* cells) const;
	int hash(const JInt* cells) const;
	int hash(const Node* node) const;
	int hash(const Edge* edge) const;
	int hash(const Node* from, const Node* to) const;

public:
    int Hash(const Node* node) const;

// Allocators
private:	
	Node* newNode(const JInt* cells);
	Edge* newEdge(Node* to);
//Deallocators
private:
	void deleteNode(Node* node);
	void deleteEdge(Edge* edge);

//Statistics
private:
	JInt numberNodes;
	JInt numberEdges;

//Enumerations
public:
	NodeEnumerator* getNodeRoot();
	EdgeEnumerator* getEdgeRoot(const Node* node);

	Node* getNode(NodeEnumerator*);
	Edge* getEdge(EdgeEnumerator*);

	void freeNodeEnumerator(NodeEnumerator*&en);
	void freeEdgeEnumerator(EdgeEnumerator*&en);

//Adding edges, nodes
private:
	Edge* addEdge(Node* nodeFrom, Node* nodeTo);
	Node* addNode(const JInt* cell);

//finding edges, nodes
public:
	Edge* findEdge(const Node* nodeFrom, const Node* nodeTo) const ;
	Node* findNode(const JInt* cell) const;

//reltions
private:
	bool equals(const JInt* c1, const JInt* c2) const; 


//content Operations
public:
	Node* browseTo(const JInt* cell);
	Edge* browseTo(Node* nodeTo, Node* nodeFrom);

	void addEdges(Node* node, const JDouble* min, const JDouble* max);
	void addEdgesModula(Node* node, const JDouble* min, const JDouble* max, int mod_start);
	void maximize();
private:
	JInt* emin;
	JInt* emax;
	JInt* point;
	JInt* pointT;
	JDouble getExtent(int axis);
	

//Accessor
public:
	const JInt* getCells(Node* node) const;
	JInt  getNodeNumber(Node* node) const;
	void  setNodeNumber(Node* node, JInt number);

//StrongComponentsLocalization
public:
	GraphComponents* localazeStrongComponents();
	void resolveEdges(Graph* parent);
private:
	JInt tmin(JInt a, JInt b) const;

// Loops localization
public:
	Graph* localizeLoops();

//Quantitive Info
public:
	JInt getNumberOfNodes() const;
	JInt getNumberOfArcs() const;

	Node* getEdgeTo(Edge* e) const;

//Comparison
public:
	bool equals(Graph* graph) const; 

//NodeFlags:
private:
	int flagCounter;
	int isLoopFlagID;

public:
	//todo: Incapsulate flagID for more safetyness usage
	int registerFlag();
	bool readFlag(Node* node, int flagID);
	void setFlag(Node* node, int flagID, bool value = true);

private:
	bool isLoop(Node* node);
	void setLoop(Node* node);
	
};

Graph*	createGraph(FileInputStream& o);
void	saveGraph(FileOutputStream& o, Graph* graph);
