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
	dual,	helpstring("ISymbolicImage Interface"),
	pointer_default(unique)
]
__interface ISymbolicImage : IGraph
{
	//tree content 
	[propget, id(1), helpstring("property kernel")]  
		HRESULT kernel([out, retval] IKernel** pVal);  
	[propputref, id(1), helpstring("property kernel")] 
		HRESULT kernel([in] IKernel* newVal);  	
};


[
	dual,
	uuid("4840FAA7-422A-4717-8318-E3DC82599CBC"),
	helpstring("ISymbolicImage possible events"),
	pointer_default(unique)
]
__interface ISymbolicImageEvents {
	[id(31), helpstring("New computation result created.")]
		HRESULT newChildSymbolicImage([in]ISymbolicImage* image);
	[id(32), helpstring("New computation result created.")]
		HRESULT newChildProjectiveBundle([in]IProjectiveBundle* bundle);
};
