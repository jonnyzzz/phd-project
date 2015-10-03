#include "stdafx.h"
#include "IProjectiveExtensionInfo.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


IProjectiveExtensionInfo::IProjectiveExtensionInfo(ISystemFunctionDerivate* function) : function(function)
{
}

IProjectiveExtensionInfo::~IProjectiveExtensionInfo(void)
{
}
