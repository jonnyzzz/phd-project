#pragma once

class Graph;
class GraphComponents;
class Function;
class FunctionMS;

class ProgressBarInfo;
class ISystemFunction;

class Computator
{
public:
	Computator(void);
	virtual ~Computator(void);

public:
	typedef list<Graph*> Result;

	struct MorseResult {
		double lower;
		double upper;
		int lowerLength;
		int upperLength;
	};

public:
	GraphComponents* performSI(Graph* graph, Function* function, JInt* devider);
	GraphComponents* performSI(GraphComponents* cms, Function* function, JInt* devider);

	GraphComponents* performSIPoint(Graph* graph, ISystemFunction* function, JInt* devider, JInt* ks, ProgressBarInfo* info = NULL);
	GraphComponents* performSIPoint(GraphComponents* graph, ISystemFunction* function, JInt* devider, JInt* ks, ProgressBarInfo* info = NULL);

	Graph* toMS(Graph* graph, JInt* factor);
	Graph* toMS(GraphComponents* cms, JInt* factor);

	GraphComponents* performMS(Graph* graph, Function* function, JInt* factor);
	GraphComponents* performMS(GraphComponents* graph, Function* function, JInt* factor);

	GraphComponents* performMSPoint(Graph* graph, Function* function, JInt* factor, JInt* ks);
	GraphComponents* performMSPoint(GraphComponents* graph, Function* function, JInt* factor, JInt* ks);

	MorseResult performMorse(Graph* graph, Function* function);	

private:
	GraphComponents* strong(Graph* graph);
	GraphComponents* strong_edges(Graph* graph);

private:
	template <class MSComputationProcess> 
		GraphComponents* _performMS(Graph* graph, Function* function, JInt* factor);
	template <class MSComputationProcess> 
		GraphComponents* _performMS(GraphComponents* graph, Function* function, JInt* factor);	
};
