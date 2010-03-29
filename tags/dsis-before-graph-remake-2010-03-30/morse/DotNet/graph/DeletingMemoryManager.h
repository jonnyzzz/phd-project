//store for reusable objects, like structires.
//no destructor will be called!
//default constructor is needed!

template <class T>
class DeletingMemoryManager
{
private:

    struct Data {
        T* data;
        bool used;

        Data() { used = false; data=new T(); }
        ~Data() { delete data; }
    };

    int maxNumber;

    Data* content;

public:
    DeletingMemoryManager(int maxNumber) : maxNumber(maxNumber), content(new Data[maxNumber]())
    {
    }

    ~DeletingMemoryManager(void)
    {        
        delete[] content;
    }


public:
    T* Allocate() {
        return new T();
        for (int i=0; i<maxNumber; i++) {
            if (!content[i].used) {
                content[i].used = true;
                return content[i].data;
            }
        }
        throw -1;
    }

    void DeAllocate(T* data) {
        delete data;

        for (int i=0; i<maxNumber; i++) {
            if (content[i].data == data) {
                if (!content[i].used) throw -2;
                content[i].used = false;
            }
        }
        throw -1;
    }
};
