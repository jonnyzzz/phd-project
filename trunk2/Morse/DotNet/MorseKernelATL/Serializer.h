// Serializer.h : Declaration of the CSerializer

#pragma once
#include "resource.h"       // main symbols
#include "nodebase.h"
#include "symbolicImageGraph.h"
#include "projectivebundlegraph.h"
#include "morsespectrum.h"
#include "../graph/FileStream.h"



[
	object,
	uuid("F42FA761-5767-4C66-8E91-4AC5EC15AE2E"),
	dual,
	pointer_default(unique)
]
__interface ISerializerOutputData : IDispatch
{
	[id(1)]
	HRESULT FileName([out, retval] BSTR* fileName);
};

[
	object,
	uuid("5F688D62-BCE3-4787-95C5-36118686C2D1"),
	dual,
	pointer_default(unique)
]
__interface ISerializerInputData : IDispatch
{
	[id(1)]
	HRESULT FileName([out, retval] BSTR* fileName);
};


// ISerializer
[
	object,
	uuid("EEDA2826-2706-49B4-9896-D3454C400754"),
	dual,	helpstring("ISerializer Interface"),
	pointer_default(unique)
]
__interface ISerializer : IDispatch
{
	[id(1)]
	HRESULT LoadKernelNode([in] ISerializerInputData* data, [out, retval] IKernelNode** node);

	[id(2)]
	HRESULT SaveKernelNode([in] ISerializerOutputData* output, [in] IKernelNode* node);
};



// CSerializer

[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.Serializer"),
	progid("MorseKernelATL.Serializer.1"),
	version(1.0),
	uuid("3B39CBCB-C514-44FA-9FB3-79A822F13C3C"),
	helpstring("Serializer Class")
]
class ATL_NO_VTABLE CSerializer : 
	public ISerializer
{
public:
	CSerializer()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct();		
	void FinalRelease();

public:

	STDMETHOD(LoadKernelNode)(ISerializerInputData* data, IKernelNode** node);
	STDMETHOD(SaveKernelNode)(ISerializerOutputData* output, IKernelNode* node);


private:

	void SaveSymbolicImageGraph(ISymbolicImageGraph* graph, FileOutputStream& fo);
	IKernelNode* LoadSymbolicImageGraph(FileInputStream& fi);

	void SaveProjectiveBundleGraph(IProjectiveBundleGraph* graph, FileOutputStream& fo);
	IKernelNode* LoadProjectiveBundleGraph(FileInputStream& fi);

	void SaveMorseSpectrum(IMorseSpectrum* node, FileOutputStream& fo);
	IKernelNode* LoadMorseSpectrum(FileInputStream& fi);

	void SaveGraph(FileOutputStream& fo, Graph* graph);
	Graph* LoadGraph(FileInputStream& fi);
};

