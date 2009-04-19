#include "stdafx.h"
#include "Rom.h"
#include "../graph/GraphUtil.h"
#include <list>
#include <algorithm>

//using namespace stdext;
using namespace std;

/* new(address_pointer) type does not supported by MFC
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
*/


#define DUMPN(x) {cout<<#x" ";dumpNode(x);}


CRom::CRom(Graph* graph) :
graph(graph)
{
	factor = 0;
	nodes = new ContourNode[graph->getNumberOfNodes()+1];
	if (nodes == NULL) {
		cout<<endl<<endl<<endl;
		cout<<"!!!!!!!!!!!!!!!!!11ROM ALLOC ERROR!!!!!!!!!!!!!!!!!!!!!!!1";
		cout<<endl<<endl<<endl;
		ASSERT(false);
	}
	nodes_alloc = nodes;
}


CRom::~CRom(void)
{
	cout<<" WWW "<<endl;
	delete[] nodes;
	cout<<" WWW2 "<<endl;
}


double inline CRom::cost(Edge* e) {
	return cost(graph->getEdgeTo(e));
}

double inline CRom::cost(CRom::ContourNode* node) {
	return node->node_cost;
}

double inline CRom::contour_cost(CRom::ContourNode* node) {
	int kV = 1;
	double r = cost(node);
	ContourNode* n = node->next;

	while (n != node) {
		kV++;
		r += cost(n);
		n = n->next;
		ASSERT(kV < graph->getNumberOfNodes()+1);
	}
	return r/kV;
}

bool inline CRom::isSub(CRom::ContourNode* root, CRom::ContourNode* i1, CRom::ContourNode* i2) {
	int cnt = 0;
	ContourNode* t = i2;
	while ((t != i1) && (cnt < 2)) {
		if (t == root) cnt++;
		t = t->next;
	}

	return t == i1;
}

bool inline CRom::preceed(CRom::ContourNode* root, CRom::ContourNode* i1, CRom::ContourNode* i2) {
	return isSub(root, i1, i2);
}
		
bool inline CRom::tree(CRom::ContourNode*& rnode) {
	cout<<"Trre:\n";

	for (EGraphIterator it = egraph.begin(); it != egraph.end(); it++) {
		it->second->type = M2;
	}
	
	DUMPN(rnode);

	typedef list<ContourNode*> List;
	typedef List::iterator ListIterator;

	List m;
		
	double z = contour_cost(rnode);

	cout<<"z = "<<z<<"\n";

	rnode->v = 0;
	rnode->type = M1;
	m.push_front(rnode);
	
	ContourNode* n = rnode->next;
	ContourNode* p = rnode;

	while (n != rnode) {
		m.push_front(n);
		n->type = M1;
		n->v = p->v - cost(p) + z;
		p = n;
		n = n->next;
	}
	//p->next = NULL;
	ASSERT(rnode->v == 0);



	while (!m.empty()){
		ContourNode* node = m.front();	
		m.pop_front();
		node->type = M0;

        GraphEdgeEnumerator ee(graph, node->node); // = graph->getEdgeRoot(node->node);
		Edge* e;
		while (e = graph->getEdge(ee)) {

			ContourNode* to = getContourNodeTo(e);
			
			double w = node->v + cost(to) - z;

			if (to->type == M2) {
				m.push_back(to);

				to->type = M1;
				to->v = w;
				to->next = node;
			} else {
				ASSERT(to->type == M0 || to->type == M1);
				
				if ( (w + 1e-8) < to->v ) {
					if (preceed(rnode, to, node)) {
						cout<<"Restart:\n";

						DUMPN(rnode);
						DUMPN(node);
						DUMPN(to);

						to->next = node;
						rnode = to; //root <- to

						return false; //<=> start again
					} else 
                                               /// FIXED to new algorithm statement in my PHD thesis. 
                                               /// if (preceed(rnode, node, to))
                                        {
						to->v = w;
						to->next = node;
						if (to->type == M0) {
							to->type = M1;							
							m.push_front(to);
							//cout<<"->push_front("<<getID(to)<<")\n";
						}						
					}
				} else {
					//to->type = M0;
				}
			}
		}
		//GraphEdgeEnumerator object create just on stack. graph->freeEdgeEnumerator(ee);		
	}
	//p->next = rnode;
    cout<<"Final:\n";
	//dump();
	//cout<<"\n";
	return true; //contour is minimal.
}


void CRom::bigDump(CRom::ContourNode* to) {
	cout<<"\n\nGlobal dump\n\n";
	while (true) {
		DUMPN(to);
		to = to->next;
		char c;
		cin>>c;
		if (c == 'e') break;
	}
	cout<<"\n\n";
}

	
CRom::ContourNode* CRom::minimize(CRom::ContourNode* node) {
	while (!tree(node)) {
		cout<<"next\n\n";
		//dump();
		cout<<"\n\n";
	}
	cout<<"Finish\n";

	return node;
}

CRom::ContourNode::ContourNode() {
	next = NULL;	
	node = NULL;
	type = 0;
}

CRom::ContourNode* CRom::getContourNode(Node* node) {
	return egraph[node];
}

CRom::ContourNode* CRom::getContourNodeTo(Edge* edge) {
	return getContourNode(graph->getEdgeTo(edge));
}

CRom::ContourNode* CRom::createNode(Node* node) {
	//cout<<"\n->CNEW:"<<node<<"\n";
	ContourNode*& gnode = egraph[node];
	if (gnode == NULL) {
		//cout<<"\n->NEW:"<<node<<"\n";
		gnode = new(nodes_alloc++) CRom::ContourNode;		
		gnode->node = node;
		gnode->node_cost = cost(node);		
	} 
	return gnode;
}

CRom::ContourNode* CRom::createNodeTo(Edge* edge) {
	return createNode(graph->getEdgeTo(edge));
}

CRom::ContourNode* CRom::init() {

	cout<<"Start...\n";
    //dump();

	NodeEnumerator* ne = graph->getNodeRoot();
	Node* node;
	Edge* edge;
	while(node = graph->getNode(ne)) {
		ContourNode* gnode = createNode(node);
		
		EdgeEnumerator* ee = graph->getEdgeRoot(node);
		Edge* debugEdge = graph->getEdge(ee);
		//there is no outbound edges!!! unable to perform computation!
//		VERITY(debugEdge != NULL);
		ContourNode* minEdge = createNodeTo(debugEdge);
        while (edge = graph->getEdge(ee)) {
			ContourNode* gedge = createNodeTo(edge);
			if (minEdge->node_cost > gedge->node_cost) {
				minEdge = gedge;
			}
		}
		gnode->next = minEdge;
		minEdge->type++;
		graph->freeEdgeEnumerator(ee);
	}
	graph->freeNodeEnumerator(ne);

	cout<<"1\n";

	//dump();

	for (EGraphIterator it = egraph.begin(); it!= egraph.end(); it++) {
		ContourNode* node = it->second;
		while (node->type == 0) {
			node->type = M1; //mark as trash
			node = node->next;				
			node->type--;
		}
	}

	cout<<"2\n";
    
	//dump();

	ContourNode* root = NULL;
	double rootZ = 1.7E+300;
	ContourNode* tmp = NULL;
	for (EGraphIterator it = egraph.begin(); it != egraph.end(); it++) {
		tmp = it->second;
		
		//cout<<"type = "<<tmp->type<<"\n";
		if (tmp->type > 0) {			
			tmp->type = M2;
			
			double cst = cost(tmp);
			int kV = 1;            
			ContourNode* t = tmp->next;
			while (t != tmp) {
				cst += cost(t);
				kV++;
				t->type = M2;
				t = t->next;
				ASSERT(kV <= graph->getNumberOfNodes()+1);
			}

			cst /= kV;
			if (root == NULL || rootZ > cst) {				
				root = tmp;
				rootZ = cst;
				cout<<"!.!";
			}
		}
		tmp->type = M2;
	}
	// next as tree_pointer;

	cout<<"Init Cost = "<<rootZ<<"\n";

	createTreeInit(root);

	return root;
}

void CRom::createTreeInit(CRom::ContourNode* root) {
	/*
	cerr<<"here!\n";
	{
		cout<<"INter____\n\n";
		ContourNode* t = root->next;
		DUMPN(root);
		while (t != root) {
			DUMPN(t);
			t = t->next;
		}
	}
	*/
	ContourNode* p = root;
	ContourNode* q = root->next;
	while (q != root) {
		ContourNode* t = q->next;
		q->next = p;
		p = q;
		q = t;
	}
	q->next = p;
	/*
	{
		cout<<"\n\nINter____\n\n";
		ContourNode* t = root->next;
		DUMPN(root);
		while (t != root) {
			DUMPN(t);
			t = t->next;
		}
	}
	cout<<"\n\n";
	*/
}

void CRom::dump() {
	cout<<"\n";
	for (EGraphIterator it = egraph.begin(); it != egraph.end(); it++) {
		cout<< (it->second) <<"\t->\t"<<(it->second->next)<<"\t"<< it->second->type<<"\n";
	}
	cout<<"\n";
}


void CRom::cleanUP() {
	nodes_alloc = nodes;
	egraph.clear();
	

	dump();
}


void CRom::minimize() {
	cleanUP();
	factor = 1;
	cout<<"Enter\n";
	extrema = init();
	cout<<"Init\n";
//*
#ifdef _DEBUG
	dumpGraph();
#endif
//*/
	extrema = minimize(extrema);
	cout<<"Cost\n";
	answerValue = contour_cost(extrema);
	cout<<"Complete";
/*
#ifdef _DEBUG
	ofstream f;
	f.open("./extrema.ids");
	f<<"Minimum searching:\n";
	dumpExtremaContour(f, extrema);
#endif
*/
}

void CRom::maximize() {
	cleanUP();
	factor = -1;	
	extrema = minimize(init());
	answerValue = -contour_cost(extrema);
/*
#ifdef _DEBUG
	ofstream f;
	f.open("./extrema.ids", ios_base::out | ios_base::app | ios_base::ate);
	f<<"\n\nMaximum searching:\n";
	dumpExtremaContour(f, extrema);
#endif
*/
}

double CRom::getAnswer() {
	return answerValue;
}

int CRom::getAnswerLength() {
	int v = 1;
	ContourNode* n = extrema->next;
	while (n !=  extrema) {
		v++;
		n = n->next;
	}
	return v;
}


CRom::myAllocator::myAllocator() {
}

CRom::myAllocator::myAllocator(const myAllocator& al) {
	num = al.num;
}

CRom::myAllocator& CRom::myAllocator::operator =(const myAllocator& al) {
	num = al.num;
	return *this;
}
void CRom::myAllocator::init() {
 	number++;
	num = number;
}

int CRom::myAllocator::number = 0;

int dumpCount = 0;

void CRom::dumpGraph() {
	
	for (EGraphIterator it = egraph.begin(); it != egraph.end(); it++ ) {
		ids[it->second].init();
	}

	int t = 0;//ids[egraph.begin()->second].num-1;

	ids_subber = t;
//*
 	ofstream f;
	char buffer[255];
	sprintf(buffer, "./trashccc.%d.rom", dumpCount++);
	f.open(buffer);

	for (EGraphIterator it = egraph.begin(); it != egraph.end(); it++ ) {
		f<< ids[it->second].num-t <<" "<<it->second->node_cost<<" ";

		EdgeEnumerator* ee = graph->getEdgeRoot(it->first);
		Edge* edge;
		while (edge = graph->getEdge(ee)) {
			f<< ids[egraph[graph->getEdgeTo(edge)]].num-t << " ";
		}
		graph->freeEdgeEnumerator(ee);
		f<<"\n";
	}
	f.close();
	//*/
}

void CRom::dumpNode(CRom::ContourNode* node) {
	cout<<"Node = "<<getID(node)<<"\n";
}

int CRom::getID(CRom::ContourNode* node) {
	//ASSERT(graph->getCells(node)[0] == 
	return ids[node].num - ids_subber;
}

void CRom::dumpExtremaContour(ostream& o, CRom::ContourNode* node) {

	o<<"Internal coordinates of contour nodes:\n";

	o<<getID(node)<<"\t";
	ContourNode* t = node->next;
	while (t != node) {
		o<<getID(t)<<"\t";
		t = t->next;
	}

	o<<"\n\nContour value: "<<contour_cost(node)<<"\n";
	o<<"Number of nodes in countour: "<<getAnswerLength()<<"\n\n";
/*
	o<<"\n\nTo Space coordinates:\n";

	t = node;
	do {
	double x[2];
	x[0] = graph->toExternal(graph->getCells(t->node)[0],0);
	x[1] = graph->toExternal(graph->getCells(t->node)[1],1);
	o<<x[0]<<"\t"<<x[1]<<"\n";
	t = t->next;
	} while (t != node);
*/
}

