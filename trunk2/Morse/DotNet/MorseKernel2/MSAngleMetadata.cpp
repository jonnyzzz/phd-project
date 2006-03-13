// MSAngleMetadata.cpp : Implementation of CMSAngleMetadata

#include "stdafx.h"
#include "MSAngleMetadata.h"


// CMSAngleMetadata

CMSAngleMetadata::CMSAngleMetadata() {
}

HRESULT CMSAngleMetadata::FinalConstruct() {
	return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CMSAngleMetadata::FinalRelease() {
    m_pUnkMarshaler.Release();
}