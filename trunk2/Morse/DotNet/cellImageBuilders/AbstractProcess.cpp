#include "StdAfx.h"
#include ".\abstractprocess.h"
#include "graphSet.h"

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


