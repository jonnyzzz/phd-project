// Result.h : Declaration of the CResult

#pragma once
#include "resource.h"       // main symbols
#include "ResultBase.h"


// IResult
[
	object,
	uuid("9B7D45A5-77FD-4E97-8C4A-76D3610CC875"),
	dual,	helpstring("IResult Interface"),
	pointer_default(unique)
]
__interface IResult : IResultBase
{
};


