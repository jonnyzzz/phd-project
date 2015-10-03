// Serializer.h : Declaration of the CSerializer

#pragma once
#include "resource.h"       // main symbols
#include "nodebase.h"
#include "symbolicImageGraph.h"
#include "projectivebundlegraph.h"
#include "symbolicimagegroup.h"
#include "projectivebundlegroup.h"
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
	[id(2)]
	HRESULT SaveWithID([in] IKernelNode* node, [out, retval] int* ID);

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
	[id(2)]
	HRESULT LoadByID([in] int ID, [out, retval] IKernelNode** node);
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
	HRESULT LoadKernelNode([in] ISerializerInputData* data, [in] IKernel* kernel, [out, retval] IKernelNode** node);

	[id(2)]
	HRESULT SaveKernelNode([in] ISerializerOutputData* output, [in] IKernelNode* node);

	HRESULT SupportSerialization([in] IKernelNode* node, [out, retval] VARIANT_BOOL* result);
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

	STDMETHOD(LoadKernelNode)(ISerializerInputData* data, IKernel* kernel, IKernelNode** node);
	STDMETHOD(SaveKernelNode)(ISerializerOutputData* output, IKernelNode* node);

	STDMETHOD(SupportSerialization)(IKernelNode* node, VARIANT_BOOL* result);


private:

	template <typename IGraph>
	void SaveGraph(IGraph* graph, FileOutputStream& fo);

	template <typename IGraph, typename CGraph>
	IKernelNode* LoadGraph(FileInputStream& fi);


	template <typename IGroup>
	void SaveGroup(IGroup* group, FileOutputStream& fo, ISerializerOutputData* data);

	template <typename IGroup, typename IGraph, typename CGroup>
	IKernelNode* LoadGroup(FileInputStream& fi, ISerializerInputData* data);


private:    
	void SaveMorseSpectrum(IMorseSpectrum* node, FileOutputStream& fo);
	IKernelNode* LoadMorseSpectrum(FileInputStream& fi);

	void SaveGraph(FileOutputStream& fo, Graph* graph);
	Graph* LoadGraph(FileInputStream& fi);

private:
	template <typename Node>
	Node* Cast(IKernelNode* node);

	template <typename IGraph, int CODE>
	bool testAndSaveGroup(IKernelNode* anode, FileOutputStream& fo, ISerializerOutputData* data);

	template <typename IGraph, int CODE>
	bool testAndSaveGraph(IKernelNode* anode, FileOutputStream& fo);

	
};

