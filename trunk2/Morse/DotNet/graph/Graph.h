// Graph.h: interface for the Graph class.
//
//////////////////////////////////////////////////////////////////////

#ifndef GRAPH_GRAPH_H
#define GRAPH_GRAPH_H

#include "CoordinateSystem.h"
#include "MemoryManager.h"
#include "DeletingMemoryManager.h"

struct Node;
struct Edge;
struct TarjanNode;
struct NodeEnumerator;
struct EdgeEnumerator;
class GraphMemoryAllocator;
class FileInputStream;
class FileOutputStream;

class GraphComponents;

class Graph : public CoordinateSystem, private MemoryManager
{

public:
	Graph(int dimention, const JDouble* min, const JDouble* max, const JInt* grid, bool tarjanable, int nodeHashMax=13729, int edgeHashMax=7);
	
	virtual ~Graph();

	Graph* copyCoordinates(bool tarjanable);
	Graph* copyCoordinatesDevided(int* factor, bool tarjanable = true);

	Graph* Project(JInt* devidors);

protected:
	Graph* copyCoordinatesForTarjan();
	
public:
    void MergeWith(Graph* graph);

private:
	Node** nodes;
	const bool isTarjanable;


public:
	void LoadFromPointsList(const char* file);

// Hash Routins
private:
	const int nodeHashMax;
	const int edgeHashMax;

private:
	static int getNodeHashMax(int nodes);
	

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

//private:
//    DeletingMemoryManager<NodeEnumerator> cachedNodeEnumerators;
//    DeletingMemoryManager<EdgeEnumerator> cachedEdgeEnumerators;

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
	Node* findNode(const Node* node) const;

//reltions
private:
	bool equals(const JInt* c1, const JInt* c2) const; 


private:
	Node* browseToUnsafe(const JInt* cell);

	
//content Operations
public:
	Node* browseTo(const JInt* cell);
	Node* browseTo(const Node* node);
	Edge* browseTo(Node* nodeTo, Node* nodeFrom);

	void addEdges(Node* node, const JDouble* min, const JDouble* max, bool needInverse = false);
    void addEdgesRadius(Node* node, const JDouble* center, const JDouble* radius, bool needInverse = false);

    //adds node. in [0, rbound] coordinates coord[i] value will be used
    void addEdgesPartial(Node* node, int rbound, const JInt* coord, const JDouble* min, const JDouble* max);

	void addEdgesModula(Node* node, const JDouble* min, const JDouble* max, int mod_start);

	//offset1 - left bound of overlap, offset2 - right bound of overlap
	void addEdgeWithOverlaping(Node* nodeSource, JDouble* value, JDouble* offset1, JDouble* offset2);

	void maximize();
private:
	JInt* emin;
	JInt* emax;
	JInt* point;
	JInt* pointT;
	JInt* pointB;
	JInt* pointV;

    JDouble* pointMin;
    JDouble* pointMax;

	JDouble getExtent(int axis);
	

//Accessor
public:
	const JInt* getCells(Node* node) const;

private:
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


// Stable Localization
private:
	void stableLocalization_InitNode(Node* node, int flagID);
public:
	Graph* stableLocalization();

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
	//todo: Implement flagReleasing
	int registerFlag();
	void unregisterFlag(int flagID);
	bool readFlag(Node* node, int flagID);
	void setFlag(Node* node, int flagID, bool value = true);

public:
	bool isLoop(Node* node);
private:
	void setLoop(Node* node);

public:
	static Graph* createGraph(FileInputStream& o, bool loadEdges = true);
	static void	saveGraph(FileOutputStream& o, Graph* graph);
	static void	saveGraphAsPoints(FileOutputStream& o, Graph* graph);		
};

Graph*	createTestGraph(int num_nodes);

#endif //GRAPH_GRAPH_H
