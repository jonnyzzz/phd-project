#include "StdAfx.h"
#include ".\memorymanager.h"

MemoryManager::MemoryManager(int buffer_length) : buffer_length(buffer_length)
{

}

MemoryManager::~MemoryManager(void)
{
	for (BuffersList::iterator it = buffers.begin(); it != buffers.end(); it++) {
		delete it->data;
	}
    for (BuffersList::iterator it = reusable.begin(); it != reusable.end(); it++) {
		delete it->data;
	}
}



MemoryManager::Buffer MemoryManager::CreateBuffer() {
	Buffer b;
	b.data = new char[buffer_length];
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
    Buffer& myBuffer = buffers.front();

    if (myBuffer.it + size >= myBuffer.end) {
        myBuffer = PushNewBuffer();
    }
    return myBuffer;
}

void* MemoryManager::Allocate_void(size_t size) {
    Buffer& myBuffer = CurrentBuffer(size);

    void* data = myBuffer.it;
    myBuffer.it += size;
    return data;
}


void MemoryManager::Reset() {
    reusable.clear();
    reusable.splice(reusable.begin(), buffers);
    buffers.clear();
}