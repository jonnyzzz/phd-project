// GraphNode.h : Declaration of the CGraphNode

#pragma once
#include "resource.h"       // main symbols
#include "Node.h"
#include "GroupNode.h"
#include "GraphResult.h"

// IGraphNode
[
	object,
	uuid("5CBE5D72-2BA0-4321-BB64-0772D2004C9A"),
	dual,	helpstring("IGraphNode Interface"),
	pointer_default(unique)
]
__interface IGraphNode : INode
{
	[id(11), local, hidden]
	HRESULT GetGraphCount([out, retval] int* count);

	[id(12), local, hidden]
	HRESULT GetGraph([in] int index, [out, retval]void** graph);

	[id(13)]
	HRESULT GetAsGraphResult([in] int index, [out, retval] IGraphResult** result);

};


