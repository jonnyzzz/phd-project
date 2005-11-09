
#include "SIPointBuilder.h"
#include "ProgressBarInfo.h"

class SegmentProjectiveExtendedSystemFunction;

class MSPointBuilder :  public SIPointBuilder
{
   
public:
	MSPointBuilder(Graph* graph, int* factor, int* ks, SegmentProjectiveExtendedSystemFunction* function, ProgressBarInfo* info);
	virtual ~MSPointBuilder(void);

protected:
	virtual void buildImage(Graph* coordinates, Node* source);	

private:
    double* output;
	int function_dimension;
	int v_offset;
};

