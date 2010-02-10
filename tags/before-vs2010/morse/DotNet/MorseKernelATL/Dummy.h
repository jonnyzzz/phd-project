#pragma once

/*
#include "nodebase.h"

[
    object,
    uuid("ECACE910-6692-4ACC-85C2-3EF448BF2638"),
    pointer_default(unique),
    dual
]
__interface IDummy : IDispatch {
};


[
	coclass,
	threading("apartment"),
	vi_progid("MorseKernelATL.ZDummy"),
	progid("MorseKernelATL.ZDummy.1"),
	version(1.0),
	uuid("6C167CEC-20C8-45B4-B6C5-E59E15B3D19E"),
	helpstring("Dummy Class"),
]
class ATL_NO_VTABLE CDummy : 
    public IDummy, 
    public IExtendableParams,
    public IMorsable
{
public:

	DECLARE_PROTECT_FINAL_CONSTRUCT()

    HRESULT FinalConstruct() { return S_OK;}
	
    void FinalRelease() {}

	//internal functions and variables

    STDMETHOD(getCellDevider)(int axis, int* value){ return S_OK;}
    STDMETHOD(updateProgressBar)(int min, int max, int current) {return S_OK; }
    
    STDMETHOD(Morse)() {return S_OK;}
};

*/