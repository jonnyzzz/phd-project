// PersistantManager.cpp : Implementation of CPersistantManager

#include "stdafx.h"
#include "PersistantManager.h"


// CPersistantManager

CPersistantManager::CPersistantManager()
{
	m_pUnkMarshaler = NULL;
}

HRESULT CPersistantManager::FinalConstruct() 
{
	return CoCreateFreeThreadedMarshaler(
			GetControllingUnknown(), &m_pUnkMarshaler.p);
}

void CPersistantManager::FinalRelease()
{
	m_pUnkMarshaler.Release();
}