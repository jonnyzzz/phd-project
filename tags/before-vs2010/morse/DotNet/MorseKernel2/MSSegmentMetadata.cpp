// MSSegmentMetadata.cpp : Implementation of CMSSegmentMetadata

#include "stdafx.h"
#include "MSSegmentMetadata.h"


// CMSSegmentMetadata

CMSSegmentMetadata::CMSSegmentMetadata() {

}

HRESULT CMSSegmentMetadata::FinalConstruct() {
    return CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CMSSegmentMetadata::FinalRelease() {
    m_pUnkMarshaler.Release();
}