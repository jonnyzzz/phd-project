#pragma once

#include "MemoryManager.h"

class ExtendedMemoryManager : public MemoryManager
{
public:
    ExtendedMemoryManager(int size);
    virtual ~ExtendedMemoryManager(void);

public:
    class DisposeHandler {
    public:
        virtual ~DisposeHandler(){};
    };

private:
    typedef list<DisposeHandler*> DisposeList;

    DisposeList disposeList;

private:
    void Dispose();

public:

    virtual void Reset();

    template<class C>
        C* AllocateDisposable() {
            C* data = Allocate<C>();
            disposeList.push_back(static_cast<DisposeHandler*>(data));
            return data;
        }
};
