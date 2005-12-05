#include "stdafx.h"
#include "ExtendedMenoryManager.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


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
