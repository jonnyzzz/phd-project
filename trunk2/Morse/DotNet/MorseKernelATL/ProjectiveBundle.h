// ProjectiveBundle.h : Declaration of the CProjectiveBundle

#pragma once
#include "resource.h"       // main symbols

#include "Kernel.h"
#include "NodeBase.h"
#include "GraphInfo.h"
#include "MorseSpectrum.h"

// IProjectiveBundle
[
	object,
	uuid("1C62FD1D-F7D8-417E-9DAA-5AECF07CF7D3"),
	dual,	helpstring("IProjectiveBundle Interface"),
	pointer_default(unique)
]
__interface IProjectiveBundle : IGraph
{
	[propget, id(1), helpstring("property kernel")] 
		HRESULT kernel([out, retval] IKernel** pVal);
	[propputref, id(1), helpstring("property kernel")] 
		HRESULT kernel([in] IKernel* newVal);
};

[
	dual,
	uuid("A9EBC232-AB43-43EA-89E6-6710FDD35342"),
	helpstring("Events for Projective Bundle Class"),
	pointer_default(unique)
]
__interface IProjectiveBundleEvents {
	[id(36), helpstring("Computation result")]
		HRESULT newChildProjectiveBundle([in] IProjectiveBundle* pb);
	[id(37), helpstring("Computation result")]
		HRESULT newChildMorseSpectrum([in] IMorseSpectrum* ms);
};

