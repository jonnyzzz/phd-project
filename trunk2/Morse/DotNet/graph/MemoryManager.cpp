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
}



MemoryManager::Buffer MemoryManager::CreateBuffer() {
	Buffer b;
	b.data = new char[buffer_length];
	b.it = b.data;
	b.end = ((char*)b.data) + buffer_length;
	return b;
}