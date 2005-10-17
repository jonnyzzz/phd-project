#include "../graph/Graph.h"
#include "../graph/GraphUtil.h"
#include "../graph/ExtendedMenoryManager.h"
#include <list>
using namespace std;

class LoopIterator : private ExtendedMemoryManager
{
public:
	LoopIterator(Graph* graph);
	virtual ~LoopIterator(void);

private:
	struct NodeEx {
		Node* node;
		NodeEx* parent;			
		GraphEdgeEnumerator ee;
		int deep;

		NodeEx(Graph* graph, Node* node, NodeEx* parent, int deep) : node(node), parent(parent), deep(deep), ee(graph,node) {}
		virtual ~NodeEx() {}
	};

	typedef list<NodeEx*> NodeExList;

public:
	typedef list<Node*> NodeList;
	typedef list<NodeList> NodeLists;

	NodeLists process();

private:
	bool ReadFlag(Node* node);
	void SetFlag(Node* node, bool value);
	
	void ResetFlags();

	bool ReadVisitedFlag(Node* node);
	void SetVisitedFlag(Node* node);


	NodeEx* FindNextPath(NodeEx* node);

	/// Returns next Node to check
	NodeEx* DeepSearch(NodeEx* startNode, NodeLists& list);

private:
	Graph* graph;

	const int flagID;
	const int flagIDLoop;
	const int maxSearchLength;

};
