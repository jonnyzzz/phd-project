#include "stdafx.h"
#include "AbstractProcess.h"
#include "GraphSet.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



AbstractProcess::AbstractProcess(ProgressBarInfo* info) : info(info)
{
	wasInitialized = false;
}

AbstractProcess::~AbstractProcess(void)
{
}



void AbstractProcess::start() {
	wasInitialized = true;
}


GraphSet AbstractProcess::Apply(AbstractProcess* ps, GraphSet& set) {
	ps->start();
	for (GraphSetIterator it = set.iterator(); it.HasNext(); it.Next()) {
		ps->processNextGraph(it.Current());
	}
	return ps->results();	
}