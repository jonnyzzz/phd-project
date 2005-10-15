#include "stdafx.h"
#include "MemoryManager.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MemoryManager::MemoryManager(size_t buffer_length) : buffer_length(buffer_length)
{

}

MemoryManager::~MemoryManager(void)
{
	for (BuffersList::iterator it = buffers.begin(); it != buffers.end(); it++) {
		//delete[] it->data;
		free(it->data);
	}
    for (BuffersList::iterator it = reusable.begin(); it != reusable.end(); it++) {
		//delete[] it->data;
		free(it->data);
	}
}



MemoryManager::Buffer MemoryManager::CreateBuffer() {
	Buffer b;
	//b.data = new char[buffer_length];
	b.data = (char*)malloc(sizeof(char)*buffer_length);
	if (b.data == NULL) {
	  int cnt=1000;
	  for(int cnt=0; cnt<1000; cnt++) {
	    sleep(1000);
	    b.data = (char*)malloc(sizeof(char)*buffer_length);
	    if (b.data != NULL) break;
	  }

	  if (b.data == NULL) {
	    buffer_length /= 2;
	    cout<<"Buffer size was decreaded in two times!\n";
	    return CreateBuffer();
	  }
	  //cout<<"Memory Allocation Error!";
	  //	throw -1;
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
