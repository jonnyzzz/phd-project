#include "stdafx.h"
#include "MemoryManager.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

MemoryManager::MemoryManager(size_t buffer_length)
{
	if (buffer_length > 511000)
		buffer_length = 511000;
	this->buffer_length = buffer_length;
}


MemoryManager::~MemoryManager(void)
{
	for (BuffersList::iterator it = buffers.begin(); it != buffers.end(); it++) {
		//delete[] it->data;
		free(it->data);
		//GlobalFree((HGLOBAL)it->data);
	}
    for (BuffersList::iterator it = reusable.begin(); it != reusable.end(); it++) {
		//delete[] it->data;
		free(it->data);
		//GlobalFree((HGLOBAL)it->data);
	}
}



MemoryManager::Buffer MemoryManager::CreateBuffer() {
	Buffer b;
	//b.data = new char[buffer_length];
	b.data = (char*)malloc(sizeof(char)*buffer_length);
	//b.data = (char*)GlobalAlloc(LMEM_FIXED, sizeof(char)*buffer_length);
	if (b.data == NULL) {
	  cout<<"\n\n\n!!!\n!!!\n!!! Memory Allocation Error!\n!!!\n!!!\n\n\n";
	  cout<<endl<<"Buffer size is "<<buffer_length<<endl<<endl<<endl<<endl;
	  throw -1;
	  ATLASSERT(false);
	}
	b.it = b.data;
	b.end = b.data + buffer_length;
	return b;
}

MemoryManager::Buffer& MemoryManager::PushNewBuffer() {
    Buffer buffer;
    if (reusable.size() > 0) {
        buffer = reusable.front();
        reusable.pop_front();
        buffer.it = buffer.data;        
    } else {
        buffer = CreateBuffer();
    }
    buffers.push_front(buffer);
    return buffers.front();
}

MemoryManager::Buffer& MemoryManager::CurrentBuffer(size_t size) {

    ATLASSERT(size <= buffer_length);    

    if (buffers.size() > 0 ) {
        Buffer& myBuffer = buffers.front();

        if (myBuffer.it + size >= myBuffer.end) {
            return PushNewBuffer();
        }
        return myBuffer;
    } else {
        return PushNewBuffer();
    }        
}

void* MemoryManager::Allocate_void(size_t size) {
    Buffer& myBuffer = CurrentBuffer(size);

    void* data = myBuffer.it;
    myBuffer.it += size;
    return data;
}


void MemoryManager::Reset() {    
    reusable.splice(reusable.begin(), buffers);
    buffers.clear();
}
