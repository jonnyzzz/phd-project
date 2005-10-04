#include "StdAfx.h"
#include ".\ms2creationcomputationprocess.h"
#include ".\Graph.h"
#include ".\Function.h"
#define _USE_MATH_DEFINES
#include <math.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MS2CreationComputationProcess::MS2CreationComputationProcess(Graph* graph, int factorSI, int factorMS) :
parent(graph), factorMS(factorMS), factorSI(factorSI), graph(graph)
{
   //cout<<"graph "<<graph<<"\n";

   point = new JInt[4];
   b = new JInt[4];
   
   dimension = 2;
   newDimension = 3;

   //cout<<"here\n";

   result = createGraph();

//   cout<<"crateComplete\n";
}

MS2CreationComputationProcess::~MS2CreationComputationProcess(void)
{
   delete[] point;
   delete[] b;
}

int inline MS2CreationComputationProcess::Factor(int i) {
   return ( (i < parent->getDimention())?factorSI:factorMS);
}

Graph* MS2CreationComputationProcess::createGraph() {

   //cout<<"new Dim "<<newDimension<<"\n";

   JDouble* min = new JDouble[newDimension];
   JDouble* max = new JDouble[newDimension];
   JInt* grid = new JInt[newDimension];

   for (int i=0; i<graph->getDimention(); i++) {
      min[i] = graph->getMin()[i];
      max[i] = graph->getMax()[i];
      grid[i] = graph->getGrid()[i] * Factor(i);
   }

   min[2] = 0;
   max[2] = M_PI;
   grid[2] = Factor(2);
   this->dimension = graph->getDimention();

   Graph* gr =  new Graph(newDimension, min, max, grid, false);

   delete[] min;
   delete[] max;
   delete[] grid;

   return gr;
}


void MS2CreationComputationProcess::nextStep(Graph* graph) {
   
   this->graph = graph;

   //cout<<"result "<<result<<"\n";
   //cout<<"graph "<<graph<<"\n";

   NodeEnumerator* ne = graph->getNodeRoot();
   Node* node;
   while (node = graph->getNode(ne)) {
      buildNodeMultiplication(node);
   }
   graph->freeNodeEnumerator(ne);

}


void MS2CreationComputationProcess::buildNodeMultiplication(Node* node) {
   for (int i=0; i<=newDimension; i++) {
      b[i] = 0;
   }

   while (b[newDimension] == 0) {      
      for (i=0; i<dimension; i++) {
         point[i] = (graph->getCells(node)[i])*Factor(i) + b[i];
      }
      for (i=dimension; i<newDimension;i++) {
         point[i] = b[i];
      }

      Node* n = result->browseTo(point);
      
      ASSERT(n != NULL);
          
      b[0]++;
      for ( i=0;i<newDimension;i++) {
         if (b[i] >= Factor(i)) {
            b[i] = 0;
            b[i+1]++;
         }
      }     
   }
}

Graph* MS2CreationComputationProcess::getResult() {
   //cout<<"result\n";
   return result;
}
