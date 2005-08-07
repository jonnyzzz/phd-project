#pragma once

#include <list>
using namespace std;

#ifndef ATLASSERT
#define ATLASSERT(x)
#endif

class MemoryManager
{
public:
	MemoryManager(int buffer_length);
	virtual ~MemoryManager(void);

    MemoryManager(const MemoryManager& man) {
        ATLASSERT(false);
    }

    MemoryManager& operator = (const MemoryManager&) {
        ATLASSERT(false);
    }

private:
	struct Buffer {
		char* data;
		char* it;
		char* end;
	};

private:
	int buffer_length;

private:
	typedef list<Buffer> BuffersList;
	BuffersList buffers;
    BuffersList reusable;


private:
	Buffer CreateBuffer();

    Buffer& PushNewBuffer();
    Buffer& CurrentBuffer(size_t size);

public:
    void* Allocate_void(size_t size);

    //Default constructor will be called. No destructor will be called
    template <class C> 
    C* Allocate() {
        return new(Allocate_void(sizeof(C))) C;
    }

    template <class C>
    C* AllocateArray(int length) {
        return new(Allocate_void(sizeof(void*)*length)) C[length];
    }

    //Reuse allocated memory. No destructors called for created objects
    void Reset();
};
