// Graph.cpp: implementation of the Graph class.
//
//////////////////////////////////////////////////////////////////////
#include "stdafx.h"
#include "Graph.h"
#include "Stack.h"
#include "GraphComponents.h"
#include "FileStream.h"
#include "GraphUtil.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define MEMORY_MANAGER

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////


struct Node {
	JInt* cell;
	/*bool isLoop; */
		
	Edge** edges;
	Node* next;

	//possible to optimize    
	int bits;
};

struct TarjanNode : Node {
	
	//tarjans stuff
	JInt label;  //tarjan markers
	JInt number; //tarjan markers
	EdgeEnumerator* enumerator;  //tarjan hard optimization of edge-list
};

struct Edge {
	Node* to;

	Edge* next;
};


Graph::Graph(int dimention, const JDouble* min, const JDouble* max, const JInt* grid, bool tarjanable, int nodeHashMax, int edgeHashMax) 
: CoordinateSystem(dimention, min, max, grid),
    MemoryManager(( sizeof(TarjanNode) +  sizeof(Edge)*edgeHashMax + sizeof(JInt)*dimention)*nodeHashMax/4 + sizeof(void*)*nodeHashMax),
	isTarjanable(tarjanable), nodeHashMax(nodeHashMax), edgeHashMax(edgeHashMax)
{	
  //	if (isTarjanable) {
  //		cout<<"Using Tarjan Graph"<<"\n";
  //	} else {
  //		cout<<"Not Using Tarjan Graph\n";
  //	}
	
	//cout<<"NodeHash = "<<this->nodeHashMax<<"\nEdgeHash = "<<this->edgeHashMax<<"\n";
    //edgeHashMax = 10000;
	//nodeHashMax = 10000;
	numberEdges = 0;
	numberNodes = 0;
	flagCounter = 0;
	isLoopFlagID = registerFlag();

#ifdef MEMORY_MANAGER
	nodes = AllocateArray<Node*>(nodeHashMax);//new Node*[nodeHashMax];
#else
    nodes = new Node*[nodeHashMax];
#endif

	for (int i=0; i<nodeHashMax; i++) {
		nodes[i] = NULL;
	}
#ifdef MEMORY_MANAGER
	emin = AllocateArray<JInt>(dimention);// new JInt[dimention];
	emax = AllocateArray<JInt>(dimention);//new JInt[dimention];
    point = AllocateArray<JInt>(dimention+1);//new JInt[dimention+1];
	pointT = AllocateArray<JInt>(dimention+1);//new JInt[dimention+1];
	pointB = AllocateArray<JInt>(dimention+1);//new JInt[dimention+1];
	pointV = AllocateArray<JInt>(dimention+1);//new JInt[dimention+1];    
#else
	emin =  new JInt[dimention];
	emax =  new JInt[dimention];
    point = new JInt[dimention+1];
	pointT = new JInt[dimention+1];
	pointB = new JInt[dimention+1];
	pointV = new JInt[dimention+1];
#endif
}




Graph::~Graph()
{
    //All Allocations now are made using memory manager
#ifndef MEMORY_MANAGER
	Node* t;
	for (int i=0;i<nodeHashMax; i++) {
		while (nodes[i] != NULL) {
			t = nodes[i];
			nodes[i] = nodes[i]->next;
			deleteNode(t);
		}
	}
	delete[] nodes;
	delete[] emin;
	delete[] emax;
	delete[] point;
	delete[] pointT;
	delete[] pointB;
	delete[] pointV;
#endif
}


Graph* Graph::copyCoordinates(bool tarjanable) {
	return new Graph(dimention, min, max, grid, tarjanable, getNodeHashMax(getNumberOfNodes()*4));
}

Graph* Graph::copyCoordinatesForTarjan() {
	return new Graph(dimention, min, max, grid, false, getNodeHashMax(getNumberOfNodes()), 1);
}

Graph* Graph::copyCoordinatesDevided(int* factor, bool tarjanable) {
	int fact = 1;
	for (int i=0; i<dimention; i++) {
		point[i] = grid[i]*factor[i];
		fact *= factor[i];
	}
	
	return new Graph(dimention, min, max, point, tarjanable, getNodeHashMax(getNumberOfNodes()*fact));
}

////////////////////////////////////////////////////////////////////////////////
///////  Hash
////////////////////////////////////////////////////////////////////////////////
const JInt primes[] = { 4733, 1669, 389, 97, 3191,97, 1499,787 ,101,7, 
					   3191, 97,  1499, 787 ,101,7, 3191,97, 1499,787,
					   101,7, 3191,97, 1499,787 ,101,7, 3191,97, 
					   1499,787,  101,7, 3191,97, 1499,787 ,101,7, 
   					   101,7, 3191,97, 1499,787 ,101,7, 3191,97, 
					   1499,787,  101,7, 3191,97, 1499,787 ,101,7, 
					   101,7, 3191,97, 1499,787 ,101,7, 3191,97, 
					   1499,787,  101,7, 3191,97, 1499,787 ,101,7, 
					   3191,97, 1499,787, 101,7, 3191,97, 1499,787,
					   101,7, 3191,97, 101,7, 3191,97, 1499,787 }; //max Dimension is 60

int Graph::getNodeHashMax(int nodes) {
	if (nodes < 100000) {
		return 13729;
	} else if (nodes < 500000) {
		return 49957;
	} else 
		return 112061;
}


int inline Graph::_hash(const JInt* cells) const {
	
	int ret = 0;
	int ret1 = 1;
	for (int i=0; i<dimention; i++) {
		ret  += cells[i];
		ret1 *= cells[i]+1;
	}
	ret += ret1;
	return ((ret>0)?ret:-ret);		
}

int inline Graph::hash(const Node* node) const{
	return _hash(node->cell)%nodeHashMax;
}

int inline Graph::hash(const JInt* cells) const {
	return _hash(cells)%nodeHashMax;
}

int inline Graph::hash(const Edge* edge) const {
	return _hash(edge->to->cell)%edgeHashMax;
}

int inline Graph::hash(const Node* /*from*/, const Node* to) const{
	return _hash(to->cell)%edgeHashMax;
}

int Graph::Hash(const Node* node) const {
    return _hash(node->cell);
}

///////////////////////////////////////////////////////////////////////////////
/////// Allocators
///////////////////////////////////////////////////////////////////////////////


Edge* Graph::newEdge(Node* to) {
#ifdef MEMORY_MANAGER
	Edge* e = Allocate<Edge>();//
#else
	Edge* e = new Edge;//Allocate<Edge>();//
#endif
	e->to = to;
	e->next = NULL;	

	numberEdges++;

	return e;
}

Node* Graph::newNode(const JInt* cells) {
	Node* node;

#ifdef MEMORY_MANAGER
	
	if (isTarjanable) {
		node = static_cast<Node*>(Allocate<TarjanNode>());		
	} else {
		node = Allocate<Node>();				
	}
	node->cell = AllocateArray<JInt>(dimention);//
	node->edges = AllocateArray<Edge*>(edgeHashMax);//
#else
	if (isTarjanable) {
		node = static_cast<Node*>(new TarjanNode);
	} else {
		node = new Node;
	}
	node->cell = new JInt[dimention]; //AllocateArray<JInt>(dimention);//
	node->edges = new Edge*[edgeHashMax]; //AllocateArray<Edge*>(edgeHashMax);//
#endif

	for (int i=0;i<dimention;i++) {
		node->cell[i] = cells[i];
	}
	
	for (int i=0;i<edgeHashMax;i++) {
		node->edges[i] = NULL;
	}

	node->next = NULL;
	node->bits = 0;
	//node->isLoop = false;
	if (isTarjanable) {
		TarjanNode* nodeEx = (TarjanNode*)node;
		
		nodeEx->label = 0;
		nodeEx->number = 0;
		nodeEx->enumerator = NULL;
	}

	numberNodes++;

	return node;
}

///////////////////////////////////////////////////////////////////////////////
/////// Deallocators
///////////////////////////////////////////////////////////////////////////////


void Graph::deleteEdge(Edge* edge) {
#ifndef MEMORY_MANAGER    //Nothing to delete. We use MemoryManager
    delete edge;
#endif
	numberEdges--;
}

void Graph::deleteNode(Node* node) {
#ifndef MEMORY_MANAGER
	Edge* t;
	for (int i=0; i<edgeHashMax; i++) {
		while (node->edges[i] != NULL) {
			t = node->edges[i];
			node->edges[i] = node->edges[i]->next;
			deleteEdge(t);
		}
	}
	
	delete[] node->edges;
	delete[] node->cell;	
	delete node;
#endif

	if (isTarjanable && ((TarjanNode*)node)->enumerator != NULL) 
		freeEdgeEnumerator(((TarjanNode*)node)->enumerator);

	numberNodes--;
}

///////////////////////////////////////////////////////////////////////////////
/////// Enumerators
///////////////////////////////////////////////////////////////////////////////


struct NodeEnumerator {
	int hash;
	Node* node;
};

struct EdgeEnumerator {
	const Node* node;
	int hash;
	Edge* edge;
};


NodeEnumerator* Graph::getNodeRoot() {
    NodeEnumerator* e = new NodeEnumerator;//cachedNodeEnumerators.Allocate(); //;
	e->hash = 0;
	e->node = nodes[0];
	return e;
}

EdgeEnumerator* Graph::getEdgeRoot(const Node* node) {
	EdgeEnumerator* e = new EdgeEnumerator;//cachedEdgeEnumerators.Allocate();// 
	e->node = node;
	e->hash = 0;
	e->edge = node->edges[0];

	return e;
}

Node* Graph::getNode(NodeEnumerator* en) {
	if (en->hash >= nodeHashMax) return NULL;

	if (en->node != NULL) {
		Node* node = en->node;
		en->node = en->node->next;
		return node;
	} else {
		while ((en->node == NULL) && (en->hash < nodeHashMax)) {
			en->node = nodes[++en->hash];
		}
		return getNode(en);
	}
}

Edge* Graph::getEdge(EdgeEnumerator* en) {
	if (en->hash >= edgeHashMax) return NULL;

	if (en->edge != NULL) {
		Edge* edge = en->edge;
		en->edge = en->edge->next;
		return edge;
	} else {
		while ((en->edge == NULL) && (en->hash < edgeHashMax)) {			
			en->edge = en->node->edges[++en->hash];
		}
		return getEdge(en);
	}
}

void Graph::freeEdgeEnumerator(EdgeEnumerator*&en) {
    //cachedEdgeEnumerators.DeAllocate(en);
	delete en;
	en = NULL;
}

void Graph::freeNodeEnumerator(NodeEnumerator*&en) {
    //cachedNodeEnumerators.DeAllocate(en);
	delete en;
	en = NULL;
}

///////////////////////////////////////////////////////////////////////////////
/////// Addind edges, Nodes
///////////////////////////////////////////////////////////////////////////////

Edge* Graph::addEdge( Node* from, Node* to) {
	Edge* e = newEdge(to);
	int h = hash(e);
	e->next = from->edges[h];
	from->edges[h] = e;
	if (to == from) setLoop(from); //from->isLoop = true;
	return e;
}

Node* Graph::addNode(const JInt* cell) {
	Node* n = newNode(cell);
	int h = hash(n);
	n->next = nodes[h];
	nodes[h] = n;
	return n;
}

///////////////////////////////////////////////////////////////////////////////
/////// finding edges, Nodes
///////////////////////////////////////////////////////////////////////////////
Edge* Graph::findEdge(const Node* from, const Node* to) const {
	int h = hash(from, to);
	Edge* e = from->edges[h];
	while (e != NULL && e->to != to) {
		e = e->next;
	}
	return e;
}

Node* Graph::findNode(const JInt* cell) const{
	int h = hash(cell);
	Node* n = nodes[h];

	while (n!= NULL && !equals(n->cell, cell)) {
		n = n->next;
	}
	return n;
}

Node* Graph::findNode(const Node* node) const {
	return findNode(node->cell);
}

///////////////////////////////////////////////////////////////////////////////
/////// relations
///////////////////////////////////////////////////////////////////////////////
bool Graph::equals(const JInt* c1, const JInt* c2)const {
	for (int i=0; i<dimention; i++) {
		if (c1[i] != c2[i]) return false;
	}
	return true;
}


///////////////////////////////////////////////////////////////////////////////
/////// content Operations
///////////////////////////////////////////////////////////////////////////////

inline Node* Graph::browseToUnsafe(const JInt* cell) {
	Node* t = findNode(cell);
	if (t == NULL) {
		return addNode(cell);
	} else {
		return t;
	}
}

Node* Graph::browseTo(const JInt* cell) {
	if (!intersects(cell)) return NULL;
	return browseToUnsafe(cell);
}

Node* Graph::browseTo(const Node* node) {
	return browseTo(node->cell);
}

Edge* Graph::browseTo(Node* from, Node* to) {
	Edge* e = findEdge(from, to);
	if (e == NULL) {
		return addEdge(from, to);
	} else {
		return e;
	}
}

JDouble inline Graph::getExtent(int i) {
	return this->getEps()[i]/10;
}

void Graph::addEdges(Node* node, const JDouble* min, const JDouble* max, bool needInverse) {	
	if (!intersects(min, max)) return;
	
	for (int i=0; i<dimention; i++) {
		emin[i] = this->toInternal(min[i] - getExtent(i), i);
		if (emin[i] < 0) emin[i] = 0;
		emax[i] = this->toInternal(max[i] + getExtent(i), i);
		if (emax[i] > grid[i]) emax[i] = grid[i];
		point[i] = emin[i];
	}
	
	point[dimention] = 0;
	
	Node* to;
	while (point[dimention] == 0) {
		to = browseTo(point);
		if ((node != NULL) && (to != NULL)) {
			if (needInverse) {
				browseTo(to, node);
			} else {
				browseTo(node, to);
			}
		}
		
		point[0]++;
		for (int i=0;i<dimention;i++) {
			if (point[i] > emax[i]) {
				point[i] = emin[i];
				point[i+1]++;
			}
		}
	}
}

void Graph::addEdgesPartial(Node* node, int ubound, const JInt* coord, const JDouble* min, const JDouble* max) {
    
    if (!intersects(min, max, ubound, dimention)) return;
	int i;
    for (i=0; i<ubound; i++) {
        point[i] = coord[i];
    }
	for (i=ubound; i<dimention; i++) {
		emin[i] = this->toInternal(min[i] - getExtent(i), i);
		emax[i] = this->toInternal(max[i] + getExtent(i), i);
		point[i] = emin[i];
	}
	
	point[dimention] = 0;
	
	Node* to;
	while (point[dimention] == 0) {
		to = browseToUnsafe(point);
		if ((node != NULL) && (to != NULL)) {
			browseTo(node, to);
		}
		
		point[ubound]++;
		for (i=ubound;i<dimention;i++) {
			if (point[i] > emax[i]) {
				point[i] = emin[i];
				point[i+1]++;
			}
		}
	}
}

void Graph::addEdgesModula(Node* node, const JDouble* min, const JDouble* max, int mod_start) {
	if (!intersects(min, max, mod_start)) return;

	for (int i=0; i<mod_start; i++) {
		emin[i] = this->toInternal(min[i] - getExtent(i), i);
		emax[i] = this->toInternal(max[i] + getExtent(i), i);
		pointT[i] = point[i] = emin[i];
	}

	for (int i=mod_start; i<dimention; i++) {
		emin[i] = this->toInternalModulo(min[i] - getExtent(i), i);
		emax[i] = this->toInternalModulo(max[i] + getExtent(i), i);
		point[i] = emin[i];
		pointT[i] = reduce(point[i], i);

	}
	
	point[dimention] = 0;
	
	Node* to;
	while (point[dimention] == 0) {
		to = browseTo(pointT);
		if ((node != NULL) && (to != NULL)) {
			browseTo(node, to);
		}
		
		point[0]++;
		for (int i=0;i<dimention;i++) {
			if (point[i] > emax[i]) {
				point[i] = emin[i];
				point[i+1]++;
			}
			if (i >= mod_start) {
				pointT[i] = reduce(point[i], i);
			} else {
				pointT[i] = point[i];
			}
		}
	}
}


void Graph::addEdgeWithOverlaping(Node* nodeSourse, JDouble* value, JDouble* offset1, JDouble* offset2) {
	if (!intersects(value, value)) return;
	
	for (int i=0; i<dimention; i++) {
		JDouble tmp;		
		point[i] = toInternalExt(value[i], i, &tmp);
		if (tmp + offset2[i] < value[i]) {
			pointT[i] = 1;
		} else if (tmp + offset1[i] > value[i]) {
			pointT[i] = -1;
		} else {
			pointT[i] = 0;
		}
		pointB[i] = 0;
	}
	pointB[dimention] = 0;
   
	while (pointB[dimention] == 0) {
		for (int i=0; i<dimention; i++) {
			pointV[i] = point[i] + pointB[i]*pointT[i];
		}
		Node* res = browseTo(pointV);
		if (res != NULL) {
			browseTo(nodeSourse, res);
			
		}

		pointB[0]++;
		for (int i = 0; i<dimention; i++) {
			if (pointB[i] > ((pointT[i] != 0)?1:0)) {
				pointB[i] = 0;
				pointB[i+1]++;
			}
		}
	}
}

void Graph::maximize() {
	this->addEdges(NULL, min, max);
}

///////////////////////////////////////////////////////////////////////////////
/////// accessors
///////////////////////////////////////////////////////////////////////////////

const JInt* Graph::getCells(Node* node) const {
	return node->cell;
}

JInt Graph::getNodeNumber(Node* node) const {
    ATLASSERT(isTarjanable);
	return ((TarjanNode*)node)->number;
}

void Graph::setNodeNumber(Node* node, JInt number) {
    ATLASSERT(isTarjanable);
	((TarjanNode*)node)->number = number;
}

Node* Graph::getEdgeTo(Edge* e) const {
	return e->to;
}

///////////////////////////////////////////////////////////////////////////////
/////// Strong Component Locallization
///////////////////////////////////////////////////////////////////////////////


GraphComponents* Graph::localazeStrongComponents() {
    ATLASSERT(isTarjanable);

	cout<<"Localization of strong components\n";

	GraphComponents* cmps = new GraphComponents();
	TarjanNode* v;
	TarjanNode* w;
	Edge* e;
	int state = 2;
	JInt cnt = 10;
	
	Stack stack(this);
	Stack marsh(this);
	Graph* tmp;
	
	
	NodeEnumerator* enumerator = getNodeRoot();
	
	while (v = (TarjanNode*) getNode(enumerator)) {
		if (v->label == 0) {
			while (state > 1) {
	///			TRACE("Step : %d\n", state);

				switch (state) {
				case 2:
					stack.push(v);
					marsh.push(v);
					cnt++;
					v->label = cnt;
					v->number = cnt;
					state = 3;
					break;
					
				case 3:
					if (v->enumerator == NULL) v->enumerator = getEdgeRoot(v);
					e = getEdge(v->enumerator);
					if (e != NULL) {
						w = (TarjanNode*)e->to;
						if (((TarjanNode*)e->to)->label == 0) {
							v = w;
							state = 2;
						} else {
							state = 4;
						}
					} else {
						if (v->label < v->number) {
							state = 5;
						} else if (v->label == v->number) {
							state = 6;
						} else ASSERT(FALSE);
					}
					break;
				case 4:
					if ((w->number < v->number) && stack.contains(w)) {
						v->label = tmin(v->label, w->label);
					}
					state = 3;
					break;
				case 5:
					v = marsh.pop();
					w = marsh.top();
					w->label = tmin(w->label, v->label);
					v = w;
					state = 3;
					break;
				case 6:
					if (v == stack.top()) {
						stack.pop();
						if (isLoop(v)) {
							tmp = this->copyCoordinatesForTarjan();												
							tmp->addNode(v->cell);
							cmps->addGraphAsComponent(tmp);
						}
					} else {
						tmp = this->copyCoordinatesForTarjan();
						do {
							w = stack.pop();
							tmp->addNode(w->cell);
						} while (v != w);
						cmps->addGraphAsComponent(tmp);
					}
					VERIFY( v == marsh.pop());
					v = marsh.top();
					state = ((v==NULL)?1:3);
					break;
				}			
			} 
			state = 2;
		}
	}
	this->freeNodeEnumerator(enumerator);

    GraphNodeEnumerator ee(this);
    TarjanNode* node;
    while ((node = (TarjanNode*)ee.next()) != NULL) {
        if (node->enumerator != NULL) {
            freeEdgeEnumerator(node->enumerator);
        }
    }

	//TRACE("Count: %d\n", cnt-10);
	
	return cmps;
}

JInt Graph::tmin(JInt a, JInt b) const{
	return (a>b)?b:a;
}

void Graph::resolveEdges(Graph* root) {
   ATLASSERT(root->isTarjanable);

   Node* node;
   Node* rootNode;
   NodeEnumerator* en = this->getNodeRoot();
   while (node = this->getNode(en)) {
      rootNode = root->findNode(this->getCells(node));
      ASSERT(rootNode);
      EdgeEnumerator* ee = root->getEdgeRoot(rootNode);
      Edge* edge;
      while (edge = root->getEdge(ee)) {
         Node* nodeTo = this->findNode(root->getCells(root->getEdgeTo(edge)));
         if (nodeTo != NULL) {
            this->addEdge(node, nodeTo);
         }
      }
      root->freeEdgeEnumerator(ee);
   }
   this->freeNodeEnumerator(en);
}

///////////////////////////////////////////////////////////////////////////////
/////// Loops localization
///////////////////////////////////////////////////////////////////////////////

Graph* Graph::localizeLoops() {
	ATLASSERT(isTarjanable);

	Graph* ret = this->copyCoordinatesForTarjan();

	NodeEnumerator* ne = this->getNodeRoot();
	Node* node;
	while (node = this->getNode(ne)) {
		if (isLoop(node)) {
			Node* n = ret->browseTo(node->cell);
			ret->browseTo(n, n);
		}
	}
	this->freeNodeEnumerator(ne);

	return ret;
}

///////////////////////////////////////////////////////////////////////////////
/////// Stable Localization
///////////////////////////////////////////////////////////////////////////////

void Graph::stableLocalization_InitNode(Node* node, int flagID) {
		if (!readFlag(node, flagID)) {
			((TarjanNode*)node)->label = 0;
			setFlag(node, flagID, true);
		}
}


Graph* Graph::stableLocalization() {
	ATLASSERT(isTarjanable);

	const int flagID = this->registerFlag();	
	{
		GraphNodeEnumerator ne(this);
		TarjanNode* node;
		while ((node = (TarjanNode*)ne.next()) != NULL) {
			stableLocalization_InitNode(node, flagID);
			GraphEdgeEnumerator ee(this, node);
			TarjanNode* to;
			while ((to = (TarjanNode*)ee.nextTo()) != NULL) {
				stableLocalization_InitNode(to, flagID);
				to->label++;
			}
		}
	}
	{
		typedef list<TarjanNode*> TaskList;
		TaskList tasks;
		GraphNodeEnumerator ne(this);
		TarjanNode* node;
		while ((node = (TarjanNode*)ne.next()) != NULL) {
			if (node->label == 0) {
				tasks.push_back(node);
			}
		}

		while (!tasks.empty()) {
			TarjanNode* node = tasks.front();
			tasks.pop_front();

			GraphEdgeEnumerator ee(this, node);
			TarjanNode* to;
			while ((to = (TarjanNode*)ee.nextTo()) != NULL) {
				to->label--;
				if (to->label == 0) {
					tasks.push_back(to);
				}
			}
		}
	}

	Graph* ret = this->copyCoordinatesForTarjan();

	GraphNodeEnumerator ne(this);
	TarjanNode* node;
	while ((node =(TarjanNode*)ne.next()) != NULL) {
		if (node->label != 0)
			ret->browseToUnsafe(getCells(node));
	}

	return ret;
}

///////////////////////////////////////////////////////////////////////////////
/////// Quantitive Info
///////////////////////////////////////////////////////////////////////////////


JInt Graph::getNumberOfArcs() const {
	return numberEdges;
}

JInt Graph::getNumberOfNodes()  const {
	return numberNodes;
}

bool Graph::equals(Graph* graph) const {
	return CoordinateSystem::equals(graph);
}


///////////////////////////////////////////////////////////////////////////////
/////// Serialization
///////////////////////////////////////////////////////////////////////////////
const char GRAPH_OPEN_TAG[] = "<Graph>";
const char GRAPH_CLOSE_TAG[]= "</Graph>";

Graph*	Graph::createGraph(FileInputStream& o) {
	char buff[1024];
	o>>buff;
	ASSERT(strcmp(buff, GRAPH_OPEN_TAG) == 0);

	int dimention;
	int nodes;
	int edges_cnt;
	int edges;

	o>>dimention>>nodes>>edges_cnt;

	JInt* grid = new JInt[dimention];
	JDouble* min = new JDouble[dimention];
	JDouble* max = new JDouble[dimention];

	for (int i=0; i<dimention; i++) {
		o>>min[i]>>max[i]>>grid[i];
	}

	Graph* graph = new Graph(dimention, min, max, grid, false, Graph::getNodeHashMax(nodes));
	Node* node;

	for (int ne = 0; ne < nodes; ne++) {
		for (int i=0; i<dimention;i++) {
			o>>grid[i];
		}
		if (edges_cnt != 0){
			node = graph->browseToUnsafe(grid);
		} else {
			node = graph->addNode(grid);
		}

		ASSERT(node != NULL);

		o>>edges;

		for (int i=0; i<edges; i++) {
			for (int j=0; j<dimention; j++) {
				o>>grid[j];
			}
			graph->addEdge(node, graph->browseTo(grid));
		}
	}

	o>>buff;
	ASSERT(strcmp(buff, GRAPH_CLOSE_TAG) == 0);

	delete[] min;
	delete[] max;
	delete[] grid;

	return graph;
}

void Graph::saveGraph(FileOutputStream& o, Graph* graph) {
	o.stress();
	o<<GRAPH_OPEN_TAG;
	o.stress();

	o<<graph->getDimention()<<graph->getNumberOfNodes()<<graph->getNumberOfArcs();
	o.stress();
	o.stress();

	for (int i=0; i<graph->getDimention(); i++) {
		o<<graph->getMin()[i];
		o<<graph->getMax()[i];
		o<<graph->getGrid()[i];
		o.stress();
	}

	o.stress();
	o.stress();

	JInt edges = 0;

	EdgeEnumerator* ee;
	NodeEnumerator* ne = graph->getNodeRoot();

	Node* node;
	Edge* edge;

	while (node = graph->getNode(ne)) {
		ee = graph->getEdgeRoot(node);
		edges = 0;
		while (graph->getEdge(ee)) edges++;
		graph->freeEdgeEnumerator(ee);

		for (int i=0; i< graph->getDimention(); i++) {
			o<<node->cell[i];
		}
		o<<edges;

		ee = graph->getEdgeRoot(node);
		while (edge = graph->getEdge(ee)) {
			for (int i=0; i< graph->getDimention(); i++) {
				o<<edge->to->cell[i];
			}
		}
		graph->freeEdgeEnumerator(ee);
		o.stress();
	}
	graph->freeNodeEnumerator(ne);
	o.stress();

	o<<GRAPH_CLOSE_TAG;
	o.stress();
}


void Graph::saveGraphAsPoints(FileOutputStream& o, Graph* graph) {
	GraphNodeEnumerator ne(graph);
	int dim = graph->getDimention();

    Node* node;
	while (node = ne.next()) {
		for (int i=0; i<dim; i++) {
			JDouble d = graph->toExternal(graph->getCells(node)[i], i) + graph->getEps()[i]/2;
			o<<d;
		}
		o.stress();
	}
}


//////////////////////////////////////////////////////////////////////
// Flags

int Graph::registerFlag() {
	
	flagCounter++;
	ASSERT(flagCounter < 31); // bits in char
	return flagCounter;
}

void Graph::unregisterFlag(int flagID) {
	
}

bool Graph::readFlag(Node* node, int flagID) {	

	int mask = (1<<flagID);
	return (node->bits & mask) != 0;
}

void Graph::setFlag(Node* node, int flagID, bool value) {
	if (value) {
		int mask = (1<<flagID);
		node->bits = node->bits | mask;
	} else {
		int mask = ~(1<<flagID);
		node->bits = node->bits & mask;
	}

	ASSERT(readFlag(node, flagID) == value); 
	/*
	Debugging
	if( readFlag(node, flagID) != value) {
		ASSERT(false);
		setFlag(node, flagID, value);
	}
	*/
}

////////////////////////////////////////////////////////////////////
bool inline Graph::isLoop(Node* node) {
	return readFlag(node, isLoopFlagID);
}

void inline Graph::setLoop(Node* node) {
	setFlag(node, isLoopFlagID);
}


Graph* createTestGraph(int num_nodes) {
	JDouble min = 1;
	JDouble max = 2;
	JInt grid = num_nodes;
	return new Graph(1, &min, &max, &grid, true);
}



////////////////////////////////////////////////////////////////////////
//   Megre
///////////////////////////////////////////////////////////////////////

void Graph::MergeWith(Graph* graph) {
   
    GraphNodeEnumerator ne(graph);        
    Node* node;
    while( (node = ne.next()) != NULL) {
        Node* rnode = this->browseTo(node);

        GraphEdgeEnumerator ee(graph, node);
        Node* toNode;
        while (toNode = ee.nextTo()) {
            this->browseTo(rnode, graph->browseTo(toNode));
        }
    }
}   


///////////////////////////////////////////////////////////////////////////

Graph* Graph::Project(JInt* devidors) {
	
	int fct = 1;
	for (int i=0; i<dimention; i++) {
		point[i] = this->getGrid()[i]/devidors[i];
		fct*=point[i];
	}

	Graph* newGraph = new Graph(dimention, this->getMin(), this->getMax(), point, false, getNodeHashMax(this->getNumberOfNodes()/fct));

	GraphNodeEnumerator ne(this);
	Node* node;
	while (node = ne.next()) {
		for (int i=0; i<dimention; i++) {
			point[i] = this->getCells(node)[i]/devidors[i];
		}
		newGraph->browseToUnsafe(point);
	}

	return newGraph;
}
