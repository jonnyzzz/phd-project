// Rom.cpp: implementation of the CRom class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Rom.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CRom::CRom(Graph *gr, JGraphFunction *f)
{
	CString s((LPCSTR)IDS_DLL_NAME);
	hMod = AfxLoadLibrary(s);
	
	DLLLoaded = !(hMod == NULL);

	if (DLLLoaded)
	{
		GetResult = (GETRESULT)GetProcAddress(hMod, ("GetResult"));
		
		SetGraphNodes = (SETGRAPHNODES)GetProcAddress(hMod, ("SetGraphNodes"));
		
		StartFromMemory = (STARTFROMMEMORY)GetProcAddress(hMod, ("StartFromMemory"));
		
		WriteNodeVert = (WRITENODEVERT)GetProcAddress(hMod, ("WriteNodeVert"));
		
		WriteNodeValue = (WRITENODEVALUE)GetProcAddress(hMod, ("WriteNodeValue"));
		
		GetResultMin = (GETRESULTMIN)GetProcAddress(hMod, "GetResultMin");

		GetResultMax = (GETRESULTMAX)GetProcAddress(hMod, "GetResultMax");
		
		
		DLLLoaded = !(  (GetResult==NULL)||(SetGraphNodes==NULL)
			||(StartFromMemory==NULL)||( WriteNodeVert==NULL)
			||(WriteNodeValue==NULL)|| (GetResultMin == NULL)
			||(GetResultMax == NULL)
			);
		
		if (!DLLLoaded) 
		{
			ASSERT(false);
			FreeLibrary(hMod);
		} else {
			//Anything is OK.
			if (gr!=NULL)
			{
				LoadGraph(gr,f);
			} else {
				SelfTest();
			}
		}

		if ((DLLLoaded)&&(hMod!=NULL))
		{
			FreeLibrary(hMod);
			
			GetResult = NULL;
			SetGraphNodes = NULL;
			StartFromMemory = NULL;
			WriteNodeVert = NULL;
			WriteNodeValue = NULL;
			
			DLLLoaded=false;
		}
	}
}

CRom::CRom(CMyArchive &ar)
{
	DLLLoaded=false;
	hMod=NULL;
	GetResult = NULL;
	SetGraphNodes = NULL;
	StartFromMemory = NULL;
	WriteNodeVert = NULL;
	WriteNodeValue = NULL;	

	this->Serialize(ar);
}

CRom::~CRom()
{
}

void CRom::Serialize(CMyArchive &ar)
{
	if (ar.IsLoading() )
	{
		//loading
	
		CString s;
		ar>>s;	
		ar>>this->rMin>>this->rMax;
		ar>>s;
	}else
	{
		//Saveing
		CString s;
		s.LoadString(IDS_FORMAT_MORSE_START);
		ar<<s<<this->rMin<<this->rMax;
		s.LoadString(IDS_FORMAT_MORSE_STOP);
		ar<<s;
	}
}


void CRom::LoadGraph(Graph *gr, JGraphFunction *f)
{
	//so Graph is 1 companent. only!.
	SetGraphNodes(gr->nId, gr->nVert);
//	afxDump<<gr->nId<<"\n";

	TayDouble *x=new TayDouble[gr->DIM];

	//CMyArchive ar("e:\\ROM.rom", false);
	//ofstream ar("e:\\ROM.rom");
/*
	for (int I=0;I<gr->HASH_MAX;I++)
	{
		for (axis *ax=gr->ax[I];ax!=NULL;ax=ax->next)
		{
			//CString s;

			for (int i=0;i<gr->DIM;i++)
			{
				x[i]=gr->RetriveDouble(ax->x,i) + gr->dx[i];
			}
			
			//s.Format("%d %f", ax->id, f->Ro(x));

			WriteNodeValue(ax->id, f->Ro(x));
			
			for (link *lnk=ax->vert;lnk!=NULL;lnk=lnk->next)
			{
				//CString v;
			//	v.Format(" %d", lnk->ax->id);
			//	s+=v;

				WriteNodeVert(ax->id, lnk->ax->id);
			}
			//ar<<(LPCSTR)s<<" "<<"\n";
		}
	}
	//ar.close();

	delete[] x;
*/
	StartFromMemory();

//	GetResult( (char)0, rMin);
//	GetResult( (char)1, rMax);
	rMin = GetResultMin();
	rMax = GetResultMax();
}

CString CRom::GetResultFmt(CString fmt)
{
	CString s;
	s.Format(fmt, rMin, rMax);
	return s;
}

void CRom::GetResultDbl(double &rMin, double &fMax)
{
	rMin=this->rMin;
	rMax=this->rMax;
}

double CRom::GetMin()
{
	return this->rMin;
}

double CRom::GetMax()
{
	return this->rMax;

}

void CRom::SelfTest()
{
	SetGraphNodes(10000,10000);

	for (int i=0;i<10000;i++)
	{
		WriteNodeValue(i,(i%2==0)?4:1);
		WriteNodeVert(i, (i+1)%10000);
		//WriteNodeVert(i, 0);

	}
		
	StartFromMemory();
	
	GetResult((char)0, rMin);
	GetResult((char)1, rMax);

	CString s;
	s.Format("Self Testing Result: %f %f", rMin, rMax);	

	AfxMessageBox(s,0,0);
}
