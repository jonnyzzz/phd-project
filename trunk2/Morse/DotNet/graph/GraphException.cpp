#include "StdAfx.h"
#include ".\graphexception.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


GraphException::GraphException(GraphExceptionType type)
{
}

GraphException::GraphException(GraphException& ex)
{
}

GraphException::~GraphException() 
{
}