//This is really slow implementation. While it uses std::hash_map without
//specially defined hash function

#include <hash_map>
using namespace stdext;

#include "..\graph\MemoryManager.h"
#include "Graph.h"

template <typename Data>
class AdditionalNodeParameters
{
private:
	typedef hash_map<Node*, Data*> Hash;

private:
	Graph* graph;

	MemoryManager manager;

	Hash hash;	
public:
	AdditionalNodeParameters(Graph* graph) : graph(graph), manager(sizeof(Data*)*100000) {		
	}

	virtual ~AdditionalNodeParameters(void) {		
	}

public:

	Data* getData(Node* node) {
		Data*& d = hash[node];
		if (d == NULL) {
            d = manager.Allocate<Data>();
		}
		return d;
	};

};
