#include "stdafx.h"
#include "AdaptiveBoxMethod.h"
#include <iostream>
using namespace std;

AdaptiveBoxMethod::AdaptiveBoxMethod(ISystemFunction* function, Graph* graph, JInt* division, double* precision, ProgressBarInfo* info)
: AdaptiveProcessBase(function, graph, division, precision, info), manager(sizeof(JDouble) * graph->getDimention() *1522)
{
    this->input = function->getInput();
    this->output = function->getOutput();
}

AdaptiveBoxMethod::~AdaptiveBoxMethod(void)
{
}


void inline AdaptiveBoxMethod::arraycopy(double* to, const double* from) {
    memcpy(to, from, sizeof(double)*dimension);
}

double* AdaptiveBoxMethod::createArray() {
    return manager.AllocateArray<double>(dimension);
}

double* AdaptiveBoxMethod::arraycopy(const double* node) {
    double* myDouble = createArray();
    arraycopy(myDouble, node);
    return myDouble;
}

double inline AdaptiveBoxMethod::Abs(double x) {
    return (x>0) ? x : -x;
}


void AdaptiveBoxMethod::processResultNode(Node* node) {
    manager.Reset();

    JDouble* left = manager.AllocateArray<JDouble>(dimension);
    JDouble* right = manager.AllocateArray<JDouble>(dimension);

    for (int i=0; i<dimension; i++) {
        left[i] = resultGraph->toExternal(resultGraph->getCells(node)[i],i);
        right[i] = left[i] + resultGraph->getEps()[i];
    }

    BoxList boxes;
    CellsList cells;

    BoxEdge leftBox(left);
    BoxEdge rightBox(right);
    cells.push_back(Cell(left, right));


    processCells(cells, boxes);


    //cout<<"Points = "<<boxes.size()<<"\n";

    for (BoxList::iterator it = boxes.begin(); it != boxes.end(); it++) {
        resultGraph->addEdgeWithOverlaping(node, it->valueCache, precision, precision);
    }
}


void AdaptiveBoxMethod::evaluateBox(BoxEdge& box) {
    if (box.valueCache != NULL) return;

    arraycopy(input, box.point);
    function->evaluate();

    box.valueCache = arraycopy(output);
}



bool AdaptiveBoxMethod::check(Cell& cell) {
    evaluateBox(cell.first);
    evaluateBox(cell.second);

    for (int i=0; i<dimension; i++) {
        if ( Abs(cell.first.valueCache[i] - cell.second.valueCache[i]) > precision[i]) 
            return false;
    }
    return true;
}



void AdaptiveBoxMethod::processCells(CellsList& cells, BoxList& boxes) {

    JInt* b = manager.AllocateArray<JInt>(dimension+1);    
    JDouble* center = createArray();
    JDouble* edge = createArray();

    //int iterations = 0;

    while (!cells.empty()) {
        Cell cell = cells.front();
        cells.pop_front();

      //  iterations++;


        if (check(cell)) {
            boxes.push_back(cell.first);
            boxes.push_back(cell.second);
        } else {
            

            for (int i=0; i<dimension; i++) {
                center[i] = (cell.first.point[i] + cell.second.point[i])/2;
            }

            ZeroMemory(b, sizeof(JInt)*(dimension+1)); 
            while (b[dimension] == 0) {
                bool isLeft = true;
                bool isRight = true;

                BoxEdge pointLeft(createArray());
                BoxEdge pointRight(createArray());

                for (int i=0; i<dimension; i++) {
                    JDouble tmp = (b[i]==0)? cell.first.point[i] : cell.second.point[i];                    
                    isLeft &= b[i]==0;
                    isRight &= b[i]==1;

                    if (tmp < center[i]) {
                        pointLeft.point[i] = tmp;
                        pointRight.point[i] = center[i];
                    } else {
                        pointLeft.point[i] = center[i];
                        pointRight.point[i] = tmp;
                    }
                }
                
                if (isLeft) {
                    cells.push_back(Cell(cell.first, pointRight));
                } else if (isRight) {
                    cells.push_back(Cell(pointLeft, cell.second));
                } else {
                    cells.push_back(Cell(pointLeft, pointRight));
                }

                b[0]++;
                for( int i=0; i<dimension; i++) {
                    if (b[i] > 1) {
                        b[i] = 0;
                        b[i+1]++;
                    } else  break;
                }
            }
        

        }
    }

    //cout<<"Iterations = "<<iterations<<"\n";
}