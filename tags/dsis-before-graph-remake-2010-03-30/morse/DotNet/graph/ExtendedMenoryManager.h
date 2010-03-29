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

		template<class C>
			void* AllocateDisposableBlock() {
				void* data = Allocate_void(sizeof(C));
				disposeList.push_back(static_cast<DisposeHandler*>(data));
				return data;
			}
};

#define ALLOCATE_DISPOSABLE(C, x)  (new (AllocateDisposableBlock<C>()) C x)



