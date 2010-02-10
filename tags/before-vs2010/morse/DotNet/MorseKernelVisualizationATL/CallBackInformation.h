#pragma once


//imposible to use due to no includes in cpp files.

//IGraphNodeCallBack 
[
	object,
	dual,
	uuid("FD79D381-3E0E-43E4-955B-58054274F406"),
	helpstring("Base class for informationCallBack"),
	pointer_default(unique)
]
interface IGraphNodeCallBack {
	[id(1)]
	const int CONS = 10;
};


[
	object,
	uuid("981D85DA-6F29-4AA2-856A-A48B4F4E7033"),
	dual,
	pointer_default(unique)
]
interface IGraphNodeCallBackStrongComponent {
	[id(1)]
	HRESULT getLength([out, retval] int length);
};

