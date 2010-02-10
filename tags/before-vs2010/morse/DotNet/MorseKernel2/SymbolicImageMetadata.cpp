// SymbolicImageMetadata.cpp : Implementation of CSymbolicImageMetadata

#include "stdafx.h"
#include "SymbolicImageMetadata.h"
#include "SmartInterface.h"

// CSymbolicImageMetadata



CSymbolicImageMetadata::CSymbolicImageMetadata() {

}

HRESULT CSymbolicImageMetadata::FinalConstruct() {
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CSymbolicImageMetadata::FinalRelease() {
    m_pUnkMarshaler.Release();
}
