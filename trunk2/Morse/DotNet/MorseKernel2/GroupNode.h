// GroupNode.h : Declaration of the CGroupNode

#pragma once
#include "resource.h"       // main symbols
#include "Node.h"


// IGroupNode
[
	object,
	uuid("28EBA211-E2B0-4717-87AA-63A0A5C76CDC"),
	dual,	helpstring("IGroupNode Interface"),
	pointer_default(unique)
]
__interface IGroupNode : IDispatch
{
	[id(11)]
	HRESULT GetLength([out, retval] int* count);

	[id(12)]
	HRESULT GetNode([in] int index, [out, retval] INode** node);

	[id(13)]
	HRESULT CanAddNode([in] INode* node);

	[id(14)]
	HRESULT AddNode([in] INode* node);

	[id(15)]
	HRESULT CreateNode([out, retval] INode** node);
};


