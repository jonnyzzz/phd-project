
#ifndef _MEMORY_MANAGER_H
#define _MEMORY_MANAGER_H

#include <list>
#include <iostream>
using namespace std;

class MemoryManager
{
public:
	MemoryManager(size_t buffer_length);
	virtual ~MemoryManager(void);

	MemoryManager(const MemoryManager& man) : buffer_length(0) {
 	cout<<"Copying constructor"<<endl;
        ATLASSERT(false);
    }

    MemoryManager& operator = (const MemoryManager&) {
        cout<<" operator = "<<endl;
        ATLASSERT(false);
    }

private:
	struct Buffer {
		char* data;
		char* it;
		char* end;
	};

private:
	size_t buffer_length;

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

    //constructor will be called. 
    //!!!! -> No destructor will be called <- !!!!
    template <class C> 
    C* Allocate() {
        return new(Allocate_void(sizeof(C))) C;
        //return (C*)Allocate_void(sizeof(C));
	    }

    template <class C>
    C* AllocateArray(int length) {
        return new (Allocate_void(sizeof(C)*(length))) C[length];
        //return (C*)(Allocate_void(sizeof(C)*length));
    }

    //Reuse allocated memory. No destructors called for created objects
    void virtual Reset();
};

#define ALLOCATE(C, x)  (new (Allocate_void(sizeof(C))) C x)

#endif //_MEMORY_MANAGER_H
