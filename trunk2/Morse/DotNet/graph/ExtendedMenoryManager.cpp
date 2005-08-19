#include "StdAfx.h"
#include ".\extendedmenorymanager.h"

ExtendedMemoryManager::ExtendedMemoryManager(int size) : MemoryManager(size)
{
}

ExtendedMemoryManager::~ExtendedMemoryManager(void)
{
    Dispose();
}


void ExtendedMemoryManager::Dispose() {
    for( DisposeList::iterator it = disposeList.begin(); it != disposeList.end(); it++) {
        (*it)->~DisposeHandler();
    }
    disposeList.clear();
}


void ExtendedMemoryManager::Reset() {    
    Dispose();
    MemoryManager::Reset();
}