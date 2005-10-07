#include "stdafx.h"
#include "Util.h"
#include "../graph/Graph.h"
#include "../graph/FileStream.h"
#include <iostream>
#include <stdio.h>

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
		saveGraph(fs, gr);
	}
}


void Util::ExportPoints(GraphSet set, char* file) {
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
		saveGraphAsPoints(fs, gr);
	}
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
		mySet.AddGraph( createGraph( fs ));
	}

	return mySet;
}
