// NodeBase.h : Declaration of the CNodeBase

#pragma once
#include "resource.h"       // main symbols
#include "graphinfo.h"

[
	object,
	uuid("845738BD-1D8B-42BC-A1EB-FF11F1F22E67"),
	dual,
	pointer_default(unique)
]
__interface IProgressBarNotification : IDispatch {
	[id(1)]
		HRESULT Length([out, retval] int* length);
	[id(2)]
		HRESULT Next([in] int nSteps);
	[id(3)]
		HRESULT NeedStop([out, retval] VARIANT_BOOL* stop);
	[id(4)]
		HRESULT Start();
	[id(5)]
		HRESULT Finish();
};


[
	object,
	uuid("E478D112-3D56-478E-86C0-D51986519502"),
	dual,
	pointer_default(unique)
]
__interface IParams : IDispatch {
	[id(1)]
		HRESULT GetProgressBarNotification([out, retval] IProgressBarNotification** notify);
};

//ISymbolicImageParameters
[
	object,
	uuid("F8ED2FD5-C65C-4C11-ABD0-6DC53A7F05CD"),
	dual,
	pointer_default(unique)
]
__interface ISubdevideParams : IParams {
	[id(12)]
		HRESULT getCellDevider([in] int axis, [out, retval] int* value);	
};

[
	object,
	uuid("CC76B166-5482-4EA8-977D-D47005F2BB17"),
	dual,
	pointer_default(unique)
]
__interface IExtendableParams : ISubdevideParams {
};

[
	object,
	uuid("E389B4B7-E438-4701-8719-5CD37F56D0CD"),
	dual,
	pointer_default(unique)
]
__interface IExtendablePointParams : ISubdevideParams {
};


[
	object,
	uuid("E6F9519F-6BF8-45E0-ACA2-4E710F23F80C"),
	dual,
	pointer_default(unique)
]
__interface ISubdevidePointParams : ISubdevideParams {
	[id(13)]
	HRESULT getCellPoints([in] int axis, [out, retval] int* value);
	[id(14)]
	HRESULT getOverlaping1([in] int axis, [out, retval] double* percent);
	[id(15)]
	HRESULT getOverlaping2([in] int axis, [out, retval] double* percent);
};


[
	object,
	uuid("C15CF4DF-C579-4A02-A33E-AFB26AAB2C49"),
	dual,
	pointer_default(unique)
]
__interface IHomotopParams : IParams {
	[id(10)]
	HRESULT getCoordinateAt([in] int axis, [out, retval] double* value);
	[id(11)]
	HRESULT notifyNodeNotFound( [out, retval] VARIANT_BOOL* tryAgain);
};

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
[
    object,
    uuid("18C498C5-231C-4F6A-A401-3C76F5D9D7A8"),
    dual,
    pointer_default(unique)
]
__interface IKernelPointer : IDispatch {

};


[
	object,
	uuid("E7A4DBC7-26F3-487B-9EAD-E2A7F6AF82E1"),
	dual,
	pointer_default(unique)
]
__interface IKernelNode : IDispatch {

    [propget, id(91), helpstring("property kernel, IKernel")]  
		HRESULT kernel([out, retval] IKernelPointer** pVal);  

	[propputref, id(91), helpstring("property kernel, IKernel")] 
        HRESULT kernel([in] IKernelPointer* newVal);  	
};

[
	object,
	uuid("3A59CE0B-D214-4BD9-BB1A-577822A582EE"),
	dual,
	pointer_default(unique)
]
__interface IGraph : IKernelNode {
	[id(18)]
		HRESULT graphDimension([out, retval] int* value);
	[id(19)]
		HRESULT graphInfo([out, retval] IGraphInfo** info);
    [id(17), local, hidden, helpstring("data = GraphComponents*")]
		HRESULT acceptChilds([in] void** data);
};

[
	object,
	uuid("02431842-302A-4760-80A0-1FD2C161D6AC"),
	dual,
	pointer_default(unique)
]
__interface ISubdevidable  {
	[id(20)]
	HRESULT Subdevide([in] ISubdevideParams* params);
};

[
	object,
	uuid("2EBA1301-AB35-4CC6-BA28-D2FCB0CED02B"),
	dual,
	pointer_default(unique)
]
__interface ISubdevidablePoint {
	[id(21)]
	HRESULT SubdevidePoint([in] ISubdevidePointParams* params);
};

[
	object,
	uuid("26DF2357-91F9-4C63-9417-2762B0F83401"),
	dual,
	pointer_default(unique)
]
__interface IExtendable  {
	[id(22)]
	HRESULT Extend();
};

[
	object,
	uuid("AF4F6B4B-C82F-49B9-9B01-167D5E38AD69"),
	pointer_default(unique)
]
__interface IMorsable {
	[id(24)]
	HRESULT Morse();
};

[
	object,
	uuid("424DB12A-2DE1-4A38-9CA0-2F52DF62944D"),
	dual,
	pointer_default(unique)
]
__interface IExportData {
	[id(25)]
		HRESULT ExportData([in] BSTR file);
};

[
	object,
	uuid("A395C00D-8306-4AA8-9A9F-EA9E79E74C92"),
	dual,
	pointer_default(unique)
]
__interface IHomotopFind {
	[id(27)]
		HRESULT Homotop([in]IHomotopParams* params);
};

///////////////////////////// node result /////////////////////////////

//todo: Implement interfaces and dynamic methods investigation!
[
	object,
	uuid("EA038030-124F-4F15-ACD4-E0500C5110A3"),
	dual,
	pointer_default(unique)
]
__interface IComputationResult : IDispatch {

};

[
	object,
	uuid("5195A2BC-243D-4DA4-B68F-9015D3382DB9"),
	dual,
	pointer_default(unique)
]
__interface IComputationGraphResult : IComputationResult {
	[id(60), helpstring("Localize strong components. Submits nodes throught events")]
		HRESULT StrongComponents();
	[id(61), helpstring("Localize strong components and resolve edges")]
		HRESULT StrongComponentsEdges();
	[id(62), helpstring("Localize loops")]
		HRESULT Loops();
	[id(63), helpstring("Do nothing")]
		HRESULT DoNothing();
};

[
    object,
    uuid("76314083-5CCF-4EB5-91F4-0DE79E549340"),
    dual,
    pointer_default(unique)
]
__interface IComputationExtendingResult : IComputationResult {
    [id(71), helpstring("Create Projective extension for point methods")]
        HRESULT PointMethodProjectiveExtension([in]IExtendablePointParams* params);
    [id(72), helpstring("Dimesion for new graph")]
        HRESULT PointMethodProjectiveExtensionDimension([out,retval]int* dim);
};

[
	object,
	uuid("6C613BDB-C2CE-47EA-9BA0-9F2B2D259016"),
	dual,
	pointer_default(unique)
]
__interface IComputationMorseResult : IComputationResult {
	[id(62), helpstring("should perform SimplexMethod on created graph")]
	HRESULT toResult();
};

////////////////////////////// group //////////////////////////
[
	object,
	uuid("243208B9-C9C1-429C-92E5-A1589F156376"),
	dual,
	pointer_default(unique)
]
__interface IGroupNode {
	[id(50)]
		HRESULT nodeCount([out, retval] int* val);
	[id(51)]
		HRESULT getNode([in] int index, [out, retval] IKernelNode** node);
};
