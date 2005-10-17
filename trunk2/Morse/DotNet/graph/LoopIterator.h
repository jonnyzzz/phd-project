#include "../graph/Graph.h"
#include "../graph/MemoryManager.h"
#include <list>
using namespace std;

class LoopIterator : private MemoryManager
{
public:
	LoopIterator(Graph* graph);
	virtual ~LoopIterator(void);

private:
	struct NodeEx {
		Node* node;
		NodeEx* parent;	
		int number;
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

	void DFSStep(NodeExList& start, NodeExList& next, NodeLists& lists);

private:
	Graph* graph;

	const int flagID;
	const int flagIDLoop;
	const int maxSearchLength;

};
