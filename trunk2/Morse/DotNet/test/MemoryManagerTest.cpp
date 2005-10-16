#include "StdAfx.h"
#include ".\memorymanagertest.h"
#include <iostream>
using namespace std;

#include "../graph/MemoryManager.h"

#include <set>

MemoryManagerTest::MemoryManagerTest(void) : TestBase("Memory Manager", cout)
{
}

MemoryManagerTest::~MemoryManagerTest(void)
{
}



void MemoryManagerTest::Test() {
    
    MemoryManager manager(10);

    typedef set<int*> ISet;



    ISet vset;

//    cout<<sizeof(int)<<"="<<sizeof(int*)<<"-"<<sizeof(int[0])<<"\n";
/*
    for(int i=1; i<100100; i++) {
        int* ii = manager.AllocateArray<int>(1);
        cout<<ii<<"\n";
        this->AssertTrue(vset.insert(ii).second == true, "ddd");
    }  

*/

}