#include "StdAfx.h"
#include ".\meagraphalgorithm.h"

#include <vector>
#include <list>

using namespace std;

MeaGraphAlgorithm::MeaGraphAlgorithm(void)
{
}

MeaGraphAlgorithm::~MeaGraphAlgorithm(void)
{
}
typedef list<AlgItem*> AlgItemList;

struct AlgItem {
	MeaNode* myNode;
	AlgItem* myPredecessor;
	int myDistance;
	AlgItem(MeaNode* node, AlgItem* predecessor, int distance){
		myNode = node;
		myPredecessor = predecessor;
		myDistance = distance;
	}
};

void MeaGraphAlgorithm::contour(AlgItem* item, MeaNodeSet& nodeSet){
	nodeSet.insert(item->myNode);
	AlgItem* tempItem = item->myPredecessor;
	if (tempItem != NULL){
		contour(tempItem, nodeSet);
	}
}
MeaNodeSet MeaGraphAlgorithm::searchContour(MeaNode& sourceNode){	
	//MeaGraphImpl myGraph(&graph);
	//MeaNode meaSourceNode(&sourceNode, &graph);
	MeaNodeSet result;
	AlgItemList queue;
	vector<AlgItem*> itemList;
	AlgItem* startItem = new AlgItem(&sourceNode, NULL, 0); 	
	itemList.push_back(startItem);
	queue.push_back(startItem);
	AlgItem* headItem;
	while (!queue.empty()){
		headItem = queue.front();
		queue.remove(headItem);
		MeaNodeSet& adjacents = headItem->myNode->getAdjacentNodes();
		for (MeaNodeSet::iterator it = adjacents.begin(); it!=adjacents.end(); it++) {
			MeaNode* nextNode = *it;
			if (sourceNode.equals(*nextNode)){
				/*
				AlgItem* nextItem = new AlgItem(nextNode,headItem,headItem->myDistance+1);
				*/
				contour(headItem, result);
				queue.clear();
				break;
			}
			if (nextNode->getColor()== WHITE){
				nextNode->setColor(GREY);
				AlgItem* nextItem = new AlgItem(nextNode,headItem,headItem->myDistance+1);
				queue.push_back(nextItem);
				itemList.push_back(nextItem);
			}			
		}
		headItem->myNode->setColor(BLACK);
	}	
	for (unsigned int i = 0; i<itemList.size(); i++){
		delete itemList[i];
	}
	return result;
}
