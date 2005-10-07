#include "stdafx.h"
#include "Util.h"
#include "../graph/Graph.h"
#include "../graph/FileStream.h"
#include <iostream>
#include <stdio.h>

const char FILE_MASK[] = "%s.%d";

void Util::SaveGraphSet(GraphSet set, char* file) {
	char buff[2048];

//	cout<<"file to write: "<< file<<endl;

	FileOutputStream mainFile(file);
	mainFile<<set.Length();

	if (set.Length() == 0) {
		cerr<<"Unable to save empty graph set";
	}
//	cout<<set.Length()<<endl;

//	Graph* t=set[0];	

	int cnt = 0;
	for (GraphSetIterator it = set.iterator(); it.HasNext(); it.Next()) {
		sprintf(buff, FILE_MASK, file, cnt++);

//		cout<<"Saving file "<<buff<<endl;
		FileOutputStream fs(buff);
//		cout<<"Saving file "<<buff<<endl;

		Graph* gr = it.Current();
//		cout<<"Saving file "<<buff<<endl;
//		cout<<gr->getNumberOfNodes()<<" "<<gr->getNumberOfArcs()<<endl;
		saveGraph(fs, gr);
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
