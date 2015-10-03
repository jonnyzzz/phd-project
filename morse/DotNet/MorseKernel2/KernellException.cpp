#include "StdAfx.h"
#include ".\kernellexception.h"
#include "../calculator/functionfactoryparseexception.h"

KernelException::KernelException(KernelExceptionType type, int value)
{
	value++;
	switch (type) {
		case KernelException_NegativeDimention:
			message = "dimension should be positive";
			break;
		case KernelException_NegativeGrid:
			message.Format("Grid %d should be positive", value);
			break;
		case KernelException_NegativeSpace:
			message.Format("Space section on axis %d should by positive", value);
			break;
		case KernelException_NoDimention:
			message = "No dimension defined";
			break;
		case KernelException_NoGrid:
			message.Format("Grid %d not defined", value);
			break;
		case KernelException_NoSpaceMax:
			message.Format("Space Max %d not defined", value);
			break;
		case KernelException_NoSpaceMin:
			message.Format("Space Min %d not defined", value);
			break;
		case KernelException_NoFunctionEquation:
			message.Format("Function %d not defined", value);
			break;
		case KernelException_UnableToEvaluateDimension:
			message = "Unable to evaluate dimension parameter";
			break;
		case KernelException_UnableToEvaluateGrid:
			message.Format("Unable to evaluate Grid %d parameter", value);
			break;
		case KernelException_UnableToEvaluateSpaceMax:
			message.Format("Unable to evaluate Space Max %d parameter", value);
			break;
		case KernelException_UnableToEvaluateSpaceMin:
			message.Format("Unable to evaluate Space Min %d parameter", value);
			break;
		case KernelException_UnexpectedVariableDependency:
			message.Format("System equation %d depend on unknown variable", value);
			break;	
		case KernelException_WrongIterations:
			message.Format("Iteration number should be >= 1");
			break;
		case KernelException_NoFunctionFactory:
			message = "No funciton defined";
			break;
		case KernelException_Unknown:
		default:
			message = "Unknown exception!";
			break;
	}
}


KernelException::KernelException(const GraphException &gex) {
	message = "Unknown Graph exception";
}

KernelException::KernelException(const FunctionFactoryParseException& pex) {
	message = CString(pex.getMessage());
}


KernelException::~KernelException(void)
{
}


CString KernelException::getMessage() const {
	return message;
}