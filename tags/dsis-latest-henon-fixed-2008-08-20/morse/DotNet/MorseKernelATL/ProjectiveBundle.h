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
};
