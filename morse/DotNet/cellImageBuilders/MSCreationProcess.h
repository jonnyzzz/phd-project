#include "AbstractGraphCreator.h"


class MSCreationProcess :
	public AbstractGraphCreator
{
public:
	MSCreationProcess(Graph* graph, int* factor);
	virtual ~MSCreationProcess(void);

protected:
	virtual JDouble getMax(int i);
	virtual JDouble getMin(int i);
    virtual int getNewDimension();
};

