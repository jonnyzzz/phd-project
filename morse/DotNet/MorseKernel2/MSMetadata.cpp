// MSMetadata.cpp : Implementation of CMSMetadata

#include "stdafx.h"
#include "MSMetadata.h"


// CMSMetadata

CMSMetadata::CMSMetadata() {
}

HRESULT CMSMetadata::FinalConstruct() {
    return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CMSMetadata::FinalRelease() {
    m_pUnkMarshaler.Release();
}