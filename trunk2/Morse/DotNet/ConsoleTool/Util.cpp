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


void Util::ExportPoints(GraphSet set, char* file) {
	char buff[2048];

	FileOutputStream mainFile(file);
	mainFile<<set.Length();

	sprintf(buff, "%s.gnuplot", file);
	ofstream gp;
	gp.open(buff);

//	gp<<"set terminal png size 1000,1000; set key below; set output '"<<file<<".png'; ";
	gp<<"set terminal png small color; set key below; set output '"<<file<<".png'; ";

	gp<<"plot ";

	if (set.Length() == 0) {
		cerr<<"Unable to save empty graph set";
	}

	int cnt = 0;
	for (GraphSetIterator it = set.iterator(); it.HasNext(); it.Next()) {
		sprintf(buff, FILE_MASK, file, cnt++);
		FileOutputStream fs(buff);
		Graph* gr = it.Current();
		Graph::saveGraphAsPoints(fs, gr);

		if (cnt != 1) 
			gp<<" , ";

//		gp<<"'"<<buff<<"' with dots title 'Nodes: "<<gr->getNumberOfNodes()<<"' ";
		gp<<"'"<<buff<<"' with dots ";
	}
	gp<<";";
	gp.close();
}

GraphSet Util::LoadGraphSet(char* file) {
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
		mySet.AddGraph( Graph::createGraph( fs ));
	}

	return mySet;
}
