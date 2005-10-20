#include "stdafx.h"
#include "Util.h"
#include "../graph/Graph.h"
#include "../graph/FileStream.h"
#include <iostream>
#include <fstream>
#include <stdio.h>
using namespace std;

const char FILE_MASK[] = "%s.%d";

void Util::SaveGraphSet(GraphSet set, char* file) {
	char buff[2048];

	FileOutputStream mainFile(file);
	mainFile<<set.Length();

	if (set.Length() == 0) {
		cerr<<"Unable to save empty graph set";
	}

	int cnt = 0;
	for (GraphSetIterator it = set.iterator(); it.HasNext(); it.Next()) {
		sprintf(buff, FILE_MASK, file, cnt++);
		FileOutputStream fs(buff);
		Graph* gr = it.Current();
		Graph::saveGraph(fs, gr);
	}
}


void Util::ExportPoints(GraphSet set, const char* file, const char* path) {
	char buff[2048];

	sprintf(buff, "%s%s.gnuplot", path, file);
	ofstream gp;
	gp.open(buff);
	ofstream wp;
	sprintf(buff, "%s%s.wgnuplot", path, file);
	wp.open(buff);

	wp<<"set terminal png size 1000,1000; set key below; set output '"<<file<<".png'; ";
	gp<<"set terminal png small color; set key below; set output '"<<file<<".png'; ";

	gp<<"plot ";
	wp<<"plot ";

	if (set.Length() == 0) {
		cerr<<"Unable to save empty graph set";
	}

	int cnt = 0;
	for (GraphSetIterator it = set.iterator(); it.HasNext(); it.Next()) {
		sprintf(buff, "%s%s.%d", path, file, cnt);
		FileOutputStream fs(buff);
		Graph* gr = it.Current();
		Graph::saveGraphAsPoints(fs, gr);

		if (cnt > 0) {
			gp<<" , ";
			wp<<" , ";
		}

		sprintf(buff, "%s.%d", file, cnt);

		wp<<"'"<<buff<<"' with dots title 'Nodes: "<<gr->getNumberOfNodes()<<"' ";
		gp<<"'"<<buff<<"' with dots ";

		cnt++;
	}
	gp<<"; set output 'nil';";
	wp<<"; set output 'nil';";
	gp.close();
	wp.close();
}

GraphSet Util::LoadGraphSet(char* file, bool loadEdges) {
	char buff[2048];
	GraphSet mySet;

	FileInputStream mainFile(file);
	int cnt;
	mainFile>>cnt;


	cout<<"Found "<<cnt<<" files"<<endl;

	for (int i=0; i<cnt; i++) {
		sprintf(buff, FILE_MASK, file, i);
		cout<<"Loading file "<<buff<<endl;
		FileInputStream fs(buff);
		mySet.AddGraph( Graph::createGraph( fs, loadEdges));
	}

	return mySet;
}



/*
void ReadPoints(FileInputStream& fi, double* data, int dim){
  for (int i=0; i<dim; i++){
    fi>>data[i];
  }
}

void CopyMem(const double* input, double* output, int dim) {
  memcpy(output, input, sizeof(double)*dim);
}


void Util::RawerPoints(const char* fileIn, const char* fileOut, const int* grid, int dim){
  
    double* minimum = new double[dim];
    double* maximum = new double[dim];
    double* tmp = new double[dim];
    int cnt = 0;

    {
      FileInputStream fi(fileIn);
    ReadPoints(tmp, fi);
    CopyMem(tmp, minimum, dim);
    CopyMem(tmp, maximum, dim);
    cnt++;
    
    while (!fi.eof) {
      cnt++;
      ReadPoints(tmp, fi);

      for (int i=0; i<dim; i++) {
        if (minimum[i] > tmp[i]){
   	  minimum[i] = tmp[i];
        }
        if (maximum[i] < tmp[i]){
	  maximum[i] = tmp[i];
        }
      }
    }
  }

    Graph* graph = new Graph(dim, minimum, maximum, grid, false, Graph::getNodeHashMax(cnt), 1);
  
  FileInputStream fi(fileIt);
  JInt* ints = new JInt[dim];
  
*/



