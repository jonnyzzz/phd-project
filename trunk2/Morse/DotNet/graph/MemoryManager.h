#pragma once

#include <list>

class MemoryManager
{
public:
	MemoryManager(int buffer_length);
	virtual ~MemoryManager(void);


private:
	struct Buffer {
		void* data;
		void* it;
		void* end;
	};

private:
	int buffer_length;

private:
	typedef list<Buffer> BuffersList;
	BuffersList buffers;


private:
	Buffer CreateBuffer();


};
