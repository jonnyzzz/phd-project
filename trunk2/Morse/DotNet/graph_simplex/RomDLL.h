// Rom.h: interface for the CRom class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ROM_H__0CF141B8_7E4C_49F3_8188_946F5C8DED49__INCLUDED_)
#define AFX_ROM_H__0CF141B8_7E4C_49F3_8188_946F5C8DED49__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "StdAfx.h"
#include "Graph.h"
#include "JGraphFunction.h"

typedef void (CALLBACK *GETRESULT)(char, double&);
typedef void (CALLBACK *SETGRAPHNODES)(unsigned int, unsigned int);
typedef void (CALLBACK *STARTFROMMEMORY)(void);
typedef void (CALLBACK *WRITENODEVERT)(unsigned int, unsigned int);
typedef void (CALLBACK *WRITENODEVALUE)(unsigned int, double);
typedef double (CALLBACK *GETRESULTMIN)(void);
typedef double (CALLBACK *GETRESULTMAX)(void);

class CRom  
{
public:
	CRom(Graph *gr, JGraphFunction *f);
	CRom(CMyArchive &ar);

	virtual ~CRom();

private:
	GETRESULT GetResult;
	SETGRAPHNODES SetGraphNodes;
	STARTFROMMEMORY StartFromMemory;
	WRITENODEVERT WriteNodeVert;
	WRITENODEVALUE WriteNodeValue;
	GETRESULTMIN GetResultMin;
	GETRESULTMAX GetResultMax;

	bool DLLLoaded;
	HINSTANCE hMod;
	double rMin;
	double rMax;

public:
	
	void Serialize(CMyArchive &ar);

	double GetMax();
	double GetMin();

	CString GetResultFmt(CString fmt);
	void GetResultDbl(double &min, double &max);

private:
	void SelfTest();
	void LoadGraph(Graph *gr, JGraphFunction *f);
};

#endif // !defined(AFX_ROM_H__0CF141B8_7E4C_49F3_8188_946F5C8DED49__INCLUDED_)
