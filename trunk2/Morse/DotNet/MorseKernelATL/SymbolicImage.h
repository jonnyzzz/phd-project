// SymbolicImage.h : Declaration of the CSymbolicImage

#pragma once
#include "resource.h"       // main symbols

#include "NodeBase.h"
#include "Kernel.h"
#include "GraphInfo.h"
#include "ProjectiveBundle.h"



// ISymbolicImage
[
	object,
	uuid("FA9817A1-3666-41E7-8FCF-0985A43D5FA6"),
	dual,	
    helpstring("ISymbolicImage Interface"),
	pointer_default(unique)
]
__interface ISymbolicImage : IGraph
{

};