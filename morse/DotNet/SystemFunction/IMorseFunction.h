#ifndef _CELLIMAGEBUILDERS_IMORSEFUNCTION_H
#define _CELLIMAGEBUILDERS_IMORSEFUNCTION_H

#include "ISystemFunction.h"
#include "ISystemFunctionDerivate.h"

class IMorseFunction :
    public ISystemFunction
{
public:
    IMorseFunction(ISystemFunctionDerivate* function);
    virtual ~IMorseFunction(void);

protected:
    ISystemFunctionDerivate* function;
};

#endif //_CELLIMAGEBUILDERS_IMORSEFUNCTION_H

